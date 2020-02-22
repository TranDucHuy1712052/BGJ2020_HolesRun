using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    //background
    public static float DISTANCE_BACKGROUND = 100f;
    public static Vector3 POSITION_BACKGROUND_RESPAWN = new Vector3(0, 0, 200f);
    public static float SPEED_BACKGROUND = -1f;
    public static float BACKGROUND_LIMIT = -100f;

    public static float SPEED_OTHER = -0.2f;                //negative value means moving backward

    //PLAYER
    public static float SPEED_PLAYER = 2.5f;
    public static float TIME_IMMORTAL = 3f;

    //TAG
    public static string TAG_ENEMIES = "enemies";
    public static string TAG_HOURGLASS = "hourglass";
}
