using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	GameObject player1;
	GameObject player2;
	GameObject background;
	GameObject first;
	float leftBound;
	float rightBound;

	// Use this for initialization
	void Start () {
		player1 = GameObject.Find("Player1");
		player2 = GameObject.Find("Player2");
		background = GameObject.Find("Background");

		float bgHalfWidth = background.GetComponent<SpriteRenderer> ().bounds.extents.x;
		leftBound = Camera.main.orthographicSize * Camera.main.aspect - bgHalfWidth;
		rightBound = bgHalfWidth - Camera.main.orthographicSize * Camera.main.aspect;
		Camera.main.transform.position = new Vector3 (leftBound,
                                              Camera.main.transform.position.y,
                                              Camera.main.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (player1.transform.position.x > player2.transform.position.x) {
			first = player1;
		} else {
			first = player2;
		}

		//Camera follow
		if (first.transform.position.x > leftBound && first.transform.position.x < rightBound) {
			Camera.main.transform.position = new Vector3 (first.transform.position.x,
		                                             Camera.main.transform.position.y,
		                                             Camera.main.transform.position.z);
		}
	}
}
