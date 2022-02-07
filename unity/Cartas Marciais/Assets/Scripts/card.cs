using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public int power;
    public int priority;
    public int max_combo;
    public Vector3 basePosition;
    public char[] typeText;
    public char[] followUpText;
    Vector3 displayPosition = new Vector3(5, 5.5f, -2);
    public cardType c_type;

    public cardType[] followUps  = new cardType[3]; 


    public static bool beats(card a, card b)
    { 
        if (a.c_type.GetType() != b.c_type.GetType())
        return cardType.beat(a.c_type, b.c_type);
        else
        if (a.priority<b.priority)
        return true;
        return false;
    }
    // Start is called before the first frame update

    public void Awake()
    {
        c_type = new cardType(typeText[0].ToString(), typeText[1].ToString());
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
            if (followUps[i]==c.c_type)
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
