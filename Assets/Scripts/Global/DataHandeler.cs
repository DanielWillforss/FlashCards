using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif

//Rename to Data Util
public class DataHandeler : MonoBehaviour
{
    private static readonly string path = "Assets/Data/card_data.txt";

    public static void AddNewData(string word, string translation, int initIndex = 0)
    {
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(initIndex + "*" + word + "*" + translation);
        writer.Close();
        #if UNITY_EDITOR
            AssetDatabase.ImportAsset(path);
        #endif
    }

    public static string[] GetAllData()
    {
        string[] allData = File.ReadAllLines(path);
        return allData;
    }

    public static string[][] SplitData(string[] input, int n)
    {
        if(n > input.Length)
        {
            return null;
        }

        string[][] splitData = new string[n][];

        for (int i = 0; i < n; i++)
        {
            string[] splitString = input[i].Split("*");
            splitData[i] = splitString;
        }

        return splitData;
    }

    public static int CompareDataByNumber(string x, string y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        return x[0].CompareTo(y[0]);
    }

    public static void MergeData(string[][] spitData, string[] oldData)
    {
        for(int i = 0; i < spitData.Length; i++)
        {
            oldData[i] = spitData[i][0] + "*" + spitData[i][1] + "*" + spitData[i][2];
        }
    }

    public static void ReplaceData(string[] newData)
    {
        File.WriteAllLines(path, newData);
        #if UNITY_EDITOR
            AssetDatabase.ImportAsset(path);
        #endif
    }
}
