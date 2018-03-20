using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_ctrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(-5f,0,-0.55f), transform.up, Time.deltaTime * 20f);
    }
}
