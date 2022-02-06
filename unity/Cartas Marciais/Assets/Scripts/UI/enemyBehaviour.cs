using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public card [] knownCards;
    public card inDisplay;

    // Update is called once per frame
    public card GetCard ()
    {
        inDisplay = knownCards[Random.Range(0, knownCards.Length)];
        //Instantiate[]
        return inDisplay;
    }
}
