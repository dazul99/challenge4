using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float vinput;
    [SerializeField] private GameObject focalpoint;
    private Rigidbody rb;
    private Rigidbody enemyrb;
    private Vector3 distance;
    private bool power = false;
    [SerializeField] private float strength;
    private float powerinput;
    [SerializeField] private float boost;
    private bool cd = false;
    private SpawnManager spawnManager;
    [SerializeField] private GameObject ring;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (power)
        {
            powerinput = Input.GetAxis("Jump");
            if (powerinput >0 && !cd)
            {
                rb.AddForce(focalpoint.transform.forward * boost, ForceMode.Impulse);
                StartCoroutine("Cooldown");
            }
        }
    }

    private void Movement()
    {
        vinput = Input.GetAxis("Vertical");

        rb.AddForce(focalpoint.transform.forward*vinput*speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyrb = collision.gameObject.GetComponent<Rigidbody>();
            distance = collision.gameObject.transform.position - transform.position;
            distance = distance.normalized;
            enemyrb.AddForce(distance*strength, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            StartCoroutine("PowerTimer");
        }
        Destroy(other.gameObject);
    }

    private IEnumerator PowerTimer()
    {
        power = true;
        Instantiate(ring, transform.position, Quaternion.identity); 
        yield return new WaitForSeconds(5);
        power = false;
        spawnManager.gotpower = true;
    }

    private IEnumerator Cooldown()
    {
        cd = true;
        yield return new WaitForSeconds(1);
        cd = false;
    }

}
