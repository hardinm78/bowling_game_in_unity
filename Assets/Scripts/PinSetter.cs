using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text standingDisplay;
	public GameObject pinSet;

	private float lastChangeTime;	
	private bool ballEnteredBox = false;
	private Ball ball;
	private Pin[] pins;


	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();

		CountStanding ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString ();

		if (ballEnteredBox){
			UpdateStandingCountAndSettle ();
		}
	}
	void UpdateStandingCountAndSettle(){
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



	public void RaisePins(){
		
		foreach(Pin pin in pins){
			if (pin.isStanding()){
				pin.Raise ();
			}
		}

	}

	public void LowerPins(){
		foreach(Pin pin in pins){
			pin.Lower ();
		}
	}
	public void RenewPins(){
		Instantiate (pinSet, new Vector3 (0, 40, 1829), Quaternion.identity);
	}
}
