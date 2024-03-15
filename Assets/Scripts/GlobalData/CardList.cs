using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class CardList
{
    public List<FlashCard> list;

    public FlashCard AddNewCard(string word, string translation, int initValue = 0)
    {
        int newIndex = ValidateUtil.GetAndUseNewUnusedIndex();
        FlashCard card = new FlashCard {
            index = newIndex,
            value = initValue,
            isFlagged = false,
            word = word,
            translation = translation
        };
        list.Add(card);
        return card;
    }

    public void ShiftAllCardsValue(int n)
    {
        foreach(FlashCard card in list)
        {
            card.value += n;
        }
    }

    public void SortData()
    {
        list.Sort(CompareDataByNumber);
    }

    public void SortDataByFlagged()
    {
        list.Sort(CompareDataByFlagged);
    }

    private static int CompareDataByNumber(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }

        int dif = x.value - y.value;
        if (dif != 0)
        {
            return dif;
        }
        else
        {
            return x.word.CompareTo(y.word);
        }
    }

    private static int CompareDataByFlagged(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }
        
        if(x.isFlagged && !y.isFlagged)
        {
            return -1;
        }
        else if(!x.isFlagged && y.isFlagged)
        {
            return 1;
        }
        else
        {
            return CompareDataByNumber(x, y);
        }
    }

    
}
