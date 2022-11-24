// Decompiled with JetBrains decompiler
// Type: ListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
