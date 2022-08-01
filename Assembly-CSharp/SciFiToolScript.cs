// Decompiled with JetBrains decompiler
// Type: SciFiToolScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SciFiToolScript : MonoBehaviour
{
  public StudentScript Student;
  public ParticleSystem Sparks;
  public Transform Target;
  public Transform Tip;

  private void Start() => this.Target = this.Student.StudentManager.ToolTarget;

  private void Update()
  {
    if ((double) Vector3.Distance(this.Tip.position, this.Target.position) < 0.1)
      this.Sparks.Play();
    else
      this.Sparks.Stop();
  }
}
