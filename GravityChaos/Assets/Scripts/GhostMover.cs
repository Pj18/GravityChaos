using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMover : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2d;
    public float ghostSpeed;
    
    void Start()
    {
        ghostSpeed = Random.Range(4.0f, 8.0f);
        int xx = Random.Range(1, 100);
        rb2d = GetComponent<Rigidbody2D>();
        int y;
        if(xx%2==0)
        {
            y = 1;
        }
        else
        {
            y = -1;
        }
        rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, y*ghostSpeed);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.instance.gameOver)
            rb2d.velocity = Vector2.zero;
            if(transform.position.y>=4.2f)
            {
               
                rb2d.velocity = Vector2.zero;
                rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, -ghostSpeed);
            }
            else if(transform.position.y<=-1.65f)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.velocity = new Vector2(GameController.instance.scrollSpeed, ghostSpeed);
            }
        
    }
}
