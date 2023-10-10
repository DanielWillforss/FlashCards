using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInfo : MonoBehaviour
{
    private int numberOfCards = 0;

    public void SetNbrOfCards(int nbr)
    {
        //Debug.Log("Set: " + nbr);
        numberOfCards = nbr;
    }

    public int GetNbrOfCards()
    {
        //Debug.Log("Get: " + numberOfCards);
        return numberOfCards;
    }
}
