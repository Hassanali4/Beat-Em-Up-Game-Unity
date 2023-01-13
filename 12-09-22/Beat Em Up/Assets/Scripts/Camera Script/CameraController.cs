using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = player.position + offset;
        Vector3 desiredPosition = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed);
        //transform.LookAt(player);
    }
}
