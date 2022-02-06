using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card : MonoBehaviour
{
    public int power;
    public int priority;

    cardType type;

    cardType[] followUps  = new cardType[3]; 

    // Start is called before the first frame update

    public void Start()
    {
        type = new cardType("attack", "low");
        followUps[0]  = new cardType("attack", "high");
        followUps[1]  = new cardType("block", "low");
        followUps[2]  = new cardType("attack", "high");
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
            Debug.Log("ok");
            return true;
            }
        return false;
    }
}
