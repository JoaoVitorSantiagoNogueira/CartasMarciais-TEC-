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
        "Draw > Play",
        "Play > Combo",
        "Combo > Discard",
        "Discard > Draw"
    };

    void Start()
    {
        textObj = GetComponent<Text>();
        EventController.instance.onDrawPhaseStart += SwitchLable;
        EventController.instance.onPlayPhaseStart += SwitchLable;
        EventController.instance.onComboPhaseStart += SwitchLable;
        EventController.instance.onDiscardPhaseStart += SwitchLable;
    }

    void Destroy()
    {
        EventController.instance.onDrawPhaseStart -= SwitchLable;
        EventController.instance.onPlayPhaseStart -= SwitchLable;
        EventController.instance.onComboPhaseStart -= SwitchLable;
        EventController.instance.onDiscardPhaseStart -= SwitchLable;
    }

    void SwitchLable()
    {
        i = (i+1)%4;
        textObj.text = expression [i];
    }



}
