using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashCard
{
    private int value;
    private string word;
    private string translation;

    public FlashCard(int value, string word, string translation)
    {
        this.value = value;
        this.word = word;
        this.translation = translation;
    }

    public int GetValue()
    {
        return value;
    }

    public string GetWord()
    {
        return word;
    }

    public string GetTranslation()
    {
        return translation;
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
