using UnityEngine;
using System.Collections;

[RequireComponent(typeof (AudioSource))]
public class MusicChild : MonoBehaviour {

	public float FadeRate;

	private AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartFadeOut() {
		//Debug.Log (audioSource + " FadeOut " + gameObject.name);
		StartCoroutine ("FadeOut");
	}

	public void StartFadeIn() {
		//Debug.Log (audioSource + " FadeIn " + gameObject.name);
		StartCoroutine ("FadeIn");
	}

	IEnumerator FadeOut()
	{
		while( audioSource.volume > 0.1f )
		{
			audioSource.volume = Mathf.Lerp( audioSource.volume, 0.0f, FadeRate * Time.deltaTime );
			Debug.Log (audioSource.volume);
			yield return null;
		}
		
		// Close enough, turn it off!
		audioSource.volume = 0.0f;
	}
	
	IEnumerator FadeIn()
	{
		while( audioSource.volume < 0.9f )
		{
			audioSource.volume = Mathf.Lerp( audioSource.volume, 1.0f, FadeRate * Time.deltaTime);
			yield return null;
		}
		
		// Close enough, turn it on!
		audioSource.volume = 1.0f;
	}
}
