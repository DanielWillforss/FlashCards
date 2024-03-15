using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public static class DataUtil
{
    public static void SaveCardListToJson(CardList cardList)
    {
        string cardListData = JsonUtility.ToJson(cardList);
        string filePath = Application.persistentDataPath + "/CardList_test.json";
        File.WriteAllText(filePath, cardListData);
    }

    public static CardList LoadCardListFromJson()
    {
        string filePath = Application.persistentDataPath + "/CardList.json";

        if (!File.Exists(filePath))
        {
            return new CardList { list = new List<FlashCard>() };
        }

        string cardListData = File.ReadAllText(filePath);
        return JsonUtility.FromJson<CardList>(cardListData);
    }

    public static void SaveStateInfotoJson(StateInfo stateInfo)
    {
        string stateInfoData = JsonUtility.ToJson(stateInfo);
        string filePath = Application.persistentDataPath + "/StateInfo.json";
        File.WriteAllText(filePath, stateInfoData);
    }

    public static StateInfo LoadStateInfoFromJson()
    {
        string filePath = Application.persistentDataPath + "/StateInfo.json";

        if (!File.Exists(filePath))
        {
            return new StateInfo();
        }

        string stateInfoData = File.ReadAllText(filePath);
        return JsonUtility.FromJson<StateInfo>(stateInfoData);
    }

    public static void ExportData(string path, CardList cardList)
    {
        string cardListData = JsonUtility.ToJson(cardList);
        string dataPath = path + "/Data.json";
        File.WriteAllText(dataPath, cardListData);
    }

    public static CardList ImportData(string path)
    {
        if (!File.Exists(path))
        {
            return new CardList { list = new List<FlashCard>() };
        }

        string cardListData = File.ReadAllText(path);
        return JsonUtility.FromJson<CardList>(cardListData);
    }

    public static void PrintData(FlashCard[] newData, bool showIndex, bool showValue)
    {
        string printPath = Application.persistentDataPath + "/printed_data.txt";

        string[] mergedData = new string[newData.Length];
        for (int i = 0; i < newData.Length; i++)
        {
            string indexText = "";
            if (showIndex)
            {
                indexText = "Index: " + newData[i].index + ", ";
            }
            string valueText = "";
            if (showValue)
            {
                valueText = "Value: " + newData[i].value + ", ";
            }

            mergedData[i] = indexText + valueText + "Swedish word: " + newData[i].word +
                ", French word: " + newData[i].translation;
        }

        File.WriteAllLines(printPath, mergedData);
    }

    public static void Shuffle<T>(this IList<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;
        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (Byte.MaxValue / n)));
            int k = (box[0] % n);
            n--;
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static FlashCard[] GetAllDataTxt()
    {
        string path = Application.persistentDataPath + "/card_data.txt";

        if (!File.Exists(path))
        {
            return new FlashCard[0];
        }
        string[] allData = File.ReadAllLines(path);
        FlashCard[] allCards = new FlashCard[allData.Length];
        int validElements = 0;

        for (int i = 0; i < allData.Length; i++)
        {
            string[] splitString = allData[i].Split("*");
            if (splitString.Length == 3) //Old data recovery
            {
                int? value = ValidateUtil.ValidateInt(splitString[0]);
                string word = ValidateUtil.ValidateGeneralString(splitString[1]);
                string translation = ValidateUtil.ValidateGeneralString(splitString[2]);

                if (value != null && word != null && translation != null)
                {
                    int index = ValidateUtil.GetAndUseNewUnusedIndex();
                    allCards[i] = new FlashCard
                    {
                        index = index,
                        value = value.Value,
                        isFlagged = false,
                        word = word,
                        translation = translation
                    };
                    validElements++;
                }
            }
            else if (splitString.Length == 5)
            {
                int? index = ValidateUtil.ValidateUnusedIndex(splitString[0]);
                int? value = ValidateUtil.ValidateInt(splitString[1]);
                bool? isFlagged = ValidateUtil.ValidateBoolean(splitString[2]);
                string word = ValidateUtil.ValidateGeneralString(splitString[3]);
                string translation = ValidateUtil.ValidateGeneralString(splitString[4]);

                if (index != null && value != null && isFlagged != null && word != null && translation != null)
                {
                    allCards[i] = new FlashCard
                    {
                        index = index.Value,
                        value = value.Value,
                        isFlagged = isFlagged.Value,
                        word = word,
                        translation = translation
                    };
                    validElements++;
                }
            }
            else
            {
                allCards[i] = null;
                //save in other file?
            }
        }

        if (validElements != allData.Length) //this is if something is wrong
        {
            FlashCard[] correctedCards = new FlashCard[validElements];
            for (int i = 0, j = 0; i < validElements; i++, j++)
            {
                while (allCards[j] == null || j > allData.Length)
                {
                    j++;
                }
                correctedCards[i] = allCards[j];
            }
            allCards = correctedCards;
        }

        return allCards;
    }

    public static void ReplaceDataTxt(FlashCard[] newData)
    {
        string path = Application.persistentDataPath + "/card_data.txt";

        string[] mergedData = new string[newData.Length];
        for (int i = 0; i < newData.Length; i++)
        {
            mergedData[i] = newData[i].index + "*" + newData[i].value +
                "*" + newData[i].GetIsFlaggedAsInt() + "*" + newData[i].word +
                "*" + newData[i].translation;
        }

        File.WriteAllLines(path, mergedData);
    }
}
