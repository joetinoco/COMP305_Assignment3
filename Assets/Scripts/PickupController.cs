using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

	private Transform pickup;

	void Start () {
		this.pickup = this.transform;
	}
	
	void Update () {
		this.pickup.Rotate(Vector3.forward, 1f);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Player")) {
			other.SendMessage("PickupFound");
			Destroy(this.gameObject);
		}
	}
}
