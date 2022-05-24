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
    private bool icebergIsTriggered;
    private GameObject canvas;
    
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
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
            canvas.GetComponent<TimerScript>().StartTimer();
            icebergIsTriggered = true;
        }
        else if(col.CompareTag("IcebergEnd"))
        {
            currentCheckpoint = col.transform.position;
            col.GetComponent<Collider2D>().enabled = false;
            canvas.GetComponent<TimerScript>().StopTimer();
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

        deathPanel.SetActive(!deathPanel.activeSelf);

        if (icebergIsTriggered)
        {
            canvas.GetComponent<TimerScript>().StartTimer();
        }
    }
}
