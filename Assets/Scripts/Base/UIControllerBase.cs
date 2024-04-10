using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UIControllerBase : MonoBehaviourBase
{
    //protected string autoStoragePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "Kardia Project Save", "save");
    protected string autoSavePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
         "Kardia Project Save", "save");
    protected string autoSaveFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
        "Kardia Project Save", "save", "autosave.json");
    protected string globalConfigFile;
    // Use this method to initialize any UI components
    protected override void Start()
    {
        base.Start(); // Calls the base start method for any general initialization
        InitializeUI();
    }

    // Initialize UI elements here. This can be overridden by subclasses for specific UI setups.
    protected virtual void InitializeUI()
    {
        // Initialization logic for UI elements
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
}
