using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;
    public bool talked = false;
    public bool unlock;
    public GameObject controleFinal;
    private float countdown = 3.0f;

    public void Update()
    {
        if (gameObject.name == "Nurse" && talked)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 1)
            {
                controleFinal.SetActive(true);
                countdown = 0;
            }

        }
    }
    public void ToggleDialog()
    {
        if (unlock == true)
        {
            talked = true;
            DialogManager.Instance.BeginDialog(m_Dialog);
        }
    }
}