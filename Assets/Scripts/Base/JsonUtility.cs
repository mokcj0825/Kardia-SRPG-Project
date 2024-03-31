[System.Serializable]
public class ButtonConfig
{
    public string id;
    public string tooltip;
    public int x;
}

[System.Serializable]
public class MenuConfig
{
    public ButtonConfig[] buttons;
}
