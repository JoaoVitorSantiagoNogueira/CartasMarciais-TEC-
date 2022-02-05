using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    Text textObj;
    int totalDamage;
    void Start()
    {
        textObj = GetComponent<Text>();
        EventController.instance.onPlayPhaseStart += resetDamage;
        EventController.instance.onCardPlayed += cardPlayed;
    }

    void Destroy()
    {
        EventController.instance.onPlayPhaseStart -= resetDamage;
        EventController.instance.onCardPlayed -= cardPlayed;
    }

    private void cardPlayed(card c)
    {
        addDamage(c.getPower());
    }   


    public void resetDamage()
    {
        totalDamage = 0;
        updateDisplay();
    }   

    public void setDamage(int i)
    {
        totalDamage = i;
        updateDisplay();
    }   

    public void addDamage(int i)
    {
        totalDamage += i;
        updateDisplay();
    }   

    public void updateDisplay()
    {
        textObj.text = totalDamage.ToString();
    }

}
