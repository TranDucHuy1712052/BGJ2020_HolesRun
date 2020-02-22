using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    //background
    public static float DISTANCE_BACKGROUND = 100f;
    public static Vector3 POSITION_BACKGROUND_RESPAWN = new Vector3(0, 0, 200f);
    public static float SPEED_BACKGROUND = -0.3f;
    public static float BACKGROUND_LIMIT = -100f;
    

    public static float SPEED_OTHER = -0.8f;                //negative value means moving backward

    //PLAYER
    public static float DISTANCE_LANE = 2.5f;               // khoảng cách độ ngang giữa 2 lane (cũng là khoảng cách tàu di chuyển sang trái/phải)
    public static float SPEED_PLAYER = 2.5f;
    public static float TIME_IMMORTAL = 3f;

    //TAG
    public static string TAG_ENEMIES = "enemies";
    public static string TAG_HOURGLASS = "hourglass";

    //OTHER OBJECT
    public static Vector3 POSITION_DEFAULT_SPAWNING = new Vector3(0f, 2f, 200f);

    public static float SPEED_FIREBALL = 0.12f;

    //TIME
    public static float TIME_MAX_WAIT_SPAWNING = 8f;               // tối đa 10s sẽ có 1 vật cản mới
    public static float TIME_MIN_WAIT_SPAWNING = 0.7f;                // tối thiểu 0.7s sẽ có 1 vật cản mới
}
