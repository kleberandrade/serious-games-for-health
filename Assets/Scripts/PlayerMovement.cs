using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 3f;
    private Rigidbody2D rb2d;
    [Header("Use keyboard")]
    public bool m_Keyboard = true;
    public string m_HorizonalAxis = "Horizontal";
    public string m_VerticalAxis = "Vertical";

    /*
    float speedHorizontal = 0f;
    float speedVertical = 0f;
    */

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
        if (joystick.Horizontal >= .3f)
        {
            speedHorizontal = speed;
            transform.Translate(Vector3.right * speedHorizontal * Time.deltaTime);
        }
        else if (joystick.Horizontal <= -.3f)
        {
            speedHorizontal = -speed;
            transform.Translate(Vector3.right * speedHorizontal * Time.deltaTime);
        }
        if (joystick.Vertical >= .3f)
        {
            speedVertical = speed;
            transform.Translate(Vector3.up * speedVertical * Time.deltaTime);
        }
        else if (joystick.Vertical <= -.3f)
        {
            speedVertical = -speed;
            transform.Translate(Vector3.up * speedVertical * Time.deltaTime);
        }
        else
        {
            speedHorizontal = 0;
            speedVertical = 0;
            transform.Translate(Vector3.right * speedHorizontal * Time.deltaTime);
            transform.Translate(Vector3.up * speedVertical * Time.deltaTime);
        }
        */

        Vector2 movement = Vector2.zero;
        float moveHorizontal = 0;
        float moveVertical = 0;

        if (m_Keyboard)
        {
            moveHorizontal = Input.GetAxisRaw(m_HorizonalAxis);
            moveVertical = Input.GetAxisRaw(m_VerticalAxis);
        }
        else
        {
            moveHorizontal = joystick.Horizontal;
            moveVertical = joystick.Vertical;
        }

        movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
}