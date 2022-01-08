using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*speed of 4 units per second to the left*/
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x < -20)
            Destroy(gameObject);
    }

}
