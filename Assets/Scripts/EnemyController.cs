using UnityEngine;
using System.Collections;

/*

ENEMY CONTROLLER
================

Manage enemy movement and death.

*/

public class EnemyController : MonoBehaviour {

	// ==========================================
	// Attributes
	// ==========================================

	public NavMeshAgent Agent;
	// The distance which the enemy starts to chase the player
	public float TriggeringDistance = 10f;
	
	private Transform Player;
	private Transform Enemy;
	private Rigidbody rigidBody;

	// ==========================================
	// Object initialization
	// ==========================================
	void Start () {
		this.Player = GameObject.FindWithTag("Player").transform;
		this.Enemy = this.transform;
		this.rigidBody = GetComponent<Rigidbody>();
	}
	
	// ==========================================
	// Game Lifecycle Updates
	// ==========================================
	void Update () {
		if (Player.position == null) return;
		 
		// Stop/start enemy movement according to player position 
		if (Vector3.Distance(Player.position, Enemy.position) <= TriggeringDistance) {
			this.Agent.SetDestination(this.Player.position);
			this.Agent.Resume();
		} else {
			this.Agent.Stop();
		}
	
	}

	// Collision detection methods
	// =================================================
	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.SendMessage("enemyHit");
		}
	}

}
