using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public PlayerCode player1;
    public PlayerCode player2;

    public DiceScript diceScript;
    public DiceCheckZoneScript checkZone;

    int currentTurn;
    // Start is called before the first frame update
    void Start()
    {
        player1.allowTurn = false;
        player2.allowTurn = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (diceScript.stoppedRolling)
            {
                if (!player1.isMoving || !player2.isMoving)
                {
                    endTurn();
                    diceScript.StartRoll();
                }
            }
        }

        if (checkZone.isCalled == true)
        {
            player1.RTD(checkZone.DiceNum);
            player2.RTD(checkZone.DiceNum);

            Debug.Log("Object Dice rolled " + checkZone.DiceNum);
            checkZone.isCalled = false;
        }
    }

    public void endTurn()
    {
        if(currentTurn == 0)
        {
            currentTurn++;

            player1.allowTurn = false;
            player2.allowTurn = true;
        } else
        {
            currentTurn = 0;

            player1.allowTurn = true;
            player2.allowTurn = false;
        }

        Debug.Log("It's currently the turn of Player " + (currentTurn + 1));
    }
}
