using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public GameObject objetoSelecionado = null;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && objetoSelecionado )
        {
            Debug.Log("Objeto selecionado  " + objetoSelecionado.name); //ver quais sao as opçõess do objeto
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ObjetoInterativo"))
        {
            objetoSelecionado = other.gameObject;
            Debug.Log("Objeto com interação"); 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ObjetoInterativo"))
        {
            if (other.gameObject == objetoSelecionado)
            {
                Debug.Log("Objeto nao está mais acessivel");
                objetoSelecionado = null;
            }

        }
    }
}
