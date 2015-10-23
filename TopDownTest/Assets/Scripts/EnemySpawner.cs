using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class EnemySpawner : MonoBehaviour {
	public int MaxSpawns;
	public float SpawnInterval;
	public GameObject Spawn;

	private float spawnCountdown;
	public List<GameObject> spawns;

	// Use this for initialization
	void Start () {
		spawns = new List<GameObject> ();
	}

	// Update is called once per frame
	void Update () {
		spawns = spawns.Where (s => s != null).ToList ();

		if (spawnCountdown > 0) {
			spawnCountdown -= Time.deltaTime;
		} else {
			if (spawns.Count < MaxSpawns) {
				spawns.Add ((GameObject) Instantiate(Spawn, transform.position, transform.rotation));
			}
			spawnCountdown = SpawnInterval;
		}
	}
}
