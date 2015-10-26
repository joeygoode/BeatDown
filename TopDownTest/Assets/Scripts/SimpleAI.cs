using UnityEngine;
using System.Collections;

public class SimpleAI : MonoBehaviour {
	public string TargetName;
	public float MoveSpeed;

	private GameObject target;

	// Use this for initialization
	void Start () {
		target = GameObject.Find (TargetName);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 destination = target.transform.position;
		gameObject.GetComponent<CharacterController>().SimpleMove (Movement.MoveToPosition (transform,
		                                                                                    destination,
		                                                                                    Time.deltaTime * 10)
		                                                           * MoveSpeed);
	}
}
