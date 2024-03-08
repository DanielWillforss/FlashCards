using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardPanel : MonoBehaviour
{
    private CardList cardList;

    public Button FlagButton;
    public Button EditButton;
    public Button DeleteButton;

    public TMP_InputField scoreInput;
    public TMP_InputField wordInput;
    public TMP_InputField translationInput;
    public TMP_Text flagButtonText;
    public TMP_Text editButtonText;
    public Image panelImage;
    private bool isFlagged;
    private bool isEditMode = false;
    private FlashCard card = null;
    private Action reloadCallback = null;

    private void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        cardList = s.GetCardList();
        //flaggedCards = s.GetFlaggedCards();
    }

    public void SetCard(FlashCard card)
    {
        this.card = card;
        scoreInput.text = card.value.ToString();
        wordInput.text = card.word;
        translationInput.text = card.translation;
        isFlagged = card.isFlagged;
        SetPanelStyle();
    }

    private void SetPanelStyle()
    {
        if(card == null)
        {
            FlagButton.interactable = false;
            EditButton.interactable = false;
            DeleteButton.interactable = false;
            scoreInput.interactable = false;
            wordInput.interactable = false;
            translationInput.interactable = false;
            flagButtonText.text = "Flag Card";
            editButtonText.text = "Edit Card";
            panelImage.color = new Color(1, 1, 1, 0.392f);
        }
        else if(isEditMode)
        {
            FlagButton.interactable = true;
            EditButton.interactable = true;
            DeleteButton.interactable = true;
            scoreInput.interactable = true;
            wordInput.interactable = true;
            translationInput.interactable = true;
            flagButtonText.text = "Save changes";
            editButtonText.text = "Cancel";
            panelImage.color = new Color(0.95f, 1, 0.486f, 0.392f);
        }
        else if (isFlagged)
        {
            FlagButton.interactable = true;
            EditButton.interactable = true;
            DeleteButton.interactable = true;
            scoreInput.interactable = false;
            wordInput.interactable = false;
            translationInput.interactable = false;
            flagButtonText.text = "Unflag Card";
            editButtonText.text = "Edit Card";
            panelImage.color = new Color(1, 0.373f, 0.373f, 0.392f);
        }
        else
        {
            FlagButton.interactable = true;
            EditButton.interactable = true;
            DeleteButton.interactable = true;
            scoreInput.interactable = false;
            wordInput.interactable = false;
            translationInput.interactable = false;
            flagButtonText.text = "Flag Card";
            editButtonText.text = "Edit Card";
            panelImage.color = new Color(1, 1, 1, 0.392f);
        }
    }

    public void SetReloadCallback(Action callBack)
    {
        reloadCallback = callBack;
    }

    public void EmptyCard()
    {
        this.card = null;
        scoreInput.text = "";
        wordInput.text = "";
        translationInput.text = "";
        isFlagged = false;
        SetPanelStyle();
    }

    public void ChangeFlaggedAndSaveEditButton()
    {
        if(!isEditMode)
        {
            isFlagged = !isFlagged;
            card.isFlagged = isFlagged;
            SetPanelStyle();
            reloadCallback?.Invoke();
        }
        else
        {
            isEditMode = false;
            int value = ValidateUtil.ValidateInt(scoreInput.text) ?? card.value; ;
            string word = ValidateUtil.ValidateGeneralString(wordInput.text) ?? card.word;
            string translation = ValidateUtil.ValidateGeneralString(translationInput.text) ?? card.translation;
            card.value = value;
            card.word = wordInput.text;
            card.translation = translationInput.text;

            SetPanelStyle();
        }
    }

    public void EditCardButton()
    {
        isEditMode = !isEditMode;
        if(!isEditMode)
        {
            scoreInput.text = card.value.ToString();
            wordInput.text = card.word;
            translationInput.text = card.translation;
        }
        SetPanelStyle();
    }

    public void DeleteCardButton()
    {
        cardList.list.Remove(card);
        if(reloadCallback != null)
        {
            reloadCallback();
        }
        else
        {
            EmptyCard();
        }
    }
}
