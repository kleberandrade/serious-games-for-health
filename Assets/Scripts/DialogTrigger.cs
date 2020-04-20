using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public Dialog m_Dialog;
    public bool conversoucomasecretaria = false;

    private void Start()
    {
        
    }
    public void ToggleDialog()
    {
        if (this.gameObject.name == "NPCs_8")
        {
            conversoucomasecretaria = true;
        }
        DialogManager.Instance.BeginDialog(m_Dialog);
    }

}
