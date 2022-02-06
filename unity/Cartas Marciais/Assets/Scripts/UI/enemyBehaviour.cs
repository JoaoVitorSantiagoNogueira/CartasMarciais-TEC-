using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    public card [] knownCards;
    void Start()
    {
        EventController.instance.onPlayPhaseEnd += CardContest;
    }

    // Update is called once per frame
    void CardContest ()
    {
        
    }
}
