using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate;
    public float heightOffset;
    private float Timer;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = (float)1.25;
        heightOffset = (float)2.5;
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if(Timer >= spawnRate)
        {
            spawnPipe();
            Timer = 0;
            return;
        }
        Timer += Time.deltaTime;
    }

    void spawnPipe()
    {
        float yPosition = Random.Range(-heightOffset, heightOffset);
        Vector3 newPos = new Vector3(transform.position.x, yPosition, transform.position.z);
        Instantiate(Pipe, newPos, transform.rotation);
    }
}
