﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interaction = null;
    public PlayerMoviment PlayerMoviment;

    public void Start()
    {
        PlayerMoviment = gameObject.GetComponent<PlayerMoviment>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 && interaction)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            var touchX = touchPosition.x;
            var touchY = touchPosition.y;
            Vector2 itemsPosition = Camera.main.ScreenToWorldPoint(interaction.transform.position);
            var itemsX = itemsPosition.x;
            var itemsY = itemsPosition.y;
            if ( touchX < itemsX + 1 && touchX > itemsX - 1 && touchY < itemsY + 1 && touchY > itemsY - 1)
            {
                if (interaction.CompareTag("Items"))
                {
                    Debug.Log("Item selecionado  " + interaction.name); //somente para teste, apagar depois
                    //ativar script Items do objeto
                    PlayerMoviment.enabled = false;
                    //desativar ao finalizar a interacao
                }
                if (interaction.CompareTag("NPCs"))
                {
                    Debug.Log("NPC selecionado  " + interaction.name); //somente para teste, apagar depois
                    //ativar script NPCs do NPC
                    PlayerMoviment.enabled = false;
                    //desativar ao finalizar a interacao
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Items"))
        {
            interaction = other.gameObject;
            Debug.Log("Item com interação"); //somente para teste, apagar depois
        }
        if (other.CompareTag("NPCs"))
        {
            interaction = other.gameObject;
            Debug.Log("NPCs com interação"); //somente para teste, apagar depois
        }
    }
        void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Items"))
        {
            if (other.gameObject == interaction)
            {
                Debug.Log("Item não está mais acessivel"); //somente para teste, apagar depois
                interaction = null;
            }
        }
        if (other.CompareTag("NPCs"))
        {
            if (other.gameObject == interaction)
            {
                Debug.Log("Item não está mais acessivel"); //somente para teste, apagar depois
                interaction = null;
            }
        }
    }
}
