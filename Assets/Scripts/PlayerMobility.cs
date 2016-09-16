using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public string horzAxe, vertAxe;
	bool facingRight = true;

	//(FixedUpdate doesn't require time.deltaTimeWhatever)
	void FixedUpdate(){
		//Movement
		GetComponent<Rigidbody2D>().velocity =
			new Vector2(Mathf.Lerp(0, Input.GetAxis(horzAxe)* speed, 0.8f), 
			            Mathf.Lerp(0, Input.GetAxis(vertAxe)* speed, 0.8f));

		//Change sprite rotation to match direction
		Vector2 moveDirection = GetComponent<Rigidbody2D>().velocity;
		if (moveDirection.magnitude != 0){
			float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
			if (Input.GetAxis(horzAxe) < 0 && facingRight){
				flipSprite ();
			} else if (Input.GetAxis(horzAxe) > 0 && !facingRight){
				flipSprite();
			}
		}
	}

	//Flip the sprite
	void flipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}

}
