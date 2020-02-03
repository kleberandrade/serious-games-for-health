using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    [SerializeField]
    private List<string> m_InteractableTags;
    private bool m_TouchToInteract = false;
    private SpriteRenderer m_SpriteRenderer;
    public bool m_OpenDialog = false;

    private void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                touchPosition.z = 0;
                float touchX = touchPosition.x;
                float touchY = touchPosition.y;
                float transformX = transform.position.x;
                float transformY = transform.position.y;
                float spriteX = m_SpriteRenderer.size.x;
                float spriteY = m_SpriteRenderer.size.y * 2;
                if (touchX > transformX - spriteX && touchX < transformX + spriteX && touchY > transformY - spriteY && touchY < transformY + spriteY && m_TouchToInteract)
                {
                    GetComponent<DialogTrigger>().ToggleDialog();
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach(string interactable in m_InteractableTags)
        {
            if (collision.CompareTag(interactable))
            {
                EnableInteraction(true);
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foreach (string interactable in m_InteractableTags)
        {
            if (collision.CompareTag(interactable))
            {
                EnableInteraction(false);
                break;
            }
        }
    }

    private void EnableInteraction(bool interaction)
    {
        if (interaction)
        {
            GetComponentInChildren<Canvas>().enabled = true;
        }
        else
        {
            GetComponentInChildren<Canvas>().enabled = false;
        }
        m_TouchToInteract = interaction;
    }
}
