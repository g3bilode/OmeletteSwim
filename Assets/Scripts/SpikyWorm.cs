using UnityEngine;
using System.Collections;

public class SpikyWorm : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		Player player = other.gameObject.GetComponent<Player> ();
		if (player != null) {
			GetComponent<AudioSource>().Play();
			player.damage(false);
			StartCoroutine(destroyEnemy());
		}
	}
	
	IEnumerator destroyEnemy(){
		GetComponent<BoxCollider2D> ().enabled = false;
		GetComponent<SpriteRenderer>().enabled = false;
		yield return new WaitForSeconds (1.5f);
		Destroy(transform.gameObject);
	}
}
