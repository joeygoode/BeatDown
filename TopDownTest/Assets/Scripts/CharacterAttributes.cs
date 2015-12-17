using UnityEngine;
using System.Collections;

// Stores basic information about characters (player + AI)
public class CharacterAttributes : MonoBehaviour {

	// The character's health
	public float characterHealth = 100;

	// How much damage the character's attacks do
	public float attackDamage = 10;

	// The range at which the character can attack
	public int range;

	// Is the character in range of the target?
	public bool inRange;

	public GameObject target;

	public float healthCooldown;

	private float maxHealth;

	private float REGEN_AMT = 3.50f;




	// Use this for initialization
	void Start () {
		target = null;
		healthCooldown = Time.time;
		maxHealth = characterHealth;
	}

//	// Is the character in range of the target
//	void isInRange() {
//		if(target != null) {
//			float distance = Vector3.Distance(transform.position, target.transform.position);
//			inRange = (distance <= range) || (distance >= (range * range));
//		}
//	}

	// Is the character in range of the target
	void isInRange() {
		if(target != null) {
			float distance = Vector3.Distance(transform.position, target.transform.position);
			inRange = (distance <= range);
		}
	}

	// Update is called once per frame
	void Update () {

		isInRange();
	
		// If the character dies, kill the editor (Tyler is lazy)
		if(CharacterDead()) {

			Destroy(gameObject);
			// End Game
			//UnityEditor.EditorApplication.isPlaying = false;

			//Application.Quit();
		}



		if (gameObject.tag == "Player" && Time.time - healthCooldown >= 1) {

			if (characterHealth < (maxHealth - REGEN_AMT)) {
				HealthRegen();
				healthCooldown = Time.time;
			}
		}


	}

	// Is the character's health gone
	bool CharacterDead() {

		return (characterHealth <= 0);
	}

	// Give the player health over time
	void HealthRegen() {

		characterHealth += REGEN_AMT;
	}
}
