using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardPanel : MonoBehaviour
{
    private CardListManger cardList;
    private FlaggedCards flaggedCards;

    public TMP_Text scoreText;
    public TMP_Text wordText;
    public TMP_Text translationText;
    private FlashCard card = null;
    private Action reloadCallback = null;

    private void Start()
    {
        SharedData s = SharedData.GetSharedData();
        cardList = s.GetCardList();
        flaggedCards = s.GetFlaggedCards();
    }

    public void SetCard(FlashCard card)
    {
        this.card = card;
        scoreText.text = card.GetValue().ToString();
        wordText.text = card.GetWord();
        translationText.text = card.GetTranslation();
    }

    public void SetReloadCallback(Action callBack)
    {
        reloadCallback = callBack;
    }

    public void EmptyCard()
    {
        this.card = null;
        scoreText.text = "";
        wordText.text = "";
        translationText.text = "";
    }

    public void FlagCardButton()
    {
        flaggedCards.FlagCard(card);
    }

    public void UnflagCardButton()
    {
        flaggedCards.RemoveCard(card);
        reloadCallback?.Invoke();
    }

    public void DeleteCardButton()
    {
        flaggedCards.RemoveCard(card);
        cardList.RemoveCard(card);
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
