using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class healthController : MonoBehaviour
{
    public healthDisplay [] hd;
    public int playerHealth = 30;
    public int enemyHealth = 30;

    public void Start()
    {
        EventController.instance.onPlayerAttack += decreaseEnemyHealth;
        EventController.instance.onPlayerDamage += decreasePlayerHealth;

        hd[0].showHealth(playerHealth);
        hd[1].showHealth(enemyHealth);
    }

    public void decreasePlayerHealth(int i)
    {
        playerHealth  -= i;
        if (playerHealth <=0)
        {
            Debug.Log("you lose");
            SceneManager.LoadScene("lose_screen");
        }
        EventController.instance.playerDamageDisplayUpdate(playerHealth);
    }

    public void decreaseEnemyHealth(int i)
    {
        enemyHealth  -= i;
        EventController.instance.enemyDamage(enemyHealth);
        if (enemyHealth <=0)
        {
            Debug.Log("you win");
            SceneManager.LoadScene("lose_screen");
        }
    }
}
