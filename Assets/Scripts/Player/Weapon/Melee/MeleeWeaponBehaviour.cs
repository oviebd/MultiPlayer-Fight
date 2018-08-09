using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour {

    private  Animator _anim;

    private string _animStartAttackSTring = "IsAttack";

    [SerializeField]  private int damagePerHit = 30;
    private Collider _collider;

    void Start () {
        _anim = GetComponent<Animator>();
        _collider = GetComponentInChildren<Collider>();
        StopAttack();
    }
	
	
	

    public void StartAttack()
    {
        _collider.enabled = true;
        //Invoke("StopAttack", 1.0f);
        _anim.SetBool(_animStartAttackSTring, true);
    }

    public void StopAttack()
    {
        _collider.enabled = false;
        _anim.SetBool(_animStartAttackSTring, false);
    }

    private void OnTriggerEnter(Collider other)
    {

        Damageable damagable = other.GetComponent<Damageable>();
        if (damagable != null)
        {
            damagable.Damage(damagePerHit);

            Debug.Log("Damageable Found ");
        }
        else
        {
           // Destroy(gameObject);
        }
      //  Debug.Log("Collide with Player");
    }
}
