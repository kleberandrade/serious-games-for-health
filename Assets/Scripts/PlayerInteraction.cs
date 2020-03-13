﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interaction = null;
    public PlayerMoviment PlayerMoviment;
    public GameObject joystick;

    public void Start()
    {
        PlayerMoviment = gameObject.GetComponent<PlayerMoviment>();
        joystick = GameObject.Find("Fixed Joystick");
    }
    private void Update()
    {
        if (Input.touchCount > 0 && interaction)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            var touchX = touchPosition.x;
            var touchY = touchPosition.y;
            Vector2 itemsPosition = interaction.transform.position;
            var itemsX = itemsPosition.x;
            var itemsY = itemsPosition.y;
            if ( touchX < itemsX + 1 && touchX > itemsX - 1 && touchY < itemsY + 1 && touchY > itemsY - 1)
            {
                if (interaction.CompareTag("Items"))
                {
                    Debug.Log("Item selecionado  " + interaction.name); //somente para teste, apagar depois
                    //ativar script do item
                    // desativado joystick e os movimentos, ativar quando encerrar a interacao
                    joystick.SetActive(false);
                    foreach (Transform t in transform)
                    {
                        t.gameObject.SetActive(false);
                    }
                    PlayerMoviment.enabled = false;
                }
                if (interaction.CompareTag("NPCs"))
                {
                    Debug.Log("NPC selecionado  " + interaction.name); //somente para teste, apagar depois
                    //ativar script do NPC
                    // desativado joystick e os movimentos, ativar quando encerrar a interacao
                    joystick.SetActive(false);
                    foreach (Transform t in transform)
                    {
                        t.gameObject.SetActive(false);
                    }
                    PlayerMoviment.enabled = false;
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
                Debug.Log("NPC não está mais acessivel"); //somente para teste, apagar depois
                interaction = null;
            }
        }
    }
}
