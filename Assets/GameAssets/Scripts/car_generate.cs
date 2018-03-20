using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_generate : MonoBehaviour {
    public GameObject car5;

	// Use this for initialization
	void Start () {
        Invoke("generateCar", 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void generateCar()
    {
        Instantiate(car5, new Vector3(10f, 0f, 30f), Quaternion.Euler(0f, 150f, 0f));
    }
}
