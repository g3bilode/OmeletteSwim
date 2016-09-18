using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour {

	public float speed;
	public int health = 3;
	public string horzAxe, vertAxe;
	public GameObject healthBarPrefab;
	GameObject healthBar;
	Animator anim;
	bool facingRight = true;

	void Start(){
		Vector3 healthPos = new Vector3(transform.position.x+1, transform.position.y+1, 0);
		healthBar = Instantiate(healthBarPrefab,
		            healthPos,
		            Quaternion.identity) as GameObject;
		anim = healthBar.GetComponent<Animator> ();
	}

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
	
	void Update(){
		healthBar.transform.position = 
			new Vector3 (Mathf.Lerp (healthBar.transform.position.x, transform.position.x+1, 0.2f),
		                 Mathf.Lerp (healthBar.transform.position.y, transform.position.y+1, 0.2f),
		                 0);
	}

	//Flip the sprite
	void flipSprite(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.y *= -1;
		transform.localScale = theScale;
	}

	public void damage(){
		anim.SetInteger ("Health", health - 1);
		health -= 1;
//		if (healthBar != null) {
//			Destroy (healthBar);
//		}
	}

}
