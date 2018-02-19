using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class Candy : MonoBehaviour
{

    public float Heal = 20f;

    private PlayerStats player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.HealDamage(Heal);
            Destroy(gameObject);
        }
    }
}
