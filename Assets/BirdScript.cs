using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength = 5f;  // Adjust this value to lower the bird's jump height
    public LogicScript logic;
    public bool birdIsAlive = true;

    public float upperBoundary = 5f;
    public float lowerBoundary = -5f;

    private bool gameStarted = false;

    void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.gravityScale = 0; // Disable gravity as soon as the object awakens
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        if (gameStarted && Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > upperBoundary)
        {
            Vector3 pos = transform.position;
            pos.y = upperBoundary;
            transform.position = pos;
        }
        else if (transform.position.y < lowerBoundary)
        {
            Vector3 pos = transform.position;
            pos.y = lowerBoundary;
            transform.position = pos;
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        myRigidBody.gravityScale = 5; // Enable gravity when the game starts
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}

