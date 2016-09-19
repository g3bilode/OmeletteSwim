using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public GameObject rockPrefab;
	bool ended = false;

	void OnTriggerEnter2D (Collider2D other){
		if (! ended) {
			Player winner = other.gameObject.GetComponent<Player> ();
			GameController gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
			gameController.victory (winner);

			StartCoroutine (rockSpawn (10.0f));
			ended = true;
		}
	}


	IEnumerator rockCollide(GameObject rock){
		rock.GetComponent<PolygonCollider2D> ().enabled = false;
		yield return new WaitForSeconds(0.5f);
		rock.GetComponent<PolygonCollider2D> ().enabled = true;
	}

	IEnumerator rockSpawn(float duration){
		float endTime = Time.time + duration;
		while (Time.time < endTime){
			Vector3 rockPos = new Vector3 (transform.position.x - 3,
				                              transform.position.y + 10,
				                              0);
			GameObject rock = Instantiate (rockPrefab, rockPos, Quaternion.identity) as GameObject;
			StartCoroutine (rockCollide (rock));
			yield return new WaitForSeconds (0.3f);
		}
	}
}
