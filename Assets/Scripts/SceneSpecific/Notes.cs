using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    public TMP_InputField notepad;

    void Start()
    {
        notepad.text = NotepadUtil.GetAllData();
    }

    public void SaveText()
    {
        NotepadUtil.ReplaceData(notepad.text);
    }
}
