using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

public static class DataHandeler
{
    public static readonly string path = Application.persistentDataPath + "/card_data_test.txt";

    public static FlashCard[] GetAllData()
    {
        string[] allData = File.ReadAllLines(path);
        FlashCard[] allCards = new FlashCard[allData.Length];

        for (int i = 0; i < allData.Length; i++)
        {
            allCards[i] = new FlashCard(allData[i]);
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
