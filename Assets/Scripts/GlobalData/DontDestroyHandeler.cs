using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyHandeler : MonoBehaviour
{
    private static DontDestroyHandeler handelerInstance = null;
    private StateInfo stateInfo;
    private CardList cardList;

    private void Awake()
    {
        if (handelerInstance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            handelerInstance = this;

            cardList = DataUtil.LoadCardListFromJson();
            //cardList = new CardList { list = new List<FlashCard>(DataUtil.GetAllData()) };
            stateInfo = DataUtil.LoadStateInfoFromJson();
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
        return stateInfo;
    }

    public CardList GetCardList()
    {
        return cardList;
    }

    public void CloseAndSave()
    {
        DataUtil.SaveCardListToJson(cardList);
        DataUtil.SaveStateInfotoJson(stateInfo);
        handelerInstance = null;
        Destroy(this.gameObject);
    }

    private void OnApplicationQuit()
    {
        CloseAndSave();
    }
}
