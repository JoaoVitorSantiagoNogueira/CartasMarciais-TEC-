using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extendableZone : cardZone
{
    // Start is called before the first frame update

    public hand handSlot;

    int handSize=5;
    int extraDraws=0;

    protected List<hand> cardZoneList = new List<hand>();

    public void Start()
    {
        cardCap = 10;
        EventController.instance.onDrawPhaseStart += startPhase;
        EventController.instance.onDrawCard += AddCard;
        EventController.instance.onRemoveHand += removeHand;
    }

    public void Delete()
    {
        EventController.instance.onDrawPhaseStart -= startPhase;
        EventController.instance.onDrawCard -= AddCard;
        EventController.instance.onRemoveHand -= removeHand;
    }

    public override bool hasSpace()
    {
        if (cardZoneList.Count < cardCap)
            return true;
        else return false;
    }

    public override void AddCard(card cui)
    {
        hand cz = Instantiate(handSlot, transform);
        cardZoneList.Add(cz);
        cz.AddCard(cui);
        arrangeCardPosition();
    }

    public void arrangeCardPosition()
    {
        //Debug.Log(cardZoneList.Count);
        for (int i=0; i<cardZoneList.Count;i++)
            cardZoneList[i].move(this.transform.position + Vector3.right * calculateOffset(i, cardZoneList.Count) +Vector3.up);
    }

    public float calculateOffset(int i, int max)
    {
        float I = (float) i;
        float MAX = (float) max;

        return ((I+1-((MAX+1)/2))*3);
    }

    public override void RemoveCard(int i)
    {
    cardZone cz = cardZoneList[i];
    cardZoneList.RemoveAt(i);
    
    if (cz == null)
    {
        while (cz.getHasCard())
            {
                EventController.instance.discardCards(cz.popCard(0));
            }
        Destroy(cz);
    }
    }

    public void removeHand ()
    {
        for (int i =0; i<cardZoneList.Count; i++)
        {
            if (cardZoneList[i]==null)
            {
                RemoveCard(i);
            }
            else if (cardZoneList[i].isQueuedToBeDestroyed())
            {
                RemoveCard(i);
            }

        }
        arrangeCardPosition();
    }

    public void startPhase()
    {
        EventController.instance.requestCardDraw(handSize - cardZoneList.Count +extraDraws);
    }

    public override void release()
    {
        //todo
    }

    public override void click()
    {
        //todo
    }

    public override void mouseOver()
    {
        //todo
    }
}
