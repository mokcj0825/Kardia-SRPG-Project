using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManagerBase
{

    public string autoSavePath { get; private set; }
    public string autoSaveFile { get; private set; }
    public string globalConfigFile { get; private set; }
    public string storagePath { get; private set; }

    public FileManagerBase()
    {
        autoSavePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
         "Kardia Project Save", "save");
        autoSaveFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
        "Kardia Project Save", "save", "autosave.json");
        globalConfigFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
            "Kardia Project Save", "storage", "global.config.json");
        storagePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
            "Kardia Project Save", "storage");
        Directory.CreateDirectory(storagePath);
    }

    public void InitializeGlobalConfig()
    {
        if(!File.Exists(globalConfigFile))
        {
            CreateGlobalConfig();
        }
    }

    private void CreateGlobalConfig()
    {
        GlobalConfigObject defaultConfig = new GlobalConfigObject();
        string defaultConfigJson = JsonUtility.ToJson(defaultConfig);
        File.WriteAllText(globalConfigFile, defaultConfigJson);
        Debug.Log($"Created new global config file at: {globalConfigFile}");
    }

    public void InitializeAutoSave()
    {
        if (File.Exists(autoSaveFile))
        {
            DeleteFile(autoSaveFile);
        }
        CreateFile(autoSaveFile);
    }

    public void CreateFile(string filePath, string contents = "")
    {
        File.WriteAllText(filePath, contents);
        Debug.Log($"Created file at: {filePath}");
    }

    public void DeleteFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log($"Deleted file: {filePath}");
        }
    }

}
