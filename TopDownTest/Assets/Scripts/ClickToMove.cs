using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour 
{
	public float speed;
	public CharacterController controller;
	private Vector3 position;
	
	//public AnimationClip run;
	//public AnimationClip idle;


	public bool idle;
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
		if(Input.GetMouseButton(0)) {
			//Locate where the player clicked on the terrain
			Vector3 terrainBelowCursor;
			if (Cursor.ToTerrainPosition(out terrainBelowCursor))
			{
				position = terrainBelowCursor;
				GetComponent<Animation>().Play ("Run");
			}
		}

		if (idle) {
			//Move the player to the position

			moveToPosition ();
		} else {
			position = new Vector3(0,0,0);//transform.position;
		}
	}
	
	void moveToPosition() {

		controller.SimpleMove (Movement.MoveToPosition (transform, position, Time.deltaTime * 10) * speed);
	}




}
