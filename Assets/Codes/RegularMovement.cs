using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularMovement : MonoBehaviour
{
    Transform tf;
    public bool moving = false;
    
    void Start()
    {
        tf = this.gameObject.transform;
    }

    void Update()
    {
        if (moving)
        {
            Vector3 newPos = new Vector3(tf.position.x, tf.position.y, tf.position.z + Config.SPEED_OTHER);         // Z += 20f
            tf.position = newPos;
        }
        if (tf.position.z <= Config.BACKGROUND_LIMIT)
            Destroy(gameObject);
    }
    
}
