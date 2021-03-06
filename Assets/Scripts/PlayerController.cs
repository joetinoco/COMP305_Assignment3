﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/*

PLAYER CONTROLLER
=================

Control player object movement, animations, physics and collisions.

*/

public class PlayerController : MonoBehaviour {


	// ==========================================
	// Attributes
	// ==========================================
	public Text scoreText;
	public Text healthText;
	public Text pickupsText;
	public Text gameOverText;
	public Image miniMap;

	[Header("SoundClips")]
	public AudioSource audioSource;
	public AudioClip enemyDeadSound;
	public AudioClip playerDamageSound;
	public AudioClip pickupSound;
	public AudioClip gameOverSound;


	public int pickupsFound = 0;
	private int playerHealth = 100;
	private int playerScore = 0;

	// ==========================================
	// Object initialization
	// ==========================================
	void Start() {

		gameOverText.gameObject.SetActive(false);

	}
	
	// ==========================================
	// Game Lifecycle Updates
	// ==========================================
	void Update() {
		updateUI();
	}

	// Auxiliary methods
	// ==========================================
	

	// UI updates for score changes
	private void updateUI(){
		scoreText.text = "Score: " + playerScore;
		healthText.text = "Health: " + playerHealth;
		pickupsText.text = "Pieces found: " + pickupsFound + "/5";
	}

	// Public methods
	// ==========================================

	public void PickupFound() {
		pickupsFound++;
		audioSource.PlayOneShot(this.pickupSound);
	}

	public void HowManyPickups(out int pickups) {
		pickups = pickupsFound;
	}
	
	// Allow player to update the score
	public void updateScore(int delta) {
		playerScore += delta;
	}

	// Update score and play sounds when enemies die
	public void enemyHit() {
		playerHealth -= 20;
		audioSource.PlayOneShot(this.playerDamageSound);
		updateUI();
		if (playerHealth <= 0) {
			gameOver();
		}
	}

	// Update score and play sounds when enemies die
	public void enemyDied() {
		audioSource.PlayOneShot(this.enemyDeadSound);
	}

	// Update GUI when the game ends
	public void gameOver() {
		if (playerHealth <= 0) {
			gameOverText.text = "Game over.\n";
			audioSource.PlayOneShot(this.gameOverSound);
		} else {
			gameOverText.text = "You won!\n";
		}
		miniMap.gameObject.SetActive(false);
		gameOverText.text += "SCORE: " + playerScore;
		gameOverText.gameObject.SetActive(true);
		Destroy(this.gameObject);
	}

}
