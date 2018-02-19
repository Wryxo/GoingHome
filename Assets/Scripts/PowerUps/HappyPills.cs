using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class HappyPills : MonoBehaviour
{

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
        if (col.tag == "Player")
        {
            if (player.Health < 0){
				player.TransformPlayer(false);
            	player.Health = 0;
			}
            Destroy(gameObject);
        }
    }
}
