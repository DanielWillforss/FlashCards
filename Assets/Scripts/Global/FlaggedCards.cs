using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaggedCards : CardListBase
{

    public void Create()
    {
        list = new List<FlashCard>();
    }

    public void FlagCard(FlashCard card)
    {
        if(!list.Contains(card))
        {
            AddCard(card);
        }
    }
}
