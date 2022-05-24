using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject timerExtensionPanel;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private GameObject timeText;
    private Rigidbody2D body;
    private Vector3 currentCheckpoint;
    private bool icebergIsTriggered;
    private TimerScript timerScript;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        else if(col.CompareTag("GameEnd"))
        {
            foreach (Behaviour component in components)
            {
                component.enabled = false;
            }
            
            body.velocity = Vector2.zero;
            
            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = true;

            gameEndPanel.SetActive(true);
            if (!timerScript.timeExtended)
            {
                timeText.SetActive(true);
            }
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

    public void Replay()
    {
        if (!timerScript.timeExtended)
        {
            //TODO: Set player sprite
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
