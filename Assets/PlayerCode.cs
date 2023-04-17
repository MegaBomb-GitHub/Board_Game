using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public EventController eventController;
    public Route currentRoute;
    public StateManager stateManager;

    public bool allowTurn;

    public int maxDiceNumber = 6;

    [SerializeField] float speed = 5f;
    [SerializeField] int routePos = 1;
    public int steps;
    public bool isMoving;

    [SerializeField] int passThrough;
    void Start()
    {
        Debug.Log(currentRoute.childNodeList.Count + " spaces");
    }

    void Update()
    {

    }

    IEnumerator Move()
    {
        if (isMoving) { yield break; }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextPos;
            nextPos = currentRoute.childNodeList[routePos].position;

            while (moveToNext(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            routePos++;

            if (routePos == currentRoute.childNodeList.Count)
            {
                if (currentRoute.childNodeList[routePos - 1].tag == "Finish")
                {
                    stateManager.winLevel(this.name);
                    yield break;
                }
                else
                {
                    nextPos = currentRoute.childNodeList[0].position;
                    routePos = 0;
                }
            }

            steps--;
            
        }
        isMoving = false;
    }

    bool moveToNext(Vector3 goal) {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime));
    }
    
    public void RTD(int diceRoll)
    {
        if (allowTurn && !isMoving)
        {
            steps = diceRoll;
            Debug.Log(this.name + " Rolled " + steps);

            StartCoroutine(Move());
            allowTurn = false;
        }
    }


}
