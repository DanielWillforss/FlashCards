using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SimpleFileBrowser.FileBrowser;

public class Notes : MonoBehaviour
{
    public TMP_InputField notepad;
    private StateInfo stateInfo;

    void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        stateInfo = s.GetStateInfo();

        updateNotepad();
    }

    public void SaveText()
    {
        NotepadUtil.ReplaceData(stateInfo.notePath, notepad.text);
    }

    public void SetNotePath()
    {
        FileEditorUtil.OpenEditor(
            (paths) => {
                stateInfo.notePath = paths[0];
                updateNotepad(); },
            () => Debug.Log("Canceled"),
            PickMode.Files
        );
    }

    public void ResetNotePath()
    {
        stateInfo.notePath = "";
        updateNotepad();
    }

    private void updateNotepad()
    {
        notepad.text = NotepadUtil.GetAllData(stateInfo.notePath);
    }
}
