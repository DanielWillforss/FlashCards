using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;

public static class NotepadUtil
{
    public static readonly string basePath = Application.persistentDataPath + "/notes.txt";

    public static string GetAllData(string p)
    {
        string path = p;
        if(p == "")
        {
            path = basePath;
        }
        Debug.Log(path);
        if (!File.Exists(path))
        {
            return "";
        }
        string[] allText = File.ReadAllLines(path);
        string text = allText[0];
        for (int i = 1; i<allText.Length; i++)
        {
            text = text + "\n" + allText[i];
        }
        return text;
    }

    public static void ReplaceData(string p, string newText)
    {
        string path = p;
        if (p == "")
        {
            path = basePath;
        }
        string[] mergedText = Regex.Split(newText, "\r\n|\r|\n");
        File.WriteAllLines(path, mergedText);
    }
}
