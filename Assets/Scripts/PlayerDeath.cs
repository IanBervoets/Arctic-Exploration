using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;
    [SerializeField] GameObject deathPanel;
    private Rigidbody2D body;

    public void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Die()
    {
        //TODO: Add death animation
        
        body.velocity = Vector2.zero;

        foreach (Behaviour component in components)
        {
            component.enabled = false;
        }

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
        
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
