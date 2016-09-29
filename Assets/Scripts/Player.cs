using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	
	public string horzAxe, vertAxe;
	public GameObject healthBarPrefab;
	public Player opponent;

	public float minSpeed;
	float speed;
	public float boostSpeed;
	public int health;

	GameController gameController;
	public GameObject healthBar;
	Animator healthBarAnim;
	bool facingRight = true;
	float damageTimer = 0.0f;
	float boostTimer = 0.0f;


	void Start(){
		speed = minSpeed;
		gameController = GameObject.Find("GameController").GetComponent<GameController> ();
		Vector3 healthPos = new Vector3(transform.position.x+1, transform.position.y+1, 0);
		healthBar = Instantiate(healthBarPrefab,
		            healthPos,
		            Quaternion.identity) as GameObject;
		healthBarAnim = healthBar.GetComponent<Animator> ();
	}

	//(FixedUpdate doesn't require time.deltaTimeWhatever)
	void FixedUpdate(){
		if (!gameController.finished) {
			//Movement
			GetComponent<Rigidbody2D> ().velocity =
			new Vector2 (Mathf.Lerp (0, Input.GetAxis (horzAxe) * speed, 0.8f), 
			            Mathf.Lerp (0, Input.GetAxis (vertAxe) * speed, 0.8f));

			//Change sprite rotation to match direction
			Vector2 moveDirection = GetComponent<Rigidbody2D> ().velocity;
			if (moveDirection.magnitude != 0) {
				GetComponent<Animator>().SetBool("Moving", true);
				float angle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.AngleAxis (angle, Vector3.forward), 0.2f);
				if (Input.GetAxis (horzAxe) < 0 && facingRight) {
					flipSprite ();
				} else if (Input.GetAxis (horzAxe) > 0 && !facingRight) {
					flipSprite ();
				}
			} else {
				GetComponent<Animator>().SetBool("Moving", false);
			}

			//damaged
			if (damageTimer > 0.0f){
				damageTimer -= Time.deltaTime;
				if (damageTimer <= 0.0f){
					speed = minSpeed;
				}
			}

			//damaged
			if (boostTimer > 0.0f){
				boostTimer -= Time.deltaTime;
				if (boostTimer <= 0.0f){
					speed = minSpeed;
				}
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

	//Damage player
	public void damage(bool giveBoost){
		if (health > 0) {
			if (damageTimer <= 0.0f) { //not recently damaged
				GetComponent<AudioSource> ().Play ();
				healthBarAnim.SetInteger ("Health", health - 1);
				health -= 1;
				if (health <= 0) {
					gameController.victory (opponent);
					GetComponent<Animator> ().SetBool ("Dead", true);
				} else {
					damageTimer = 2.5f;
					if (giveBoost) {
						speed = boostSpeed;
					}
					StartCoroutine (blink (damageTimer));
				}
			}
		}
	}

	public void boost(){
		if (health < 3) {
			healthBarAnim.SetInteger ("Health", health + 1);
			health +=1;
		}
		speed = boostSpeed;
		boostTimer = 2.5f;
	}

	public void kill(){
		healthBar.GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<SpriteRenderer> ().enabled = false;
		GetComponent<CircleCollider2D> ().enabled = false;
		GetComponent<BoxCollider2D> ().enabled = false;
	}

	//Blink sprite
	IEnumerator blink(float duration){
		float endTime = Time.time + duration;
		while (Time.time < endTime) {
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			yield return new WaitForSeconds (0.2f);
			gameObject.GetComponent<SpriteRenderer>().enabled = true;
			yield return new WaitForSeconds (0.2f);
		}
	}

}
