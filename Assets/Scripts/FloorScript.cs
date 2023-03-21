using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public float floorSpeed;

    void Start()
    {
        floorSpeed = 4;
    }

    void Update()
    {
        transform.position += Vector3.left * floorSpeed * Time.deltaTime;

        if(transform.position.x < -8.114f)
        {
            transform.position = new Vector3(8.15f, transform.position.y, transform.position.z);
        }
    }
}
