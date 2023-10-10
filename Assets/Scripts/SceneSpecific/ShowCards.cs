using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowCards : MonoBehaviour
{
    public bool isFlaggedCards;
    public TMP_Text pageText;
    public TMP_Text numberOfCardsText;
    private List<CardPanel> panels;
    private CardListBase cardList;
    private int currentIndex = 0;
    private int numberOfPanels;

    // Start is called before the first frame update
    void Start()
    {
        if(isFlaggedCards)
        {
            cardList = SharedData.GetSharedData().GetFlaggedCards();
        }
        else
        {
            cardList = SharedData.GetSharedData().GetCardList();
        }
        cardList.SortData();
        panels = new List<CardPanel>(FindObjectsOfType<CardPanel>());
        panels.Sort(ComparePanelByYPos);
        numberOfPanels = panels.Count;

        foreach (CardPanel p in panels)
        {
            p.SetReloadCallback(SetCards);
        }

        SetCards();
    }

    public void NextPageButton()
    {
        currentIndex++;
        SetCards();
    }

    public void LastPageButton()
    {
        if(currentIndex > 0)
        {
            currentIndex--;
            SetCards();
        }
    }

    private void SetCards()
    {
        int numberOfCards = cardList.Length();
        numberOfCardsText.text = "Total Cards: " + numberOfCards;
        pageText.text = currentIndex.ToString();

        for (int i = 0; i < numberOfPanels; i++)
        {
            int cardIndex = currentIndex * numberOfPanels + i;
            if (cardIndex < numberOfCards)
            {
                panels[i].SetCard(cardList.GetCard(cardIndex));
            }
            else
            {
                panels[i].EmptyCard();
            }
        }
    }

    private static int ComparePanelByYPos(CardPanel x, CardPanel y)
    {
        if (x == null || y == null)
        {
            return 0;
        }
        
        return y.gameObject.transform.position.y.CompareTo(x.gameObject.transform.position.y);
    }
}
