using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static PlayerRespawn instance;
    [SerializeField] private Behaviour[] components;

    private void Awake()
    {
        instance = this;
    }

    public void Respawn()
    {
        //TODO: Add respawn mechanics (maybe add an animation?)
        
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        
        LevelManager.instance.ToggleDeathPanel();
    }
}
