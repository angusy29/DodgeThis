using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class LeapSkill : MonoBehaviour {
	private ThirdPersonCharacter thePlayer;

	// skills
	public RectTransform leap_cooldown;

	private bool leaping;		// hotkey 1
	private bool leap_on_cooldown;
	private float cd_leap;
	private float leap_cooldown_interval;		// interval used to update the cooldown UI
	private float leap_length;	// length of time sprint skill lasts

	const float NORM_JUMP = 6.0f;
	const float JUMP_POWER = 10.0f;
	const float LEAP_COOLDOWN_TIME = 5.0f;
	const float LEAP_LENGTH_TIME = 5.0f;

	Vector2 COOLDOWN_EMPTY = new Vector2 (0.0f, 0.0f);
	Vector2 COOLDOWN_FULL = new Vector2(70.0f, 70.0f);


	// Use this for initialization
	void Start () {
		thePlayer = this.GetComponent<ThirdPersonCharacter> ();	

		// skill initialisation
		leaping = false;
		leap_on_cooldown = false;
		cd_leap = 0.0f;
		leap_cooldown_interval = 0.0f;

		// set skill cooldown to usable
		// this changes the UI
		leap_cooldown.sizeDelta = COOLDOWN_EMPTY;
	}

	// Update is called once per frame
	void Update () {
		// Player is sprinting
		if (!leaping && !leap_on_cooldown) {
			if (Input.GetKeyDown (KeyCode.Alpha2)) {
				leaping = true;
				leap_on_cooldown = true;
				thePlayer.set_m_jumpPower (JUMP_POWER);
				leap_cooldown.sizeDelta = COOLDOWN_FULL;
				cd_leap = Time.time;
				leap_cooldown_interval = Time.time;
				print ("Start sprint!");
			}
		}

		// update the cooldown animation
		if (leap_on_cooldown) {
			updateLeapCooldownAnimation ();
		}

		// the player can run for SPRINT_LENGTH_TIME
		// then afterwards, he will be set back to normal speed
		if (leaping && Time.time - cd_leap >= LEAP_LENGTH_TIME) {
			leaping = false;
			// set jump power to normal
			thePlayer.set_m_jumpPower(NORM_JUMP);
		}

		// if sprint skill is on cooldown, and we've waited for the cooldown timer
		// then we reset the UI image back to empty, and allow user to use the skill again
		if (!leaping && leap_on_cooldown && Time.time - cd_leap >= LEAP_COOLDOWN_TIME) {
			leap_cooldown.sizeDelta = COOLDOWN_EMPTY;
			leap_on_cooldown = false;
			print ("5 seconds elapsed!");
		}
	}

	void updateLeapCooldownAnimation() {
		float interval = 0.1f;
		if (Time.time - leap_cooldown_interval >= interval) {
			leap_cooldown_interval = Time.time;
			Vector2 v = leap_cooldown.sizeDelta;

			// 70 because the height of the skill is 70
			leap_cooldown.sizeDelta = new Vector2 (v.x, v.y - ((70/LEAP_COOLDOWN_TIME) * interval));
		}
	}
}
