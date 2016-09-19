using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		Player player = other.gameObject.GetComponent<Player> ();
		if (player != null) {
			GetComponent<AudioSource>().Play();
			player.boost();
			StartCoroutine(destroyFood());
		}
	}

	IEnumerator destroyFood(){
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (1.5f);
		GetComponent<BoxCollider2D> ().enabled = true;
		GetComponent<SpriteRenderer>().enabled = true;
	}
}
