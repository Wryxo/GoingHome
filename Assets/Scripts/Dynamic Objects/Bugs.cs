using UnityEngine;
using System.Collections;

public class Bugs : MonoBehaviour 
{

    public float DamagePerSec;
    public float Speed;
    public float Range;
    public bool Swap = false;

    private PlayerStats player;
    private Vector3 start;
    private float speedY = 0.5f;
    private const float rangeY = 0.2f;

    // Use this for initialization
	void Start ()
    {
        if (Swap) {
			Speed *= -1;
			Flip ();
		}
        player = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        start = transform.position;
    }

	// Update is called once per frame
	void FixedUpdate ()
	{

        // Move
        transform.position += new Vector3(Speed, speedY, 0) * Time.deltaTime;

        // Flip sides
	    if (transform.position.x >= start.x + Range || transform.position.x <= start.x - Range)
        {
			Speed *= -1;
			Flip ();
        }

        // little floating Up & Down
        if (transform.position.y >= start.y + rangeY || transform.position.y <= start.y - rangeY)
        {
            speedY *= -1;
        }
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            player.DealDamage(DamagePerSec * Time.deltaTime);
        }
    }
	private void Flip()
	{
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
