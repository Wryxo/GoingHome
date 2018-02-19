using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class LastExit : MonoBehaviour {

	public string nextLevelName = "";
	public bool ForPig;

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
			if (ForPig && player.Enraged){
				Application.LoadLevel(nextLevelName);
			}
			if (!ForPig && !player.Enraged) {
				Application.LoadLevel(nextLevelName);
			}

		}
	}
}
