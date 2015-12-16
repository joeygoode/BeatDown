using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {

	// The player's targeted enemy.  Changed in SimpleAI
	public GameObject targetEnemy;
	public bool attacking = false;

	public float justAttacked;



	// Use this for initialization
	void Start () {


	}

	// Attack the enemy
	void Attack() {
			
			// GOTTA GO BACK TO FIX AN ANIMATION ISSUE
		GetComponent<Dash>().dashing = false;
		attacking = true;
		justAttacked = Time.time;
			//ClickToMove.attack = true;
			// Play the attack animation
		GetComponent<Animation>().Play ("Attack1");
			// When animating,
			
		Vector3 targetPosition = new Vector3(targetEnemy.transform.position.x,
		                                     this.transform.position.y,
		                                     targetEnemy.transform.position.z);
			
			// Look at the target
			transform.LookAt(targetPosition);

			//If the player attacks on beat
			if (GetComponent<RhythmBehavior>().onBeat){

				// Play the correct sound
				GetComponent<RhythmBehavior>().onBeatAttack.Play();

				// Decrement the target's health (Double Damage)
				targetEnemy.GetComponent<CharacterAttributes>().characterHealth 
					-= (GetComponent<CharacterAttributes>().attackDamage * 2);

			// Change the enemy's color to green
			targetEnemy.GetComponent<Renderer> ().material.color = Color.green;
			}

			// If the player attacks off beat
			else {

			// Play the right sound
			GetComponent<RhythmBehavior>().offBeatAttack.Play();

			// Decrement the target's health
			targetEnemy.GetComponent<CharacterAttributes>().characterHealth 
				-= GetComponent<CharacterAttributes>().attackDamage;

			// Change the target's color to red
			targetEnemy.GetComponent<Renderer> ().material.color = Color.red;
			}
		
		//		if(!Animation.IsPlaying(attack.name)) {
		//			ClickToMove.attack = false;
		//		}
		
	}


	
	// Update is called once per frame
	void Update () {

		targetEnemy = GetComponent<CharacterAttributes>().target;


		if(targetEnemy != null && Input.GetMouseButtonDown(0) && GetComponent<CharacterAttributes>().inRange && 
		   (Time.time - justAttacked > .45f)) {
			Attack();
		}

	}
}
