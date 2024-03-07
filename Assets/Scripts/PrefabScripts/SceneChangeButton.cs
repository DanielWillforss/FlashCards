using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SceneChangeButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string tag = gameObject.tag;
        GetComponent<Button>().onClick.AddListener(() => SceneHandeler.ChangeScene(tag));
        GetComponentInChildren<TMP_Text>().text = tag;
    }
}
