using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlaneCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponent<PlayerDeath>().Die();
        }
    }
}
