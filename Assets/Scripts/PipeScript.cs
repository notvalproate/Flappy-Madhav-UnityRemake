using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    //Reference to the Score's script and Level's script
    private ScoreScript rs;
    private LevelScript Level;
    //X value at which pipe should be destroyed, and bool to check if it has passed the cat
    private float despawnX = -11;
    private bool Crossed = false;
  
    void Start()
    {
        //Initialize the script references using the tags
        Level = GameObject.FindGameObjectWithTag("Level").GetComponent<LevelScript>();
        rs = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<ScoreScript>();
    }

    void Update()
    {
        //Move the pipe towards the left
        transform.position += Vector3.left * Level.levelSpeed * Time.deltaTime;

        //If pipe goes further than the left of the screen, destroy it
        if(transform.position.x < despawnX)
        {
            Destroy(gameObject);
            return;
        }

        //If pipe hasnt yet crossed the cat, and its X value is less than the cat, Increment the score and set crossed = true
        //Using this as an alternative to creating a trigger component
        if (!Crossed && (transform.position.x < -0.90))
        {
            rs.Increment();
            Crossed = true;
        }
    }
}
