// Decompiled with JetBrains decompiler
// Type: StringArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
