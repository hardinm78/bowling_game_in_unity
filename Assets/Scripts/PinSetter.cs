using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public float distanceToRaise = 40f;

	private float lastChangeTime;	
	private bool ballEnteredBox = false;


	private Ball ball;

	Pin[] pins;


	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();

		CountStanding ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox){
			CheckStanding ();
		}
	}
	void CheckStanding(){
		int currentStanding = CountStanding ();

		if (currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;
			if ((Time.time - lastChangeTime) > settleTime){
			PinsHaveSettled ();

			}

	}
	void PinsHaveSettled(){
		ball.Reset ();
		lastStandingCount = -1;
		ballEnteredBox = false;
		standingDisplay.color = Color.green;

	}
	int CountStanding(){
		int standingCount = 0;
		 pins = GameObject.FindObjectsOfType<Pin> ();

		foreach(Pin pin in pins){
			if (pin.isStanding()){
				standingCount++;
			}
		}
		return standingCount;		
	}



	void OnTriggerEnter(Collider other){

		if (other.tag == "Ball"){
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}

	}

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Pin"){

			Destroy (other.gameObject);
		}


	}


	public void RaisePins(){
		print("raising");
		foreach(Pin pin in pins){
			if (pin.isStanding()){
				pin.transform.Translate (new Vector3 (0 ,distanceToRaise,0), Space.World);
			}
		}

	}

	public void LowerPins(){
		print("lowering");
	}
	public void RenewPins(){
		print("renewing");
	}
}
