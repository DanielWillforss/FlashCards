using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class ShowCards : MonoBehaviour
{
    public TMP_Text pageText;
    public TMP_Text numberOfCardsText;
    private List<CardPanel> panels;
    private CardList cardList;
    private int currentIndex = 0;
    private int numberOfPanels;
    private int lastIndex;
    private bool onlyShowFlagged = false;

    // Start is called before the first frame update
    void Start()
    {
        cardList = DontDestroyHandeler.GetHandeler().GetCardList();

        cardList.SortData();
        panels = new List<CardPanel>(FindObjectsOfType<CardPanel>());
        panels.Sort(ComparePanelByPos);
        numberOfPanels = panels.Count;
        lastIndex = (cardList.list.Count-1)/numberOfPanels;
        if(lastIndex < 0)
        {
            lastIndex = 0;
        }

        foreach (CardPanel p in panels)
        {
            p.SetReloadCallback(SetCards);
        }

        SetCards();
    }

    public void OnlyShowFlaggedButton()
    {
        onlyShowFlagged = !onlyShowFlagged;
        if(onlyShowFlagged)
        {
            lastIndex = (cardList.list.Count(card => card.isFlagged) - 1) / numberOfPanels;
            if(currentIndex > lastIndex)
            {
                currentIndex = lastIndex;
            }
            cardList.SortDataByFlagged();
        }
        else
        {
            lastIndex = (cardList.list.Count - 1) / numberOfPanels;
            cardList.SortData();
        }
        SetCards();
    }

    public void NextPageButton()
    {
        if(currentIndex < lastIndex)
        {
            currentIndex++;
        } else
        {
            currentIndex = 0;
        }
        SetCards();
    }

    public void PrevoiusPageButton()
    {
        if(currentIndex > 0)
        {
            currentIndex--;
        } else
        {
            currentIndex = lastIndex;
        }
        SetCards();
    }

    private void SetCards()
    {
        int numberOfCards = cardList.list.Count;
        numberOfCardsText.text = "Total Cards: " + numberOfCards;
        pageText.text = currentIndex.ToString();

        for (int i = 0; i < numberOfPanels; i++)
        {
            int cardIndex = currentIndex * numberOfPanels + i;
            if (cardIndex < numberOfCards)
            {
                FlashCard card = cardList.list[cardIndex];
                if(onlyShowFlagged && !card.isFlagged)
                {
                    panels[i].EmptyCard();
                }
                else
                {
                    panels[i].SetCard(card);
                }
            }
            else
            {
                panels[i].EmptyCard();
            }
        }
    }

    private static int ComparePanelByPos(CardPanel x, CardPanel y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        Vector2 xPos = x.gameObject.transform.position;
        Vector2 yPos = y.gameObject.transform.position;

        
        if (xPos.y > yPos.y)
        {
            return -1;
        }
        else if (xPos.y < yPos.y)
        {
            return 1;
        }
        else if (xPos.x > yPos.x)
        {
            return 1;
        }
        else if (xPos.x < yPos.x)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
