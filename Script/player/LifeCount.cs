using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCount : MonoBehaviour {

	private int lifePlayer ;
	public GameObject[] lifeSprite;
	private BoxCollider2D myBoxPlayer;
	private bool blink;
	private float currentTimeToblink;
	// Use this for initialization
	void Start () {
		myBoxPlayer = GetComponent<BoxCollider2D> (); // pega o box collider do objeto
		lifePlayer = 3;
		currentTimeToblink = 1.2f;

	}
	
	// Update is called once per frame
	void Update () {
		verifyLife (lifePlayer);

		// faz um limite na vida , não pode ser maior que 3 e nem menor que 0
		if (lifePlayer >= 3)
			lifePlayer = 3;
		if (lifePlayer <= 0)
			lifePlayer = 0;


	
	
	} //------------end update




	void verifyLife(int lifePlayer){
		switch (lifePlayer) {
		// seta as imagens das naves dependendo do numero de vidas que o personagem tem
		case 1: // se tiver 1 vida somente 1 nave vai estar ativa
			lifeSprite [0].SetActive(false);
			lifeSprite [1].SetActive(false);
			lifeSprite [2].SetActive(true);
			break;

		case 2:// se tiver 2 vidas somente 2 nave vai estar ativa
			lifeSprite [0].SetActive(false);
			lifeSprite [1].SetActive(true);
			lifeSprite [2].SetActive(true);
			break;

		case 3:// se tiver 3 vidas todas as naves vão estar ativas
			lifeSprite [0].SetActive(true);
			lifeSprite [1].SetActive(true);
			lifeSprite [2].SetActive(true);
			break;
		case 0: // a nave principal é desligada e não há nenhuma nave ativa.
			lifeSprite [0].SetActive (false);
			lifeSprite [1].SetActive (false);
			lifeSprite [2].SetActive (false);
			GC_.gameOver = true;
			gameObject.SetActive (false);
			break;

		}
	
	} //----------------------------------------------- end verify


	public void OnTriggerEnter2D(Collider2D coll2d){
		if (coll2d.gameObject.tag == "rock") { // se a nave colidir com o meteóro, ela perde -1 de vida
			lifePlayer-=1;
			transform.position = new Vector2 (0, -4);
		}

		if (coll2d.gameObject.tag == "ball") { // se a nave colidir com a bolinha, ela ganha + 1 de vida
			lifePlayer+=1;
		}
	}













}
