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

    public int getPower()
    {
        return power;
    }
}
