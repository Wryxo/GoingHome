using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    public GameObject[] EntitiesToSpawn;
    public float SpawningChance;
    public float SpawnTime;

    public GameObject SpawnedObject;
    private float spawnTimer;

    // Use this for initialization
    void Start()
    {
        SpawningChance = Mathf.Clamp(SpawningChance, 0.0f, 1.0f);
        if (Random.value < SpawningChance)
        {
            Spawn();
        }
        GetComponent<SpriteRenderer>().color = Color.clear;
    }

    // Update is called once per frame
    private void Update()
    {
        if (SpawnedObject != null) return;

        spawnTimer += Time.deltaTime;
        if (spawnTimer > SpawnTime)
        {
            Spawn();
        }
    }

    void Spawn()
    {
        var choice = (int)(Random.value * EntitiesToSpawn.Length);
        SpawnedObject = Instantiate(EntitiesToSpawn[choice], transform.position, Quaternion.identity) as GameObject;
        var test = SpawnedObject.GetComponent<FallingShit>();
        if (test != null) test.Spawner = gameObject;

        if (SpawnTime <= 0)
        {
            DestroyObject(gameObject);
            return;
        }
        spawnTimer = 0;
        //spawnedObject.transform.parent = transform;
    }
}
