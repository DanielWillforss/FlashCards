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

    private CardList cardList;
    private StateInfo stateInfo;
    private int totalNumberOfCards;
    private int currentIndex = 0;
    private List<FlashCard> randomList = new List<FlashCard>();

    void Start()
    {
        DontDestroyHandeler s = DontDestroyHandeler.GetHandeler();
        cardList = s.GetCardList();
        stateInfo = s.GetStateInfo();

        cardList.SortData();
        totalNumberOfCards = stateInfo.numberOfCards;
        if(totalNumberOfCards == 0)
        {
            EndCards();
        }
        else
        {
            for(int i = 0; i < totalNumberOfCards; i++)
            {
                randomList.Add(cardList.list[i]);
            }
            DataUtil.Shuffle(randomList);
            ShowNewCard();
        }
    }

    private void ShowNewCard()
    {
        word.text = randomList[currentIndex].word;
        showAnswersButton.interactable = true;
        correctButton.interactable = false;
        wrongButton.interactable = false;
        translation.text = "";
    }

    public void ShowAnswer()
    {
        translation.text = randomList[currentIndex].translation;
        showAnswersButton.interactable = false;
        correctButton.interactable = true;
        wrongButton.interactable = true;
        if (100 * Random.value < stateInfo.pronFreq) //should be pronFreq%
        {
            translation.text = translation.text + "\nCheck Pronunciation";
        }
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
        randomList[currentIndex].isFlagged = true;
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
