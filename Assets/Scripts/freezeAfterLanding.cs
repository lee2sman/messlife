using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeAfterLanding : MonoBehaviour {

	Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> (); 

	}

	// Use this for initialization
	void OnCollisionEnter (Collision other) {

		Debug.Log (other.gameObject.name);
		rb.constraints = RigidbodyConstraints.FreezeAll;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
