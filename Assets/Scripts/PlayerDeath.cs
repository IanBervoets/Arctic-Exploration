using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;

    public void Die()
    {
        //TODO: Add death animation
        
        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }
        
        LevelManager.instance.ToggleDeathPanel();
    }
}
