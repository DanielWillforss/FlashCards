using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileEditorUtil
{
    public static void Setup()
    {
        FileBrowser.SetFilters(true, new FileBrowser.Filter("Text Files", ".txt"));
        FileBrowser.SetDefaultFilter(".txt");
        FileBrowser.SetExcludedExtensions(".lnk", ".tmp", ".zip", ".rar", ".exe");
        FileBrowser.AddQuickLink("Users", "C:\\Users", null);
    }

    public static void OpenEditor()
    {
        FileBrowser.ShowLoadDialog(
            (paths) => { printFromFile(paths[0]); },
            () => { Debug.Log("Canceled"); },
            FileBrowser.PickMode.Files, 
            false, 
            null, 
            null, 
            "Select File", "Select"
        );
    }

    private static void printFromFile(string path)
    {
        if(path == "")
        {
            Debug.Log("Failed");
        } else
        {
            string[] allData = File.ReadAllLines(path);
            Debug.Log(allData[0]);
        }
    }
}
