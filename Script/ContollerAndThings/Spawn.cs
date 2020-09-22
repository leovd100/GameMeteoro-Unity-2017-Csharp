using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {


	// SEM MÚSICA NÃO FUNCIONA !!!! 

	private float[] spectrum;
	public GameObject[] targets;
	private float positionRandom;
	private Vector2 positionSet;
	private float timeToSpawn;
	//-----------------Life spawn
	public GameObject lifeTarget;
	public float timeToLifeSpawn;
	// Use this for initialization
	void Start () {


		positionRandom = Random.Range (-2.36f, 2.36f);
		positionSet = new Vector2 (positionRandom,transform.position.y);
		timeToSpawn = 1;
		timeToLifeSpawn = 10f;
	}
	
	// Update is called once per frame
	void Update () {
	

		spectrum = AudioListener.GetSpectrumData (512, 0, FFTWindow.Hamming); // pega as batidas das músicas
		// decrementa o tempo até 0 para spwnar um objeto
		timeToSpawn -= Time.deltaTime; 
		// decrementa o tempo até 0 para spwnar a vida
		timeToLifeSpawn -= Time.deltaTime;

		// faz um sorteio de uma posição para ser passado ao objeto a ser spawnado
		positionRandom = Random.Range (-2.36f, 2.36f);
		// recebe a posição setada 
		positionSet = new Vector2 (positionRandom,transform.position.y);


		if (spectrum [0] > 0.065f && timeToSpawn <= 0) {
			
			Instantiate (targets [0], positionSet, Quaternion.identity);

			timeToSpawn = 0.4f;
		}else 	if (spectrum [0] > 0.019f && spectrum [0] < 0.05f && timeToSpawn <= 0) {
	

			Instantiate (targets [1], positionSet, Quaternion.identity);

			timeToSpawn = 0.4f;
		}

	
		//Spawna vida
		if (timeToLifeSpawn <= 0) {
			positionRandom = Random.Range (-2.36f, 2.36f);
			positionSet = new Vector2 (positionRandom,transform.position.y);

			Instantiate (lifeTarget, positionSet, Quaternion.identity);
			timeToLifeSpawn = 12f;
		}




	}
}
