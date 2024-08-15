using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;

    public GameObject startScreen; // Reference to the Start Screen UI

    private GameObject bird; // Reference to the Bird GameObject

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void StartGame()
    {
        // Hide the start screen and show the game UI
        if (startScreen != null)
        {
            startScreen.SetActive(false);
        }

        // Initialize the game state
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }

        if (bird != null)
        {
            bird.SetActive(true);
            BirdScript birdScript = bird.GetComponent<BirdScript>();
            if (birdScript != null)
            {
                birdScript.birdIsAlive = true; // Start the game
            }
        }
    }

    public void SetBird(GameObject birdObject)
    {
        bird = birdObject;
    }
}
