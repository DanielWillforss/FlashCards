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
        FlashCard worstCard = cardList.GetCard(0);
        feedbackText.text = "Total number of words: " + cardList.Length() + 
            "\nWorst performing: '" + worstCard.GetWord() + "' - '" + worstCard.GetTranslation() + "' (" + worstCard.GetValue() + ")";

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
            stateInfo.numberOfCards = input.Value;
            SceneHandeler.ChangeScene("FlashWords");
        }  
    }
}
