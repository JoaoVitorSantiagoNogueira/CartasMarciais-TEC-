using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : cardZone
{

    public override void AddCard(card c)
    {
        c.transform.position = transform.position + Vector3.up*0.3f;
        base.AddCard(c);
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

    public override void click()
    {
        throw new System.NotImplementedException();
    }
}
