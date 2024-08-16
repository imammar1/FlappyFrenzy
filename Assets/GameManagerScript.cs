using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    public GameObject startScreenCanvas;
    public BirdScript birdScript;
    public PipeSpawnScript pipeSpawnScript;
    public GameObject cloudSpawner; // Reference to the CloudSpawner GameObject
    public Text scoreText;

    private bool gameStarted = false;

    void Start()
    {
        // Show the start screen, hide the score, and disable cloud spawning at the beginning
        startScreenCanvas.SetActive(true);
        scoreText.gameObject.SetActive(false);
        birdScript.gameObject.SetActive(false); // Hide the bird initially
        cloudSpawner.SetActive(false); // Disable cloud spawning initially

        // Disable bird and pipes at the start
        birdScript.enabled = false;
        pipeSpawnScript.enabled = false;
    }

    public void StartGame()
    {
        // Hide the start screen and enable game objects and score text
        startScreenCanvas.SetActive(false);
        birdScript.gameObject.SetActive(true); // Show the bird when the game starts
        birdScript.enabled = true;
        pipeSpawnScript.enabled = true;
        scoreText.gameObject.SetActive(true); // Show the score text
        cloudSpawner.SetActive(true); // Enable cloud spawning when the game starts
        birdScript.StartGame(); // Start the bird's game logic
        gameStarted = true;
    }

    void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }
}