using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playZone : cardZone
{

    bool rightPhase = false;

    void Start()
    {
        cardCap = 2;
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
        base.AddCard(c);
        c.transform.position = transform.position + Vector3.up*0.3f + (cardList.Count-1)* Vector3.right;
    }

    public override bool acceptCard(card c)
    {
        if (!rightPhase)
        return false;
        else if (hasSpace())
        return true;
        else {
        return cardList[cardList.Count-1].comboOk(c);
        }
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
            EventController.instance.discardCards(popCard(0));
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
