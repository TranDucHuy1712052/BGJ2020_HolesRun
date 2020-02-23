using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Xử lí các sự kiện liên quan đến đạn dược
public class Bullet : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(new Vector3(0, 0, speed));
    }

    //Khi trúng một vật thể nào đó, phá hủy vật thể đó luôn
    private void OnCollisionEnter(Collision collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.tag != Config.TAG_CONSTANT)
            Destroy(collision.gameObject);
        Destroy(gameObject);                        //tự hủy
    }

    //Dính lửa hay bất kì particle nào (nếu PS có cài đặt collision) => tự hủy
    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
