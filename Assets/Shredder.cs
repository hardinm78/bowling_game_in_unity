﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit(Collider other){

		if (other.gameObject.tag == "Pin"){
			Destroy (other.gameObject);
		}

	}

}
