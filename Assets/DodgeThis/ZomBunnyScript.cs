using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZomBunnyScript : MonoBehaviour {
	private float delay;		// this is the delay before start walking
	private int WALL_START;	// this is the wall id the AI begins from

	private float time;		// used to calculate elapsed time
	private float speed;

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
		delay = Random.Range (0.0f, 1.0f) * 1000;	// * 1000 convert to milliseconds
		time = Time.time;
		speed = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		float elapsedTime = Time.time;

		if (elapsedTime - time >= delay) {
			float posX = this.transform.position.x;
			float posY = this.transform.position.y;
			float posZ = this.transform.position.z;
			// start walking
			if (WALL_START == NORTH_WALL) {
				// decrement z
				this.transform.position.Set(posX, posY, posZ - speed);
			}

			if (WALL_START == SOUTH_WALL) {
				// increment z
				this.transform.position.Set(posX, posY, posZ + speed);
			}

			if (WALL_START == EAST_WALL) {
				// decrement x
				this.transform.position.Set(posX - speed, posY, posZ);
			}

			if (WALL_START == WEST_WALL) {
				// increment x
				this.transform.position.Set(posX + speed, posY, posZ);
			}
		}
	}
}
