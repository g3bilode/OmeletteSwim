using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject first;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.transform.position.x > player2.transform.position.x) {
			first = player1;
		} else {
			first = player2;
		}

		Camera.main.transform.position = new Vector3 (first.transform.position.x,
		                                             Camera.main.transform.position.y,
		                                             Camera.main.transform.position.z);
	}
}
