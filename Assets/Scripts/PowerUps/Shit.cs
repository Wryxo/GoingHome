using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Shit : MonoBehaviour
{

    public float Damage = 20f;

    public GameObject Spawner;

    private PlayerStats player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col);
        if (col.tag != "Player") return;
        player.DealDamage(Damage);
        if (Spawner != null)
        {
            var test1 = Spawner.GetComponent<Pigeon>();
            if (test1 != null) test1.SpawnedObjects--;
        }
        Destroy(gameObject);
    }
}
