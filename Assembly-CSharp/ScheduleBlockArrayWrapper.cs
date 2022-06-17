// Decompiled with JetBrains decompiler
// Type: ScheduleBlockArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class ScheduleBlockArrayWrapper : ArrayWrapper<ScheduleBlock>
{
  public ScheduleBlockArrayWrapper(int size)
    : base(size)
  {
  }

  public ScheduleBlockArrayWrapper(ScheduleBlock[] elements)
    : base(elements)
  {
  }
}
