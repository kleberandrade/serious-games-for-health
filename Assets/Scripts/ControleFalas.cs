using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleFalas : MonoBehaviour
{
    private int numSelector = 2;
    public GameObject[] selectorArr = new GameObject[2];
    private bool unlock = true;
    private bool talked = false;
    private int index = 0;

    void Update()
    {
        talked = selectorArr[index].gameObject.GetComponent<DialogTrigger>().talked;
        if (talked == true)
        {
            index += 1;
            if (index >= numSelector)
            {
                Destroy(this.gameObject);
            }
            talked = selectorArr[index].gameObject.GetComponent<DialogTrigger>().talked;
            unlock = true;
            selectorArr[index].gameObject.GetComponent<DialogTrigger>().unlock = unlock;
            Debug.Log(selectorArr[index]);
        }
    }
}

