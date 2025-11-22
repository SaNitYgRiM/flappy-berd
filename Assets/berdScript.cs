using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class berdScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float flapStrength;
    public Rigidbody2D myRigidbody;
    public LogicScript logic;
    public bool birdIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame

    void jump()
    {
        myRigidbody.velocity = Vector2.up * flapStrength;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            jump();
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began)
            {
                jump();
            }
        }


        if (transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
        {
            logic.GameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        logic.GameOver();
        birdIsAlive = false;
    }


}
