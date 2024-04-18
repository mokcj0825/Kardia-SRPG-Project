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
        CreateUi();
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

    private void CreateUi()
    {
        messages = new List<MessageData>
        {
            new MessageData("Welcome to the game, please enter your name - Bottom", MessagePosition.Bottom),
            new MessageData("Welcome to the game, please enter your name - Top", MessagePosition.Top),
            new MessageData("Welcome to the game, please enter your name - Middle", MessagePosition.Middle),
            new MessageData("Welcome to the game, please enter your name - Bottom 2", MessagePosition.Bottom)
        };

        //ShowMessage("Welcome to the game, please enter your name.", MessagePosition.Bottom);
        //ShowMessage("Welcome to the game, please enter your name Middle.", MessagePosition.Middle);
        //ShowMessage("Welcome to the game, please enter your name Top.", MessagePosition.Top);
    }

    private void SetDifficulty(string difficulty)
    {
        Debug.Log($"Difficulty set to {difficulty}");
        // Additional logic for setting the difficulty
        // SceneManager.LoadScene("NextScene");
    }
}

