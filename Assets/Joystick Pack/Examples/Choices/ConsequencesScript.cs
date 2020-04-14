using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsequencesScript : MonoBehaviour
{

    public void DetermineConsequence(ChoicesData choices, int consequence)
    {
        for(int i = 0; i < choices.Questions.Length; i++)
        {
            if (consequence == choices.Questions[i].id)
            {
                choices.Questions[i].isUnlocked = true;
                break;
            }
        }

    }

}
