using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListBase : MonoBehaviour
{
    protected List<FlashCard> list = null;

    public void AddCard(FlashCard card)
    {
        list.Add(card);
    }

    public FlashCard GetCard(int index)
    {
        return list[index];
    }

    public void RemoveCard(FlashCard card)
    {
        list.Remove(card);
    }

    public int Length()
    {
        return list.Count;
    }

    public void SortData()
    {
        list.Sort(CompareDataByNumber);
    }

    private static int CompareDataByNumber(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        int dif = x.GetValue() - y.GetValue();
        if (dif != 0)
        {
            return dif;
        }
        else
        {
            return x.GetWord().CompareTo(y.GetWord());
        }
    }
}
