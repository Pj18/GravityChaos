using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool isDead = false;
    private bool direc = false;
    
    public float force = 10f;
    public float smooth = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isDead&& Input.GetMouseButtonDown(0))
        {
            rb2d.velocity = Vector2.zero;
            if(!direc)
            {
                //Quaternion target = Quaternion.Euler(180, 0, 0);
                //rb2d.AddForce(new Vector2(0, force));
                rb2d.velocity = new Vector2(0, 5);
                anim.SetTrigger("Jump");
                transform.eulerAngles = new Vector2(180, 0);
                //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
                Physics2D.gravity = new Vector2(0, 12f);
                direc = true;
            }
            else
            {
                //Quaternion target = Quaternion.Euler(180, 0, 0);
                rb2d.velocity = new Vector2(0,-5);
                //rb2d.AddForce(new Vector2(0, force));
                anim.SetTrigger("Jump");
                // transform.rotation = target;
                transform.eulerAngles = new Vector2(0, 0);
                Physics2D.gravity = new Vector2(0, -12f);
                direc = false;
            }
        }
        if(isDead)
        {
            transform.eulerAngles=new Vector3(0,0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if(collision.gameObject.tag== "ghost"||collision.gameObject.tag=="thorns")
        {
            isDead = true;
            anim.SetTrigger("Dead");
            
            //gameObject.GetComponent<PolygonCollider2D>().size = new Vector2(1.392282f, 0.3198395f);
            Physics2D.gravity = new Vector2(0, -12f);
            transform.eulerAngles = new Vector2(0, 0);
            rb2d.velocity = Vector2.zero;
            rb2d.velocity = new Vector2(-2.5f, 2.5f);
            GameController.instance.PlayerDied();
        }
    }
}
