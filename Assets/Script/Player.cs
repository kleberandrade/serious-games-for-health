using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour

{
    [SerializeField]
    private float speed;

    void Start()
    {
        speed = 2;
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        MovimentPlayer();
    }

    private void MovimentPlayer()
    {
        float speedHorizontal = Input.GetAxis("Horizontal");
        float speedVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * speedHorizontal * speed * Time.deltaTime);
        transform.Translate(Vector3.up * speedVertical * speed * Time.deltaTime);
    }
}

