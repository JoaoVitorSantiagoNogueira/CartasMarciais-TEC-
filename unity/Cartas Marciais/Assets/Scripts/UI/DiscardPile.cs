using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : cardZone
{

    bool discardPhase;

    public void Start()
    {
        EventController.instance.onDiscardCards += AddCard;
        EventController.instance.onDiscardPhaseStart += setPhase;
        EventController.instance.onDiscardPhaseEnd += unsetPhase; 
    }

    public void Destroy()
    {
        EventController.instance.onDiscardCards -= AddCard;                
    }

    public override void AddCard(card c)
    {
        c.transform.position = transform.position + Vector3.up*0.3f;
        base.AddCard(c);
    }

    public override bool acceptCard(card c)
    {
        return discardPhase;
    }

    public override bool hasSpace()
    {
        return true;
    }

    public override void release()
    {
        throw new System.NotImplementedException();
    }

    public override void mouseOver()
    {
        throw new System.NotImplementedException();
    }

    public void setPhase()
    {
        discardPhase = true;
    }

    public void unsetPhase()
    {
        discardPhase = false;
    }
    public override void click()
    {
        throw new System.NotImplementedException();
    }
}
