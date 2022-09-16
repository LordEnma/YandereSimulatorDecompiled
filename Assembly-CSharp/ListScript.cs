// Decompiled with JetBrains decompiler
// Type: ListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ListScript : MonoBehaviour
{
  public Transform[] List;
  public bool AutoFill;

  public void Start()
  {
    if (!this.AutoFill)
      return;
    for (int index = 1; index < this.List.Length; ++index)
      this.List[index] = this.transform.GetChild(index - 1);
  }
}
