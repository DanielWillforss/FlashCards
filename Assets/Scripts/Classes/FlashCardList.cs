using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCardList
{
    public List<FlashCard> list;

    public FlashCardList(FlashCard[] cards = null)
    {
        if(cards != null)
        {
            list = new List<FlashCard>(cards);
        }
        else
        {
            list = new List<FlashCard>();
        }
    }

    public void Add(FlashCard card)
    {
        list.Add(card);
    }

    public FlashCard Get(int index)
    {
        return list[index];
    }

    public void Sort()
    {
        list.Sort(CompareDataByNumber);
    }
    
    public FlashCard[] GetArray()
    {
        return list.ToArray();
    }

    private static int CompareDataByNumber(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        return x.GetValue() - y.GetValue();
    }
}
