using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class IceCreamVan : MonoBehaviour
{
    public float HealPerSec;
    private PlayerStats player;
    CircleCollider2D collider;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            float d = Vector3.Distance(col.transform.position, transform.position);
            d /= collider.radius;
            float strength = 1f / (1f + Mathf.Pow(2f * d, 4));
            player.HealDamage(HealPerSec * Time.deltaTime * strength);
        }
    }
}
