using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantSchild : MonoBehaviour,ISchild {

    public Utility.ShieldType schildType;

    public GameObject _shieldObj;
    [SerializeField] private float _coolDownTime;
    [SerializeField] private float _shieldLifeTime;

    float _lastShieldSpawnTime;
    bool  _isShieldActivated;

    private Collider _collider;
    private SliderController _shieldCooldownSlider;

    void Awake () {

        _collider = GetComponent<Collider>();
        _collider.enabled = false;

        _isShieldActivated = false;
        _lastShieldSpawnTime =Time.time;
        _shieldObj.SetActive (false);
    }

   
    public void DamageSchild(int amount)
    {
      
    }

    public void HitBySchild(int amount)
    {
        
    }

    public void ShieldSetUp(SliderController coolDownSlider)
    {
        _isShieldActivated = false;
       _lastShieldSpawnTime =Time.time;
        _shieldCooldownSlider = coolDownSlider;
    }

   
    public void ActivateSchild()
    {
        if (Time.time -_lastShieldSpawnTime >= _coolDownTime && _isShieldActivated == false)
        {
            _collider.enabled = true;
            _isShieldActivated = true;

            _shieldObj.SetActive(true);
            Invoke("DeactivateSchild", _shieldLifeTime);
        }
    }

    public void DeactivateSchild()
    {
        _collider.enabled = false;
        //  Debug.Log("Deactive Schild called ");
        _lastShieldSpawnTime = Time.time;
        _shieldCooldownSlider.OnCooldown(_coolDownTime);
        _isShieldActivated = false;
        _shieldObj.SetActive(false);
      
        GetComponentInParent<ShieldManager>().DeactiveShield();
    }
}
