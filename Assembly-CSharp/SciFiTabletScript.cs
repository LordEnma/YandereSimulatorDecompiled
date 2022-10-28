// Decompiled with JetBrains decompiler
// Type: SciFiTabletScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SciFiTabletScript : MonoBehaviour
{
  public StudentScript Student;
  public HologramScript Holograms;
  public Transform Finger;
  public bool Updated;

  private void Start() => this.Holograms = this.Student.StudentManager.Holograms;

  private void Update()
  {
    if ((double) Vector3.Distance(this.Finger.position, this.transform.position) < 0.1)
    {
      if (this.Updated)
        return;
      this.Holograms.UpdateHolograms();
      this.Updated = true;
    }
    else
      this.Updated = false;
  }
}
