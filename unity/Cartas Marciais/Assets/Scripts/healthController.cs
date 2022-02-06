using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthController : MonoBehaviour
{
    public int playerHealth = 6;
    public int enemyHealth = 6;

    public void Start()
    {
        EventController.instance.onPlayerAttack += decreaseEnemyHealth;
    }

    public void decreasePlayerHealth(int i)
    {
        playerHealth  -= i;
        if (playerHealth <=0)
        {
            Debug.Log("you lose");
        }
    }

    public void decreaseEnemyHealth(int i)
    {
        enemyHealth  -= i;
        if (enemyHealth <=0)
        {
            Debug.Log("you win");
        }
    }



}
