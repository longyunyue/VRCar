using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGyro : MonoBehaviour {
	public Camera camera;
	// Use this for initialization
	void Start () {
		if (BoolVrandphone.IsPhone)
			camera.gameObject.AddComponent <NonVR>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
