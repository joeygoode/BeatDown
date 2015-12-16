using UnityEngine;
using System.Collections;






public class ClickToMove : MonoBehaviour 
{


	// The player's speed
	public float speed;

	// The player's controller
	public CharacterController controller;


	private Vector3 position;


	public bool idle;

	// Is the player attacking
	public static bool attack;
	//public static bool die;

	// Use this for initialization
	void Start () 
	{
		position = transform.position;
		idle = true;
	}
	
	// Update is called once per frame
	void Update () {


		// On left click
		if(Input.GetMouseButton(0)) {

			//Locate where the player clicked on the terrain
			Vector3 terrainBelowCursor;
			if (Cursor.ToTerrainPosition(out terrainBelowCursor))
			{
				position = terrainBelowCursor;
				if(!GetComponent<CharacterAttributes>().inRange){
				GetComponent<Animation>().Play ("Walk");
				}
			}
		}

		if (idle) {

			//Move the player to the position
			moveToPosition ();

		} else {

			position = new Vector3(transform.position.x, 0.5289f, transform.position.z);
		}
	}

	// Moves the player
	void moveToPosition() {

		if(!GetComponent<CharacterAttributes>().inRange) { 
		controller.SimpleMove (Movement.MoveToPosition (transform, position, Time.deltaTime * 10) * speed);
		}
	}




}
