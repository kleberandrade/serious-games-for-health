using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNPCs : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int index = 0;
    private float distancia = 0.05f;
    private float velocidade = 2;
    private Vector2 direcao;

    private void FixedUpdate()
    {
        Movimento();
    }

    private void Movimento()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, velocidade * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[index].position) <= distancia)
        {
            Pause();
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }
    }
    public void Pause()
    {
        StartCoroutine(PauseCoroutine());
    }
    public IEnumerator PauseCoroutine()
    {
        velocidade = 0;
        yield return new WaitForSeconds(5.0f);
        velocidade = 2;
    }
    private void OnTriggerEnter2D(Collider2D collision) //PROVISORIO
    {
        if (collision.CompareTag("Player"))
        {
            //pegar o objeto interaction do player
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        velocidade = 2;
    }
}
