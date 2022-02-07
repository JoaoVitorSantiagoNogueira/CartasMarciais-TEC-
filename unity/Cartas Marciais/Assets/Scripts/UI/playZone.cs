using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playZone : cardZone
{

    int combo_limit = -1;
    bool PlayPhase = false;
    bool ComboPhase = false;

    bool PlayerWon;


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
            if (EventController.instance.duel(c))
            {
                PlayerWon = true;
            }
                else 
                PlayerWon = false;
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

        if (ComboPhase && PlayerWon)
        return cardList[cardList.Count-1].comboOk(c);

        return false;
    }

    public override void release()
    {
        //todo
    }

    public override void mouseOver()
    {
        //todo
    }

    public override void click()
    {
        //todo
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
        if (!PlayerWon)
        {
            EventController.instance.playerLost();
        }
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
            if (PlayerWon)
            EventController.instance.playerAttack(GetCard(i).power);
            EventController.instance.discardCards(popCard(i));
        }
        combo_limit =-1;

    }
}
