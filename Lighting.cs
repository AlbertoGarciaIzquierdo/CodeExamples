using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighting : MonoBehaviour {
	float randomNumber;
	byte moveFactor;
	private new AudioSource audio;
	public AudioClip ThunderClip;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
		StartCoroutine (RandomGen ());
	}
	
	// Update is called once per frame
	void Update () {
		if (randomNumber < 5 && !audio.isPlaying) {
			audio.PlayOneShot (ThunderClip, 0.5f);
			GetComponent<Animation> ().Play ("LightingAnim");
		}
	}

	IEnumerator RandomGen(){
		while (true) {
			randomNumber = Random.Range (0, 100);
			yield return new WaitForSeconds (5);
		}
	}

}
