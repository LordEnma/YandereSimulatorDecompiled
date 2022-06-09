// Decompiled with JetBrains decompiler
// Type: ArrayLayout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
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
