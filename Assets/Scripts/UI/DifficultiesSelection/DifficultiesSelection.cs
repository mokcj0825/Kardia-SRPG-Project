using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DifficultiesSelection : UIControllerBase
{
    GlobalConfigObject globalConfig;

    private Text messageText;
    private InputField nameInputField;

    void Start()
    {
        base.Start();
        LoadGlobalConfig();
        LoadDialogScript(Path.Combine(Application.dataPath, "Scripts/UI/DifficultiesSelection/dialog_1.json"));
        DisplayNextMessage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadGlobalConfig()
    {
        string loadedData = File.ReadAllText(fileManager.globalConfigFile);
        globalConfig = JsonUtility.FromJson<GlobalConfigObject>(loadedData);

    }

    private void LoadDialogScript(string filePath)
    {
        string jsonText = File.ReadAllText(filePath);
        message = JsonUtility.FromJson<MessageData>(jsonText);
    }

    private void SetDifficulty(string difficulty)
    {
        Debug.Log($"Difficulty set to {difficulty}");
        // Additional logic for setting the difficulty
        // SceneManager.LoadScene("NextScene");
    }
}

