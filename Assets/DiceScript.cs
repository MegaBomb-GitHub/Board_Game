using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {

	public DiceCheckZoneScript checkZone;
	[SerializeField] Vector3 diceSpawn;

	static Rigidbody rb;
	public Vector3 diceVelocity;

	public bool stoppedRolling;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		diceVelocity = rb.velocity;
		if(diceVelocity != Vector3.zero)
        {
			stoppedRolling = false;
        }
        else
        {
			stoppedRolling = true;
        }
	}

	public void StartRoll()
    {
		checkZone.DiceNum = 0;
		float dirX = Random.Range(0, 500);
		float dirY = Random.Range(0, 500);
		float dirZ = Random.Range(0, 500);
		transform.position = diceSpawn;
		transform.rotation = Quaternion.identity;
		rb.AddForce(transform.up * 500);
		rb.AddTorque(dirX, dirY, dirZ);
	}

	void OnDrawGizmos()
    {
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(diceSpawn, 1);
    }
}
