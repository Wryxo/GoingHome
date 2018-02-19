using UnityEngine;
using System.Collections;

public class BreakablePlatform : MonoBehaviour {
    private PlayerStats player;
	
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
		}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player") return;
        if (player.SelfControl < 80f && player.Health < 0f)
        {
            Destroy(gameObject);
        }
    }
}
