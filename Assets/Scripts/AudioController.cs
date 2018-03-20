using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour {
	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		audioSource = gameObject.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StopPlay()
	{
		if(audioSource!=null&&audioSource.isPlaying){
			audioSource.Pause ();
		}
	}
}
