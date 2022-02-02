using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extendableZone : cardZone
{
    // Start is called before the first frame update

    public hand handSlot;

    protected List<hand> cardZoneList = new List<hand>();

    public void Start()
    {
        cardCap = 10;
        EventController.instance.onDrawCard += AddCard;
    }

    public void Delete()
    {
        EventController.instance.onDrawCard -= AddCard;
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

        for (int i=0; i<cardZoneList.Count;i++)
            cardZoneList[i].move(this.transform.position + Vector3.right * calculateOffset(i, cardZoneList.Count) +Vector3.up);
    }

    public float calculateOffset(int i, int max)
    {
        float I = (float) i;
        float MAX = (float) max;

        return ((I+1-((MAX+1)/2))*3);
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
