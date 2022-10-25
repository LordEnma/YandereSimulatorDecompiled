// Decompiled with JetBrains decompiler
// Type: YanSavePlayerPrefTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public struct YanSavePlayerPrefTracker
{
  public List<string> PrefFormatValues;
  public YanSavePlayerPrefsType PrefType;
  public string PrefFormat;
  public int RangeMax;
}
