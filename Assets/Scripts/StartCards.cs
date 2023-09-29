using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartCards : MonoBehaviour
{
    public TMP_InputField inputField;
    private SharedData sharedData;

    // Start is called before the first frame update
    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();
    }

    public void StartFlashCards()
    {
        try
        {
            sharedData.SetActiveCards(Int32.Parse(inputField.text));
            SceneHandeler.ChangeScene("FlashWords");
        }
        catch (FormatException)
        {
            Debug.Log("Error");
        }
    }
}
