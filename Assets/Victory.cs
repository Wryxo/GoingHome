using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Victory : MonoBehaviour {

	void Awake() {
		Destroy(GameObject.FindWithTag ("User Interface"));
		Destroy(GameObject.Find ("PlayerStats"));
	}

	void Update(){
		if (Input.anyKeyDown) {
			FinishIt();
		}
	}
	// Use this for initialization
	public void FinishIt() {
		foreach (var go in GameObject.FindObjectsOfType<GameObject>())
			Destroy(go);
		Application.LoadLevel("Menu");
	}
}
