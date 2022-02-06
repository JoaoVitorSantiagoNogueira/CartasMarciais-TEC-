using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventController : singleton<EventController>
{

    public Deck playerDeck;
    public playZone pz;
    int currentPhase;
    enum phase
    {
        PreGame = -1,
        Draw = 0,
        Play = 1,
        Combo = 2,
        Discard = 3,
        Count = 4
    }

    public void Start()
    {
        setPhase (-1);
    }

    public void AdvancePhase()
    {
        setPhase((currentPhase + 1)% (int) phase.Count);
    }

    void setPhase (int i)
    {
        currentPhase = i ;
        switch(currentPhase)
        {
            case (int) phase.Draw:
                DiscardPhaseEnd();
                //playerDeck.DealNewHand();
                DrawPhaseStart();
                break;
            case (int) phase.Play:
                DrawPhaseEnd();
                PlayPhaseStart();
                break;
            case (int) phase.Combo:
                PlayPhaseEnd();
                ComboPhaseStart();
                break;
            case (int) phase.Discard:
                ComboPhaseEnd();
                DiscardPhaseStart();
                break;
        }
    }

    //events
    public event Action<card> onDiscardCards;//change to list
    public void discardCards(card lc)
    {
        if (onDiscardCards != null)
        {
            onDiscardCards(lc);
        }
    }

    public event Action onDrawPhaseStart;
    public void DrawPhaseStart()
    {
        if (onDrawPhaseStart!=null)
        onDrawPhaseStart();
    }

    public event Action onDrawPhaseEnd;
    public void DrawPhaseEnd()
    {
        if (onDrawPhaseEnd!=null)
        onDrawPhaseEnd();
    }

    public event Action onPlayPhaseStart;
    public void PlayPhaseStart()
    {
        if (onPlayPhaseStart!=null)
        onPlayPhaseStart();
    }

    public event Action onPlayPhaseEnd;
    public void PlayPhaseEnd()
    {
        if (onPlayPhaseEnd!=null)
        onPlayPhaseEnd();
    }

    public event Action onComboPhaseStart;
    public void ComboPhaseStart()
    {
        if (onComboPhaseStart!=null)
        onComboPhaseStart();
    }

    public event Action onComboPhaseEnd;
    public void ComboPhaseEnd()
    {
        if (onComboPhaseEnd!=null)
        onComboPhaseEnd();
    }

    public event Action onDiscardPhaseStart;
    public void DiscardPhaseStart()
    {
        if (onDiscardPhaseStart!=null)
        onDiscardPhaseStart();
    }

    public event Action onDiscardPhaseEnd;
    public void DiscardPhaseEnd()
    {
        if (onDiscardPhaseEnd!=null)
        onDiscardPhaseEnd();
    }

    public event Action <card> onDrawCard;
    public void DrawCard(card c)
    {
        if (onDrawCard!=null)
        onDrawCard(c);
    }

    public event Action onRemoveHand;
    public void removeHand()
    {
        if (onRemoveHand!=null)
        onRemoveHand();
    }

    public event Action <card> onCardPlayed;
    public void cardPlayed(card c)
    {
        if (onCardPlayed!=null)
        onCardPlayed(c);
    }

    public event Action onCardResolve;
    public void cardResolve()
    {
        if (onCardResolve!=null)
        onCardResolve();
    }

    public event Action <int> onRequestCardDraw;
    public void requestCardDraw(int i)
    {
        if (onRequestCardDraw!=null)
        onRequestCardDraw(i);
    }

    public event Action <int> onPlayerAttack;
    public void playerAttack(int i)
    {
        if (onPlayerAttack!=null)
        onPlayerAttack(i);
    }
}
