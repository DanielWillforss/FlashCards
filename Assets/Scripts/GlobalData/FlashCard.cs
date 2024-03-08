using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FlashCard
{
    public int index;
    public int value;
    public bool isFlagged;
    public string word;
    public string translation;

    public void UpdateValue(bool raise)
    {
        if (raise)
        {
            value++;
        }
        else
        {
            value--;
        }
    }

    public int GetIsFlaggedAsInt()
    {
        if (isFlagged)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
