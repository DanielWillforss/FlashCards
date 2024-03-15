using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCards : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    private CardList cardList;
    private StateInfo stateInfo;

    void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        cardList = s.GetCardList();
        stateInfo = s.GetStateInfo();
        cardList.SortData();
        SetInfoText();
    }

    //Logic to make sure it's only numbers
    public void StartFlashCards()
    {
        int? input = ValidateUtil.ValidatePosInt(inputField.text);
        if(input == null)
        {
            feedbackText.text = "Input is not a valid number";
        }
        else
        {
            stateInfo.numberOfCards = input.Value;
            SceneUtil.ChangeScene("FlashWords");
        }  
    }

    private void SetInfoText()
    {
        FlashCard worstCard = cardList.list[0];
        string t = "Information";
        if(stateInfo.showTotalNumberOfWords)
        {
            t = t + "\nTotal number of words: " + cardList.list.Count;
        }
        if(stateInfo.showWorstPerforming)
        {
            t = t + "\nWorst performing: '" + worstCard.word + "' - '" + worstCard.translation + "' (" + worstCard.value + ")";
        }
        feedbackText.text = t;
    }
}
