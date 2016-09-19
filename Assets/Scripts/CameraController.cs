using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Player player1;
	public Player player2;
	GameObject background;
	Player first;
	float leftBound;
	float rightBound;

	// Use this for initialization
	void Start () {
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
			if (player2.transform.position.x < (transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect))){
				player2.damage(false);
			}
		} else {
			first = player2;
			if (player1.transform.position.x < (transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect))){
				player1.damage(false);
			}
		}

		//Camera follow
		if (first.transform.position.x > leftBound && first.transform.position.x < rightBound) {
			Camera.main.transform.position = new Vector3 (first.transform.position.x,
		                                             Camera.main.transform.position.y,
		                                             Camera.main.transform.position.z);
		}
	}
}
