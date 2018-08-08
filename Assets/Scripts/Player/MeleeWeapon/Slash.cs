using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {

    public GameObject weapon;
    public float slashAngle;
    public float slashSpeed;

    bool isSlashing;
    float tempTimeofSlash;
    Quaternion target;

    private void Awake()
    {
        isSlashing = false;
        SetWeaponAngle();
    }

    // Use this for initialization
    void Start () {
        //StartSlashing();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartSlashing();
        }
    }

    // Update is called once per frame
    void  FixedUpdate ()
    {

        if (isSlashing && !Mathf.Approximately(transform.rotation.y, target.y))
        {
            float step = slashSpeed * Time.fixedDeltaTime;
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, target, step);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 180, 0), step);
        }        
        else if(isSlashing && Mathf.Approximately(transform.rotation.y, target.y))
        {
            isSlashing = false;
            weapon.SetActive(false);
            transform.rotation = Quaternion.Euler(0, -slashAngle / 2, 0);
        }
	}

    public void StartSlashing()
    {
        isSlashing = true;
        weapon.SetActive(true);
        tempTimeofSlash = Time.time;
        target = transform.rotation;
        target.y += slashAngle;
    }

    void SetWeaponAngle()
    {
        transform.rotation = Quaternion.Euler(0, -slashAngle / 2, 0);
        target = transform.rotation;
        target.y += slashAngle;
    }
}
