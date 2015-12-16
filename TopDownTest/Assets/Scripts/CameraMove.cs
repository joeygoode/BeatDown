using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public GameObject target;
	public float xOffset = 100;
	public float yOffset = 100;
	public float zOffset = 100;
	


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
	
		this.transform.position = new Vector3(target.transform.position.x + xOffset,
		                                      target.transform.position.y + yOffset,
		                                      target.transform.position.z + zOffset);

		// C# or UnityScript
		var d = Input.GetAxis("Mouse ScrollWheel");
		if (d > 0f)
		{
			// scroll up
			if (yOffset > 15 && zOffset < -10) {
				
				yOffset -= .5f;
				zOffset += .5f;
					
			}
		}
		else if (d < 0f)
		{
			// scroll down

			if (yOffset < 25 && zOffset > -20) {

				yOffset += .5f;
				zOffset -= .5f;

			}
		}
	}
}
