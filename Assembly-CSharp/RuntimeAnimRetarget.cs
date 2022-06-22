// Decompiled with JetBrains decompiler
// Type: RuntimeAnimRetarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RuntimeAnimRetarget : MonoBehaviour
{
  public GameObject Source;
  public GameObject Target;
  private Component[] SourceSkelNodes;
  private Component[] TargetSkelNodes;

  private void Start()
  {
    Debug.Log((object) this.Source.name);
    this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
    this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
  }

  private void LateUpdate()
  {
    this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
    for (int index = 0; index < 154; ++index)
      this.TargetSkelNodes[index].transform.localRotation = this.SourceSkelNodes[index].transform.localRotation;
  }
}
