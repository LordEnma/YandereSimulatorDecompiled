// Decompiled with JetBrains decompiler
// Type: YanSavePlayerPrefTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
