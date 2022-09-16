// Decompiled with JetBrains decompiler
// Type: YanSaveStaticIdentifier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class YanSaveStaticIdentifier : MonoBehaviour
{
  [SerializeField]
  public List<string> StaticTypeNames = new List<string>();
  [SerializeField]
  public List<KeyValuePair<System.Type, string>> DisabledMembers = new List<KeyValuePair<System.Type, string>>();
  [SerializeField]
  public List<YanSavePlayerPrefTracker> PrefTrackers = new List<YanSavePlayerPrefTracker>();
}
