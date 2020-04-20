using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog m_Dialog;
    public bool talked = false;

    private void Start()
    {
        
    }
    public void ToggleDialog()
    {
        if (this.gameObject.name == "Secretaria")
        {
            talked = true;
        }
        DialogManager.Instance.BeginDialog(m_Dialog);
    }

}
