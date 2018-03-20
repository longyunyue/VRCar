using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour {
    MeshRenderer[] mats;

	// Use this for initialization
	void Start () {
        mats=GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer mat in mats)
            foreach(Material m in mat.materials)
            m.color = new Vector4(0f, 0f, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
