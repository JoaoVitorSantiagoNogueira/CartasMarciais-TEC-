using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboDisplay : display
{
    int comboCount = -1;
    public override void Start()
    {
        base.Start();
        EventController.instance.onCardPlayed += comboLimit;
        EventController.instance.onCardResolve += resolve;
    }

    public void Destroy()
    {
        EventController.instance.onCardPlayed -= comboLimit;
        EventController.instance.onCardResolve -= resolve;
    }

    public void comboLimit(card c)
    {
        if (comboCount == -1)
        {
            comboCount = c.max_combo;
        }
        else comboCount = System.Math.Min(comboCount-1, c.max_combo);
        updateDisplay(comboCount.ToString());
    }

    public void resolve()
    {
        comboCount = -1;
        updateDisplay ("-");
    }
}
