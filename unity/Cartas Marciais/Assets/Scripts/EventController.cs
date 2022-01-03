using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
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
                playerDeck.DealNewHand();
                AdvancePhase();
                break;
            case (int) phase.Play:
                pz.setPhase(true);
            break;
        }
    }
}
