[System.Serializable]
public class MessageData
{
    public string Text;
    public MessagePosition Position;

    public MessageData(string text, MessagePosition position)
    {
        Text = text;
        Position = position;
    }
}