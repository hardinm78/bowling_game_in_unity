using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;
	public float distanceToRaise = 40f;
	private Rigidbody rigi;

	private Pin[] pins;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update (){
		isStanding ();		
	}

	public bool isStanding(){

		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
		float tiltInZ = Mathf.Abs(rotationInEuler.z);

		if (tiltInX < standingThreshold && tiltInZ < standingThreshold){
			return true;
		}else {
			return false;
			}
	}

	public void Raise(){
		rigi.useGravity = false;

			if (isStanding()){
				transform.Translate (new Vector3 (0 ,distanceToRaise,0), Space.World);
			}
		}

	

	public void Lower(){
		
		transform.Translate (new Vector3 (0 ,-distanceToRaise,0), Space.World);
		rigi.useGravity = true;
	}

}
