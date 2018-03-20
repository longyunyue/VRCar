using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeinRoom : MonoBehaviour {
    public Image fadeinbg;
    public Image welcomeTo;
    public Image audiVirtualRoom;
    public GameObject raycast_canvas;
    public AudioSource welcomeAudio;
    float a = 1f;
    static bool Fadein=true;

	// Use this for initialization
	void Start () {
        fadeinbg.fillAmount = 1f;
        welcomeTo.fillAmount = 0f;
        audiVirtualRoom.fillAmount = 0f;
        if (Fadein)
        {
            StartCoroutine(fadein());
            Fadein = false;
            
        }
        else
        {
            fadeinbg.fillAmount = 0f;
            raycast_canvas.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator fadein()
    {
        welcomeAudio.Play();
        yield return welcome(); 
        yield return audiVroom(); 
        yield return bgfade();

    }
    
    IEnumerator welcome()
    {
        while (welcomeTo.fillAmount < 1f)
        {
            welcomeTo.fillAmount += 0.02f;
            yield return true;
        }

    }
    IEnumerator audiVroom()
    {
        while (audiVirtualRoom.fillAmount < 1f)
        {
             audiVirtualRoom.fillAmount += 0.02f;
            yield return true;
        }
    }
    IEnumerator bgfade()
    {
        Debug.Log("bgfade");
        yield return new WaitForSeconds(1);
        while (a >= 0f)
        {
            fadeinbg.color=new Vector4(0f, 0f, 0f, a);
            welcomeTo.color = new Vector4(0f, 0f, 0f, a);
            audiVirtualRoom.color = new Vector4(0f, 0f, 0f, a);
            a -= 0.02f;
            yield return true;
        }
        raycast_canvas.SetActive(true);
    }
}
