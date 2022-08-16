// Decompiled with JetBrains decompiler
// Type: ArrayLayout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class ArrayLayout
{
  public ArrayLayout.rowData[] rows = new ArrayLayout.rowData[6];

  [Serializable]
  public struct rowData
  {
    public bool[] row;
  }
}
