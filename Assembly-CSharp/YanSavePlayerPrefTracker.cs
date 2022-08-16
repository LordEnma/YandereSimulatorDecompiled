// Decompiled with JetBrains decompiler
// Type: YanSavePlayerPrefTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
