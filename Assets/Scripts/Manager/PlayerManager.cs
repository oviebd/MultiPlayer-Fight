using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerManager
{

    [HideInInspector] public int playerNum;
    public Transform m_SpawnPoint;
    [HideInInspector] public GameObject m_Instance;


    private PlayerMovement _movement;
    private PlayerWeaponManager _playerWeaponManager;


    private List<Color> PlayerColors = new List<Color>();
    
  
    
    public void Setup()
    {
        _movement = m_Instance.GetComponent<PlayerMovement>();
        _playerWeaponManager = m_Instance.GetComponent<PlayerWeaponManager>();

        _movement.playerNum = playerNum;
        _playerWeaponManager.playerNum = playerNum;
        m_Instance.name = "Palyer  " + playerNum;

        SetPlayerMatColor();

    }

    void SetPlayerMatColor()
    {
        SetPlayersColorList();

        Renderer renderer = m_Instance.GetComponentInChildren<Renderer>();
        if (renderer != null)
        {
            Material[] matArray = new Material[10];
            // Debug.Log("Renderer Not Null");
            matArray = renderer.materials;
           // Debug.Log("Player Mat num : " + matArray.Length);
            matArray[0].color =PlayerColors[playerNum-1];
        }
    }

    void SetPlayersColorList()
    {
        PlayerColors.Clear();

        PlayerColors.Add(Color.red);
        PlayerColors.Add(Color.cyan);

        PlayerColors.Add(Color.green);
        PlayerColors.Add(Color.blue);
    }
}
