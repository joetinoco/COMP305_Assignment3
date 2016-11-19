using UnityEngine;
using System.Collections;

public class SparksBehaviour : MonoBehaviour {

	public float EmitterDuration;
	public ParticleSystem ParticleSystem;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		EmitterDuration -= Time.deltaTime;
		if (EmitterDuration <= 0) {
			ParticleSystem.Stop();
		}
	
	}
}
