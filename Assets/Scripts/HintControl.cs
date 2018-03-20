using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HintControl : MonoBehaviour {
    public float Hint1 = 0;
    public float speed = 50;
    private Slider slider;
    private Text text;
    private Image background;
    // Use this for initialization
    void Start () {
        text = GameObject.Find("Text").transform.GetComponent<Text>();
        background = GameObject.Find("Background").transform.GetComponent<Image>();
        background.enabled = false;
        text.enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit rayHit;
        Ray ray = new Ray(Camera.main.gameObject.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out rayHit))
        {
            if (rayHit.transform.gameObject.name == "Hinbox1")
            {
                Hint1 += speed * Time.deltaTime;
                GameObject hint1 = GameObject.Find("Slider");
                if (hint1 != null)
                {
                    slider = hint1.GetComponent<Slider>();
                    slider.value = Hint1 / 10;
                    if (slider.value >= 1)
                    {
                        text.enabled = true;
                        background.enabled = true;
                    }
                }
            }
        }
        else
        {
            Hint1 = 0;
            GameObject hint1 = GameObject.Find("Slider");
            if (hint1 != null)
            {
                slider = hint1.GetComponent<Slider>();
                slider.value = Hint1 / 10;
                text.enabled = false;
                background.enabled = false;
            }
        }
    }
}
