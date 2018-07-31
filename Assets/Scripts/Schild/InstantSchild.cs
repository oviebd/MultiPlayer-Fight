using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSchild : MonoBehaviour,ISchild {

    public Utility.SchildTypes schildType;

    public GameObject _schildObj;
    [SerializeField] private float _coolDownTime;
    [SerializeField] private float _schildLifeTime;

    float _lastSchildSpawnTime;
    bool  _isSchildActivated;

    void Awake () {

        _isSchildActivated = false;
        _lastSchildSpawnTime = Time.time;
   
    }

   
    public void DamageSchild(int amount)
    {
      
    }

    public void HitBySchild(int amount)
    {
        
    }

    public void ShieldSetUp()
    {
        _isSchildActivated = false;
        _lastSchildSpawnTime = Time.time;
    
    }

   
    public void ActivateSchild()
    {
        if(Time.time -_lastSchildSpawnTime >= _coolDownTime && _isSchildActivated == false)
        {
            _isSchildActivated = true;

            _schildObj.SetActive(true);
            Invoke("DeactivateSchild", 1.0f);
        }
       
    }

    public void DeactivateSchild()
    {
        Debug.Log("Deactive Schild called ");
        _lastSchildSpawnTime = Time.time;
        _isSchildActivated = false;
        _schildObj.SetActive(false);
    }
}
