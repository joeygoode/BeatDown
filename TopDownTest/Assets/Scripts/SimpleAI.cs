using UnityEngine;
using System.Collections;

// Enemy AI Class
public class SimpleAI : MonoBehaviour {

	/**
	 * The name of the object to look for
	 */
	public string TargetName;

	/**
	 * The move speed of the enemy
	 */
	public float MoveSpeed;

	/**
	 * Where the enemy should move to
	 */
	private Vector3 destination;

	/**
	 * How far away the enemy can see
	 */
	public int range;

	/**
	 * The player
	 */
	public GameObject player;

	/** 
	 * Is the enemy inRange of the player
	 */
	public bool inRange;

	/** 
	 * In-Game time of last attack
	 */
	public float justAttacked;

	/** 
	 * Is the AI currently attacking?
	 * (For Animation)
	 */ 
	public bool attacking;

	/**
	 * Is the AI doing nothing (i.e. not chasing && not attacking)
	 * (For Animation)
	 */
	public bool idle = true;


	// Is the enemy in range of the player
	void isInRange(){

		if (Vector3.Distance(transform.position, player.transform.position) <= range) {

			inRange = true;
			attacking = true;
		}

		else {
			inRange = false;
			attacking = false;
		}
	}




	// Use this for initialization
	void Start () {
		justAttacked = Time.time;
	}

	
	// Update is called once per frame
	void Update () {

		isInRange();

		destination = player.transform.position;


		if (Vector3.Distance(transform.position, player.transform.position) > range * (range/3)) {

			GetComponent<Animation>().Play ("Idle");
		}


		// If we arent in range and we aren't too far away from the player, chase the player
		float distance = Vector3.Distance(transform.position,player.transform.position);
		bool shouldChase = (distance < range * (range / 3)) && !inRange;
		if (shouldChase) {
			Vector3 movement = Movement.MoveToPosition(transform,destination,Time.deltaTime * 10) * MoveSpeed;
			gameObject.GetComponent<CharacterController>().SimpleMove(movement);
			if (GameObject.Find("EventSubscriber").GetComponent<EventSubscriber>().onBeat ) {
				GetComponent<Animation>().Play ("Walk");
					
			}
		}

		if (Time.time - justAttacked > 4){
			if (inRange ) {
				if (gameObject.tag == "Boss") {
					GetComponent<Animation>().Play("Combo");
					player.GetComponent<CharacterAttributes>().characterHealth -= 
					GetComponent<CharacterAttributes>().attackDamage/3;
					justAttacked = Time.time;
				}

				if (gameObject.tag == "Enemy") {
					GetComponent<Animation>().Play("Attack");
					player.GetComponent<CharacterAttributes>().characterHealth -= 
						GetComponent<CharacterAttributes>().attackDamage;
					justAttacked = Time.time;
				}
			}
			
		}
	}


	// When the mouse is over the enemy
	void OnMouseOver() {

		// Set this enemy to the player's targeted enemy
		player.GetComponent<CharacterAttributes>().target = gameObject;
	}

	// When the mouse is not over the enemy
	void OnMouseExit() {

		// Set the player's targeted enemy to null
		player.GetComponent<CharacterAttributes>().target = null;
	}
}

