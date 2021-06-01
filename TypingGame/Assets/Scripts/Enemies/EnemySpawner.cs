using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float minTime, maxTime;
    //public Vector2 pos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoroutine());
    }

    IEnumerator spawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));

            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
