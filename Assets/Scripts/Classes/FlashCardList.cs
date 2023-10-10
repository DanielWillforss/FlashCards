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

    public int Length()
    {
        return list.Count;
    }

    public bool Remove(FlashCard card)
    {
        return list.Remove(card);
    }

    private static int CompareDataByNumber(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        int dif = x.GetValue() - y.GetValue();
        if(dif != 0)
        {
            return dif;
        }
        else
        {
            return x.GetWord().CompareTo(y.GetWord());
        }
    }
}
