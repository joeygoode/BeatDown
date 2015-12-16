using UnityEngine;
using System.Collections;

public class RhythmBehavior : MonoBehaviour {

	public int beat = 0;
	public bool onBeat = false;

	public Color playerCol = new Color(1,1,1);

	// A list of the audio sources on this object
	// This will be reworked**************
	private AudioSource[] allMyAudioSources; 

	// The sound played when the player attacks on beat
	public AudioSource onBeatAttack;

	// The sound played when the player attacks off beat
	public AudioSource offBeatAttack;

	// The sound played when the player attacks on beat
	public AudioSource clap;

	// The sound played when the player attacks on beat
	public AudioSource onBeatChime;

	// The sound played when the player attacks on beat
	public AudioSource offBeatChime;


	// Set Framerate to 30
	void Awake() {


	}

	// Use this for initialization
	void Start () {
	
		// Initialize audio sources
		allMyAudioSources = GetComponents<AudioSource>();

		// 4 - onBeatAttack, 3 - offBeatAttack 2 - Clap, 1 - OnBeatChime, 0 - OffBeatChime

		onBeatAttack = allMyAudioSources[4];

		offBeatAttack = allMyAudioSources[3];
		
		clap = allMyAudioSources[2];
		
		onBeatChime = allMyAudioSources[1];
		
		offBeatChime = allMyAudioSources[0];

	}

	// Counts the incrementations for the beat
//	void CountBeat(){
//
//		// If the beat is at 30 reset it to 0
//		if (beat == 30) {
//			beat = 0;	
//		}
//		// Else increment the beat
//		else {
//			beat++;
//		}
//	}


	//Is the game on a beat
//	void GameOnBeat() {
//
//		// If the game is close to the beat
//		if ((beat >= 0 && beat <= 4) || (beat >= 26 && beat <= 30)) {
//
//			// Set onBeat to true
//			onBeat = true;
//		}
//		// Else the game is not close to the beat
//		else {
//
//			// Set the beat to false
//			onBeat = false;
//		}
//
//	}


	
	// Update is called once per frame
	void FixedUpdate () {

//		CountBeat();
//
//		GameOnBeat();
//
//		// Play our filler beat
//		if (beat == 30) {
//
//			clap.Play ();
//		}
//
//		// Change the player's color on beat.
//		if (onBeat) {
//
//			playerCol.r = 1;
//			playerCol.g = 0;
//			playerCol.b = 0;
//
//			GetComponent<Renderer> ().material.color = playerCol;
//
//
//
//		}
//
//		// Fade the player's color to black while off beat
//		else {
//
//			playerCol.r -= .035f;
//			playerCol.g -= .035f;
//			playerCol.b -= .035f;
// 
//			GetComponent<Renderer> ().material.color = playerCol;
//		}
//	
	}
}
