using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour {

	public Vector3 diceVelocity;

	public int DiceNum;
	public bool isCalled = false;

	// Update is called once per frame
	void FixedUpdate () {
		diceVelocity = DiceScript.diceVelocity;
	}

	void OnTriggerStay(Collider col)
	{
		if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f && !isCalled)
		{
			switch (col.gameObject.name) {
			case "1 Check":
				DiceNum = 6;
				break;
			case "2 Check":
				DiceNum = 5;
				break;
			case "3 Check":
				DiceNum = 4;
				break;
			case "4 Check":
				DiceNum = 3;
				break;
			case "5 Check":
				DiceNum = 2;
				break;
			case "6 Check":
				DiceNum = 1;
				break;
			}

			isCalled = true;
		}
	}
}
