using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio_Capture : MonoBehaviour {
    /*string filename = "record1";
    string path = "";
    bool write=true;
    AudioClip audclip;
    public GameObject audioSource;*/

    // Use this for initialization
    void Start () {
        //AudioSource aud = GetComponent<AudioSource>();
        //aud.clip = Microphone.Start("Microphone(Realtek High Definition Audio)", false, 10, 44100);
        //Invoke("end", 10);
		StartCoroutine(speech_analysis());

        
       

    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Microphone.IsRecording("Microphone(Realtek High Definition Audio)"));
        /*if (!Microphone.IsRecording("Microphone(Realtek High Definition Audio)")&&write)
        {
            AudioSource aud2 = GetComponent<AudioSource>();
            SavWav.Save(filename, aud2.clip);
            write = false;
        }*/
            

    }
    public void end()
    {
        Microphone.End("Microphone(Realtek High Definition Audio)");
    }

	public IEnumerator speech_analysis()
    {  
		yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
		if (Application.HasUserAuthorization (UserAuthorization.Microphone)) {
			AudioSource aud = GameObject.Find ("audioSource").GetComponent<AudioSource> ();
			aud.clip = Microphone.Start ("built-in Microphone", false, 5, 16000);
			yield return new WaitForSeconds (5);
			while (!(Microphone.GetPosition ("") > 0)) {
			}
			;
			Microphone.End ("built-in Microphone");
			var samples = new float[aud.clip.samples];
			aud.clip.GetData (samples, 0);
			Int16[] intData = new Int16[samples.Length];
			//converting in 2 float[] steps to Int16[], //then Int16[] to Byte[]

			Byte[] bytesData = new Byte[samples.Length * 2];
			//bytesData array is twice the size of
			//dataSource array because a float converted in Int16 is 2 bytes.

			int rescaleFactor = 32767; //to convert float to Int16

			for (int i = 0; i < samples.Length; i++) {
				intData [i] = (short)(samples [i] * rescaleFactor);
				Byte[] byteArr = new Byte[2];
				byteArr = BitConverter.GetBytes (intData [i]);
				byteArr.CopyTo (bytesData, i * 2);
			}
			Debug.Log ("we will call api");
			Debug.Log (bytesData.Length);
			StartCoroutine (CallSpeechApi.Call2 (bytesData));
		} else {
			print ("No MicroPhone permission");
		}
        
        //SavWav.Save("record", aud.clip);
    }


}
