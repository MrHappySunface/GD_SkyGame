using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSpawner : MonoBehaviour
{
    public GameObject spawner;
    public float delay = 20f;
    public bool active = true;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(EnemyGenerator());
    }

    IEnumerator EnemyGenerator()
    {
        yield return new WaitForSeconds(delay);
        if (active)
        {
            var newTransform = transform;

            Instantiate(spawner); 
        }

        StartCoroutine(EnemyGenerator());
    }

}
