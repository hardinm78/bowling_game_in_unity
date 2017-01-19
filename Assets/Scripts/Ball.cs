using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody rigi;

	AudioSource ballSound;

	public bool inPlay = false;

	public Vector3 launchVelocity;

	private Vector3 ballStartPos;



	// Use this for initialization
	void Start () {
		ballStartPos = transform.position;

		rigi = GetComponent<Rigidbody> ();
		ballSound = GetComponent<AudioSource> ();
		rigi.useGravity = false;

	}

	public void Launch (Vector3 velocity)
	{
		inPlay = true;
		rigi.useGravity = true;
		rigi.velocity = velocity;
		ballSound.Play ();
	}

	public void Reset(){
		inPlay = false;
		transform.position = ballStartPos;
		rigi.velocity = Vector3.zero;
		rigi.angularVelocity = Vector3.zero;
		rigi.useGravity = false;


	}

}
