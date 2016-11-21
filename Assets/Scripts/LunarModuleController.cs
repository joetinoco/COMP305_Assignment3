using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*

LUNAR MODULE CONTROLLER
=======================

Manage the final game scene

*/

public class LunarModuleController : MonoBehaviour {

	// ==========================================
	// Attributes
	// ==========================================	

	public PlayerController player;
	public Text gameOverText;
	
	private bool liftOff = false;
	private Transform module;
	public ParticleSystem booster;

	// ==========================================
	// Object initialization
	// ==========================================
	void Start () {
		module = GetComponent<Transform>();
	}
	
	// ==========================================
	// Game Lifecycle Updates
	// ==========================================
	void Update () {
		if (liftOff) {
			module.transform.position = new Vector3(
				module.transform.position.x,
				module.transform.position.y + 0.2f,
				module.transform.position.z
			);
		}
		
	}

	// Collision detection methods
	// =================================================
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			if(player.pickupsFound < 5) {
				gameOverText.text = "You have not found all\nmissing pieces." ;
				gameOverText.gameObject.SetActive(true);
			} else {
				// Player won the game
				player.gameOver();
				this.booster.Play();
				this.liftOff = true;
			}
		}
	}

	void OnCollisionExit(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			if(player.pickupsFound < 5) {
				gameOverText.gameObject.SetActive(false);
			}
		}
	}
}
