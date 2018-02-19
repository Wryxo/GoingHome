using UnityEngine;
using System.Collections;

public class RainyDay : MonoBehaviour {

	public float DamagePerSec;

	private PlayerStats player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PlayerStats> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player.DealDamage(DamagePerSec * Time.deltaTime);
	}
}
