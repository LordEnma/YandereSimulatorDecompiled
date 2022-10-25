// Decompiled with JetBrains decompiler
// Type: ArrayLayout
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
