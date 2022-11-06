// Decompiled with JetBrains decompiler
// Type: YouTubeChatMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class YouTubeChatMessage
{
  public string Author;
  public string TimeStamp;
  public string Message;

  public YouTubeChatMessage(string author, string timestamp, string message)
  {
    this.Author = author;
    this.TimeStamp = timestamp;
    this.Message = message;
  }
}
