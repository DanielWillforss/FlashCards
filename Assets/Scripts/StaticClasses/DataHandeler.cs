using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public static class DataHandeler
{
    public static readonly string path = Application.persistentDataPath + "/card_data.txt";
    public static readonly string printPath = Application.persistentDataPath + "/printed_data.txt";

    public static FlashCard[] GetAllData()
    {
        if(!File.Exists(path))
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
                int? value = ValidateInput.ValidateInt(splitString[0]);
                string word = ValidateInput.ValidateGeneralString(splitString[1]);
                string translation = ValidateInput.ValidateGeneralString(splitString[2]);

                if (value != null && word != null && translation != null)
                {
                    int index = ValidateInput.GetAndUseNewUnusedIndex();
                    allCards[i] = new FlashCard(index, value.Value, false, word, translation);
                    validElements++;
                }
            }
            else if (splitString.Length == 5)
            {
                int? index = ValidateInput.ValidateUnusedIndex(splitString[0]);
                int? value = ValidateInput.ValidateInt(splitString[1]);
                bool? isFlagged = ValidateInput.ValidateBoolean(splitString[2]);
                string word = ValidateInput.ValidateGeneralString(splitString[3]);
                string translation = ValidateInput.ValidateGeneralString(splitString[4]);

                if (index != null && value != null && isFlagged != null && word != null && translation != null)
                {
                    allCards[i] = new FlashCard(index.Value, value.Value, isFlagged.Value, word, translation);
                    validElements++;
                }
            }
            else
            {
                allCards[i] = null;
                //save in other file?
            }
        }

        if(validElements != allData.Length) //this is if something is wrong
        {
            FlashCard[] correctedCards = new FlashCard[validElements];
            for (int i = 0, j = 0; i < validElements; i++, j++)
            {
                while(allCards[j] == null || j > allData.Length)
                {
                    j++;
                }
                correctedCards[i] = allCards[j];
            }
            allCards = correctedCards;
        }
        
        return allCards;
    }

    public static void ReplaceData(FlashCard[] newData)
    {
        string[] mergedData = new string[newData.Length];
        for(int i = 0; i<newData.Length; i++)
        {
            mergedData[i] = newData[i].GetIndex() + "*" + newData[i].GetValue() + 
                "*" + newData[i].GetIsFlaggedAsInt() + "*" + newData[i].GetWord() +
                "*" + newData[i].GetTranslation();
        }

        File.WriteAllLines(path, mergedData);
    }

    public static void PrintData(FlashCard[] newData, bool showIndex, bool showValue)
    {
        string[] mergedData = new string[newData.Length];
        for (int i = 0; i < newData.Length; i++)
        {
            string indexText = "";
            if(showIndex)
            {
                indexText = "Index: " + newData[i].GetIndex() + ", ";
            }
            string valueText = "";
            if(showValue)
            {
                valueText = "Value: " + newData[i].GetValue() + ", ";
            }

            mergedData[i] = indexText + valueText + "Swedish word: " + newData[i].GetWord() +
                ", French word: " + newData[i].GetTranslation();
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
}
