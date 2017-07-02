using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class OuterPlaneScript : MonoBehaviour {
	public ThirdPersonCharacter thePlayer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
				
	}

	void OnTriggerEnter(Collider other) {
		// resets the position of the player if it is the player
		// who went onto the lava
		if (other.gameObject.name == "ThirdPersonController") {
			thePlayer.transform.position = new Vector3 (0.0f, 3.0f, 0.0f);
		}
	}
}
