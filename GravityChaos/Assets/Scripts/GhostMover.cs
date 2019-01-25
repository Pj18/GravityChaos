using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public float ghostSpeed=5f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, ghostSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
            if(transform.position.y>=4.2f)
            {
               
                rb2d.velocity = Vector2.zero;
                rb2d.velocity = new Vector2(0, -ghostSpeed);
            }
            else if(transform.position.y<=-1.65f)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.velocity = new Vector2(0, ghostSpeed);
            }
        
    }
}
