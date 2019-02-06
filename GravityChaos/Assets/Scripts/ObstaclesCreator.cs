using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesCreator : MonoBehaviour
{

    public int PoolSize = 5;
    public GameObject thornsobject;
    public GameObject ghostobject;
    public GameObject scorecolliderobject;
    public GameObject coinobject;
    public float spawnRate = 2f;
    public float thornMax = 2.5f;
    public float thornMin = -2.35f;
    private GameObject[] thornarray;
    private GameObject[] scorecolliderarray;
    private GameObject[] ghostarray;
    private GameObject[] coinarray;
    private Vector2 objectPoolPosition = new Vector2(-25f, -15f);
    private float timeSinceLastSpawned;
    private float totaltime = 0;
    private float spawnXPosition = 8f;
    private int currentThorn=0;
    private int currentGhost = 0;
    private int currentscorecollider=0;
    private int currentcoin = 0;
    // Start is called before the first frame update
    void Start()
    {
        thornarray = new GameObject[PoolSize];
        ghostarray = new GameObject[PoolSize];
        scorecolliderarray = new GameObject[PoolSize];
        coinarray = new GameObject[PoolSize];
        for(int i=0;i<PoolSize;i++)
        {
            thornarray[i] = (GameObject)Instantiate(thornsobject, objectPoolPosition, Quaternion.identity);
        }


        for (int i = 0; i < PoolSize; i++)
        {
            ghostarray[i] = (GameObject)Instantiate(ghostobject, objectPoolPosition, Quaternion.identity);
        }


        for (int i = 0; i < PoolSize; i++)
        {
            scorecolliderarray[i] = (GameObject)Instantiate(scorecolliderobject, objectPoolPosition, Quaternion.identity);
        }

        for (int i = 0; i < PoolSize; i++)
        {
            coinarray[i] = (GameObject)Instantiate(coinobject, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;
        totaltime += Time.deltaTime;
        if(GameController.instance.gameOver==false&&totaltime>=5.0f)
        {
            totaltime = 0;
            spawnRate -= 0.15f;
            GameController.instance.scrollSpeed -= 0.15f;
        }
        if(GameController.instance.gameOver==false&&timeSinceLastSpawned>=spawnRate)
        {
            timeSinceLastSpawned = 0;
            int selector = Random.Range(1, 3);
            int xx = Random.Range(-2, 2);
            if (selector==1)
            {
                
                scorecolliderarray[currentscorecollider].transform.position = new Vector2(spawnXPosition+2, 0.0f);
                coinarray[currentcoin].transform.position = new Vector2(spawnXPosition + 3+xx, Random.Range(-3.0f, 3.0f));
                ghostarray[currentGhost].transform.position = new Vector2(spawnXPosition, 0.0f);
                currentGhost = (currentGhost + 1) % PoolSize;
                currentscorecollider = (currentscorecollider + 1) % PoolSize;
                currentcoin = (currentcoin + 1) % PoolSize;
            }
            else
            {
                coinarray[currentcoin].transform.position = new Vector2(spawnXPosition + 3+xx, Random.Range(-3.0f, 3.0f));
                scorecolliderarray[currentscorecollider].transform.position = new Vector2(spawnXPosition+2, 0.0f);
                thornarray[currentThorn].transform.position = new Vector2(spawnXPosition, Random.Range(thornMin, thornMax));
                currentThorn = (currentThorn + 1) % PoolSize;
                currentscorecollider = (currentscorecollider + 1) % PoolSize;
                currentcoin = (currentcoin + 1) % PoolSize;
            }
        }
        
    }

    
}
