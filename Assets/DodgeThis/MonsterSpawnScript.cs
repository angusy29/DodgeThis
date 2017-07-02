using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnScript : MonoBehaviour {
	public GameObject zombear;
	public GameObject zombunny;
	public GameObject hellelephant;
	public int thisWallID;	// 0, 1, 2, 3

	/*
	 * Spawn attributes
	 */
	private ArrayList allMonsters;	// all monsters at this wall
	public int max_monsters;	// max number of monsters at this wall
	public float minWallX;		// minimum X coordinate to spawn
	public float maxWallX;		// maximum X coordinate to spawn
	public float minWallZ;		// minimum Z coordinate to spawn
	public float maxWallZ;		// maximum Z coordinate to spawn
	private float spawnTimer;		// keeps track of the timer, to know when to respawn
	private float spawnInterval;		// spawn interval, to spawn more units
	public float MAX_SPAWN_INTERVAL;		// max spawn interval

	private const float SPAWN_HEIGHT = 1.5f;

	/* This is the nth wall
	 * Monster spawns from nth wall
	 * and makes its way to the opposite wall
	 * (n + 2) % 4
	 */
	private const int NORTH_WALL = 0;
	private const int EAST_WALL = 1;
	private const int SOUTH_WALL = 2;
	private const int WEST_WALL = 3;

	// Use this for initialization
	void Start () {
		allMonsters = new ArrayList ();
		int num_monsters = Random.Range (1, max_monsters);
		spawnInterval = Random.Range (5, MAX_SPAWN_INTERVAL);

		for (int i = 0; i < num_monsters; i++) {
			float spawnLocationX = Random.Range (minWallX, maxWallX);
			float spawnLocationZ = Random.Range (minWallZ, maxWallZ);
			Quaternion spawnRotation = Quaternion.identity;

			spawnRotation = setSpawnRotation (spawnRotation);

			GameObject monster = (GameObject) Instantiate(zombunny, new Vector3(spawnLocationX, SPAWN_HEIGHT, spawnLocationZ), spawnRotation);
			monster.transform.parent = gameObject.transform;
			allMonsters.Add (monster);
		}

		spawnTimer = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		float elapsedTime = Time.time;

		if (elapsedTime - spawnTimer >= spawnInterval) {
			int num_monsters = Random.Range (5, max_monsters);
			spawnInterval = Random.Range (5, MAX_SPAWN_INTERVAL);

			for (int i = 0; i < num_monsters; i++) {
				float spawnLocationX = Random.Range (minWallX, maxWallX);
				float spawnLocationZ = Random.Range (minWallZ, maxWallZ);
				Quaternion spawnRotation = Quaternion.identity;

				spawnRotation = setSpawnRotation (spawnRotation);

				GameObject monster = (GameObject) Instantiate(zombunny, new Vector3(spawnLocationX, SPAWN_HEIGHT, spawnLocationZ), spawnRotation);
				monster.transform.parent = gameObject.transform;
				allMonsters.Add (monster);
			}

			spawnTimer = Time.time;
		}
	}

	/*
	 * Rotate the monster so that it is facing the center
	 */
	private Quaternion setSpawnRotation(Quaternion spawnRotation) {
		if (thisWallID == NORTH_WALL)
			spawnRotation = Quaternion.Euler (new Vector3 (0.0f, 180f, 0.0f));

		if (thisWallID == EAST_WALL)
			spawnRotation = Quaternion.Euler (new Vector3 (0.0f, -90.0f, 0.0f));

		if (thisWallID == SOUTH_WALL)
			spawnRotation = Quaternion.Euler (new Vector3 (0.0f, 0.0f, 0.0f));

		if (thisWallID == WEST_WALL)
			spawnRotation = Quaternion.Euler(new Vector3(0.0f, 90.0f, 0.0f));

		return spawnRotation;
	}
}
