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
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive) 
        {
            myRigidbody.velocity = Vector2.up *flapStrength;
        }
        if(transform.position.y > Camera.main.orthographicSize || transform.position.y < -Camera.main.orthographicSize)
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
