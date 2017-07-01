using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class SprintSkill : MonoBehaviour {
	private ThirdPersonCharacter thePlayer;

	// skills
	public RectTransform sprint_cooldown;

	private bool sprinting;		// hotkey 1
	private bool sprint_on_cooldown;
	private float cd_sprint;
	private float sprint_cooldown_interval;		// interval used to update the cooldown UI
	private float sprint_length;	// length of time sprint skill lasts

	const float NORM_SPEED = 1.0f;
	const float SPRINT_SPEED = 2.0f;
	const float SPRINT_COOLDOWN_TIME = 5.0f;
	const float SPRINT_LENGTH_TIME = 1.0f;

	Vector2 COOLDOWN_EMPTY = new Vector2 (0.0f, 0.0f);
	Vector2 COOLDOWN_FULL = new Vector2(70.0f, 70.0f);


	// Use this for initialization
	void Start () {
		thePlayer = this.GetComponent<ThirdPersonCharacter> ();	

		// skill initialisation
		sprinting = false;
		sprint_on_cooldown = false;
		cd_sprint = 0.0f;
		sprint_cooldown_interval = 0.0f;

		// set skill cooldown to usable
		// this changes the UI
		sprint_cooldown.sizeDelta = COOLDOWN_EMPTY;
	}
	
	// Update is called once per frame
	void Update () {
		// Player is sprinting
		if (!sprinting && !sprint_on_cooldown) {
			if (Input.GetKeyDown (KeyCode.Alpha1)) {
				sprinting = true;
				sprint_on_cooldown = true;
				thePlayer.set_m_AnimSpeedMultiplier (SPRINT_SPEED);
				thePlayer.set_m_MoveSpeedMultiplier (SPRINT_SPEED);
				sprint_cooldown.sizeDelta = COOLDOWN_FULL;
				cd_sprint = Time.time;
				sprint_cooldown_interval = Time.time;
				print ("Start sprint!");
			}
		}

		// update the cooldown animation
		if (sprint_on_cooldown) {
			updateSprintCooldownAnimation ();
		}

		// the player can run for SPRINT_LENGTH_TIME
		// then afterwards, he will be set back to normal speed
		if (sprinting && Time.time - cd_sprint >= SPRINT_LENGTH_TIME) {
			sprinting = false;
			thePlayer.set_m_AnimSpeedMultiplier (NORM_SPEED);
			thePlayer.set_m_MoveSpeedMultiplier (NORM_SPEED);
		}

		// if sprint skill is on cooldown, and we've waited for the cooldown timer
		// then we reset the UI image back to empty, and allow user to use the skill again
		if (!sprinting && sprint_on_cooldown && Time.time - cd_sprint >= SPRINT_COOLDOWN_TIME) {
			sprint_cooldown.sizeDelta = COOLDOWN_EMPTY;
			sprint_on_cooldown = false;
			print ("5 seconds elapsed!");
		}
	}

	void updateSprintCooldownAnimation() {
		float interval = 0.1f;
		if (Time.time - sprint_cooldown_interval >= interval) {
			sprint_cooldown_interval = Time.time;
			Vector2 v = sprint_cooldown.sizeDelta;

			// 70 because the height of the skill is 70
			sprint_cooldown.sizeDelta = new Vector2 (v.x, v.y - ((70/SPRINT_COOLDOWN_TIME) * interval));
		}
	}
}
