using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System;
using UnityEngine.SceneManagement;


public static class CallSpeechApi{
    public static bool isvideo = false;
    public static bool isvideo1 = false;
    public static bool isvideo2 = false;

    public static bool iscomplete = false;

    public static IEnumerator Call(string filePath,string fileName) {
		//Token
		string subscriptionKey ="bc5172cf6ce7474db7cfb33f3f2fb62f";
		UnityWebRequest www = UnityWebRequest.Post("https://api.cognitive.microsoft.com/sts/v1.0/issueToken","");
		www.SetRequestHeader ("Ocp-Apim-Subscription-Key", subscriptionKey);
		yield return www.Send();
		if(www.isNetworkError)
			Debug.Log (www.error);

		//Upload Audio

		WWWForm audioform = new WWWForm();
		string path = @filePath;
		FileStream fs=new FileStream(path,FileMode.Open,FileAccess.Read);
		byte[] bytes = new byte[fs.Length];
		fs.Read(bytes, 0, bytes.Length);
		fs.Flush();
		fs.Close();
		audioform.AddBinaryData(System.Guid.NewGuid().ToString(),bytes,fileName,"audio/wav");
		UnityWebRequest audiowww = UnityWebRequest.Post("https://speech.platform.bing.com/speech/recognition/conversation/cognitiveservices/v1?language=en-US", audioform);
		audiowww.SetRequestHeader ("Authorization", "Bearer "+ www.downloadHandler.text);
		audiowww.SetRequestHeader ("Content-Type", @"audio/wav; codec='audio/pcm'; samplerate=16000");        
		yield return audiowww.Send ();
		if (audiowww.isNetworkError)
			Debug.Log (audiowww.error);
		else
			Debug.Log (audiowww.downloadHandler.text);
	}

	public static IEnumerator Call2(byte[] data) {
		Debug.Log ("Call2");
		//Token
		//yield return new WaitForSeconds(10);
		string subscriptionKey ="bc5172cf6ce7474db7cfb33f3f2fb62f";
		UnityWebRequest www = UnityWebRequest.Post("https://api.cognitive.microsoft.com/sts/v1.0/issueToken","");
		www.SetRequestHeader ("Ocp-Apim-Subscription-Key", subscriptionKey);
		yield return www.Send();
		if(www.isNetworkError)
			Debug.Log (www.error);
		if(true){
			//Upload Audio
			WWWForm audioform = new WWWForm();
			//	string path = @filePath;
			//	FileStream fs=new FileStream(path,FileMode.Open,FileAccess.Read);
			//	byte[] bytes = new byte[fs.Length];
			//	fs.Read(bytes, 0, bytes.Length);
			//	fs.Flush();
			//	fs.Close();
			Debug.Log (data.Length);
			audioform.AddBinaryData(System.Guid.NewGuid().ToString(),data);
			UnityWebRequest audiowww = UnityWebRequest.Post("https://speech.platform.bing.com/speech/recognition/conversation/cognitiveservices/v1?language=zh-CN", audioform);
			audiowww.SetRequestHeader ("Authorization", "Bearer "+ www.downloadHandler.text);
			audiowww.SetRequestHeader ("Content-Type", @"audio/wav; codec='audio/pcm'; samplerate=16000");        
			yield return audiowww.Send ();


			Debug.Log ("Response");
            iscomplete = true;
			if (audiowww.isNetworkError)
				Debug.Log (audiowww.error);
			else
				Debug.Log (audiowww.downloadHandler.text);
			//Return Result Model
			ResultModel resultmodel = JsonUtility.FromJson<ResultModel> (audiowww.downloadHandler.text);

			if (resultmodel.DisplayText.Contains ("车里")||resultmodel.DisplayText.Contains ("驾驶")||resultmodel.DisplayText.Contains ("内饰")) {

                GameObject.Find("Camera").transform.position = new Vector3(9.5f, 1.85f, 41.2f);
                Camera.main.gameObject.AddComponent<IncarCameraControl>();
                iscomplete = true;
                foreach (Transform child in GameObject.Find("HomeButtonSide").transform)
                    child.gameObject.SetActive(false);
                foreach (Transform child in GameObject.Find("HomeButton").transform)
                    child.gameObject.SetActive(false);
                foreach (Transform child in GameObject.Find("HomeButtonBehind").transform)
                    child.gameObject.SetActive(false);
                foreach (Transform child in GameObject.Find("HomeButtonIncar").transform)
                    child.gameObject.SetActive(true);
         
            }  else {
				Debug.Log ("I can't understand you!");
				iscomplete = true;
				//called = false;
			}
            if (resultmodel.DisplayText.Contains("视频") || resultmodel.DisplayText.Contains("发动机") || resultmodel.DisplayText.Contains("引擎"))
            {
                if (HomeButtonController.FrontCar)
                {
                    GameObject.Find("VideoControl (2)").SetActiveRecursively(true);
                    CallSpeechApi.isvideo2 = true;
                    iscomplete = true;
                }
                if (HomeButtonController.SideCar)

                {
                    GameObject.Find("VideoControl").SetActiveRecursively(true);
                    CallSpeechApi.isvideo = true;
                    iscomplete = true;
                }

                if (HomeButtonController.BehindCar)
                {
                    GameObject.Find("VideoControl (1)").SetActiveRecursively(true);
                    CallSpeechApi.isvideo1 = true;
                    iscomplete = true;
                }
                //GameObject.Find("VideoPlayer").transform.LookAt(Camera.main.transform);
            }
            else
            {
                Debug.Log("I can't understand you!");
				iscomplete = true;
                //called = false;
            }
            //Audio_Capture.allowsend = false;
        }	

	}

	[Serializable]

	public class ResultModel{
		public string RecognitionStatus;
		public string DisplayText;
		public long Offset;
		public long Duration;
	}

}
