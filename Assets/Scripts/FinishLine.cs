using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public GameObject[] rockPrefabs;
	bool ended = false;

	void OnTriggerEnter2D (Collider2D other){
		if (! ended) {
			Player winner = other.gameObject.GetComponent<Player> ();
			GameController gameController = GameObject.Find ("GameController").GetComponent<GameController> ();
			gameController.victory (winner);
			StartCoroutine (savePlayer(winner));
			StartCoroutine (rockSpawn (6.0f));
			ended = true;
		}
	}

	IEnumerator rockSpawn(float duration){
		this.GetComponent<AudioSource>().Play();
		float endTime = Time.time + duration;
		while (Time.time < endTime){
			if(Random.value > 0.5){
				this.GetComponent<AudioSource>().Play();
			}
			Vector3 rockPos = new Vector3 (transform.position.x - Random.Range(0,10),
			                               transform.position.y + 10,
			                               0);
			GameObject rock = Instantiate (rockPrefabs[Random.Range(0,2)], rockPos, Quaternion.identity) as GameObject;
			StartCoroutine (rockCollide (rock));

			rockPos = new Vector3 (transform.position.x - (12+Random.Range(0,10)),
			                               transform.position.y + 10,
			                               0);
			rock = Instantiate (rockPrefabs[Random.Range(0,2)], rockPos, Quaternion.identity) as GameObject;
			StartCoroutine (rockCollide (rock));
			yield return new WaitForSeconds (0.35f);
		}
	}

	IEnumerator rockCollide(GameObject rock){
		rock.GetComponent<PolygonCollider2D> ().enabled = false;
		yield return new WaitForSeconds(1.0f);
		rock.GetComponent<PolygonCollider2D> ().enabled = true;
	}

	IEnumerator savePlayer(Player winner){
		for (int i=0; i<30; i++) {
			winner.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
			yield return new WaitForSeconds(0.1f);
		}
	}

}
