using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    bool isOnGround;
    public Vector3 initialPosition;
    public int spinSpeed  = 10;
    int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {

        dontGoOffScreen();

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isOnGround)
        {
            jump();
            Text myText = GameObject.Find("Canvas/Text").GetComponent<Text>();
            myText.text = "Score: " + score++;
        }

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * 5f * Time.deltaTime;
    }

    void dontGoOffScreen()
    {
        transform.position=new Vector3(Mathf.Clamp(transform.position.x,-7f,7f),Mathf.Clamp(transform.position.y,-4f,4f),transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    void jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300.0f));
        isOnGround = false;
    }
}
