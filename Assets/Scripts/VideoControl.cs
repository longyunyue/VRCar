using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoControl : MonoBehaviour {
    private VideoPlayer videoPlayer;
    float time = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(wait());
    }
    void Offvideo()
    {
        //Debug.Log(CallSpeechApi.isvideo);
        if (CallSpeechApi.isvideo)
        {
            if (!GameObject.Find("Plane").transform.GetComponent<VideoPlayer>().isPlaying)
            {
                GameObject.Find("VideoControl").SetActiveRecursively(false);
                CallSpeechApi.isvideo = false;
            }
        }
        if (CallSpeechApi.isvideo1)
        {
            if (!GameObject.Find("Plane1").transform.GetComponent<VideoPlayer>().isPlaying)
            {
                GameObject.Find("VideoControl (1)").SetActiveRecursively(false);
                CallSpeechApi.isvideo1 = false;
            }
        }
        if (CallSpeechApi.isvideo2)
        {
            if (!GameObject.Find("Plane2").transform.GetComponent<VideoPlayer>().isPlaying)
            {
                GameObject.Find("VideoControl (2)").SetActiveRecursively(false);
                CallSpeechApi.isvideo2 = false;
            }
        }
    }

    private IEnumerator wait()
    {
        if (CallSpeechApi.isvideo || CallSpeechApi.isvideo1 || CallSpeechApi.isvideo2)
        {
            yield return new WaitForSeconds(5);
            Offvideo();
        }
        
    }
}
