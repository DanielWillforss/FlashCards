using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddWords : MonoBehaviour
{
    public TMP_InputField word;
    public TMP_InputField translation;
    private SharedData sharedData;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();
    }

    public void AddWordButton()
    {
        //Add more logic
        sharedData.AddNewData(word.text, translation.text);
        word.text = "";
        translation.text = "";
    }
}
