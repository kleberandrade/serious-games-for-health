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
        Debug.Log(angle);
        animator.SetFloat("Angle", angle);
        movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
}