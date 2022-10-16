// Decompiled with JetBrains decompiler
// Type: YouTubeChatMessage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
