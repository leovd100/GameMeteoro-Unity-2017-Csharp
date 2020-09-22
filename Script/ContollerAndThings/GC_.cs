using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GC_ : MonoBehaviour {
	public static bool gameOver;
	//public GameObject conjCanv;

	public ParticleSystem winEfect;
	public Image fundo;
	public Image cinza;
	public Button buttonRestart;
	public Image imageButton;
	public Text textButton;
	private GameObject spawn;
	private float timeToMenu;
	private Quaternion trs;

	//--------------SCORE

	private float hightScore;
	public static float myScore;
	public Text score;
	public Text textHightScore;
	public Text textMyScore;

	public AudioSource aud;
	private bool win = true;
	public float timeSleep = 5;



	public GameObject[] screnGameObejcts;


	// Use this for initialization
	void Start () {
		gameOver = false;
		myScore = 0;
		hightScore = PlayerPrefs.GetFloat ("hight");
		//conjCanv.SetActive (false);
	
		spawn = GameObject.FindGameObjectWithTag("spawn");
		spawn.SetActive(true);
		timeToMenu = 1.9f;



	}

	// Update is called once per frame
	void Update () {
		
		//Score tela
		score.text = "Score: " + myScore.ToString("F2");



	
		if (myScore > hightScore) {
			PlayerPrefs.SetFloat("hight",myScore);
			hightScore = PlayerPrefs.GetFloat ("hight");
		}

		if (gameOver) {
			
			aud.Pause ();
			timeToMenu -= Time.deltaTime;
			//conjCanv.SetActive (true);
			spawn.SetActive(false);

			if (timeToMenu <= 0) {
				screnGame() ;
				textEndGame ();
				offGm (); // desliga os elementos da tela
			}
		}


		if (aud.isPlaying == false) {
			timeSleep -= Time.deltaTime;
		} else {
			timeSleep = 5;
		}
			

		if (!gameOver && timeSleep <= 0 && win) {
			
			winEfect.Play ();
			screnGame() ;
			textEndGame ();
			offGm (); // desliga os elementos da tela
			win = false;
		}




	}
	public void RestartButton (){
		Application.LoadLevel("tb");

	}




	void screnGame(){
		imageButton.enabled = true;
		fundo.enabled = true;
		cinza.enabled = true;
		buttonRestart.enabled = true;

	}

	void textEndGame(){
		textButton.text = "Restart";
		textHightScore.text = "Hight Score: " + hightScore.ToString("F2");
		textMyScore.text = "Score: " + myScore.ToString("F2");
	}



	void offGm(){

		for (int i = 0; i < screnGameObejcts.Length; i++) {
			screnGameObejcts [i].SetActive (false);
		}
	}



}
