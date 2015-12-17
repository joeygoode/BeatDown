using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour {

	// How long the dash lasts
	public float dashDuration;

	// They speed of the player during the dash
	public float dashMoveSpeed;

	// The player's controlled
	public CharacterController controller;

	// The target position to dash to
	private Vector3 position;

	//How much time the dash has left
	private float durationRemaining;

	// The particle system that plays during an on beat dash
	private ParticleSystem dashParticles;

	public bool dashing = false;


	
	// Use this for initialization
	void Start () {

		// target position = our position
		position = transform.position;

		durationRemaining = 0.0f;

		dashParticles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

		// When the player presses the dash key
		// Modularize this*********************

		// Fail fast if attacking
		if (GetComponent<Combat>().attacking) {
			return;
		}

		if (Input.GetMouseButtonDown(1)) {

			GetComponent<Combat>().attacking = false;
			dashing = true;
			// Get the position of the cursor in the world
			Vector3 terrainBelowCursor;
			if (Cursor.ToTerrainPosition(out terrainBelowCursor)) {
				//Set the target position to the mouse position
				position = terrainBelowCursor;
				//controller.GetComponent<ClickToMove> ().idle = false;

				// If the player dashes on beat
				if(GameObject.Find("EventSubscriber").GetComponent<EventSubscriber>().onBeat) {

					// Play the correct sound
					GetComponent<RhythmBehavior>().onBeatChime.Play();
					GetComponent<Animation>().Play("DashStart");
					Debug.Log ("Playing DashStart");

					// Dash lasts twice as long
					durationRemaining = dashDuration * 2;

					// Activate the particles
					dashParticles.Play();
				}

				else {
					GetComponent<Animation>().Play("DashStart");
					Debug.Log ("Playing DashStart");
					GetComponent<RhythmBehavior>().offBeatChime.Play();
					durationRemaining = dashDuration;
				}
			}
		}

		// If there is still time in the dash
		if (durationRemaining > 0.0f) {

			// Set the vector to move to
			Vector3 moveVector = Movement.MoveToPosition(transform, position, 1);

			// If we get to the target position
			if (moveVector == new Vector3(0,0,0)) {
				// End the dash
				durationRemaining = 0.0f;


			}

			// Move the player
			controller.SimpleMove(moveVector * dashMoveSpeed);
			// Decrement the duration
			durationRemaining -= Time.deltaTime;

		}
			
		// Dash has ended
		if (dashing && durationRemaining <= 0.0f) {
			dashing = false;
			//controller.GetComponent<ClickToMove> ().idle = true;
			GetComponent<Animation>().Play("DashStop");
			Debug.Log ("Playing DashStop");

			// Kill particles
			dashParticles.Pause();
			dashParticles.Clear();
		}


		if (!dashing) {

			GetComponent<Animation>().Play("Idle");
			Debug.Log ("Playing Idle");
		}
	}
}