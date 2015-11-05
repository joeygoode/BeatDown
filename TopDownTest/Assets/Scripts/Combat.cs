using UnityEngine;
using System.Collections;

public class Combat : MonoBehaviour {


	public GameObject targetEnemy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey (KeyCode.Space)) {

			// GOTTA GO BACK TO FIX AN ANIMATION ISSUE
			ClickToMove.attack = true;
			// When animating,

			if(targetEnemy != null) {

				transform.LookAt(targetEnemy.transform.position);
				//targetEnemy.GetComponent<SimpleAI>.getHit(10);
			}

		}

//		if(!Animation.IsPlaying(attack.name)) {
//			ClickToMove.attack = false;
//		}

	}
}
