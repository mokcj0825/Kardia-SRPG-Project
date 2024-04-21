using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UIControllerBase : MonoBehaviourBase
{
    protected Canvas canvas;
    private Text topText;
    private Text middleText;
    private Text bottomText;

    protected MessageData message;
    private int currentStepIndex = 0;

    // Use this method to initialize any UI components
    protected override void Start()
    {
        base.Start();
        InitializeUI();
    }

    // Initialize UI elements here. This can be overridden by subclasses for specific UI setups.
    protected virtual void InitializeUI()
    {
        canvas = FindObjectOfType<Canvas>();
        canvas.GetComponent<RectTransform>().sizeDelta = new Vector2(screenWidth, screenHeight);
        AddCanvasOnClickListener();
        topText = CreateTextObject("TopText", screenHeight * 0.75f);
        middleText = CreateTextObject("MiddleText", screenHeight * 0.5f);
        bottomText = CreateTextObject("BottomText", screenHeight * 0.25f);
    }

    // Shows a UI element. Could be overridden to include animations or additional logic.
    public virtual void Show()
    {
        gameObject.SetActive(true);
        // Optionally, add animations or other effects for the UI appearing
    }

    // Hides a UI element. Could be overridden to include animations or additional logic.
    public virtual void Hide()
    {
        gameObject.SetActive(false);
        // Optionally, add animations or other effects for the UI disappearing
    }

    // Update UI elements with the latest game data
    public virtual void UpdateUI()
    {
        // This method should be overridden to refresh UI components based on game data
    }

    // Optional: Manage dialogs or interactive elements
    public virtual void ShowDialog(string message, System.Action onConfirm = null, System.Action onCancel = null)
    {
        // Implementation for showing dialog boxes with confirm/cancel actions
        // This can be abstract here and implemented specifically in subclasses
    }

    // Optional: Manage in-game notifications or messages
    public virtual void ShowNotification(string message)
    {
        // Implementation for showing in-game notifications or messages
        // Could be used for tooltips, hints, or other brief messages to the player
    }

    Text CreateTextObject(string name, float verticalPosition)
    {
        GameObject textObj = new GameObject(name);
        textObj.transform.SetParent(canvas.transform, false);

        Text textComponent = textObj.AddComponent<Text>();
        textComponent.font = Resources.GetBuiltinResource<Font>("LegacyRuntime.ttf");
        textComponent.fontSize = 24;
        textComponent.alignment = TextAnchor.MiddleCenter;
        textComponent.rectTransform.sizeDelta = new Vector2(screenWidth * 0.9f, screenHeight * 0.15f);
        textComponent.rectTransform.anchoredPosition = new Vector2(0, verticalPosition - screenHeight / 2);
        textComponent.enabled = false;

        return textComponent;
    }

    protected void ShowMessage(string message, MessagePosition position)
    {
        Text targetText = middleText; // Default to middle.
        switch (position)
        {
            case MessagePosition.Top:
                targetText = topText;
                break;
            case MessagePosition.Middle:
                targetText = middleText;
                break;
            case MessagePosition.Bottom:
                targetText = bottomText;
                break;
        }
        targetText.text = message;
        targetText.enabled = true;
    }

    public void HideMessage(MessagePosition position)
    {
        Text targetText = middleText; // Default to middle
        switch (position)
        {
            case MessagePosition.Top:
                targetText = topText;
                break;
            case MessagePosition.Middle:
                targetText = middleText;
                break;
            case MessagePosition.Bottom:
                targetText = bottomText;
                break;
        }

        targetText.enabled = false; // Disable the text when not needed
    }

    private void AddCanvasOnClickListener()
    {
        //canvas.gameObject.AddComponent<Button>().onClick.AddListener(DisplayNextMessage);
        // Create a new GameObject to act as the clickable area for advancing messages
        GameObject clickArea = new GameObject("ClickArea");
        clickArea.transform.SetParent(canvas.transform, false);

        // Add an Image component which will be used to capture the click events
        Image clickAreaImage = clickArea.AddComponent<Image>();
        clickAreaImage.color = new Color(0, 0, 0, 0); // Make it transparent

        // Optionally, adjust the size and position of the click area here
        RectTransform rectTransform = clickArea.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.anchoredPosition = Vector2.zero;

        // Add a Button component to this click area for handling clicks
        Button clickButton = clickArea.AddComponent<Button>();
        clickButton.onClick.AddListener(DisplayNextMessage);

        // Set the position and size of the click area
        // Example: Set it to cover the bottom part of the screen
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 0.8f); // Cover bottom 30% of the screen
        rectTransform.anchoredPosition = new Vector2(0, 1);
        rectTransform.sizeDelta = new Vector2(0, 0);
    }

    protected void DisplayNextMessage()
    {
        if(currentStepIndex < message.steps.Length)
        {
            MessageDataStep step = message.steps[currentStepIndex];
            ShowMessage(step.text, step.position);
            currentStepIndex++;
        } else
        {
            currentStepIndex = 0;
            Debug.Log("Current message display completed.");
        }
    }
}
