using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour
{

    public float DamagePerSec;
    private PlayerStats player;
    CircleCollider2D collider;
    private Music hudba;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hudba == null)
        {
            hudba = GameObject.FindGameObjectWithTag("Music").GetComponent<Music>();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            float d = Vector3.Distance(col.transform.position, transform.position);
            d /= collider.radius;
            float strength = 1f / (1f + Mathf.Pow(2f * d, 4));
            player.DealDamage(DamagePerSec * Time.deltaTime * strength);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (hudba)
                hudba.Radio = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (hudba)
                hudba.Radio = false;
        }
    }
}
