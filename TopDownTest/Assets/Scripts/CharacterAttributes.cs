using UnityEngine;
using System.Collections;

public class CharacterAttributes : MonoBehaviour {

	public static int characterHealth = 100;
	public int attackDamage = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(CharacterDead()) {

			// End Game
			UnityEditor.EditorApplication.isPlaying = false;
		}


	}

	// Is the character's health gone
	bool CharacterDead() {

		return (characterHealth <= 0);
	}
}
