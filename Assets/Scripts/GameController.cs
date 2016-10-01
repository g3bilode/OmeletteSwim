﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player1;
	public Player player2;
	public Text victoryText;
	public GameObject restartButton;
	public GameObject exitButton;
	public GameObject mainButton;
	public bool finished = false;
	public bool isPause = false;

	void Start(){
		transform.FindChild("Music").GetComponent<AudioSource>().Play();
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPause = !isPause;
			if(isPause){
				Time.timeScale = 0;
				restartButton.SetActive(true);
				exitButton.SetActive(true);
				mainButton.SetActive(true);
			} else {
				Time.timeScale = 1;
				restartButton.SetActive(false);
				exitButton.SetActive(false);
				mainButton.SetActive(false);
			}
		}
	}

	public void victory(Player winner){
		if (winner == player1) {
			victoryText.text = "PLAYER ONE\nSURVIVES";
			StartCoroutine(crushLoser(player2));
		} else {
			victoryText.text = "PLAYER TWO\nSURVIVES";
			StartCoroutine(crushLoser(player1));
		}
		finished = true;
		victoryText.gameObject.SetActive (true);
		Camera.main.GetComponent<EdgeCollider2D> ().enabled = false;
		restartButton.SetActive (true);

		transform.FindChild("Music").GetComponent<AudioSource>().Stop();
		transform.FindChild("VictorySound").GetComponent<AudioSource>().Play();
	}

	IEnumerator crushLoser(Player loser){
		loser.healthBar.GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds(7.0f);
		loser.GetComponent<Animator>().SetBool("Dead", true);
	}

}
