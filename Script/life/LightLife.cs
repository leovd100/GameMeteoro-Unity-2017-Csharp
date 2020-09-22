using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LightLife : MonoBehaviour {

	public Light lightLh;
	private bool tr;

	// Use this for initialization
	void Start () {
		lightLh = GetComponent<Light> ();
		tr = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (lightLh.intensity >= 10) 
			tr = true;
		
		 else if (lightLh.intensity == 0) 
			tr = false;
		

		if (tr) {
			lightLh.intensity -= Time.deltaTime*8;
		} else {
			lightLh.intensity += Time.deltaTime*8;
		}
	}
}
