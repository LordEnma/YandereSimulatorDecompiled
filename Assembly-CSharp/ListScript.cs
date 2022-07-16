// Decompiled with JetBrains decompiler
// Type: ListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
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
