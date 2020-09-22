using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour {


	public GameObject target;
	private float timeToShot;


	// Use this for initialization
	void Start () {
		timeToShot = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {

		timeToShot -= Time.deltaTime;

		if (Input.GetMouseButton (0) && timeToShot <=0) {
			Instantiate (target, transform.position, Quaternion.identity);
			timeToShot = 0.2f;
		}


	}
}
