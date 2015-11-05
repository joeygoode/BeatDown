using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {
	public string TargetName;
	public float MoveSpeed;

	private Vector3 destination;

	public int range;

	public GameObject target;

	public GameObject player;



	public void getHit(int damage) {

		CharacterAttributes.characterHealth -= damage;
	}


	// Is the enemy in range of the player
	bool inRange(){

		if ((Vector3.Distance(transform.position, player.transform.position) <= range) ||
		    Vector3.Distance(transform.position, player.transform.position) >= range * range) {
			return true;
		}

		else {
			return false; 
		}
	}


	// Use this for initialization
	void Start () {
		//target = GameObject.Find (TargetName);
		
		//player = GameObject.FindGameObjectWithTag("Player");
	}

	
	// Update is called once per frame
	void Update () {

		destination = target.transform.position;

		if (!inRange ()) {

			//transform.LookAt(player.transform.position);
			
			gameObject.GetComponent<CharacterController>().SimpleMove (Movement.MoveToPosition (transform,
		                                                                                    destination,
		                                                                                    Time.deltaTime * 10)
		                                                           * MoveSpeed);
		}
	}

	void OnMouseOver() {



		player.GetComponent<Combat>().targetEnemy = gameObject;

		Debug.Log("Mouse is over Enemy");
	}
}
