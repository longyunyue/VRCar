using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light_ctrl : MonoBehaviour {
    public Light l1;
    public Light l2;
    public Light l3;
    public AudioSource lighton;


    // Use this for initialization
    void Start () {
        StartCoroutine(light_on());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator light_on()
    {
        yield return new WaitForSeconds(1f);
        l1.enabled = true;
        lighton.Play();
        yield return new WaitForSeconds(1f);
        l2.enabled = true;
        lighton.Play();
        yield return new WaitForSeconds(1f);
        l3.enabled = true;
        lighton.Play();
    }
}
