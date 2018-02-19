using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public bool Radio = false;
	public bool Human = true;
	
	private int oldTrack = -1;
	private MusicChild humanChild;
	private MusicChild pigChild;
	private MusicChild radioChild;

	// Use this for initialization
	void Start () {
		oldTrack = -1;
		humanChild = transform.Find ("HumanMusic").GetComponent<MusicChild> ();
		pigChild = transform.Find ("PigMusic").GetComponent<MusicChild> ();
		radioChild = transform.Find ("RadioMusic").GetComponent<MusicChild> ();
	}	
	// Update is called once per frame
	void Update () {
		PlayMusic ();
	}


	public void PlayMusic() {
		if (Radio) {
			if (oldTrack != 2) {
				if (oldTrack == 0) {
					humanChild.StartFadeOut();
				}
				if (oldTrack == 1) {
					pigChild.StartFadeOut();
				}
				oldTrack = 2;
				radioChild.StartFadeIn();
			}
		} else {
			if (oldTrack != 0 && Human) {
				if (oldTrack == 2) {
					radioChild.StartFadeOut();
				}
				if (oldTrack == 1) {
					pigChild.StartFadeOut();
				}
				oldTrack = 0;
				humanChild.StartFadeIn();
			}
			if (oldTrack != 1 && !Human) {
				if (oldTrack == 2) {
					radioChild.StartFadeOut();
				}
				if (oldTrack == 0) {
					humanChild.StartFadeOut();
				}
				oldTrack = 1;
				pigChild.StartFadeIn();
			}
		}
	}

}
