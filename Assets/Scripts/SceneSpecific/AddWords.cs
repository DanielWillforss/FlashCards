using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AddWords : MonoBehaviour
{
    public TMP_InputField word; //0
    public TMP_InputField translation; //1
    public TMP_InputField initValue;
    public TMP_Text feedbackText;
    public Button revertButton;

    private CardList cardList;
    private FlashCard lastCard = null;
    private int selectCounter;

    void Start()
    {
        cardList = DontDestroyHandeler.GetHandeler().GetCardList();
        revertButton.interactable = false;
    }

    void Update()
    {
        TrackInputs();
    }

    public void AddWordButton()
    {
        string w = ValidateUtil.ValidateGeneralString(word.text);
        string t = ValidateUtil.ValidateGeneralString(translation.text);
        int? i = ValidateUtil.ValidateInt(initValue.text);
        if(w != null && t != null)
        {
            feedbackText.text = "Added: " + w + " -> " + t;

            lastCard = i != null ? 
                cardList.AddNewCard(w, t, i.Value) : 
                cardList.AddNewCard(w, t);

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
        cardList.list.Remove(lastCard);
        feedbackText.text = "Removed: " + lastCard.word + " * " + lastCard.translation;
        lastCard = null;
        revertButton.interactable = false;
    }

    public void TrackInputs()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(selectCounter == 0)
            {
                selectCounter = 1;
                translation.Select();
            }
            else
            {
                selectCounter = 0;
                word.Select();
            }
        }
        else if(Input.GetKeyDown(KeyCode.Return) && selectCounter == 1)
        {
            AddWordButton();
            selectCounter = 0;
            word.Select();
        }
    }

    public void WordFieldSelected()
    {
        selectCounter = 0;
    }

    public void TranslationFieldSelected()
    {
        selectCounter = 1;
    }
}
