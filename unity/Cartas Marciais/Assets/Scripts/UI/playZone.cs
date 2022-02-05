using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playZone : cardZone
{

    bool rightPhase = false;

    void Start()
    {
        cardCap = 1;
        EventController.instance.onPlayPhaseStart += startPlay;
        EventController.instance.onComboPhaseEnd   += stopPlay;
    }

    void Destroy()
    {
        EventController.instance.onPlayPhaseStart -= startPlay;
        EventController.instance.onPlayPhaseEnd   -= stopPlay ;
    }

    public override void AddCard(card c)
    {
        EventController.instance.cardPlayed(c);
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
            {
            GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
            EventController.instance.discardCards(moveCardFrom(0));
            }
    }

    public void startPlay ()
    {
        setPhase(true);
    }

    public void stopPlay ()
    {
        setPhase (false);
    } 
}
