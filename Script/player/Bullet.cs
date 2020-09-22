using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	private float speedBullet;

	// Use this for initialization
	void Start () {
		speedBullet = 8;
	}
	
	// Update is called once per frame
	void Update () {
		
			
		transform.Translate (0, speedBullet * Time.deltaTime, 0); // movimentação da bala
		if(transform.position.y > 8) // se a bala passar de um determinado valor no eixo Y, ela é destruída.
			Destroy (gameObject);
	}
}
