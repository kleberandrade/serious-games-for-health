using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;
    public bool talked = false;
    public bool unlock;
    public GameObject controleFinal;
    public bool final;

    public void Update()
    {
        final = GameObject.Find("Dialog Manager").GetComponent<DialogManager>().final;
        if (this.gameObject.name == "Nurse" && final)
        {
            controleFinal.SetActive(true);
            unlock = false;
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