using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 2f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Vector2 movement = Vector2.zero;

        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        movement = new Vector2(moveHorizontal, moveVertical);
        if (moveVertical > 0)
        {
            moveVertical = 1;
            Debug.Log("Vertical" + moveVertical);
        }
        if(moveVertical < 0)
        {
            moveVertical = -1;
        }
        if(moveHorizontal > 0)
        {
            moveHorizontal = 1;
        }
        if(moveHorizontal < 0)
        {
            moveHorizontal = -1;
        }
        Debug.Log("Normalize" + movement.normalized);
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
}