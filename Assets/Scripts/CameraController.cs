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
    private float lookAhead;

    private void Update()
    {
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + cameraHeight, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (cameraDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
    }
}
