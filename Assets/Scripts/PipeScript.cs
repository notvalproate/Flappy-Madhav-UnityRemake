using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public ScoreScript rs;
    public float pipeSpeed;
    private float despawnX;
    private bool Crossed = false;
  
    void Start()
    {
        rs = GameObject.FindGameObjectWithTag("ScoreTag").GetComponent<ScoreScript>();
        pipeSpeed = 4;
        despawnX = -11;
    }

    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;

        if(transform.position.x < despawnX)
        {
            Destroy(gameObject);
            return;
        }

        if (!Crossed && (transform.position.x < -0.90))
        {
            rs.Increment();
            Crossed = true;
        }
    }
}
