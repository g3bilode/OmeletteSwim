using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public Player player1;
	public Player player2;
	public Text victoryText;
	public GameObject restartButton;
	public bool finished = false;

	void Start(){
		transform.FindChild("Music").GetComponent<AudioSource>().time = 57.0f;
		transform.FindChild("Music").GetComponent<AudioSource>().Play();
	}

	public void victory(Player winner){
		if (winner == player1) {
			victoryText.text = "PLAYER ONE\nSURVIVES";
		} else {
			victoryText.text = "PLAYER TWO\nSURVIVES";
		}
		finished = true;
		victoryText.gameObject.SetActive (true);
		Camera.main.GetComponent<EdgeCollider2D> ().enabled = false;
		restartButton.SetActive (true);

		transform.FindChild("Music").GetComponent<AudioSource>().Stop();
		transform.FindChild("VictorySound").GetComponent<AudioSource>().Play();
	}

}
