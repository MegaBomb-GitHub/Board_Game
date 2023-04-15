using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public List<string> playerTurn;
    public int maxPlayers = 2;
    public int currentTurn;

    private int maxDiceNumber = 6;
    private int diceRoll;

    // Start is called before the first frame update
    void Start()
    {
        playerTurn = new List<string>();
        for (int i = 1; i < maxPlayers + 1; i++)
        {
            playerTurn.Add("Player " + i);
            Debug.Log("Player " + i);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endTurn()
    {
        if(currentTurn + 1 != maxPlayers)
        {
            currentTurn++;
        } else
        {
            currentTurn = 0;
        }

        Debug.Log("It's currently the turn of " + playerTurn[currentTurn]);
    }

    public void RTD()
    {
        diceRoll = Random.Range(1, maxDiceNumber);
    }
}
