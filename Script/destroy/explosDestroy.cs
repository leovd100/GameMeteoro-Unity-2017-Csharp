using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosDestroy : MonoBehaviour {
	private float timeToDestroy;
	public bool isRock;
	private BoxCollider2D myBox;
	// Use this for initialization
	void Start () {
		timeToDestroy = 0.9f;
		myBox = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeToDestroy -= Time.deltaTime;
		if (!isRock) {
			if (timeToDestroy <= 0)
				Destroy (gameObject);
		} else {
			if (timeToDestroy <= 0) {
				myBox.enabled = false;
			}
			if (transform.position.y <= -9) 
				Destroy (gameObject);
			
		}
	}
}
