using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerDisplay : display
{
    int powerCount = 0;

    public override void Start()
    {
        base.Start();
        EventController.instance.onCardResolve += powerIncrease;
    }

    public void Destroy()
    {
        EventController.instance.onCardResolve += powerIncrease;
    }


    public void powerIncrease()
    {
        powerIncrease(1);
    }

    public void powerIncrease(int i)
    {
        powerCount +=1;
        updateDisplay(powerCount.ToString());
    }

    public bool powerSpend(int i)
    {
        if (powerCount - i <0)
        {
            return false;
        }
        else 
        {
            powerCount -= i;
            return true;
        }

    }
    


}
