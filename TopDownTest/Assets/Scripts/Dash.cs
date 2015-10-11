using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

	public float dashDuration;
	public float dashMoveSpeed;
	public CharacterController controller;
	private Vector3 position;
	private float durationRemaining;

	// Use this for initialization
	void Start () {
		position = transform.position;
		durationRemaining = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("d") && controller.GetComponent<ClickToMove> ().idle) {
			Vector3 terrainBelowCursor;
			if (Cursor.ToTerrainPosition(out terrainBelowCursor))
			{
				position = terrainBelowCursor;
				controller.GetComponent<ClickToMove> ().idle = false;
				durationRemaining = dashDuration;
			}
		}
		if (durationRemaining > 0.0f) {
			Vector3 moveVector = Movement.MoveToPosition(transform, position, 1);
			if (moveVector == new Vector3(0,0,0)) {
				durationRemaining = 0.0f;
			}
			controller.SimpleMove(moveVector * dashMoveSpeed);
			durationRemaining -= Time.deltaTime;
			if (durationRemaining <= 0.0f) {
				controller.GetComponent<ClickToMove> ().idle = true;
			}
		}
	}
}
