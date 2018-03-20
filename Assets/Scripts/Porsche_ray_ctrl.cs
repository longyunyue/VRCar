using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Porsche_ray_ctrl : MonoBehaviour {
	public Image loadingbar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

		RaycastHit hitInfo;
		if (Physics.Raycast (ray, out hitInfo)) {
			if (hitInfo.collider.gameObject.name == "back") {
				if (loadingbar.fillAmount == 1f)
				{
					SceneManager.LoadScene("MasterRoom");
				}
				else
				{
					loadingbar.fillAmount += 0.01f;
				}
				
			}
		}
		else
			loadingbar.fillAmount = 0f;
		
	}
}
