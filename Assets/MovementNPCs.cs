using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNPCs : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //PROVISORIO
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ALGUEM TIRA ESSA CRIANÇA DAQUI, EU NÃO AGUENTO MAIS");
        }
    }
}
