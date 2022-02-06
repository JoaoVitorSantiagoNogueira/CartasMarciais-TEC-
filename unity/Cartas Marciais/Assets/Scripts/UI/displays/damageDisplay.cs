using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageDisplay : display
{
    // Start is called before the first frame update
    int totalDamage;
    public override void Start()
    {
        base.Start();
        EventController.instance.onPlayPhaseStart += resetDamage;
        EventController.instance.onCardPlayed += cardPlayed;
    }

    public void Destroy()
    {
        base.Start();
        EventController.instance.onPlayPhaseStart -= resetDamage;
        EventController.instance.onCardPlayed -= cardPlayed;
    }

    private void cardPlayed(card c)
    {
        addDamage(c.getPower());
    }   


    public void resetDamage()
    {
        totalDamage = 0;
        updateDisplay();
    }   

    public void setDamage(int i)
    {
        totalDamage = i;
        updateDisplay();
    }   

    public void addDamage(int i)
    {
        totalDamage += i;
        updateDisplay();
    }   

    public void updateDisplay()
    {
        base.updateDisplay(totalDamage.ToString());
    }

}
