using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Video_ctrl : MonoBehaviour {
    public GameObject video1;
    public GameObject video2;
    public GameObject button1;
    public GameObject button2;
    private bool StartPlaying;
    private int sliderCount = 0;
    public Image slider1;
    public Image slider2;
    public GameObject triangle1;
    public GameObject triangle2;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.name == "Video_SS_UI")
            {
                if (!StartPlaying && (sliderCount == 100))
                {
                    video1.SetActive(true);
                    button2.SetActive(false);
                    StartPlaying = true;
                    triangle1.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("rec");
                    sliderCount = 0;
                }
                else if (StartPlaying && (sliderCount == 100))
                {
                    video1.SetActive(false);
                    button2.SetActive(true);
                    StartPlaying = false;
                    triangle1.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tri");
                    sliderCount = 0;
                }
                else
                {
                    //donothing
                }
                sliderCount++;
            }
            else if (hitInfo.collider.gameObject.name == "Video_S_UI")
            {
                if (!StartPlaying && (sliderCount == 100))
                {
                    video2.SetActive(true);
                    button1.SetActive(false);
                    StartPlaying = true;
                    triangle2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("rec");
                    sliderCount = 0;
                }
                else if (StartPlaying && (sliderCount == 100))
                {
                    video2.SetActive(false);
                    button1.SetActive(true);
                    StartPlaying = false;
                    triangle2.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("tri");
                    sliderCount = 0;
                }
                else
                {
                    //donothing
                }
                sliderCount++;
            }
        }
        else
            sliderCount = 0;
        slider1.fillAmount = sliderCount / 100f;
        slider2.fillAmount = sliderCount / 100f;
	}
    public void StopVideo()
    {
        video1.SetActive(false);
        video2.SetActive(false);
    }
}
