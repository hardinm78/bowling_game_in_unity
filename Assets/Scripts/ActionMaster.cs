using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster  {

	public enum Action{Tidy,Reset,EndTurn,EndGame}
//	private int[] bowls = new int[21];
	private int bowl = 1;

	public Action Bowl(int pins){

	if (pins < 0 || pins >10){
			throw new UnityException ("invalid pin count");
	}

	if (pins == 10){
		return Action.EndTurn;
			bowl += 2;
	}

	if (bowl%2!=0){
			bowl += 1;
			return Action.Tidy;
		}else if (bowl%2==0){
			bowl += 1;
			return Action.EndTurn;
	}

		throw new UnityException ("not sure what action to return");
	}

}
