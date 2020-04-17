using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;
    public float speed = 7f;
    Animator animator;
    public float angle;
    public bool isRun;
    public int direction;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 movement = Vector2.zero;

        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        angle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg; //criando uma variavel de angulo
        angle = (angle + 360) % 360;
        if (angle >= 135  && angle < 225) //Down
        { 
            moveHorizontal = 0;
            moveVertical = -1;
            direction = 1;
}
        if (angle >= 225 && angle < 315) //Left
        {
            moveHorizontal = -1;
            moveVertical = 0;
            direction = 2;
        }
        if (angle >=315 || angle > 0 && angle < 45) //Up
        {
            moveHorizontal = 0;
            moveVertical = 1;
            direction = 3;
        }
        if (angle >=45 && angle < 135) // Rigth
        {
            moveHorizontal = 1;
            moveVertical = 0;
            direction = 4;
        }
        if (moveVertical == 0 && moveHorizontal == 0)
        {
            isRun = false;
        }
        else
        {
            isRun = true;
        }
        animator.SetBool("IsRun", isRun);
        animator.SetInteger("Direction", direction);
        movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
}