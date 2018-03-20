using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRLoaderScript : MonoBehaviour {
	public Camera camera;
	void Start() {
		if (BoolVrandphone.IsVR) {
			if (BoolVrandphone.Oncevr) {
				StartCoroutine (LoadDevice ("Cardboard"));
				BoolVrandphone.Oncevr = false;
			}
		}
		if (BoolVrandphone.IsPhone) {
			UnityEngine.XR.XRSettings.LoadDeviceByName ("Cardboard");
			UnityEngine.XR.XRSettings.enabled = true;
			UnityEngine.XR.XRSettings.enabled = false;
			//camera.gameObject.AddComponent <GyroController>();
		}
			
	}

	IEnumerator LoadDevice(string newDevice) {
		UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
		yield return null;
		UnityEngine.XR.XRSettings.enabled = true;
	}

	void Update(){
		if (BoolVrandphone.IsPhone) {
			Camera.main.transform.rotation = UnityEngine.XR.InputTracking.GetLocalRotation (UnityEngine.XR.XRNode.CenterEye);
			Camera.main.ResetAspect ();
		}
	}
}