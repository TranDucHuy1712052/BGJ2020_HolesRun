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
    public GameObject[] obstacleList, bonusList;            // 2 danh sách (vật cản và bonus), bonus có cách spawn khác
   
    //UI
    public Text timeScoreText;
    public Text lifeRemainText;

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
            RespawnThings();                                //tạo ra vật thể mới
            beginWaitingTime = recentTime;
            spawnWaitTime = Random.Range(Config.TIME_MIN_WAIT_SPAWNING, maxSpawnWaitTime);
        }
        //điều chỉnh maxWaitTime để tăng độ khó theo thời gian
        if (maxSpawnWaitTime > Config.TIME_MIN_WAIT_SPAWNING + 0.8)
            maxSpawnWaitTime -= 0.001f; 
    }

    //Tạo ra các vật thể mới dựa trên danh sách các vật thể
    void RespawnObstacle()
    {
        int ranNum = Random.Range(0, obstacleList.Length);
        GameObject obj = Instantiate(obstacleList[ranNum]);
        obj.transform.parent = gameplayLevel.transform;

        int ranLane = Random.Range(-1, 2);
        obj.transform.position = new Vector3(ranLane * Config.DISTANCE_LANE, Config.POSITION_DEFAULT_SPAWNING.y, Config.POSITION_DEFAULT_SPAWNING.z);
        
    }

    void RespawnBonus()
    {
        int ranNum = Random.Range(0, bonusList.Length);             //chú ý là danh sách khác với hàm tạo obstacle ở trên
        GameObject obj = Instantiate(bonusList[ranNum]);
        obj.transform.parent = gameplayLevel.transform;

        int ranLane = Random.Range(-1, 2);
        obj.transform.position = new Vector3(ranLane * Config.DISTANCE_LANE, Config.POSITION_DEFAULT_SPAWNING.y, Config.POSITION_DEFAULT_SPAWNING.z);
    }

    void RespawnThings()
    {
        int ran = Random.Range(0, 10);
        if (ran < 2)                    //ra bonus, tỉ lệ 20%
            RespawnBonus();
        else 
            RespawnObstacle();
    }

    //=====================================
    // HÀM CẬP NHẬT UI

}
