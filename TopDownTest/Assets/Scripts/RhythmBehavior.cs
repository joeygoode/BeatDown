using UnityEngine;
using System.Collections;

public class RhythmBehavior : MonoBehaviour {

	public int beat = 0;
	public bool onBeat = false;

	// Set Framerate to 30
	void Awake() {
		Application.targetFrameRate = 30;
	}

	// Use this for initialization
	void Start () {
	
	}

	// Counts the incrementations for the beat
	void CountBeat(){

		// If the beat is at 30 reset it to 0
		if (beat == 30) {
			beat = 0;	
		}
		// Else increment the beat
		else {
			beat++;
		}
	}


	//Is the game on a beat
	void GameOnBeat() {

		// If the game is close to the beat
		if ((beat >= 0 && beat <= 5) || (beat >= 25 && beat <= 30)) {

			// Set onBeat to true
			onBeat = true;
		}
		// Else the game is not close to the beat
		else {

			// Set the beat to false
			onBeat = false;
		}

	}


	
	// Update is called once per frame
	void Update () {

		CountBeat();
		GameOnBeat();
	
	}
}
