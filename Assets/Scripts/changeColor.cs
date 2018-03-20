using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeColor : MonoBehaviour {
    public GameObject car5_body;
    public Material color1;
    public Material color2;
    public Material color3;
    public Image loadingbar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.name == "color1")
            {
                if (loadingbar.fillAmount == 1f)
                    car5_body.GetComponent<MeshRenderer>().material = color1;
                else
                    loadingbar.fillAmount += 0.01f;
            }
            else if (hitInfo.collider.gameObject.name == "color2")
            {
                if(loadingbar.fillAmount == 1f)
                    car5_body.GetComponent<MeshRenderer>().material = color2;
                else
                    loadingbar.fillAmount += 0.01f;
            }
            else if (hitInfo.collider.gameObject.name == "color3")
            {
                if (loadingbar.fillAmount == 1f)
                    car5_body.GetComponent<MeshRenderer>().material = color3;
                else
                    loadingbar.fillAmount += 0.01f;
            }
        }
        else
        {
            loadingbar.fillAmount = 0f;
        }
    }
}
