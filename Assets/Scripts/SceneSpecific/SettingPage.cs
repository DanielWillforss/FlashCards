using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingPage : MonoBehaviour
{
    public TMP_Text path;

    void Start()
    {
        path.text = "File Path: " + DataHandeler.path;
    }
}
