using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance { get; private set; }

    public bool final = false;
    public bool talked = false;

    public void Update()
    {
        talked = GameObject.Find("Nurse").GetComponent<DialogTrigger>().talked; //mudar quando tiver o diario
    }

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
    public Image m_PlayerImage;
    public Image m_CharacterImage;

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
        ToggleJoystickCanvas(false);
        m_Sentences.Clear();
        UpdateUI(dialog);
    }

    private static void ToggleJoystickCanvas(bool open)
    {
        //GameObject.Find("Joystick Canvas").GetComponent<ToggleJoystick>().toggleJoystick(open);
    }

    public void UpdateUI(Dialog dialog)
    {
        if (m_NameText) m_NameText.text = dialog.m_Name;
        if (m_BackgroundImage) m_BackgroundImage.sprite = dialog.m_BackgroundImage;
        if (m_PlayerImage) m_PlayerImage.sprite = dialog.m_PlayerImage;
        if (m_CharacterImage) m_CharacterImage.sprite = dialog.m_CharacterImage;

        foreach (var sentence in dialog.m_Sentences)
            m_Sentences.Enqueue(sentence);

        StartCoroutine(FirstSentence());
    }

    public IEnumerator FirstSentence()
    {
        m_SkipText.text = "NEXT";

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

        m_SkipText.text = m_Sentences.Count == 1 ? "CLOSE" : "NEXT";

        var sentence = m_Sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(WriteSentence(sentence));
    }

    public void CloseDialog()
    {
        OpenDialogAnimation(false);
        ToggleJoystickCanvas(true);
        m_SkipText.text = "";
        if (talked)
        {
            final = true;
        }
    }

    private IEnumerator WriteSentence(DialogSentence sentence)
    {
        m_NameText.text = sentence.m_SpeakerName;
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
    public Sprite m_PlayerImage;
    public Sprite m_CharacterImage;
    public List<DialogSentence> m_Sentences;
}

[Serializable]
public class DialogSentence
{
    [TextArea(1, 10)]
    public string m_Text;
    public string m_SpeakerName;
}