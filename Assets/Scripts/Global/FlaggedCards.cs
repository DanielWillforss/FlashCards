using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaggedCards : MonoBehaviour
{

    public FlashCardList flaggedData = new FlashCardList();

    public void FlagCard(FlashCard card)
    {
        flaggedData.Add(card);
    }

    public FlashCard GetCard(int index)
    {
        return flaggedData.Get(index);
    }

    public void UnflagCard(FlashCard card)
    {
        flaggedData.Remove(card);
    }

    public int Length()
    {
        return flaggedData.Length();
    }
}
