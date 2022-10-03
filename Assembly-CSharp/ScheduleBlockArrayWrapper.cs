// Decompiled with JetBrains decompiler
// Type: ScheduleBlockArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
