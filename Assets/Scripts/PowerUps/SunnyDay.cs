using UnityEngine;
using System.Collections;

public class SunnyDay : MonoBehaviour {

	public float HealPerSec;
	private PlayerStats player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("GameController").GetComponent<PlayerStats> ();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		player.HealDamage(HealPerSec * Time.deltaTime);
	}
}
