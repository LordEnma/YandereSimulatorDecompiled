// Decompiled with JetBrains decompiler
// Type: IntAndIntPair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
