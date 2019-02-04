using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public static GameController instance;
    public GameObject foxobject;
    public bool gameOver = false;
    public bool gamestarted = false;
    public float scrollSpeed = -5.5f;
    private int score = 0;
    public Text Scoretext;
    public GameObject Gameovertext;
    public GameObject GameName;
    public GameObject Taptext;
    public GameObject PlayagainText;
    private float timer=0;
    // Start is called before the first frame update

    private void Start()
    {
        Time.timeScale = 0;
    }
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
        if(!gamestarted&&Input.GetMouseButtonDown(0))
        {
            gamestarted = true;
            foxobject.SetActive(true);
            GameName.SetActive(false);
            Taptext.SetActive(false);
            Time.timeScale = 1.0f;
        }
        Debug.Log(score);
        if(gameOver&&Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if(gameOver&&waiter(1.5f))
        {
            // StartCoroutine(waiter());
            Gameovertext.SetActive(true);
            PlayagainText.SetActive(true);

        }
    }

    public void Scored(int s)
    {
        if (gameOver)
            return;
        score+=s;
        Scoretext.text = "Score : " + score;
    }

    public void PlayerDied()
    {
        gameOver = true;
        
        //timecalc = true;
        
    }

    private bool waiter(float seco)
    {
        float maxTimer = seco;
        timer += Time.deltaTime;
        if (timer >= maxTimer)
            return true;
        return false;
       
    }
}
