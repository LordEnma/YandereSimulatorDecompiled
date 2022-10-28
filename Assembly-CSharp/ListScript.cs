// Decompiled with JetBrains decompiler
// Type: ListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
