using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedData : MonoBehaviour
{
    private int numberOfCards = 0;
    public FlashCardList allData = null;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AllData");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        allData = new FlashCardList(DataHandeler.GetAllData());

        Debug.Log(allData);
    }

    public FlashCard AddNewData(string word, string translation, int initIndex = 0)
    {
        FlashCard card = new FlashCard(initIndex, word, translation);
        allData.Add(card);
        return card;
    }

    public void SetNbrOfCards(int nbr)
    {
        numberOfCards = nbr;
        allData.Sort();
    }

    public int GetNbrOfCards()
    {
        return numberOfCards;
    }

    public FlashCard GetCard(int index)
    {
        return allData.Get(index);
    }

    private void OnApplicationQuit()
    {
        DataHandeler.ReplaceData(allData.GetArray());
    }

    public void CloseAndSave()
    {
        DataHandeler.ReplaceData(allData.GetArray());
        Destroy(this.gameObject);
    }

    public int GetTotalNumberOfCards()
    {
        return allData.Length();
    }

    public void RemoveData(FlashCard card)
    {
        allData.Remove(card);
    }
}
