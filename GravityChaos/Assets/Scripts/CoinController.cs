using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{

    public Vector3 vel ;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!GameController.instance.gameOver)
        transform.position += vel * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Fox")
        {
            gameObject.transform.position = new Vector2(-25f, -15f);
            GameController.instance.Scored(2);
        }
    }
}
