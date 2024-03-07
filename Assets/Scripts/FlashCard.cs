using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCard
{
    private int index;
    private int value;
    private string word;
    private string translation;
    private bool isFlagged;

    //public FlashCard(int value, string word, string translation)
    //{
     //   this.value = value;
      //  this.word = word;
      //  this.translation = translation;
      //  this.isFlagged = false;
    //}

    public FlashCard(int index, int value, bool isFlagged, string word, string translation)
    {
        this.index = index;
        this.value = value;
        this.isFlagged = isFlagged;
        this.word = word;
        this.translation = translation;
    }

    public int GetIndex()
    {
        return index;
    }

    public int GetValue()
    {
        return value;
    }

    public string GetWord()
    {
        return word;
    }

    public void SetCard(int value, string word, string translation)
    {
        this.value = value;
        this.word = word;
        this.translation = translation;
    }

    public string GetTranslation()
    {
        return translation;
    }

    public bool GetIsFlagged()
    {
        return isFlagged;
    }

    public int GetIsFlaggedAsInt()
    {
        if(isFlagged)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public void SetIsFlagged(bool isFlagged)
    {
        this.isFlagged = isFlagged;
    }

    public void UpdateValue(bool raise)
    {
        if(raise)
        {
            value++;
        }
        else
        {
            value--;
        }
    }

}
