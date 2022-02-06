using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardType
{

    public cardType(string button, string input)
    {
        setInput(button, input);
    }
    enum direction
    {
        high,
        mid,
        low,
        any
    }

    enum button
    {
        attack,
        block,
        move,
        any
    }
    direction d;
    button b;


    public void setInput(string button, string direction)
    {
        setButton(button);
        setDirection(direction);
    }

    public void setButton(string s)
    {
        if (s=="attack" || s=="A"|| s=="a" || s=="Attack")
            b = button.attack;
        if (s=="block" || s=="B" || s=="b" || s=="Block")
            b = button.block;
        if (s=="move" || s=="M" || s=="m"  || s=="c" || s=="C" || s=="Move")
            b = button.move;
        if (s=="any" || s=="*" || s=="Any")
            b = button.any;
    }

    public void setDirection(string s)
    {
        if (s=="high" || s=="h"|| s=="H" || s=="High")
            d = direction.high;
        if (s=="mid" || s=="m" || s=="M" || s=="Mid")
            d = direction.mid;
        if (s=="low" || s=="L" || s=="l" || s=="Low")
            d = direction.low;
        if (s=="any" || s=="*" || s=="Any")
            d = direction.any;
    }


    public bool isHigh()
    {
        if (d == direction.high || d == direction.any)
        return true;
        else
        return false;
    }

    public bool isMid()
    {
        if (d == direction.mid || d == direction.any)
        return true;
        else
        return false;
    }

    public bool isLow()
    {
        if (d == direction.low || d == direction.any)
        return true;
        else
        return false;
    }


        public bool isAttack()
    {
        if (b == button.attack || b == button.any)
        return true;
        else
        return false;
    }

    public bool isBlock()
    {
        if (b == button.block || b == button.block)
        return true;
        else
        return false;
    }

    public bool isMove()
    {
        if (b == button.move || b == button.any)
        return true;
        else
        return false;
    }


    public static bool operator ==(cardType obj1, cardType obj2)
    {
        bool match_buttons = ((obj1.b == obj2.b) ||  (obj1.b==button.any) ||  (obj2.b==button.any));
        Debug.Log ("buttons" + (match_buttons).ToString());

        bool match_direction = ((obj1.d == obj2.d) ||  (obj1.d==direction.any) ||  (obj2.d==direction.any));
        Debug.Log ("direction" + (obj1.d).ToString() + (obj2.d).ToString());

        return match_buttons && match_direction;
    }

    public static bool operator !=(cardType obj1, cardType obj2)
    {
        return !(obj1 == obj2);
    }
}
