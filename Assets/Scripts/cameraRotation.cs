using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        // Camera.main.transform.eulerAngles= new Vector3(0f, 90f, 0f);
        Camera.main.transform.Rotate(new Vector3(0f, 70f, 0f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
