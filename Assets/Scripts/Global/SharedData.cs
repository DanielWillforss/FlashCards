using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharedData : MonoBehaviour
{
    private static SharedData dataInstance = null;
    private StateInfo stateInfoScript;
    private CardListManger cardListScript;
    private FlaggedCards flaggedCardsScript;

    private void Awake()
    {
        if (dataInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            dataInstance = this;

            stateInfoScript = GetComponent<StateInfo>();
            cardListScript = GetComponent<CardListManger>();
            cardListScript.Create();
            flaggedCardsScript = GetComponent<FlaggedCards>();
            flaggedCardsScript.Create();
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static SharedData GetSharedData()
    {
        return dataInstance;
    }

    public StateInfo GetStateInfo() {
        return stateInfoScript;
    }

    public CardListManger GetCardList()
    {
        return cardListScript;
    }

    public FlaggedCards GetFlaggedCards()
    {
        return flaggedCardsScript;
    }

    public void CloseAndSave()
    {
        FindObjectOfType<CardListManger>().SaveData();
        dataInstance = null;
        Destroy(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        CloseAndSave();
    }
}
