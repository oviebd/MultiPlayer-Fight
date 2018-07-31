using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchildManager : MonoBehaviour {

    SchildFactory schildFactory;
    public Utility.SchildTypes schildType;
    public GameObject schild_prefab;
    GameObject current_schild;
  
    ISchild iSchild;
  
    public int playerNum;

    void Start ()
    {
        Init();
 	}
	
	void Init()
    {
        current_schild =  Instantiate(schild_prefab, transform, false);
     
        schildFactory = new SchildFactory();
        iSchild = schildFactory.GetSchild(schildType, current_schild);
        iSchild.ShieldSetUp();

        Debug.Log("Player Num :" + playerNum);
    }


    public void ActivateSchild()
    {
        iSchild.ActivateSchild();
    }


    void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            ActivateSchild();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            iSchild.DeactivateSchild();
        }
    }


    

}
