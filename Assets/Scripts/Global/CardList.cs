using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CardList : MonoBehaviour
{
    protected List<FlashCard> list = null;

    public void Create()
    {
        FlashCard[] cards = DataHandeler.GetAllData();
        list = new List<FlashCard>(cards);
    }

    public FlashCard AddNewCard(string word, string translation, int initValue = 0)
    {
        int newIndex = ValidateInput.GetAndUseNewUnusedIndex();
        FlashCard card = new FlashCard(newIndex, initValue, false, word, translation);
        AddCard(card);
        return card;
    }

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

    

    public int LengthOfFlagged()
    {
        return list.Count(card => card.GetIsFlagged());
    }

    public FlashCard[] GetCardArray()
    {
        FlashCard[] array = list.ToArray();
        return array;
    }

    public void SaveData()
    {
        SortData(); //Mby Different sort
        DataHandeler.ReplaceData(list.ToArray());
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

    private static int CompareDataByFlagged(FlashCard x, FlashCard y)
    {
        if (x == null || y == null)
        {
            return 0;
        }
        
        if(x.GetIsFlagged() && !y.GetIsFlagged())
        {
            return -1;
        }
        else if(!x.GetIsFlagged() && y.GetIsFlagged())
        {
            return 1;
        }
        else
        {
            return CompareDataByNumber(x, y);
        }
    }
}
