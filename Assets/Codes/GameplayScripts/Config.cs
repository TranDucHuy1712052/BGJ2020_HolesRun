using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
    //background
    public static float DISTANCE_BACKGROUND_BLOCK = 100f;   // độ dài của 1 background block (ta có 3 block)             
    public static Vector3 POSITION_BACKGROUND_RESPAWN = new Vector3(0, 0, 200f);                //vị trí quay trở lại của 1 block (sau khi đi hết quãng đường)
    public static float SPEED_BACKGROUND = -0.8f;           
    public static float BACKGROUND_LIMIT = -100f;           // tọa độ z thấp nhất background block có thể tới. Dưới con số này, game tự chuyển block đó lên trên lại.
    
    
    //PLAYER
    public static float DISTANCE_LANE = 3f;               // khoảng cách độ ngang giữa 2 lane (cũng là khoảng cách tàu di chuyển sang trái/phải)
    public static float SPEED_PLAYER = 3f;                // tốc độ di chuyển giữa 2 làn
    public static float TIME_IMMORTAL = 3f;                 // thời gian "bất tử" là 3s
    public static int NUMBER_LIFE = 2;                      // tối đa 2 mạng, dù có ăn thêm viên ngọc gì đó thì cũng không hơn số này

    //TAG
    public static string TAG_ENEMIES = "enemies";
    public static string TAG_HOURGLASS = "hourglass";
    public static string TAG_LIFE_SUPPORT = "life_support";
    public static string TAG_CONSTANT = "constant";                 //obj có tag này không thể bị xóa hay bị ảnh hưởng.
    public static string TAG_AMMO_BOX = "ammo_box";

    //OTHER OBJECT
    public static Vector3 POSITION_DEFAULT_SPAWNING = new Vector3(0f, 2f, 200f);
    public static float SPEED_OTHER = -1f;                        //giá trị âm nghĩa là đi ngược hướng của người chơi (nếu xét theo trục Z)
    public static float SPEED_FIREBALL = 0.12f;

    //TIME
    public static float TIME_MAX_WAIT_SPAWNING = 8f;                    // tối đa 8s sẽ có 1 vật cản mới
    public static float TIME_MIN_WAIT_SPAWNING = 0.7f;                  // tối thiểu 0.7s sẽ có 1 vật cản mới
}
