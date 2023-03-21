using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float jumpStrength;
    public float gravityStrength;

    // Start is called before the first frame update
    void Start()
    {
        rb.gravityScale = gravityStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.up * jumpStrength;
        }
    }
}
