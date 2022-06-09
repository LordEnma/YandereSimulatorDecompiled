// Decompiled with JetBrains decompiler
// Type: YouTubeChatMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
