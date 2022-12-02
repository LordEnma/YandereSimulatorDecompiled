using System;

[Serializable]
public class YouTubeChatMessage
{
	public string Author;

	public string TimeStamp;

	public string Message;

	public YouTubeChatMessage(string author, string timestamp, string message)
	{
		Author = author;
		TimeStamp = timestamp;
		Message = message;
	}
}
