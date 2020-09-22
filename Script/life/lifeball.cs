using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeball : MonoBehaviour {
	LifeCount life = new LifeCount();
	private float speedBall;
	// Use this for initialization
	void Start () {
		speedBall = Random.Range (6.0f, 9.0f); // sorteia uma velocidade para a bola de vida
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (0, -speedBall * Time.deltaTime, 0); // faz a bola de vida se movimentar
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Player") { // se colidir com o objeto de tag player, ele é destuído

			Destroy (gameObject);
		}

	}

}
