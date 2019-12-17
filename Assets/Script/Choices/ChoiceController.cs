using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceController : MonoBehaviour
{
    public Text m_QuestionDisplayText;
    public SimpleObjectPool m_AnswerButtonObjectPool;
    public Transform m_AnswerButtonParent;

    private DataController m_DataController;
    private ChoicesData m_CurrentChoicesData;
    private QuestionData[] m_QuestionPool;
    private ConsequencesScript m_ConsequenceScript;

    private int m_QuestionIndex;
    private List<GameObject> m_AnswerButtonGameObjects = new List<GameObject>();

    private void Start()
    {
        m_DataController = FindObjectOfType<DataController>();
        m_CurrentChoicesData = m_DataController.GetCurrentChoicesData();
        m_QuestionPool = m_CurrentChoicesData.Questions;
        m_ConsequenceScript = GetComponent<ConsequencesScript>();

        m_QuestionIndex = 0;

        ShowChoices();
    }

    public void ShowChoices()
    {
        RemoveAnswersButton();

        QuestionData questionData = m_QuestionPool[m_QuestionIndex];
        while (!CheckIfUnlockedQuestion(questionData))
        {
            CheckIfWithinIndexRange();
            questionData = m_QuestionPool[m_QuestionIndex];
        }
        m_QuestionDisplayText.text = questionData.Question;

        for (int i = 0; i < questionData.Answers.Length; i++)
        {
            GameObject answerButtonGameObject = m_AnswerButtonObjectPool.GetObject();
            m_AnswerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(m_AnswerButtonParent);
            answerButtonGameObject.transform.localScale = Vector3.one;

            ChoicesButton answerButton = answerButtonGameObject.GetComponent<ChoicesButton>();
            answerButton.Setup(questionData.Answers[i]);
        }
    }

    public void RemoveAnswersButton()
    {
        while (m_AnswerButtonGameObjects.Count > 0)
        {
            m_AnswerButtonObjectPool.ReturnObject(m_AnswerButtonGameObjects[0]);
            m_AnswerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(int unlockQuestion)
    {
        if (unlockQuestion != 0)
        {
            m_ConsequenceScript.DetermineConsequence(m_CurrentChoicesData, unlockQuestion);
        }

        CheckIfWithinIndexRange();
        ShowChoices();
    }

    private void CheckIfWithinIndexRange()
    {
        if (m_QuestionPool.Length > m_QuestionIndex + 1)
        {
            m_QuestionIndex++;
        }
        else
        {
            m_QuestionIndex = 0;
        }
    }

    private bool CheckIfUnlockedQuestion(QuestionData questionData)
    {
        if (questionData.isUnlocked == false)
        {
            return false;
        }

        return true;
    }

}
