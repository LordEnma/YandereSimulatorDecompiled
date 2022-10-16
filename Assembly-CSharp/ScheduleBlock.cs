// Decompiled with JetBrains decompiler
// Type: ScheduleBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class ScheduleBlock
{
  public float time;
  public string destination;
  public string action;

  public ScheduleBlock(float time, string destination, string action)
  {
    this.time = time;
    this.destination = destination;
    this.action = action;
  }
}
