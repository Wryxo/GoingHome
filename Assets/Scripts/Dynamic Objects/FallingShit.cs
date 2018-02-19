using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class FallingShit : MonoBehaviour
{
    public float Damage = 20f;
    public GameObject ShitPrefab;

    public GameObject Spawner;

    //Rigidbody2D rb;
    private PlayerStats player;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.16f, 0.16f);
    }

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, 2.0f, LayerMask.GetMask("Player"));
        if (hit)
        {
            //Debug.Log(hit.collider.name);
            player.DealDamage(Damage);
            if (Spawner != null)
            {
                var test1 = Spawner.GetComponent<Pigeon>();
                if (test1 != null) test1.SpawnedObjects--;
            }
            Destroy(gameObject);
        }
    }

    /*
    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Player" || col.gameObject.name == "CharacterHero")
        {
            player.DealDamage(Damage);
            if (Spawner != null)
            {
                var test1 = Spawner.GetComponent<Pigeon>();
                if (test1 != null) test1.SpawnedObjects--;
            }
            Destroy(gameObject);
        }
    }
    //*/

    void OnCollisionEnter2D(Collision2D col)
    {
        //if (col.gameObject.isStatic)
        //Debug.Log(col.gameObject.tag);
        /*
        if (col.gameObject.tag == "Player" || col.gameObject.name == "CharacterHero")
        {
            player.DealDamage(Damage);
            if (Spawner != null)
            {
                var test1 = Spawner.GetComponent<Pigeon>();
                if (test1 != null) test1.SpawnedObjects--;
            }
            Destroy(gameObject);
        }
        else 
        //*/
        if (col.gameObject.tag != "Falling Shit" && col.gameObject.tag != "Shit")
        {
            if (ShitPrefab == null)
            {
                if (Spawner != null)
                {
                    var test1 = Spawner.GetComponent<Pigeon>();
                    if (test1 != null) test1.SpawnedObjects--;
                }
            }
            else
            {
                var newShit = Instantiate(ShitPrefab);
                newShit.GetComponent<Shit>().Spawner = Spawner;
                //newShit.transform.position = new Vector3(transform.position.x, transform.position.y - 0.3f, newShit.transform.position.z);
                newShit.transform.position = new Vector3(col.contacts[0].point.x, col.contacts[0].point.y, newShit.transform.position.z);
                if (Spawner != null)
                {
                    var test2 = Spawner.GetComponent<Spawner>();
                    if (test2 != null)
                    {
                        test2.SpawnedObject = newShit;
                    }
                }
                //newShit.transform.parent = transform.parent;
            }
            Destroy(gameObject);
        }

        //Vector2 pos = col.contacts[0].point;
        //newShit.transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
