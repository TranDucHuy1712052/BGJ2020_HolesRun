using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private int laneIndex = 0;                  //chỉ số của làn đang chạy
    private int life = Config.NUMBER_LIFE, ammo = 0;
    private bool isImmortal = false;
    float startImmortalTime = 0f;

    public Text lifeRemainText, ammoRemainText;         //UI liên quan đến nhân vật chính, để thay đổi
    public GameObject bulletTemplateObj;                //template để sinh ra obj đạn
    

    //=======================================

    void Start()
    {
        tf = this.gameObject.transform;
        lifeRemainText.text = life.ToString();
        ammoRemainText.text = ammo.ToString();
    }
    
    void Update()
    {
        //Keyboard (A - left, D - right)
        //3 làn đánh số như sau: (-1, 0, 1) 
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        else if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        //Mouse (left click - shoot)
        if (Input.GetMouseButtonDown(0))
            ShootABullet();

        //Cập nhật các khoảng thời gian: Thời gian bất tử, thời gian chuyển làn, ...
        if (isImmortal)
        {
            float recentTime = Time.time;
            if (recentTime - startImmortalTime >= 3f)               //sau 3s, tắt chế độ bất tử
                BecomeKillable();
        }
    }


    //Không được đùa với lửa - đụng vào là tiêu (nếu k có đồ bảo vệ)
    private void OnParticleCollision(GameObject other)
    {
        if (!isImmortal)
        {
            life = 0;
            lifeRemainText.text = life.ToString();
            Destroy(gameObject);
        }
    }

    //=========================
    // VA CHẠM

    private void OnCollisionEnter(Collision collision)
    {
        GameObject touched = collision.gameObject;
        Debug.LogWarning("COLLISION ! == " + collision.gameObject.name);
        if (touched.tag == Config.TAG_ENEMIES)
        {
            if (!isImmortal)
                LoseLife();
        }
        else if (touched.tag == Config.TAG_HOURGLASS)
            BecomeImmortal();
        else if (touched.tag == Config.TAG_LIFE_SUPPORT)
            GainLife();
        else if (touched.tag == Config.TAG_AMMO_BOX)
            GainAmmo();

        Destroy(touched);
    }

    //====================
    // CÁC ĐỘNG TÁC KHÁC
    
    private void ShootABullet()
    {
        if (ammo <= 0) return;              //hết đạn không bắn được
        ammo--;
        ammoRemainText.text = ammo.ToString();
        GameObject bullet = Instantiate(bulletTemplateObj);
        bullet.transform.position = new Vector3(tf.position.x, tf.position.y, tf.position.z + 5);
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
        startImmortalTime = Time.time;
        isImmortal = true;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.magenta;
    }
    void BecomeKillable() {
        isImmortal = false;
        this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }
    void GainLife()
    {
        if (life >= Config.NUMBER_LIFE) return;                  //chỉ tối đa 2 mạng
        life++;
        lifeRemainText.text = life.ToString();
    }
    void LoseLife()
    {
        life--;
        lifeRemainText.text = life.ToString();
        if (life == 0) Die();
    }
    void GainAmmo()
    {
        ammo += 10;
        ammoRemainText.text = ammo.ToString();
    }
    void Die() { Destroy(this.gameObject); }            
}
