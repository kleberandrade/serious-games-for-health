using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNPCs : MonoBehaviour
{
    [SerializeField]
    //private Joystick joystick;
    private float speed = 3.75f;
    //Animator animator;
    private bool isRun;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //animator = gameObject.GetComponent<Animator>();

    }
    void Update()
    {
        Vector2 movement = Vector2.zero;
        float moveHorizontal = 1;
        if (moveHorizontal == -1) // parado
        {
        }
        else
        {
            isRun = true;
        }
        //animator.SetBool("IsRun", isRun);
       // animator.SetInteger("Direction", direction);
        movement = new Vector2(moveHorizontal, transform.position.y);

        rb2d.MovePosition(rb2d.position + movement.normalized * speed * Time.deltaTime);
    }
private void OnTriggerEnter2D(Collider2D collision) //PROVISORIO
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ALGUEM TIRA ESSA CRIANÇA DAQUI, EU NÃO AGUENTO MAIS");
        }
        isRun = false;
    }
}
