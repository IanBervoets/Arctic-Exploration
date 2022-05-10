using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraDistance;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private float cameraHeight;
    [SerializeField] public float yCameraMin;
    private float lookAhead;
    private float yCamera;
    

    private void Update()
    {
        //Sets minimum cameraheight by using Math.Clamp
        yCamera = player.position.y + cameraHeight;
        yCamera = Math.Clamp(yCamera, yCameraMin, Mathf.Infinity);
        
        //Makes camera follow player
        transform.position = new Vector3(player.position.x + lookAhead, yCamera, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (cameraDistance * player.localScale.x), Time.deltaTime * cameraSpeed);

        //TODO: Remove this in cleanup
        //Can be used to change min cameraheight for debug
        if (Input.GetKey(KeyCode.C))
        {
            yCameraMin = 1;
        }
    }
}
