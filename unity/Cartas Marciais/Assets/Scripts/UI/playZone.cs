using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playZone : cardZone
{

    int combo_limit = -1;
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
        if (combo_limit == -1)
        {
            combo_limit = c.max_combo;
        }
        else 
            combo_limit = (Math.Min(combo_limit-1, c.max_combo));

        EventController.instance.cardPlayed(c);
        base.AddCard(c);
        c.transform.position = transform.position + Vector3.up*0.3f + (cardList.Count-1)* Vector3.right;
    }

    public override bool acceptCard(card c)
    {
        if (!rightPhase)
        return false;

        if (combo_limit==0)
        return false;

        if (hasSpace())
        return true;
        Debug.Log("até aqui fi");
        return cardList[cardList.Count-1].comboOk(c);

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
            for (int i = cardList.Count-1; i >= 0; i--)
            {
                EventController.instance.cardResolve();
                EventController.instance.discardCards(popCard(i));
            }
                combo_limit =-1;
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
