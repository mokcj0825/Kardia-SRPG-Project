[System.Serializable]
public class ButtonConfig
{
    public string id;
    public string tooltip;
    public int x;
    public string onClick;
}

[System.Serializable]
public class GlobalConfig
{
    public bool loadBackground;
    public bool loadSound;

}

[System.Serializable]
public class MenuConfig
{
    public ButtonConfig[] buttons;
    public GlobalConfig global;
}
