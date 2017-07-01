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
	private int max_monsters;	// max number of monsters at this wall
	public float minWallX;
	public float maxWallX;
	public float minWallZ;
	public float maxWallZ;

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
		max_monsters = Random.Range (5, 15);
	
		for (int i = 0; i < max_monsters; i++) {
			float spawnLocationX = Random.Range (minWallX, maxWallX);
			float spawnLocationZ = Random.Range (minWallZ, maxWallZ);
			Quaternion spawnRotation = Quaternion.identity;

			spawnRotation = setSpawnRotation (spawnRotation);

			GameObject monster = (GameObject) Instantiate(zombunny, new Vector3(spawnLocationX, SPAWN_HEIGHT, spawnLocationZ), spawnRotation);
			monster.transform.parent = gameObject.transform;
			allMonsters.Add (monster);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	Quaternion setSpawnRotation(Quaternion spawnRotation) {
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
