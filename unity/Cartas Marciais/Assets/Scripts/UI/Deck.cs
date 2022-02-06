using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : hand
{
    public card [] deckList;

    public override void Start()
    {
        base.Start();
        EventController.instance.onRequestCardDraw += DealCards;
    }

    public void Destroy()
    {
        EventController.instance.onRequestCardDraw -= DealCards;
    }

    public void DealCards(int i)
    {
        for (int j = 0; j < i; j++)
        {
                EventController.instance.DrawCard(Instantiate(deckList[Random.Range(0, 9)]));
        }
    }

}
