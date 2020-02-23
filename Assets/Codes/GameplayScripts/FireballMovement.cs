using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quả cầu lửa có thể đi theo chiều ngang (đi qua các làn khác)
public class FireballMovement : MonoBehaviour
{
    GameObject obj;
    Transform tf;
    public float x_speed = Config.SPEED_FIREBALL;              //1f trên 1s
    private float maxDistance = Config.DISTANCE_LANE * 2;

    void Start()
    {
        obj = this.gameObject;
        tf = this.gameObject.transform;                 //lấy trước các object, transform để rút gọn code
        x_speed = Config.SPEED_FIREBALL;                //gán từ đầu
    }

    void Update()
    {
        Vector3 newPos = new Vector3(tf.position.x - x_speed, tf.position.y, tf.position.z + Config.SPEED_OTHER);         // Z += 20f
        tf.position = newPos;
        if (Mathf.Abs(tf.position.x) >= Config.DISTANCE_LANE + 0.2)
            x_speed *= -1;                        //đổi chiều 
        
        if (tf.position.z <= Config.BACKGROUND_LIMIT)               //quá limit => xóa vật thể
            Destroy(gameObject);
    }
}
