using SimpleFileBrowser;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static SimpleFileBrowser.FileBrowser;

public class SettingPage : MonoBehaviour
{
    private CardList cardList;
    private StateInfo stateInfo;

    public TMP_Text path;
    public TMP_Text printPath;
    public Toggle indexToggle;
    public Toggle valueToggle;
    public TMP_Text printFeedbackText;
    public TMP_InputField pronunciationFreqField;
    public TMP_InputField shiftInput;
    public Toggle showAllCardsToggle;
    public Toggle showWorstToggle;

    private bool initializing = true;

    void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        cardList = s.GetCardList();
        stateInfo = s.GetStateInfo();

        path.text = "outdated"; //DataUtil.path;
        printPath.text = "outdated"; // DataUtil.printPath;
        pronunciationFreqField.text = stateInfo.pronFreq.ToString();
        showAllCardsToggle.isOn = stateInfo.showTotalNumberOfWords;
        showWorstToggle.isOn = stateInfo.showWorstPerforming;
        initializing = false;

        FileEditorUtil.Setup();
    }

    public void PrintButton()
    {
        DataUtil.PrintData(cardList.list.ToArray(), indexToggle.isOn, valueToggle.isOn);
        printFeedbackText.text = "Printed!";
    }

    public void ChangePronFreq()
    {
        int freq = ValidateUtil.ValidatePosInt(pronunciationFreqField.text) ?? 0;
        stateInfo.pronFreq = freq;
        pronunciationFreqField.text = stateInfo.pronFreq.ToString();
    }

    public void ExportDataButton()
    {
        FileEditorUtil.OpenEditor(
            (paths) => { DataUtil.ExportData(paths[0], cardList); }, 
            () => Debug.Log("Canceled"),
            PickMode.Folders
        );
    }
    public void ImportDataButton()
    {
        FileEditorUtil.OpenEditor(
            (paths) => { Debug.Log(DataUtil.ImportData(paths[0]).list[0].word); }, //Currently Doesnt Save
            () => Debug.Log("Canceled"),
            PickMode.Files
        );
    }

    public void ShiftValuesButton()
    {
        int s = ValidateUtil.ValidateInt(shiftInput.text) ?? 0;
        cardList.ShiftAllCardsValue(s);
    }

    public void UpdateShowToggles()
    {
        if(!initializing)
        {
            stateInfo.showTotalNumberOfWords = showAllCardsToggle.isOn;
            stateInfo.showWorstPerforming = showWorstToggle.isOn;
        }
    }
}
