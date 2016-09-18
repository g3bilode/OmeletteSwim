using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		Player winner = other.gameObject.GetComponent<Player> ();
		GameController gameController = GameObject.Find("GameController").GetComponent<GameController> ();
		gameController.victory (winner);
	}
}
