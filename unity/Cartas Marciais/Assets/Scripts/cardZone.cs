using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardZone : MonoBehaviour
{
    int cardCap;
    List<CardUI> cardList;

    void Start()
    {
        
    }

    // Update is called once per frame
    void AddCard(CardUI cui)
    {
        cardList.Add(cui);
    }

    void AddCard (CardUI cui, int pos)
    {
        cardList.Insert(pos, cui);
    }

    void RemoveCard(int index)
    {
        cardList.RemoveAt(index);
    }

    CardUI GetCard (int index)
    {
        return cardList[index];
    }

    CardUI moveCardFrom (int index)
    {
        CardUI c = GetCard(index);
        RemoveCard(index);
        return c;
    }
    
}
