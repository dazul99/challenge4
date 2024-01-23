using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float speed=0.5f;

    private Vector3 goal = new Vector3 (0, 0, -10);
    private Rigidbody rb;
    private Vector3 direction;

    private SpawnManager spawnManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

    }

    private void Movement()
    {
        direction = goal - transform.position;
        direction = direction.normalized;
        rb.AddForce(direction * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(gameObject);
            spawnManager.enemiesinscene--;
        }
    }

}
