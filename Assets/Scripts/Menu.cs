using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject sound;

    public void Start()
    {
        sound = GameObject.Find("Sound");
    }
    public void Play()
    {
        Destroy(sound);
        SceneManager.LoadScene("Demo");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
