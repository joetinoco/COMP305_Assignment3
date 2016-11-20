using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip LaserSound;
	public GameObject MuzzleFlash;
	public Transform FlashPoint;
	public GameObject LaserImpact;
	public GameObject ExplosionEffect;
	public Transform PlayerCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetButtonDown("Fire1")) {
			
			Instantiate(this.MuzzleFlash, this.FlashPoint.position, Quaternion.identity);

			RaycastHit hit;

			if (Physics.Raycast(this.PlayerCamera.position, this.PlayerCamera.forward, out hit)) {
				if (hit.transform.gameObject.CompareTag("Enemy")) {
					Destroy (hit.transform.gameObject);
					GameObject explosion = (GameObject)Instantiate(ExplosionEffect, hit.point, Quaternion.identity);
					explosion.SetActive(true);
					Destroy(explosion, 1);
					this.SendMessage("enemyDied");
					this.SendMessage("updateScore", 100);
				} else {
					GameObject sparks = (GameObject)Instantiate(LaserImpact, hit.point, Quaternion.identity);
					Destroy(sparks, 5);
				}
			}

			audioSource.PlayOneShot(this.LaserSound);

		}
	}
}
