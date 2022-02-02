using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : hand
{
    public card cardPref;
    
    public hand [] handSlots;

    

    public override void Start()
    {
        base.Start();
        EventController.instance.onDrawPhaseStart += DealNewHand;
    }

    public void Destroy()
    {
        EventController.instance.onDrawPhaseStart -= DealNewHand;
    }



    public void DealNewHand()
    {
        Debug.Log("DealNewHand");
        for (int i = 0; i < 3; i++)
        {
                EventController.instance.DrawCard(Instantiate(cardPref));
        }
    }

}
