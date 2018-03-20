using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackFrontScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit rayHit;
        Ray ray = new Ray(Camera.main.gameObject.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.collider.gameObject.name == "BackFront")
            {
                Debug.Log("HERE");
                SceneManager.LoadScene("MasterRoom");
            }
        }
    }
}
