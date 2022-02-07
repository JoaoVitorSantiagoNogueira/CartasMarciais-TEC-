using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public card [] knownCards;
    public card inDisplay;

    public void Start()
    {
        EventController.instance.onPlayPhaseEnd += reset;
    }


    // Update is called once per frame
    public card GetCard ()
    {
        inDisplay = (card) Instantiate(knownCards[Random.Range(0, knownCards.Length)], new Vector3(-4,0,1), Quaternion.identity);
        return inDisplay;
    }

    public void reset()
    {
        Debug.Log("check");
        EventController.instance.discardCards(inDisplay);
        
    }
}
