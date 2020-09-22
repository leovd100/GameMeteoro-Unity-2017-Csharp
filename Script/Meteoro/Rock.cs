using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour {
	
	private float speedRock;
	private int life;
	public Color[] colorRock; // o meteóro contem 5 cores dependendo da quantade de vida que ele recebe
	public SpriteRenderer[] fins;
	public GameObject explose;

	// Use this for initialization
	void Start () {
		speedRock = Random.Range (2.7f, 10.0f); // velocidade do meteóro é sorteada pelo Random. range
		this.life = Random.Range (1,5); // a vida do meteóro é sorteada pelo random.range
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Translate (0, -speedRock * Time.deltaTime, 0);
		verify ();
		changeColor ();
	}


	// função de colisão 2D
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "bullet") {
			if (transform.position.y < 4.46) {
				this.life--;
			}

		}
	
	}



	public void verify(){
		if (transform.position.y <= -8) {
			Destroy (gameObject);
		}
		if (this.life <= 0) {
			GC_.myScore += Random.Range (5.0f, 30.0f); // quando o meteóro é destuído, ele envia uma pontuação ao jogador.
			Instantiate (explose, transform.position, Quaternion.identity); // Instancia a explosão
			Destroy (gameObject);

		}
	}
	// muda de cor dependendo da quantidade de vida
	public void changeColor(){

		switch (this.life) {
		case 1:
			for (int i = 0; i < fins.Length; i++) {	
				fins [i].color = colorRock [0]; // seta a cor em todos os UI referentes ao meteóro

			}
			break;
		case 2:
			for (int i = 0; i < fins.Length; i++) {	
				fins [i].color = colorRock [1];
			}
			break;
		case 3:
			for (int i = 0; i < fins.Length; i++) {	
				fins [i].color = colorRock [2];
			}
			break;
		case 4:
			for (int i = 0; i < fins.Length; i++) {	
				fins [i].color = colorRock [3];
			}
			break;
		case 5:
			for (int i = 0; i < fins.Length; i++) {	
				fins [i].color = colorRock [4];
			}
			break;
		}

	}



}
