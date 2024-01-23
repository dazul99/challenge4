using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRing : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerController.transform.position;
    }
}
