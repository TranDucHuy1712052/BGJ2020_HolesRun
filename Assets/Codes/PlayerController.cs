using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private int laneIndex = 0;                  //chỉ số của làn đang chạy
    private bool isImmortal = false;

    float startImmortalTime = 0f;

    void Start()
    {
        tf = this.gameObject.transform;    
    }
    
    void Update()
    {
        //Keyboard (A - left, D - right)
        //3 làn đánh số như sau: (-1, 0, 1) 
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }


        //Cập nhật các khoảng thời gian: Thời gian bất tử, thời gian chuyển làn, ...
        float recentTime = Time.time;
        if (isImmortal)
        {
            if (recentTime - startImmortalTime >= 3f)               //sau 3s, tắt chế độ bất tử
                BecomeKillable();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject touched = collision.gameObject;
        Debug.LogWarning("COLLISION ! == " + collision.gameObject.name);
        if (touched.tag == Config.TAG_ENEMIES)
        {
            if (!isImmortal)
                Die();
        }
        else if (touched.tag == Config.TAG_HOURGLASS)
        {
            startImmortalTime = Time.time;
            BecomeImmortal();
        }

        Destroy(touched);
    }



    //====================
    // HÀM DI CHUYỂN

    void MoveLeft()
    {
        if (laneIndex > -1)
        {
            laneIndex -= 1;             //lane index bị trừ nghĩa là di chuyển sang làn bên trái
            tf.position = new Vector3(tf.position.x - Config.SPEED_PLAYER, tf.position.y, tf.position.z);
        }
    }

    void MoveRight()
    {
        if (laneIndex < 1)
        {
            laneIndex += 1;
            tf.position = new Vector3(tf.position.x + Config.SPEED_PLAYER, tf.position.y, tf.position.z);
        }
    }


    //======================
    // HÀM SỰ KIỆN

    void BecomeImmortal() {
        isImmortal = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = new Color(1f,1f,1f,0.2f);
    }
    void BecomeKillable() {
        isImmortal = false;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    void Die() { Destroy(this.gameObject); }            
}
