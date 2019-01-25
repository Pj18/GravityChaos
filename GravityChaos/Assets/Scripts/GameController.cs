using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public bool gameOver = false;
    public float scrollSpeed = -5.5f;
    private int score = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
    }

    public void Scored()
    {
        if (gameOver)
            return;
        score++;
    }

    public void PlayerDied()
    {
        gameOver = true;
    }
}
