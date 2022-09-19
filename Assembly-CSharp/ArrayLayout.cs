// Decompiled with JetBrains decompiler
// Type: ArrayLayout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
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
