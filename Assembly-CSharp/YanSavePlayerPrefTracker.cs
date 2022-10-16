// Decompiled with JetBrains decompiler
// Type: YanSavePlayerPrefTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
