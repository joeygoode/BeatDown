using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour {

	// Use this for initialization
	void Start () {

		gameObject.GetComponent<Light>().intensity = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(GameObject.Find ("MC_Walk2").GetComponent<RhythmBehavior>().onBeat) {

			gameObject.GetComponent<Light>().intensity = 1;
		}
		
		else {

			gameObject.GetComponent<Light>().intensity -= .01f;
		}
	}

}