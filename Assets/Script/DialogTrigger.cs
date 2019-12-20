using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog m_Dialog;

	public void PlayConversation() {
		DialogManager.Instance.BeginDialog(m_Dialog);
	}
}
