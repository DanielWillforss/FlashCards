using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListManger : CardListBase
{

    public void Create()
    {
        FlashCard[] cards = DataHandeler.GetAllData();
        list = new List<FlashCard>(cards);
    }

    public FlashCard AddNewCard(string word, string translation, int initIndex = 0)
    {
        FlashCard card = new FlashCard(initIndex, word, translation);
        AddCard(card);
        return card;
    }

    public void SaveData()
    {
        SortData();
        DataHandeler.ReplaceData(list.ToArray());
    }

}
