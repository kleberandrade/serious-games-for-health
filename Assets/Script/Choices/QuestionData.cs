using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    
    public string Question;

    public int id;

    public bool isUnlocked = true;

    public AnswerData[] Answers;

}
