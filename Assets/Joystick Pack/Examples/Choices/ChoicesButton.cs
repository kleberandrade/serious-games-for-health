using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicesButton : MonoBehaviour
{

    public Text m_AnswerText;

    private AnswerData m_AnswerData;
    private ChoiceController m_ChoiceController;

    void Start()
    {
        m_ChoiceController = FindObjectOfType<ChoiceController>();
    }

    public void Setup(AnswerData data)
    {
        m_AnswerData = data;
        m_AnswerText.text = m_AnswerData.Answer;
    }

    public void HandleClick()
    {
        m_ChoiceController.AnswerButtonClicked(m_AnswerData.Consequence);
    }

}
