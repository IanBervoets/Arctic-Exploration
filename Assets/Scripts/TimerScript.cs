using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private GameObject timerGameObject;
    [SerializeField] private GameObject timerExtensionPanel;
    [SerializeField] public float timeLeft = 60f;
    private PlayerDeath PlayerDeath;
    private float timer;
    private int timesLost;
    private bool timerIsOn;
    public bool timeExtended;

    private void Start()
    {
        PlayerDeath = GameObject.Find("Player").GetComponent<PlayerDeath>();
    }

    void Update()
    {
        //TODO: remove this in cleanup
        if (Input.GetKey(KeyCode.T))
        {
            StartTimer();
        }
        
        if (timerIsOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                text.text = Convert.ToInt64(timer).ToString();
            }
            else
            {
                if (timesLost != 5)
                {
                    PlayerDeath.Die();
                    timesLost++;
                    timerIsOn = false;
                }
                else
                {
                    timerExtensionPanel.SetActive(true);
                    PlayerDeath.Die();
                    timesLost++;
                    timerIsOn = false;
                }
            }
        }
    }
    
    public void StartTimer()
    {
        if (timeExtended)
        {
            timeLeft = 120f;
        }
        timer = timeLeft;
        timerIsOn = true;
        timerGameObject.SetActive(true);
    }

    public void StopTimer()
    {
        timerIsOn = false;
        timerGameObject.SetActive(false);
    }

    public void ExtendTimer()
    {
        timeExtended = true;
    }
}
