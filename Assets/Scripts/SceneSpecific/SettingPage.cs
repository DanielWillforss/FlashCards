using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingPage : MonoBehaviour
{
    public TMP_Text path;
    private SharedData sharedData;

    void Start()
    {
        sharedData = FindObjectOfType<SharedData>();

        path.text = DataHandeler.path;
    }
}
