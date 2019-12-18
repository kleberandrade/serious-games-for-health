using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 2f;
    float speedHorizontal = 0f;
    float speedVertical = 0f;
    void Update()
    {
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
        if (joystick.Vertical <= -.3f)
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
    }
}
