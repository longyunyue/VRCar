using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
public class NonVR : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (BoolVrandphone.IsPhone) {
			UnityEngine.XR.XRSettings.LoadDeviceByName ("Cardboard");
			UnityEngine.XR.XRSettings.enabled = true;
			UnityEngine.XR.XRSettings.enabled = false;
			//camera.gameObject.AddComponent <GyroController>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (BoolVrandphone.IsPhone) {
			Camera.main.transform.rotation = UnityEngine.XR.InputTracking.GetLocalRotation (UnityEngine.XR.XRNode.CenterEye);
			Camera.main.ResetAspect ();
		}
	}
}
