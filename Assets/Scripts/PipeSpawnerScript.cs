using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    //Gameobject to instantiate pipes
    public GameObject Pipe;

    //Spawn rate and the offset between which pipe's will spawn
    public float spawnRate;
    public float heightOffset;
    //Timer initialized to a really high value so that Pipe appears as soon as game starts
    private float Timer = 100;

    void Update()
    {
        //When timer exceeds the spawnrate time, spawn a pipe and reset timer
        if(Timer >= spawnRate)
        {
            spawnPipe();
            Timer = 0;
            return;
        }
        //Otherwise add time passed to the timer
        Timer += Time.deltaTime;
    }

    void spawnPipe()
    {
        //Get the Y position of the new pipe
        float yPosition = Random.Range(-heightOffset, heightOffset);

        //Create a new vector that will be assigned to the new pipe
        Vector3 newPos = new Vector3(transform.position.x, yPosition, transform.position.z);

        //Instantiate a new pipe with that transform.position as newPos
        Instantiate(Pipe, newPos, transform.rotation);
    }
}
