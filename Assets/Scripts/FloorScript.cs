using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private LevelScript Level;

    void Start()
    {
        //Get reference to the Level Script using the tag
        Level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelScript>();
    }
    void Update()
    {
        //Move the floor towards the left
        transform.position += Vector3.left * Level.levelSpeed * Time.deltaTime;

        //When floor's right edge reaches the right of the screen, reset the position of the floor
        //The values -8.114 and 8.15 were found out by just testing/moving the floor in the scene
        if(transform.position.x < -8.114f)
        {
            transform.position = new Vector3(8.15f, transform.position.y, transform.position.z);
        }
    }
}
