using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedData : MonoBehaviour
{
    private int numberOfCards = 0;
    public string[] allData = null;
    private string[][] cardsInUse = null;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetActiveCards(int nbrOfCards)
    {
        numberOfCards = nbrOfCards;
        allData = DataHandeler.GetAllData();
        Array.Sort<string>(allData, DataHandeler.CompareDataByNumber);
        cardsInUse = DataHandeler.SplitData(allData, numberOfCards);
    }

    public int GetNbrOfCards()
    {
        return numberOfCards;
    }

    public string[] GetCard(int index)
    {
        return cardsInUse[index];
    }
    
    public void UpdateScore(int index, bool wasCorrect)
    {
        try
        {
            int currentScore = Int32.Parse(cardsInUse[index][0]);
            if(wasCorrect)
            {
                currentScore++;
            }
            else
            {
                currentScore--;
            }
            cardsInUse[index][0] = currentScore.ToString();
        }
        catch (FormatException)
        {
            Debug.Log("Error");
        }
    }

    public void EndCurrentSession()
    {
        DataHandeler.MergeData(cardsInUse, allData);
        DataHandeler.ReplaceData(allData);
        Destroy(this.gameObject);

    }
}
