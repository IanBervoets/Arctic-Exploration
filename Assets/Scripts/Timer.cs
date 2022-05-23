using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private float timeLeft = 10f;
    private float timer;
    private int timesLost;
    
    
    void Start()
    {
        ResetTimer();
    }
    
    void Update()
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
            enabled = false;
            //TODO: add condition here for timer extension
        }
    }

    private void ResetTimer()
    {
        timer = timeLeft;
    }
}
