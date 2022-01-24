using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonTextController : MonoBehaviour
{
    // Start is called before the first frame update
    Text textObj;

    int i = -1;

    static string[] expression = new string[] {
        "To Play",
        "To Combo",
        "To Discard",
        "To Draw"
    };

    void Start()
    {
        textObj = GetComponent<Text>();
        EventController.instance.onDrawPhaseStart += SwitchLable;
        EventController.instance.onPlayPhaseStart += SwitchLable;
        EventController.instance.onComboPhaseStart += SwitchLable;
        EventController.instance.onDiscardPhaseStart += SwitchLable;
    }

    void SwitchLable()
    {
        i = (i+1)%4;
        textObj.text = expression [i];
    }



}
