using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCards : MonoBehaviour
{
    public TMP_InputField inputField;
    private SharedData sharedData;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();
    }

    //Logic to make sure it's only numbers
    public void StartFlashCards()
    {
        try
        {
            sharedData.SetNbrOfCards(Int32.Parse(inputField.text));
        }
        catch (FormatException)
        {
            Debug.Log("Error");
        }
    }
}
