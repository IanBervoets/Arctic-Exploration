using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;
    [SerializeField] GameObject deathPanel;
    [SerializeField] private GameObject timerExtensionPanel;
    private Vector3 currentCheckpoint;
    private bool icebergIsTriggered;
    private TimerScript timerScript;

    private void Start()
    {
        timerScript = GameObject.Find("Canvas").GetComponent<TimerScript>();
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
        if (col.CompareTag("Checkpoint"))
        {
            currentCheckpoint = col.transform.position;
            col.GetComponent<Collider2D>().enabled = false;
        }
        else if(col.CompareTag("IcebergStart"))
        {
            currentCheckpoint = col.transform.position;
            col.GetComponent<Collider2D>().enabled = false;
            timerScript.StartTimer();
            icebergIsTriggered = true;
        }
        else if(col.CompareTag("IcebergEnd"))
        {
            currentCheckpoint = col.transform.position;
            col.GetComponent<Collider2D>().enabled = false;
            timerScript.StopTimer();
            icebergIsTriggered = false;
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

        GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;

        if (!timerExtensionPanel.activeSelf)
        {
            deathPanel.SetActive(!deathPanel.activeSelf);
        }
        
        if (icebergIsTriggered)
        {
            if (timerExtensionPanel.activeSelf)
            {
                timerExtensionPanel.SetActive(false);
            }

            timerScript.StartTimer();
        }
    }
}
