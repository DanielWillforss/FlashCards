using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddWords : MonoBehaviour
{
    public TMP_InputField word;
    public TMP_InputField translation;
    public TMP_Text feedbackText;
    public Button revertButton;

    private SharedData sharedData;
    private FlashCard lastCard = null;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();
        revertButton.interactable = false;
    }

    public void AddWordButton()
    {
        feedbackText.text = "Added: " + word.text + " * " + translation.text;
        lastCard = sharedData.AddNewData(word.text, translation.text);
        word.text = "";
        translation.text = "";
        revertButton.interactable = true;
    }

    public void RemoveLastWord()
    {
        sharedData.RemoveData(lastCard);
        feedbackText.text = "Removed: " + lastCard.GetWord() + " * " + lastCard.GetTranslation();
        lastCard = null;
        revertButton.interactable = false;
    }
}
