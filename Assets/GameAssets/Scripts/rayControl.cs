using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class rayControl : MonoBehaviour {

    public GameObject car_intro5;
    public GameObject car_intro4;
    public GameObject car_intro3;
    public GameObject car_intro2;
    public GameObject car_intro1;
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
            if (hitInfo.collider.gameObject.name == "car5_intro")
            {
                if (XRSettings.enabled)
                {
                    car_intro5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro5.transform.position = new Vector3(10.5f, 9.6966f, 1036.4f);
                }
                else
                {
                    car_intro5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro5.transform.position = new Vector3(15f, 9.6966f, 1028.4f);
                }
            }
            else if (hitInfo.collider.gameObject.name == "car4_intro")
            {
                if (XRSettings.enabled)
                {
                    car_intro4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro4.transform.position = new Vector3(10.4f, 9.3f, 1009.6f);
                }
                else
                {
                    car_intro4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro4.transform.position = new Vector3(14f, 9.3f, 1011f);
                }
            }
            else if (hitInfo.collider.gameObject.name == "car3_intro")
            {
                if (XRSettings.enabled)
                {
                    car_intro3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro3.transform.position = new Vector3(-12.1f, 10.065f, 1011.5f);
                }
                else
                {
                    car_intro3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro3.transform.position = new Vector3(7.6f, 10.065f, 1015.5f);
                }
            }
            else if (hitInfo.collider.gameObject.name == "car2_intro")
            {
                if (XRSettings.enabled)
                {
                    car_intro2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro2.transform.position = new Vector3(37.1f, 9.945f, 1009.1f);
                }
                else
                {
                    car_intro2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro2.transform.position = new Vector3(29f, 9.945f, 1013.1f);
                }
            }
            else if (hitInfo.collider.gameObject.name == "car1_intro")
            {
                if (XRSettings.enabled)
                {
                    car_intro1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro1.transform.position = new Vector3(14.3f, 9.945f, 1000f);
                }
                else
                {
                    car_intro1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5");
                    car_intro1.transform.position = new Vector3(18f, 9.945f, 1007f);
                }
            }
            else if(hitInfo.collider.gameObject.name == "car1")
            {
                if (loadingbar.fillAmount == 1f)
                {
                    SceneManager.LoadScene("ShowCarRoom");
                }
                else
                {
                    loadingbar.fillAmount += 0.01f;
                }
            }
			else if(hitInfo.collider.gameObject.name == "porsche")
			{
				if (loadingbar.fillAmount == 1f)
				{
					SceneManager.LoadScene("Porsche_Room");
				}
				else
				{
					loadingbar.fillAmount += 0.01f;
				}
			}

        }
        else
        {
            carIntroReset();
            
        }

    }
    void carIntroReset()
    {
        car_intro5.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5_1");
        car_intro5.transform.position = new Vector3(1.953216f, 9.696667f, 1054.191f);
        car_intro4.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5_1");
        car_intro4.transform.position = new Vector3(-0.82312f, 9.3f, 999.1539f);
        car_intro3.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5_1");
        car_intro3.transform.position = new Vector3(-54.63435f, 10.065f, 1001.083f);
        car_intro2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5_1");
        car_intro2.transform.position = new Vector3(52.04533f, 9.945f, 999.4927f);
        car_intro1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("info5_1");
        car_intro1.transform.position = new Vector3(-0.47207f, 9.945f, 942.7162f);
        loadingbar.fillAmount = 0f;
    }
}
