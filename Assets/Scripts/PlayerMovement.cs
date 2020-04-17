using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Joystick joystick;
    private float speed = 3.75f;
    Animator animator;
    private float angle;
    private bool isRun;
    private int direction;
    private float horizontal;
    private float vertical;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        
    }
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical"); //Caso o jogador utilize teclado
        Vector2 movement = Vector2.zero;
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;
        angle = Mathf.Atan2(moveHorizontal, moveVertical) * Mathf.Rad2Deg; //criando uma variavel de angulo
        angle = (angle + 360) % 360; // transformando em 360
        if ((angle >= 135  && angle < 225) || vertical == -1)  //Down
        { 
            moveHorizontal = 0;
            moveVertical = -1;
            direction = 1;
}
        if (angle >= 225 && angle < 315 || horizontal == -1) //Left
        {
            moveHorizontal = -1;
            moveVertical = 0;
            direction = 2;
        }
        if (angle >=315 || angle > 0 && angle < 45|| vertical == 1) //Up
        {
            moveHorizontal = 0;
            moveVertical = 1;
            direction = 3;
        }
        if (angle >=45 && angle < 135 || horizontal == 1) // Right
        {
            moveHorizontal = 1;
            moveVertical = 0;
            direction = 4;
        }
        if ((horizontal == 0 && vertical == 0) && (moveVertical == 0 && moveHorizontal== 0))
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