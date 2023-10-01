using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandeler : MonoBehaviour
{
    public static readonly string path = Application.persistentDataPath + "/card_data.txt";

    public static FlashCard[] GetAllData()
    {
        string[] allData = File.ReadAllLines(path);
        FlashCard[] allCards = new FlashCard[allData.Length];

        for (int i = 0; i < allData.Length; i++)
        {
            string[] splitString = allData[i].Split("*");
            allCards[i] = new FlashCard(splitString[0], splitString[1], splitString[2]);
        }

        return allCards;
    }

    public static void ReplaceData(FlashCard[] newData)
    {
        string[] mergedData = new string[newData.Length];
        for(int i = 0; i<newData.Length; i++)
        {
            mergedData[i] = newData[i].GetValue() + 
                "*" + newData[i].GetWord() +
                "*" + newData[i].GetTranslation();
        }

        File.WriteAllLines(path, mergedData);
    }
}
