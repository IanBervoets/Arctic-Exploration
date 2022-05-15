using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;
    [SerializeField] GameObject deathPanel;
    private Vector3 currentCheckpoint;
    
    private void Start()
    {
        currentCheckpoint = GameObject.Find("Player").transform.position;
    }
    
    public void Update()
    {
        if (Input.GetKey(KeyCode.Space) && deathPanel.activeSelf)
        {
           Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Checkpoint")
        {
            currentCheckpoint = col.transform.position;
            col.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void Respawn()
    {
        //TODO: maybe add an animation?

        transform.position = currentCheckpoint;
        
        foreach (Behaviour component in components)
        {
            component.enabled = true;
        }
        
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
