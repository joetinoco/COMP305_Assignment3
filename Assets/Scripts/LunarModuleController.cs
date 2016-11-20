using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LunarModuleController : MonoBehaviour {

	public PlayerController player;
	public Text gameOverText;
	
	private bool liftOff = false;
	private Transform module;
	public ParticleSystem booster;

	// Use this for initialization
	void Start () {
		module = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (liftOff) {
			module.transform.position = new Vector3(
				module.transform.position.x,
				module.transform.position.y + 0.2f,
				module.transform.position.z
			);
		}
		
	}

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
