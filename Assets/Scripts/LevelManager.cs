using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    [SerializeField] GameObject deathPanel;

    private void Awake()
    {
        instance = this;
    }
    
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && deathPanel.activeSelf)
        {
            PlayerRespawn.instance.Respawn();
        }
    }
    
    public void ToggleDeathPanel()
    {
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
