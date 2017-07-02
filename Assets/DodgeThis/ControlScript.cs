using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour {
	private GameObject mainMenu;
	private GameObject game;
	private GameObject escapeMenu;

	// Use this for initialization
	void Start () {
		mainMenu = GameObject.Find ("DodgeThis").transform.FindChild ("MainMenuCanvas").gameObject;
		game = GameObject.Find ("DodgeThis").transform.FindChild ("Game").gameObject;
		escapeMenu = GameObject.Find ("DodgeThis").transform.FindChild ("EscapeMenuCanvas").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (escapeMenu.activeInHierarchy) {
				game.SetActive (true);
				escapeMenu.SetActive (false);
			} else if (game.activeInHierarchy) {
				escapeMenu.SetActive (true);
				game.SetActive (false);
			}
		}
	}
}
