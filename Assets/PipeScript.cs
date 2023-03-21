using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeScript : MonoBehaviour
{
    public float pipeSpeed;
    public float despawnX;
    // Start is called before the first frame update
    void Start()
    {
        pipeSpeed = 4;
        despawnX = -11;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * pipeSpeed * Time.deltaTime;

        if(transform.position.x < despawnX)
        {
            Destroy(gameObject);
        }
    }
}
