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
    [SerializeField] private float timeLeft = 120f;
    private float timer;
    private int timesLost;
    public bool timerIsOn;
    
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
                GameObject.Find("Player").GetComponent<PlayerDeath>().Die();
                timesLost++;
                timerIsOn = false;
                
                //TODO: add condition here for timer extension
            }
        }
    }
    
    public void StartTimer()
    {
        timer = timeLeft;
        timerIsOn = true;
        timerGameObject.SetActive(true);
    }

    public void StopTimer()
    {
        timerIsOn = false;
        timerGameObject.SetActive(false);
    }
}
