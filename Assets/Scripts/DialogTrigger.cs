using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;
    public bool talked = false;
    public bool unlock;
    public void ToggleDialog()
    {
        if (unlock == true)
        {
            talked = true;
            DialogManager.Instance.BeginDialog(m_Dialog);
        }
    }
}