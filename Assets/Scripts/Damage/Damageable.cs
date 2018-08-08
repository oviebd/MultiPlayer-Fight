using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour,IDamageable {

    public int fullHealth=100;
    public bool isDestructive = false;

    public bool isItSchild = false;

    //Effects 
    [HideInInspector]public GameObject particleEffect;
    [HideInInspector]public GameObject hitObj;

    [System.Serializable]
    public class InteractionEvent : UnityEvent { }
    public InteractionEvent OnDamage = new InteractionEvent();


    public void Damage(int amount)
    {
        ReduceHealth(amount);
        OnDamage.Invoke();
       // Debug.Log("Damage amount " + amount);
       // if (!isItSchild)
        //    ReduceHealth(amount);
        
        ShowEffects();
       
    }

    void ReduceHealth(int amount)
    {
        fullHealth -= amount;
        if (fullHealth <= 0)
        {
            fullHealth = 0;
        }
    }

    void ShowEffects()
    {
        Destroy(hitObj, .1f);
        particleEffect.SetActive(true);
    }

    public int GetFullHealth()
    {
        return fullHealth;
    }
}
