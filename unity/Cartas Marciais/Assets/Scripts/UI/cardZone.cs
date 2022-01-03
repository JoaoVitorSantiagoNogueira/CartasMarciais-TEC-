using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardZone : MonoBehaviour
{
    protected int cardCap;
    
    protected bool hasCard;
    protected List<card> cardList = new List<card>();

    // Update is called once per frame
    public virtual void AddCard(card cui)
    {
        hasCard = true;
        cardList.Add(cui);
    }

    public virtual bool hasSpace()
    {
        if (cardList.Count < cardCap)
            return true;
        else return false;

    }

    public virtual void AddCard (card cui, int pos)
    {
        hasCard = true;
        cardList.Insert(pos, cui);
    }

    public void RemoveCard(int index)
    {
        cardList.RemoveAt(index);
    }

    public card GetCard (int index)
    {
        return cardList[index];
    }

    public card moveCardFrom (int index)
    {
        card c = GetCard(index);
        RemoveCard(index);
        return c;
    }

    public abstract void click();
    public abstract void release();
    public abstract void mouseOver();
    
}
