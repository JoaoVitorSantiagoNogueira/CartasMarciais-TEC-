using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public int power;
    public int priority;
    public int max_combo;
    public Vector3 basePosition;

    public static bool beats(card a, card b)
    { 
        if (a.type != b.type)
        return cardType.beat(a.type, b.type);
        else
        if (a.priority<b.priority)
        return true;
        return false;
    }

    public char[] typeText;
    public char[] followUpText;
    Vector3 displayPosition = new Vector3(5, 5.5f, -2);
    cardType type;

    public cardType[] followUps  = new cardType[3]; 

    // Start is called before the first frame update

    public void Start()
    {
        type = new cardType(typeText[0].ToString(), typeText[1].ToString());
        followUps[0]  = new cardType((followUpText[0].ToString()), (followUpText[1].ToString()));
        followUps[1]  = new cardType((followUpText[2].ToString()), (followUpText[3].ToString()));
        followUps[2]  = new cardType((followUpText[4].ToString()), (followUpText[5].ToString()));
    }
    public int getPower()
    {
        return power;
    }

    public bool comboOk(card c)
    {
        
        for (int i=0; i <3;i++)
            if (followUps[i]==c.type)
            {
            return true;
            }
        return false;
    }

    public void zoomToPlayer()
    {
        basePosition = transform.position;
        transform.position = displayPosition;
    }

    public void returnToPosition()
    {
        transform.position = basePosition;
    }
}
