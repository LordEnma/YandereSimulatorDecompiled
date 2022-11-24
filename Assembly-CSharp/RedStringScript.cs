// Decompiled with JetBrains decompiler
// Type: RedStringScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RedStringScript : MonoBehaviour
{
  public Transform Target;

  private void LateUpdate()
  {
    this.transform.LookAt(this.Target.position);
    this.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(this.transform.position, this.Target.position));
  }
}
