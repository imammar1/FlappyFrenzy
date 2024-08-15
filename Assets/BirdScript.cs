using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Define fixed boundary values
    public float upperBoundary = 5f;
    public float lowerBoundary = -5f;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive)
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        // Constrain bird position within the fixed boundaries
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
