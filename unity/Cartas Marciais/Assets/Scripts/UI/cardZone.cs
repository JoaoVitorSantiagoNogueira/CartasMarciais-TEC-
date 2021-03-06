using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardZone : MonoBehaviour
{
    private bool queuedToBeDestroyed =false;
    protected int cardCap;
    
    protected bool hasCard;
    protected List<card> cardList = new List<card>();

    public void OnDisable()
    {
        queuedToBeDestroyed = true;
    }

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

    public virtual bool acceptCard(card c)
    {
        return  hasSpace();
    }

    public virtual bool getHasCard()
    {
        return hasCard;
    }

    public virtual void AddCard (card cui, int pos)
    {
        hasCard = true;
        cardList.Insert(pos, cui);
    }

    public virtual void RemoveCard(int index)
    {
        cardList.RemoveAt(index);
        if (cardList.Count <=0)
        {
            hasCard = false;
        }
    }

    public card GetCard (int index)
    {
        return cardList[index];
    }

    public bool moveCardFrom (int index, cardZone newOwner)
    {
        if (newOwner.acceptCard(GetCard(index)))
        {
            card c = GetCard(index);
            newOwner.AddCard(c);        
            RemoveCard(index);
            return true;
        }
        else return false;
    }

    public card popCard(int i)
    {
        card c =  GetCard(i);
        RemoveCard(i);
        return c;
    }

    public bool isQueuedToBeDestroyed(){
        return queuedToBeDestroyed;
    }

    public abstract void click();
    public abstract void release();
    public abstract void mouseOver();
    
}
