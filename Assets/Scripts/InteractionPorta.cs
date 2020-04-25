using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionPorta : MonoBehaviour
{
    public GameObject interaction = null;
    public bool talked = false;
    private void Update()
    {
        talked = GameObject.Find("Interação").GetComponent<DialogTrigger>().talked;
        if (Input.touchCount > 0 && interaction && talked == true)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            var touchX = touchPosition.x;
            var touchY = touchPosition.y;
            Vector2 itemsPosition = interaction.transform.position;
            var itemsX = itemsPosition.x;
            var itemsY = itemsPosition.y;
            if (touchX < itemsX + 1 && touchX > itemsX - 1 && touchY < itemsY + 1 && touchY > itemsY - 1)
            {
                if (interaction.CompareTag("Porta"))
                {
                    SceneManager.LoadScene("Demo2"); //trocar depois, para poder usar em outras cenas tambem
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && interaction && talked == true)
        {
            if (interaction.CompareTag("Porta"))
            {
                SceneManager.LoadScene("Demo2"); //trocar depois, para poder usar em outras cenas tambem
            }

        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Porta"))
        {
            interaction = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Porta"))
        {
            if (other.gameObject == interaction)
            {
                interaction = null;
            }
        }
    }
}