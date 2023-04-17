using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StateManager : MonoBehaviour
{
    [SerializeField] private int LoadLevel;

    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;

    public TMP_Text player1Score;
    public TMP_Text player2Score;

    static int player1Points;
    static int player2Points;

    [SerializeField] private int pointsEarned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void winLevel(string winner)
    {
        if (winner == "P1")
        {
            player1Points += pointsEarned;
        } else if (winner == "P2")
        {
            player2Points += pointsEarned;
        }
        player1Score.text = player1Points.ToString();
        player2Score.text = player2Points.ToString();

        Debug.Log(player1Points + " , " + player2Points);
        SceneManager.LoadScene(LoadLevel);
    }
}
