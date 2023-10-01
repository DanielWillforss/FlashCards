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

    public void AddNewData(string word, string translation, int initIndex = 0)
    {
        allData.Add(new FlashCard(initIndex, word, translation));
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
    
    public void UpdateScore(int index, bool wasCorrect)
    {
        allData.Get(index).UpdateValue(wasCorrect);
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
}
