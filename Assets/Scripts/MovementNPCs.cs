using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class MovementNPCs : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int index = 0;
    private float distancia = 0.05f;
    private float velocidade = 2;
    Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Movimento();
    }
    private void Update()
    {
        animator.SetFloat("Velocidade", velocidade);
        animator.SetInteger("Direction", index);
    }
    private void Movimento()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, velocidade * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[index].position) <= distancia)
        {
            if (waypoints[index].CompareTag("WaypointParada"))
            {
                Pause();
            }
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
            velocidade = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        velocidade = 2;
    }
}
