using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = this.gameObject.transform;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(tf.position.x, tf.position.y, tf.position.z + Config.SPEED_BACKGROUND);         // Z += 20f
        tf.position = newPos;
        if (tf.position.z <= -10)
            tf.position = Config.POSITION_BACKGROUND_RESPAWN;
    }
}
