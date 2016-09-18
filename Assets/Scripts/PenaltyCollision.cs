using UnityEngine;
using System.Collections;

public class PenaltyCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		Player player = other.gameObject.GetComponent<Player> ();
		player.damage ();
	}
}
