using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [Header("UI (User Interface)")]
    public Text m_NameText;
    public Text m_SentenceText;
    public Text m_SkipText;
    public Image m_BackgroundImage;

    [Header("Animator")]
    public Animator m_Animator;
    private Queue<DialogSentence> m_Sentences = new Queue<DialogSentence>();
    private bool m_IsOpen;

    public void OpenDialogAnimation(bool open)
    {
        m_IsOpen = open;
        if (m_Animator) m_Animator.SetBool("Open", open);
    }

    public void BeginDialog(Dialog dialog)
    {
        if (m_IsOpen)
        {
            CloseDialog();
            return;
        }

        OpenDialogAnimation(true);
        GameObject.Find("Joystick Canvas").GetComponent<ToggleJoystick>().toggleJoystick();
        m_Sentences.Clear();
        UpdateUI(dialog);
    }

    public void UpdateUI(Dialog dialog)
    {
        if (m_NameText) m_NameText.text = dialog.m_Name;
        if (m_BackgroundImage) m_BackgroundImage.sprite = dialog.m_BackgroundImage;

        foreach (var sentence in dialog.m_Sentences)
            m_Sentences.Enqueue(sentence);

        StartCoroutine(FirstSentence());
    }

    public IEnumerator FirstSentence()
    {
        if (m_Sentences.Count == 1) m_SkipText.text = "CLOSE";
        else m_SkipText.text = "NEXT";

        m_SentenceText.text = string.Empty;
        yield return new WaitForSeconds(0.5f);

        NextSentence();
    }

    public void NextSentence()
    {
        if (m_Sentences.Count == 0)
        {
            CloseDialog();
            return;
        }

        if (m_Sentences.Count == 1) m_SkipText.text = "CLOSE";
        else m_SkipText.text = "NEXT";

        var sentence = m_Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WriteSentece(sentence));
    }

    public void CloseDialog()
    {
        OpenDialogAnimation(false);
        GameObject.Find("Joystick Canvas").GetComponent<ToggleJoystick>().toggleJoystick();
    }

    private IEnumerator WriteSentece(DialogSentence sentence)
    {
        m_SentenceText.text = string.Empty;
        foreach (char letter in sentence.m_Text.ToCharArray())
        {
            while (Time.timeScale == 0) yield return null;
            m_SentenceText.text += letter;
            yield return null;
        }
    }
}

[Serializable]
public class Dialog
{
    public string m_Name;
    public Sprite m_BackgroundImage;
    public List<DialogSentence> m_Sentences;
}

[Serializable]
public class DialogSentence
{
    [TextArea(1, 10)]
    public string m_Text;
}