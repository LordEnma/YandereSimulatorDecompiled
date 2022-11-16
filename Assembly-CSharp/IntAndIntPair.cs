// Decompiled with JetBrains decompiler
// Type: IntAndIntPair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class IntAndIntPair : SerializablePair<int, int>
{
  public IntAndIntPair(int first, int second)
    : base(first, second)
  {
  }

  public IntAndIntPair()
    : base(0, 0)
  {
  }
}
