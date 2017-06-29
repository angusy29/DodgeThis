using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class SkillsScript : MonoBehaviour {
	private ThirdPersonCharacter thePlayer;

	// skills
	private bool sprinting;		// hotkey 1
	public RectTransform sprint_cooldown;

	const float NORM_SPEED = 1.0f;
	const float SPRINT_SPEED = 2.0f;

	Vector2 COOLDOWN_EMPTY = new Vector2 (0.0f, 0.0f);
	Vector2 COOLDOWN_FULL = new Vector2(70.0f, 70.0f);

	// Use this for initialization
	void Start () {
		thePlayer = this.GetComponent<ThirdPersonCharacter> ();	

		// skill initialisation
		sprinting = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!sprinting) {
			sprint_cooldown.sizeDelta = COOLDOWN_EMPTY;
		}

		// Player is sprinting
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			sprinting = true;
			thePlayer.set_m_AnimSpeedMultiplier (SPRINT_SPEED);
			thePlayer.set_m_MoveSpeedMultiplier (SPRINT_SPEED);
			sprint_cooldown.sizeDelta = COOLDOWN_FULL;
		}
	}
}
