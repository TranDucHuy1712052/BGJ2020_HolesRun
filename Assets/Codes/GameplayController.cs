using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{
    bool isPlaying = true;

    public float spawnWaitTime = 5f;
    public float maxSpawnWaitTime = Config.TIME_MAX_WAIT_SPAWNING;          //thay đổi giảm dần theo thời gian
    float beginWaitingTime = 0f;

    public GameObject gameplayLevel;
    public GameObject[] obstacleList;

    //UI
    public Text timeScoreText;


    //=======================================================

    void Start()
    {
            
    }

    void Update()
    {
        float recentTime = Time.time;
        timeScoreText.text = recentTime.ToString();
        if (recentTime - beginWaitingTime > spawnWaitTime)
        {
            RespawnThings();
            beginWaitingTime = recentTime;
            spawnWaitTime = Random.Range(Config.TIME_MIN_WAIT_SPAWNING, maxSpawnWaitTime);
        }
        //điều chỉnh maxWaitTime để tăng độ khó theo thời gian
        if (maxSpawnWaitTime > Config.TIME_MIN_WAIT_SPAWNING + 0.8)
            maxSpawnWaitTime -= 0.001f; 
    }

    void RespawnThings()
    {
        int ranNum = Random.Range(0, obstacleList.Length);
        GameObject obj = Instantiate(obstacleList[ranNum]);
        obj.transform.parent = gameplayLevel.transform;

        int ranLane = Random.Range(-1, 2);
        obj.transform.position = new Vector3(ranLane * Config.DISTANCE_LANE, Config.POSITION_DEFAULT_SPAWNING.y, Config.POSITION_DEFAULT_SPAWNING.z);
        
    }
}
