using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListManger : MonoBehaviour
{
    private FlashCardList allData = null;

    private void Awake()
    {
        allData = new FlashCardList(DataHandeler.GetAllData());
    }

    public FlashCard AddNewCard(string word, string translation, int initIndex = 0)
    {
        FlashCard card = new FlashCard(initIndex, word, translation);
        allData.Add(card);
        return card;
    }

    public FlashCard GetCard(int index)
    {
        return allData.Get(index);
    }

    public void RemoveCard(FlashCard card)
    {
        allData.Remove(card);
    }

    public int Length()
    {
        return allData.Length();
    }

    public void SortData()
    {
        allData.Sort();
    }

    public void SaveData()
    {
        SortData();
        DataHandeler.ReplaceData(allData.GetArray());
    }

}
