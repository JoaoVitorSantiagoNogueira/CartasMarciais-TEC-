using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class singleton<T> : MonoBehaviour where T: singleton<T>
{
    public static T instance {get; private set;}
 
    void Awake (){
        if (instance != null){
             Debug.LogError("A instance already exists");
             Destroy(gameObject); //Or GameObject as appropriate
             return;
        }
        else 
            {instance = (T)this;}
    }
}
