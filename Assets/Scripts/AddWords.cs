using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddWords : MonoBehaviour
{
    public TMP_InputField word;
    public TMP_InputField translation;

    public void AddWordButton()
    {
        //Add more logic
        DataHandeler.AddNewData(word.text, translation.text);
        word.text = "";
        translation.text = "";
    }
}
