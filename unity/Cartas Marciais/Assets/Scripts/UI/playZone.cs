using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playZone : cardZone
{

    int combo_limit = -1;
    bool PlayPhase = false;
    bool ComboPhase = false;


    void Start()
    {
        cardCap = 1;
        EventController.instance.onPlayPhaseStart += startPlay;
        EventController.instance.onPlayPhaseEnd   += stopPlay;
        EventController.instance.onComboPhaseStart += startCombo;
        EventController.instance.onComboPhaseEnd   += stopCombo;

    }

    void Destroy()
    {
        EventController.instance.onPlayPhaseStart -= startPlay;
        EventController.instance.onPlayPhaseEnd   -= stopPlay;
        EventController.instance.onComboPhaseStart -= startCombo;
        EventController.instance.onComboPhaseEnd   -= stopCombo;
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
        if (!(PlayPhase||ComboPhase))
        return false;

        if (combo_limit==0)
        return false;

        if (hasSpace())
        return true;

        if (ComboPhase)
        return cardList[cardList.Count-1].comboOk(c);

        return false;
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

    public void setPhasePlay(bool p)
    {
        PlayPhase = p;
        if (p)
            GetComponent<Renderer>().material.SetColor ("_Color", Color.blue);
        else
            {
            GetComponent<Renderer>().material.SetColor ("_Color", Color.red);
            }
    }

    public void startPlay ()
    {
        setPhasePlay(true);
    }

    public void stopPlay ()
    {
        setPhasePlay(false);
    } 

    public void startCombo()
    {
        ComboPhase = true;
    }

    public void stopCombo()
    {
        ComboPhase = false;
        for (int i = cardList.Count-1; i >= 0; i--)
        {
            EventController.instance.cardResolve();
            EventController.instance.playerAttack(GetCard(i).power);
            EventController.instance.discardCards(popCard(i));
        }
        combo_limit =-1;

    }
}
