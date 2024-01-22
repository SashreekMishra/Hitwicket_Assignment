using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Rigidbody playerRb;
    public Vector3 offset;
    public float speed;
    void Start()
    {
        playerRb = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 playerForward = player.transform.forward.normalized;
        transform.position = Vector3.Lerp(transform.position,player.position + 
        player.transform.TransformVector(offset) + playerForward * (-5f),speed*Time.deltaTime);
        transform.LookAt(player);
    }
}
