// Decompiled with JetBrains decompiler
// Type: ScheduleBlock
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
