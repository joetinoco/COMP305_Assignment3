using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public NavMeshAgent Agent;
	// The distance which the enemy starts to chase the player
	public float TriggeringDistance = 10f;
	
	private Transform Player;
	private Transform Enemy;
	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		this.Player = GameObject.FindWithTag("Player").transform;
		this.Enemy = this.transform;
		this.rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Player.position == null) return;
		 
		if (Vector3.Distance(Player.position, Enemy.position) <= TriggeringDistance) {
			this.Agent.SetDestination(this.Player.position);
			this.Agent.Resume();
		} else {
			this.Agent.Stop();
		}
	
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			other.gameObject.SendMessage("enemyHit");
		}
	}

}
