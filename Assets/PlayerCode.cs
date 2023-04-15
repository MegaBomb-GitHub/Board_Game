using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCode : MonoBehaviour
{
    public Route currentRoute;

    [SerializeField] float speed = 5f;
    [SerializeField] int routePos = 1;
    public int steps;
    bool isMoving;

    [SerializeField] int passThrough;
    void Start()
    {
        Debug.Log(currentRoute.childNodeList.Count + " spaces");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
        {
            steps = Random.Range(1, 6);
            Debug.Log(steps + " Rolled");
            
            StartCoroutine(Move());
        }
    }

    IEnumerator Move()
    {
        if (isMoving) { yield break; }
        isMoving = true;

        while (steps > 0)
        {
            Vector3 nextPos;
            if (routePos == currentRoute.childNodeList.Count)
            {
                if (currentRoute.childNodeList[routePos - 1].tag == "Finish")
                {
                    yield break;
                }
                else
                {
                    nextPos = currentRoute.childNodeList[0].position;
                    routePos = 0;
                }
            }

            nextPos = currentRoute.childNodeList[routePos].position;

            while (moveToNext(nextPos)) { yield return null; }

            yield return new WaitForSeconds(0.1f);
            steps--;
            routePos++;
        }
        isMoving = false;
    }

    bool moveToNext(Vector3 goal) {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, speed * Time.deltaTime));
    } 
}
