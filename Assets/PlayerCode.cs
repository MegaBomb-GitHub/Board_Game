using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public Route currentRoute;

    int routePos;
    public int steps;
    bool isMoving;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 6);
            Debug.Log(steps + " Rolled");

            if(routePos + steps < currentRoute.childNodeList.Count)
            {
                StartCoroutine(Move());
            }
        }
    }

    IEnumerator Move()
    {
        if (isMoving) { yield break; }
        isMoving = true;

        while(steps > 0) {
            Vector3 nextPos = currentRoute.childNodeList[routePos + 1].position;

            while (moveToNext(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePos++;
        }

        isMoving = false;
    }

    bool moveToNext(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 2f * Time.deltaTime));
        
    }
}
