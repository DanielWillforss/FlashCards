using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoCards : MonoBehaviour
{
    public TMP_Text word;
    public TMP_Text translation;
    public Button showAnswersButton;
    public Button correctButton;
    public Button wrongButton;
    public Button flagCardButton;

    private CardListManger cardList;
    private FlaggedCards flaggedCards;
    private StateInfo stateInfo;
    private int totalNumberOfCards;
    private int currentIndex = 0;
    private List<FlashCard> randomList = new List<FlashCard>();

    void Start()
    {
        SharedData s = SharedData.GetSharedData();
        cardList = s.GetCardList();
        flaggedCards = s.GetFlaggedCards();
        stateInfo = s.GetStateInfo();

        cardList.SortData();
        totalNumberOfCards = stateInfo.GetNbrOfCards();
        if(totalNumberOfCards == 0)
        {
            EndCards();
        }
        else
        {
            for(int i = 0; i < totalNumberOfCards; i++)
            {
                randomList.Add(cardList.GetCard(i));
            }
            DataHandeler.Shuffle(randomList);
            ShowNewCard();
        }
    }

    private void ShowNewCard()
    {
        word.text = randomList[currentIndex].GetWord();
        showAnswersButton.interactable = true;
        correctButton.interactable = false;
        wrongButton.interactable = false;
        translation.text = "";
    }

    public void ShowAnswer()
    {
        translation.text = randomList[currentIndex].GetTranslation();
        showAnswersButton.interactable = false;
        correctButton.interactable = true;
        wrongButton.interactable = true;
    }

    public void NextCard(bool wasCorrect)
    {
        randomList[currentIndex].UpdateValue(wasCorrect);
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

    public void FlagCard()
    {
        flaggedCards.AddCard(randomList[currentIndex]);
    }

    private void EndCards()
    {
        word.text = "Done";
        translation.text = "Good job!";
        showAnswersButton.interactable = false;
        correctButton.interactable = false;
        wrongButton.interactable = false;
        flagCardButton.interactable = false;
    }
}
