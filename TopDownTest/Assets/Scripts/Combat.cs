using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

	// The player's targeted enemy.  Changed in SimpleAI
	public GameObject targetEnemy;
	public bool attacking = false;

	public float justAttacked;
	private float ANIMATION_LENGTH;



	// Use this for initialization
	void Start () {
		ANIMATION_LENGTH = GetComponent<Animation>().GetClip("Attack").length;
	}

	// Attack the enemy
	void Attack() {
			
		// GOTTA GO BACK TO FIX AN ANIMATION ISSUE
		GetComponent<Dash>().dashing = false;
		attacking = true;
		justAttacked = Time.time;
		//ClickToMove.attack = true;
		// Play the attack animation

		GetComponent<Animation>().Play ("Attack");
		Debug.Log ("Playing Attack ATATATATATATATATATATA");
		// When animating,
			
		Vector3 targetPosition = new Vector3(targetEnemy.transform.position.x,
		                                     this.transform.position.y,
		                                     targetEnemy.transform.position.z);
			
		// Look at the target
		transform.LookAt(targetPosition);

		//If the player attacks on beat
		if (GameObject.Find("EventSubscriber").GetComponent<EventSubscriber>().onBeat){

			// Play the correct sound
			GetComponent<RhythmBehavior>().onBeatAttack.Play();

			// Decrement the target's health (Double Damage)
			targetEnemy.GetComponent<CharacterAttributes>().characterHealth 
				-= (GetComponent<CharacterAttributes>().attackDamage * 3);
		}

		// If the player attacks off beat
		else {

			// Play the right sound
			GetComponent<RhythmBehavior>().offBeatAttack.Play();

			// Decrement the target's health
			targetEnemy.GetComponent<CharacterAttributes>().characterHealth 
				-= GetComponent<CharacterAttributes>().attackDamage;
		}
		
	}

	bool animationEnded() {
		return (!attacking || ((Time.time - justAttacked) >= ANIMATION_LENGTH));
	}


	
	// Update is called once per frame
	void Update () {

		targetEnemy = GetComponent<CharacterAttributes>().target;

		bool enemyExists = targetEnemy != null;
		bool leftMouseClicked = Input.GetMouseButton(0);
		bool inRange = GetComponent<CharacterAttributes>().inRange;
		bool cooledDown = (Time.time - justAttacked) > 0.45f;

		if(enemyExists 
		   && leftMouseClicked
		   && inRange
		   && cooledDown) {

			Attack();
		}
		else if (animationEnded()){
			attacking = false;
		}

	}
}
