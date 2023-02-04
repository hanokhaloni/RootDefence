using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject[] spawnObjects;

    public Transform[] spawnPoints;
    public int maxX = 10;//TODO x axis name
    public float timeTilNextSpawn = 1;
    public float speed = 10.0f;
    Vector3 direction = Vector3.up;

    int x = 0;
    float timer = 0;



    void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (timer >= timeTilNextSpawn)
        {
            x = Random.Range(0, maxX);
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            int spawnObjectIndex = Random.Range(0, spawnObjects.Length);

            var spawnPoint = spawnPoints[spawnPointIndex];
            var spawnObject = spawnObjects[spawnObjectIndex];

            Vector3 velocity = speed * direction;

            GameObject name = Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);
            name.GetComponent<Rigidbody>().velocity = velocity;
            name.GetComponent<Rigidbody>().useGravity = true;

            timer = 0;
        }
    }
}


