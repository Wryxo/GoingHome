using UnityEngine;
using System.Collections;

public class Pigeon : MonoBehaviour
{
    public GameObject fallingShitPrefab;
    public float shittingInterval = 2f;
    public float shittingIntervalSpread = 1f;
    public float yOffset = 1.0f;
    public int MaxNumberOfShits;

    public int SpawnedObjects = 0;

    float lastShittingTime = 0f;
    float nextDelay = 0f;

    float CalculateDelay()
    {
        return shittingInterval + Random.Range(-1f, 1f) * shittingIntervalSpread;
    }

    void Start()
    {
        nextDelay = CalculateDelay();
        lastShittingTime = Time.time;
        GetComponent<SpriteRenderer>().color = Color.grey;
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnedObjects < MaxNumberOfShits)
        {
            var sinceLastShit = Time.time - lastShittingTime;
            if (!(sinceLastShit > nextDelay)) return;
            lastShittingTime = Time.time;

            var position = new Vector3(transform.position.x, transform.position.y - yOffset, transform.position.z);

            SpawnedObjects++;
            var fallingShit = Instantiate(fallingShitPrefab, position, Quaternion.identity) as GameObject;
            fallingShit.GetComponent<FallingShit>().Spawner = gameObject;
            nextDelay = CalculateDelay();
            //Debug.Log(nextDelay);
            //Rigidbody2D rb = fallingShit.GetComponent<Rigidbody2D>();
            //rb.velocity = GetComponent<Rigidbody2D>().velocity;
            //TODO spawn falling shit here
        }
        else
        {
            lastShittingTime = Time.time;
        }
    }
}
