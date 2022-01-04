﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playZone : cardZone
{

    bool rightPhase;

    void Start()
    {
        cardCap = 1;
        setPhase(false);
    }

    public override void AddCard(card c)
    {
        Debug.Log("AddCard");
        c.transform.position = transform.position + Vector3.up*0.3f;
        base.AddCard(c);
    }

    public override bool hasSpace()
    {
        if (base.hasSpace() && rightPhase) 
        return true;
        else return false;
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

    public void setPhase(bool p)
    {
        rightPhase = p;
        if (p)
            GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
        else
            GetComponent<Renderer>().material.SetColor ("_Color", Color.red);

    }
}