using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.IO;

public class MainMenu : UIControllerBase
{
    // Assuming you have a canvas in your scene where UI elements can be instantiated
    private Canvas mainMenuCanvas;

    private MenuConfig menuConfig;

    private AudioSource audioSource;
    private Image backgroundImage;

    void Start()
    {
        mainMenuCanvas = FindObjectOfType<Canvas>(); // Find the canvas in the scene
        audioSource = gameObject.AddComponent<AudioSource>(); // Add an AudioSource component dynamically
        
        LoadMenuConfig();
        foreach(var button in menuConfig.buttons)
        {
            CreateButton(button);
            
        }
        LoadBackgroundImage();
        LoadAndPlayThemeSong();
    }

    private void CreateButton(ButtonConfig buttonConfig)
    {
        // Create a new button GameObject
        GameObject buttonObj = new GameObject(buttonConfig.id);
        buttonObj.AddComponent<RectTransform>(); // Add RectTransform for UI positioning
        Button button = buttonObj.AddComponent<Button>(); // Add Button component
        Image buttonImage = buttonObj.AddComponent<Image>(); // Add Image component for button visuals
        buttonObj.AddComponent<CanvasRenderer>(); // Required for UI rendering

        // Set parent to the canvas
        buttonObj.transform.SetParent(mainMenuCanvas.transform, false);

        // Optionally, set button colors or add a sprite to buttonImage
        buttonImage.color = Color.white; // Example: Set to white or use a sprite

        // Set button text
        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);
        Text buttonText = textObj.AddComponent<Text>();
        buttonText.text = buttonConfig.tooltip;
        buttonText.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf"); // Example: Using built-in Arial font
        buttonText.alignment = TextAnchor.MiddleCenter;
        buttonText.color = Color.black;

        // Adjust RectTransform of the button and text
        RectTransform rectTransform = buttonObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(160, 30); // Example: Set button size
        rectTransform.anchoredPosition = new Vector2(200, 40 - 40 * buttonConfig.x); // Example: Position it. You'd adjust this based on layout.

        // Assigning a default Unity button sprite (optional)
        //buttonImage.sprite = UnityEngine.UI.SpriteState.allSprites.FirstOrDefault(); // You may want to use a specific sprite

        // TODO: Add listeners to the button to define its behavior
        button.onClick.AddListener(() => OnButtonClick(buttonConfig.id));
    }

    void OnButtonClick(string buttonId)
    {
        // Handle button click events based on buttonId
        Debug.Log($"Button {buttonId} clicked!");

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
        backgroundImage.transform.SetParent(mainMenuCanvas.transform, false);
        backgroundImage.sprite = Resources.Load<Sprite>("Images/MainMenuBackground");
        // Set the Image type to preserve the aspect ratio
        backgroundImage.type = Image.Type.Sliced;
        backgroundImage.preserveAspect = true;

        // Get the RectTransform and set its anchors and pivot to stretch across the parent
        RectTransform rectTransform = backgroundImage.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0); // Anchors to the bottom-left corner
        rectTransform.anchorMax = new Vector2(1, 1); // Anchors to the top-right corner
        rectTransform.pivot = new Vector2(0.5f, 0.5f); // Pivot in the center
        rectTransform.offsetMin = Vector2.zero; // No offset for the lower bound
        rectTransform.offsetMax = Vector2.zero; // No offset for the upper bound
        rectTransform.SetAsFirstSibling();
    }

    private void LoadAndPlayThemeSong()
    {
        audioSource.clip = Resources.Load<AudioClip>("Audio/ThemeSong");
        audioSource.loop = true;
        audioSource.Play();
    }

    private void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void LoadGame()
    {
        Debug.Log("Load game functionality not implemented.");
    }

    private void OpenConfig()
    {
        Debug.Log("Config menu functionality not implemented.");
    }

    private void OpenExtras()
    {
        Debug.Log("Extras functionality not implemented.");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
