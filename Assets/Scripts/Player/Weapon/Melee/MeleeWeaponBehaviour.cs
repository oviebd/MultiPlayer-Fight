using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour {

    private  Animator _anim;

    private string _animStartAttackSTring = "IsAttack"; 

    void Start () {
        _anim = GetComponent<Animator>();
        StopAttack();
    }
	
	
	void Update () {
		
	}

    public void StartAttack()
    {
       
        //Invoke("StopAttack", 1.0f);
        _anim.SetBool(_animStartAttackSTring, true);
    }

    public void StopAttack()
    {
        _anim.SetBool(_animStartAttackSTring, false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide with Player");
    }
}
