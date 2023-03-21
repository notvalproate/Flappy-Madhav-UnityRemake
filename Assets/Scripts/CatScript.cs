using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    private LevelScript Level;
    public Rigidbody2D rb;

    void Start()
    {
        //Get reference to the Level Script using the tag, and change the cat's RigidBody gravity strength
        Level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelScript>();
        rb.gravityScale = Level.gravityStrength;
    }

    void Update()
    {
        //If either left-click, space, or up arrow is pressed, set the velocity to an upwards vector
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.up * Level.jumpStrength;
        }
    }
}
