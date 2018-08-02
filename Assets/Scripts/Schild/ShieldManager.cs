using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour {

    ShieldFactory shieldFactory;
    public Utility.ShieldType shieldType;
    public GameObject shield_prefab;
    GameObject current_shield;

    ISchild iSchild;
  
    public int playerNum;

    private string _shieldInput= "Shield";

    void Start ()
    {
       
        Init();
 	}
	
	void Init()
    {
        current_shield =  Instantiate(shield_prefab, transform, false);
     
        shieldFactory = new ShieldFactory();
        iSchild = shieldFactory.GetSchild(shieldType, current_shield);
        iSchild.ShieldSetUp();

        _shieldInput = _shieldInput+playerNum;
     //   Debug.Log("Player Num :" + playerNum);
    }


    public void ActivateSchild()
    {
        iSchild.ActivateSchild();
    }

    public void DeactiveShield()
    {
     
    }
   

    void Update () {

        if (Input.GetButtonDown(_shieldInput))
        {
            ActivateSchild();
        }
        

        if (Input.GetKeyDown(KeyCode.B))
        {
         //   iSchild.DeactivateSchild();
        }
    }


    

}
