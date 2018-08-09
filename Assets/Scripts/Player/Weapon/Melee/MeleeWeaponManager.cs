﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponManager : MonoBehaviour {

    [SerializeField] private GameObject _meleeWeaponPrefab;
    private MeleeWeaponBehaviour _meleeBehaviour;

    private PlayerWeaponManager _playerWeaponManager;
    private int _playerNum;

    private string _meleeBtn;

    // CoolDown
   
    private float _prevMeleeTime;
    [SerializeField] float _meleeCoolDownTime = 1.0f;

    void Start () {

        InstantiateMeleeWeapon();
        _playerWeaponManager = gameObject.GetComponentInParent<PlayerWeaponManager>();
        _playerNum = _playerWeaponManager.playerNum;

        _prevMeleeTime = Time.time;
        _meleeBtn = "P" + _playerNum + "melee";

    }

    void ActivateMeleeAttack()
    {
        _prevMeleeTime = Time.time;
        _meleeBehaviour.StartAttack();
    }

    void InstantiateMeleeWeapon()
    {
       GameObject meleeWeaponObj = Instantiate(_meleeWeaponPrefab, _meleeWeaponPrefab.transform.position, Quaternion.identity);
        meleeWeaponObj.transform.SetParent(transform, false);
        meleeWeaponObj.transform.localRotation = _meleeWeaponPrefab.transform.rotation;

        _meleeBehaviour = meleeWeaponObj.GetComponent<MeleeWeaponBehaviour>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.M))
        {
            if( (Time.time - _prevMeleeTime) >= _meleeCoolDownTime)
            {
                // Debug.Log("Melee Input DOwn");
                ActivateMeleeAttack();
            }
         
        }

    }
}