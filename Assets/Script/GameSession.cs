using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    int score = 0;


    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    public int GetScore()
    {
        return this.score;
    }

    public void AddToScore(int scoreValue)
    {
        this.score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
