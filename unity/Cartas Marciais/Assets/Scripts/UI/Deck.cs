using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : hand
{
    public card cardPref;
    
    public hand [] handSlots;

    public void DealNewHand()
    {
        Debug.Log("DealNewHand");
        for (int i = 0; i < handSlots.Length; i++)
        {
            if (handSlots[i].hasSpace())
            {
                handSlots[i].AddCard(Instantiate(cardPref));
            }
        }
    }

}
