using UnityEngine;
using System.Collections;

public static class Movement {

	public static Vector3 MoveToPosition(Transform currentTransform, Vector3 destination, float turnSpeed) {
		if(Vector3.Distance(currentTransform.position, destination)>4)
		{
			Quaternion newRotation = Quaternion.LookRotation(destination-currentTransform.position);
			
			newRotation.x = 0f;
			newRotation.z = 0f;
			
			currentTransform.rotation = Quaternion.Slerp(currentTransform.rotation, newRotation, turnSpeed);
			return currentTransform.forward;
			//GetComponent<Animation>().CrossFade(run.name);
		}
		return new Vector3 (0, 0, 0);
	}
}
