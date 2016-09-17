using UnityEngine;
using System.Collections;

public class EndCollision : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		PlayerMobility player = other.gameObject.GetComponent<PlayerMobility> ();
		player.damage ();
	}
}
