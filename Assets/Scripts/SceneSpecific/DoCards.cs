using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DoCards : MonoBehaviour
{
    public TMP_Text word;
    public TMP_Text translation;

    private SharedData sharedData;
    private int totalNumberOfCards;
    private int currentIndex = 0;
    private FlashCard currentCard;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();

        totalNumberOfCards = sharedData.GetNbrOfCards();
        if(totalNumberOfCards == 0)
        {
            EndCards();
        }
        else
        {
            ShowNewCard();
        }
    }

    private void ShowNewCard()
    {
        currentCard = sharedData.GetCard(currentIndex);
        word.text = currentCard.GetWord();
        translation.text = "";
    }

    //Add feedback
    public void ShowAnswer()
    {
        translation.text = currentCard.GetTranslation();
    }

    //Add feedback
    public void NextCard(bool wasCorrect)
    {
        sharedData.UpdateScore(currentIndex, wasCorrect);
        currentIndex++;
        if(currentIndex == totalNumberOfCards)
        {
            EndCards();
        }
        else
        {
            ShowNewCard();
        }
    }

    //Lock everything when done
    private void EndCards()
    {
        word.text = "done";
        translation.text = "good job";
    }
}
