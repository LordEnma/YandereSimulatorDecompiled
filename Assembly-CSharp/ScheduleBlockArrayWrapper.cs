// Decompiled with JetBrains decompiler
// Type: ScheduleBlockArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
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
