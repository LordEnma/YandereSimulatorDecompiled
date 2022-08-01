// Decompiled with JetBrains decompiler
// Type: LookAtSCP
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LookAtSCP : MonoBehaviour
{
  public Transform SCP;

  private void Start()
  {
    if ((Object) this.SCP == (Object) null)
      this.SCP = GameObject.Find("SCPTarget").transform;
    this.transform.LookAt(this.SCP);
  }

  private void LateUpdate() => this.transform.LookAt(this.SCP);
}
