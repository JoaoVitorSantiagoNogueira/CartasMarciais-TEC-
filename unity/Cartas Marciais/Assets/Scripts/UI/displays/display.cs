using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class display : MonoBehaviour
{
    Text textObj;
    public virtual void Start()
    {
        textObj = GetComponent<Text>();
    }

    // Update is called once per frame
    public void updateDisplay(string s)
    {
        textObj.text = s;
    }
}
