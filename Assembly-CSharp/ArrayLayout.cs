// Decompiled with JetBrains decompiler
// Type: ArrayLayout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
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
