using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControleFalas : MonoBehaviour
{
    private readonly int numSelector = 2;
    public GameObject[] selectorArr = new GameObject[2];
    private bool unlock = true;
    private bool talked = false;
    private int index = 0;
    public Text[] textArr = new Text[2];

    void Update()
    {
        talked = selectorArr[index].gameObject.GetComponent<DialogTrigger>().talked;
        if (talked == true)
        {
            textArr[index].color = Color.gray;
            index += 1;
            if (index >= numSelector) //arrumar
            {
                Destroy(this.gameObject);
            }
            talked = selectorArr[index].gameObject.GetComponent<DialogTrigger>().talked;
            unlock = true;
            selectorArr[index].gameObject.GetComponent<DialogTrigger>().unlock = unlock;
        }
    }
}

