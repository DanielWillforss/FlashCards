using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        cardList = s.GetCardList();
        stateInfo = s.GetStateInfo();

        path.text = DataHandeler.path;
        printPath.text = DataHandeler.printPath;
        pronunciationFreqField.text = stateInfo.pronFreq.ToString();
    }

    public void PrintButton()
    {
        DataHandeler.PrintData(cardList.GetCardArray(), indexToggle.isOn, valueToggle.isOn);
        printFeedbackText.text = "Printed!";
    }

    public void ChangePronFreq()
    {
        int freq = ValidateInput.ValidatePosInt(pronunciationFreqField.text) ?? 0;
        stateInfo.pronFreq = freq;
        pronunciationFreqField.text = stateInfo.pronFreq.ToString();
    }


}
