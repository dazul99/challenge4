using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float hinput;
    [SerializeField] private Transform player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hinput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up, hinput * speed * Time.deltaTime);
        transform.position = player.position;
    }
}
