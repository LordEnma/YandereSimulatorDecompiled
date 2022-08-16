// Decompiled with JetBrains decompiler
// Type: ScheduleBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
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
