// Decompiled with JetBrains decompiler
// Type: RedStringScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
