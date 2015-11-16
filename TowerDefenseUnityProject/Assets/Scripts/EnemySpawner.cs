using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ObjectToSpawn;
    private float timer = 0;
    [SerializeField]
    private float SpawnInterval = 1;

    void Update()
    {
        SpawnEnemies();
        timer += Time.deltaTime;
    }

    public void SpawnEnemies()
    {
        if (timer >= SpawnInterval)
        {
            timer = 0;
            Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
        }
    }
}