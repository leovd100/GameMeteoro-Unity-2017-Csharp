using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour {

	public float moveSpeed,turnSpeed;
	private Vector2 positionPlayer;
	public ParticleSystem particle;

	// Use this for initialization
	void Start () {
		particle = GetComponent<ParticleSystem> ();
		// valor de inicial da posicao
		transform.position = new Vector2 (0, -4);
	}
	
	// Update is called once per frame
	void Update () {


		// Utiliza as setinhas e o S e W para direção

		move ();
		positionPlayer = transform.position;
		sides (positionPlayer);


	}


	// função de momiventação do player
	public void move(){ 



		if (Input.GetAxis ("Vertical") > 0) { // W
			transform.Translate (Vector3.up * moveSpeed * Time.deltaTime);
			particle.Play ();

		} else if (Input.GetAxis ("Vertical") < 0) { // S
			transform.Translate (-Vector3.up * moveSpeed * Time.deltaTime);
			particle.Play ();
		} else {
			particle.Stop();
		}


		if (Input.GetAxis ("Horizontal") > 0) { // A
			transform.Translate (-Vector3.right * -moveSpeed * Time.deltaTime);
		} else if (Input.GetAxis ("Horizontal") < 0) { // D
			transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		}




	}

	// cria uma trava para o player delimitando os lados que ele pode se mover
	public void sides(Vector2 myPos){

		// -4.7 down
		// -2.36 2.36
		// verifica os valores dos lados
		if (myPos.x >= 2.37f) {
			transform.position = new Vector2 (2.37f, myPos.y);
		} 

		if (myPos.x  <= -2.37) {
			transform.position = new Vector2 (-2.37f, myPos.y);
		}

		// verifica os valores de cima e de baixo
	
		if (myPos.y <= -4.30) {
			transform.position = new Vector2 (myPos.x, -4.30f);
		}


		if (myPos.y >= -1) {
			transform.position = new Vector2 (myPos.x, -1);
		}



	
		if (myPos.y <= -4.30 && myPos.x >= 2.37f) {
			transform.position = new Vector2 (2.37f, -4.30f);
		} else 	if (myPos.y <= -4.30 && myPos.x <= -2.37f) {
			transform.position = new Vector2 (-2.37f, -4.30f);
		}
	

		if (myPos.y >= -1.0f  && myPos.x >= 2.37f) {
			transform.position = new Vector2 (2.37f, -1);
		} else 	if (myPos.y >= -1 && myPos.x <= -2.37f) {
			transform.position = new Vector2 (-2.37f, -1.0f);
		}


	}














}
