using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthDisplay : display
{
    public bool isEnemy;
    public override void Start()
    {
        
        base.Start();
        if (isEnemy)
        {
            EventController.instance.onEnemyDamage += showHealth;
        }
        else
            EventController.instance.onPlayerDamageDisplayUpdate += showHealth;
    }

    public void Destroy()
    {
        base.Start();
        if (isEnemy)
        {
            EventController.instance.onEnemyDamage += showHealth;
        }
        else
            EventController.instance.onPlayerDamageDisplayUpdate += showHealth;
    }

    // Update is called once per frame
    public void showHealth(int i)
    {
        Debug.Log(i);
        updateDisplay(i.ToString());
    }
}
