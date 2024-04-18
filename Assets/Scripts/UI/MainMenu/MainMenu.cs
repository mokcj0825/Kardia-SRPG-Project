using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.IO;
using System.Reflection;

public class MainMenu : UIControllerBase
{

    private MenuConfig menuConfig;

    private AudioSource audioSource;
    private Image backgroundImage;

  

    void Start()
    {
        base.Start();
        canvas = FindObjectOfType<Canvas>(); // Find the canvas in the scene
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component dynamically
        
        LoadMenuConfig();
        foreach(var button in menuConfig.buttons)
        {
            CreateButton(button);
            
        }
        if (menuConfig.global.loadBackground)
        {
            LoadBackgroundImage();
        }
        if(menuConfig.global.loadSound)
        {
            LoadAndPlayThemeSong();
        }
    }

    private void CreateButton(ButtonConfig buttonConfig)
    {
        GameObject buttonObj = CreateButtonObject(buttonConfig.id);
        ConfigureButtonAppearance(buttonObj);
        CreateButtonText(buttonObj, buttonConfig.tooltip);
        ConfigureButtonRectTransform(buttonObj, 160, 30,  200, 40 - 40 * buttonConfig.x);
        AssignButtonAction(buttonObj.GetComponent<Button>(), buttonConfig);
    }

    void OnButtonClick(ButtonConfig buttonConfig)
    {
        // Handle button click events based on buttonId
        Debug.Log($"Button {buttonConfig.onClick} clicked!");
        MethodInfo mi = this.GetType().GetMethod(buttonConfig.onClick, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        if(mi != null)
        {
            mi.Invoke(this, null);
        } else
        {
            Debug.LogError("Method not found: " + buttonConfig.onClick);
        }
        // Example: Load different scenes or perform actions based on buttonId
    }

    private void LoadMenuConfig()
    {
        string filePath = Path.Combine(Application.dataPath, "Scripts/UI/MainMenu/config.json");
        Debug.Log(filePath);
        if(File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            menuConfig = JsonUtility.FromJson<MenuConfig>(dataAsJson);
        } else
        {
            Debug.Log("Cannot find config file.");
        }
    }


    private void LoadBackgroundImage()
    {
        backgroundImage = new GameObject("BackgroundImage").AddComponent<Image>();
        backgroundImage.transform.SetParent(canvas.transform, false);
        backgroundImage.sprite = Resources.Load<Sprite>("Images/MainMenuBackground");
        backgroundImage.type = Image.Type.Sliced;
        backgroundImage.preserveAspect = true;

        RectTransform rectTransform = backgroundImage.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0); 
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(0.5f, 0.5f); 
        rectTransform.offsetMin = Vector2.zero; 
        rectTransform.offsetMax = Vector2.zero; 
        rectTransform.SetAsFirstSibling();
    }

    private void LoadAndPlayThemeSong()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/ThemeSong");
        audioSource.loop = true;
        audioSource.Play();
    }

    [UsedInConfig]
    private void StartGame()
    {
        Debug.Log("Start Game.");
        fileManager.InitializeGlobalConfig();
        fileManager.InitializeAutoSave();
        SceneManager.LoadScene("DifficultiesSelectionScene");
    }

    [UsedInConfig]
    private void LoadGame()
    {
        Debug.Log("Load game functionality not implemented.");
    }

    [UsedInConfig]
    private void OpenConfig()
    {
        Debug.Log("Config menu functionality not implemented.");
    }

    [UsedInConfig]
    private void OpenExtras()
    {
        Debug.Log("Extras functionality not implemented.");
    }

    [UsedInConfig]
    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    private GameObject CreateButtonObject(string buttonId)
    {
        GameObject buttonObj = new GameObject(buttonId);
        buttonObj.AddComponent<RectTransform>();
        buttonObj.transform.SetParent(canvas.transform, false);
        return buttonObj;
    }

    private void ConfigureButtonAppearance(GameObject buttonObj)
    {
        Button button = buttonObj.AddComponent<Button>();
        Image buttonImage = buttonObj.AddComponent<Image>();
        buttonImage.color = Color.white;
        // TODO: Set image sprite for button if necessary
        // buttonImage.sprite = UnityEngine.UI.SpriteState.allSprites.FirstOrDefault();
    }

    private void CreateButtonText(GameObject buttonObj, string tooltip)
    {
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);
        Text buttonText = textObj.AddComponent<Text>();

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = new Vector2(0, 0);
        textRect.anchorMax = new Vector2(1, 1);
        textRect.sizeDelta = Vector2.zero;
        textRect.anchoredPosition = Vector2.zero;

        buttonText.text = tooltip;
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf"); // Ensure this font exists
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;
    }

    private void ConfigureButtonRectTransform(GameObject buttonObj, float width, float height, int xPosition, int yPosition)
    {
        RectTransform rectTransform = buttonObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(width, height); // Adjust size as needed
        rectTransform.anchoredPosition = new Vector2(xPosition, yPosition); // Adjust position as needed
    }

    private void AssignButtonAction(Button button, ButtonConfig buttonConfig)
    {
        button.onClick.AddListener(() => OnButtonClick(buttonConfig));
    }



}
