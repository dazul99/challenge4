using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    private float x = 19;
    private float minz = 10;
    private float maxz = 27;
    private float y = 0;

    public int enemiesinscene = 0;
    private int level = 0;

    [SerializeField] private GameObject power;

    private PlayerController playerController;

    private Vector3 position = Vector3.zero;

    public bool gotpower = false;

    void Start()
    {
        getrandompositionpower();
        Instantiate(power, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesinscene < 1)
        {
            level++;
            spawnenemies();
        }

        if ( gotpower)
        {
            gotpower = false;
            StartCoroutine("Spawnpowerup");
        }
    }

    private void spawnenemies()
    {
        for (int i = 0; i < level; i++)
        {
            getrandomposition();
            Instantiate(enemy, position, Quaternion.identity);
        }
        enemiesinscene = level;

    }

    private void getrandomposition()
    {
        position = new Vector3 (Random.Range(-x,x), y,Random.Range(minz,maxz));
    }
    private void getrandompositionpower()
    {
        position = new Vector3(Random.Range(-x, x), y, Random.Range(-7, minz));
    } 
    private IEnumerator Spawnpowerup()
    {
        yield return new WaitForSeconds(Random.Range(1,8));
        getrandompositionpower();
        Instantiate(power, position, Quaternion.identity);
    }

}
