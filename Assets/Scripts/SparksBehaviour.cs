using UnityEngine;
using System.Collections;

/*

SPARKS BEHAVIOUR
================

Control the effect when the laser hits a surface other than an enemy

*/

public class SparksBehaviour : MonoBehaviour {

	// ==========================================
	// Attributes
	// ==========================================
	public float EmitterDuration;
	public ParticleSystem ParticleSystem;

	// ==========================================
	// Object initialization
	// ==========================================
	void Start () {
	
	}
	
	// ==========================================
	// Game Lifecycle Updates
	// ==========================================
	void Update () {

		EmitterDuration -= Time.deltaTime;
		if (EmitterDuration <= 0) {
			ParticleSystem.Stop();
		}
	
	}
}
