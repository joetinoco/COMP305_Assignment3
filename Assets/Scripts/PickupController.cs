using UnityEngine;
using System.Collections;

/*

PICKUP CONTROLLER
=================

Manage piece pickups

*/

public class PickupController : MonoBehaviour {

	// ==========================================
	// Attributes
	// ==========================================
	private Transform pickup;

	// ==========================================
	// Object initialization
	// ==========================================
	void Start () {
		this.pickup = this.transform;
	}

	// ==========================================
	// Game Lifecycle Updates
	// ==========================================	
	void Update () {
		this.pickup.Rotate(Vector3.forward, 1f);
	}

	// Collision detection methods
	// =================================================
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			other.SendMessage("PickupFound");
			Destroy(this.gameObject);
		}
	}
}
