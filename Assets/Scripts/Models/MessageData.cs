[System.Serializable]
public class MessageData
{
    public MessageDataStep[] steps;


    public MessageDataEndHandler onEnd;

}

[System.Serializable]
public class MessageDataStep
{
    public string text;
    public MessagePosition position;
}

[System.Serializable]
public class MessageDataEndHandler
{
    public string action;
    public EndHandlerOption[] options;
    public string targetVariable;
    public bool needConfirm;
    public string nextScript;
}

[System.Serializable]
public class EndHandlerOption
{
    public string selection;
    public string description;
}