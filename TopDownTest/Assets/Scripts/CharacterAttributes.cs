using UnityEngine;
using System.Collections;

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




	// Use this for initialization
	void Start () {
		target = null;
	}

	// Is the character in range of the target
	void isInRange() {
		
		if(target != null) {
			if ((Vector3.Distance(transform.position, target.transform.position) <= range) ||
			    Vector3.Distance(transform.position, target.transform.position) >= range * range) {
				
				inRange = true;
			}
			
			else {
				inRange = false; 
			}
		}
	}

	// Update is called once per frame
	void Update () {

		isInRange();
	
		// If the character dies, kill the editor (Tyler is lazy)
		if(CharacterDead()) {

			// End Game
			//UnityEditor.EditorApplication.isPlaying = false;

			//Application.Quit();
		}


	}

	// Is the character's health gone
	bool CharacterDead() {

		return (characterHealth <= 0);
	}
}
