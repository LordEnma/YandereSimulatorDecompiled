// Decompiled with JetBrains decompiler
// Type: YouTubeChatMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
