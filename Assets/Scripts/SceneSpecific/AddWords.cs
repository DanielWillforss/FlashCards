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

    private CardListManger cardList;
    private FlashCard lastCard = null;

    void Start()
    {
        cardList = SharedData.GetSharedData().GetCardList();
        revertButton.interactable = false;
    }

    public void AddWordButton()
    {
        string w = ValidateInput.ValidateGeneralString(word.text);
        string t = ValidateInput.ValidateGeneralString(translation.text);
        if(w != null && t != null)
        {
            feedbackText.text = "Added: " + word.text + " -> " + translation.text;
            lastCard = cardList.AddNewCard(word.text, translation.text);
            word.text = "";
            translation.text = "";
            revertButton.interactable = true;
        } 
        else
        {
            feedbackText.text = "Not valid inputs";
        }
    }

    public void RemoveLastWord()
    {
        cardList.RemoveCard(lastCard);
        feedbackText.text = "Removed: " + lastCard.GetWord() + " * " + lastCard.GetTranslation();
        lastCard = null;
        revertButton.interactable = false;
    }
}
