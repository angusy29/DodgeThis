using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class ZomBunnyScript : MonoBehaviour {
	private GameObject thePlayer;
	public float MAX_DELAY;

	private float delay;		// this is the delay before start walking

	private float time;		// used to calculate elapsed time
	private float speed;

	// Use this for initialization
	void Start () {
		thePlayer = GameObject.Find ("ThirdPersonController");
		delay = Random.Range (0.0f, MAX_DELAY);
		time = Time.time;
		speed = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
		float elapsedTime = Time.time;

		if (elapsedTime - time >= delay) {
			GetComponent<Animation> ().Play ();
			transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "ThirdPersonController") {
			thePlayer.transform.position = new Vector3 (0.0f, 3.0f, 0.0f);
		}
	}
}
