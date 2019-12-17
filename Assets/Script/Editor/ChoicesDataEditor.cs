using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

public class ChoicesDataEditor : EditorWindow
{

    public ChoicesGameData m_ChoicesGameData;

    private string choicesDataProjectFilePath = "/Resources/Choices.json";

    [MenuItem("Window/Choices Data Editor")]
    static void Init()
    {
        EditorWindow.GetWindow(typeof(ChoicesDataEditor)).Show();
    }

    void OnGUI()
    {
        if (m_ChoicesGameData != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("m_ChoicesGameData");
            EditorGUILayout.PropertyField(serializedProperty, true);

            serializedObject.ApplyModifiedProperties();

            if (GUILayout.Button("Save data"))
            {
                SaveGameData();
            }
        }

        if (GUILayout.Button("Load data"))
        {
            LoadGameData();
        }
    }

    private void LoadGameData()
    {
        string filePath = Application.dataPath + choicesDataProjectFilePath;

        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            m_ChoicesGameData = JsonUtility.FromJson<ChoicesGameData>(dataAsJson);
        }
        else
        {
            m_ChoicesGameData = new ChoicesGameData();
        }
    }

    private void SaveGameData()
    {

        string dataAsJson = JsonUtility.ToJson(m_ChoicesGameData);

        string filePath = Application.dataPath + choicesDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);

    }
}