using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCards : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    private CardListManger cardList;
    private StateInfo stateInfo;

    void Start()
    {
        SharedData s = SharedData.GetSharedData();
        cardList = s.GetCardList();
        stateInfo = s.GetStateInfo();
        feedbackText.text = "Total number of words: " + cardList.Length();
    }

    //Logic to make sure it's only numbers
    public void StartFlashCards()
    {
        int? input = ValidateInput.ValidatePosInt(inputField.text);
        if(input == null)
        {
            feedbackText.text = "Input is not a valid number";
        }
        else
        {
            stateInfo.SetNbrOfCards(input.Value);
            SceneHandeler.ChangeScene("FlashWords");
        }  
    }
}
