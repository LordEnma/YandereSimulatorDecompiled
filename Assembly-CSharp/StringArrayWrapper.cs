// Decompiled with JetBrains decompiler
// Type: StringArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
  public StringArrayWrapper(int size)
    : base(size)
  {
  }

  public StringArrayWrapper(string[] elements)
    : base(elements)
  {
  }
}
