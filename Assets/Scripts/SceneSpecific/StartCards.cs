using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCards : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    private SharedData sharedData;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();
        feedbackText.text = "Total number of words: " + sharedData.GetTotalNumberOfCards();
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
            sharedData.SetNbrOfCards(input.Value);
            SceneHandeler.ChangeScene("FlashWords");
        }  
    }
}
