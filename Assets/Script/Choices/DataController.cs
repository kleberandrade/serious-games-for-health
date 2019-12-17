using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private ChoicesData[] allChoicesData;

    private string gameDataFileName = "Resources/Choices.json";

    private void Start()
    {
        LoadGameData();
    }

    private void LoadGameData()
    {
        // Path.Combine combines strings into a file path
        // Application.DataPath points to the "Assets" folder in the Editor
        string filePath = Path.Combine(Application.dataPath, gameDataFileName);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a ChoicesGameData object from it
            ChoicesGameData loadedData = JsonUtility.FromJson<ChoicesGameData>(dataAsJson);

            // Retrieve the allChoicesData property of loadedData
            allChoicesData = loadedData.allChoicesData;
        }
        else
        {
            Debug.LogError("Cannot load game data at: " + filePath);
        }
    }

    public ChoicesData GetCurrentChoicesData()
    {
        return allChoicesData[0];
    }
}
