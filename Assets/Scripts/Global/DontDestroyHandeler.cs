using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyHandeler : MonoBehaviour
{
    private static DontDestroyHandeler handelerInstance = null;
    private StateInfo stateInfoScript;
    private CardList cardListScript;

    private void Awake()
    {
        if (handelerInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            handelerInstance = this;

            stateInfoScript = GetComponent<StateInfo>();
            cardListScript = GetComponent<CardList>();
            cardListScript.Create();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static DontDestroyHandeler GetHandeler()
    {
        return handelerInstance;
    }

    public StateInfo GetStateInfo() {
        return stateInfoScript;
    }

    public CardList GetCardList()
    {
        return cardListScript;
    }

    public void CloseAndSave()
    {
        cardListScript.SaveData();
        handelerInstance = null;
        Destroy(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        CloseAndSave();
    }
}
