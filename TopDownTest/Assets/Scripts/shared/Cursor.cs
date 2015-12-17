using UnityEngine;
using System.Collections;

public static class Cursor {

	public static bool ToTerrainPosition(out Vector3 location) {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 1000)) {
			if (hit.collider.tag != "Player") { // && hit.collider.tag != "Enemy") {
				location = hit.point;
				return true;
			}
		}
		location = new Vector3 ();
		return false;
	}
}
