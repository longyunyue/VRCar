using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class ray_point_size_ajust : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(XRSettings.enabled){
            GameObject.Find("Ray_Point").GetComponent<Image>().rectTransform.localScale = new Vector3(0.10f, 0.10f, 1f);
        }
        else
            GameObject.Find("Ray_Point").GetComponent<Image>().rectTransform.localScale = new Vector3(0.25f, 0.25f, 1f);

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
