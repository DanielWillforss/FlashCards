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

    private SharedData sharedData;
    private int totalNumberOfCards;
    private int currentIndex = 0;
    private List<FlashCard> randomList = new List<FlashCard>();

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
            for(int i = 0; i < totalNumberOfCards; i++)
            {
                randomList.Add(sharedData.GetCard(i));
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

    private void EndCards()
    {
        word.text = "Done";
        translation.text = "Good job!";
        showAnswersButton.interactable = false;
        correctButton.interactable = false;
        wrongButton.interactable = false;
    }
}
