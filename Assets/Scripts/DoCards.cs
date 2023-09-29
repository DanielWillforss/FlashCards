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
    private string[] currentCard;

    // Start is called before the first frame update
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
        word.text = currentCard[1];
        translation.text = "";
    }

    public void ShowAnswer()
    {
        translation.text = currentCard[2];
    }

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

    private void EndCards()
    {
        word.text = "done";
        translation.text = "good job";
    }

    public void ReturnToMenu()
    {
        sharedData.EndCurrentSession();
        SceneHandeler.ChangeScene("FlashMenu");
    }
}
