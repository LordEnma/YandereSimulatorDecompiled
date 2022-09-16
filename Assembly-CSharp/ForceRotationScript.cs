// Decompiled with JetBrains decompiler
// Type: ForceRotationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ForceRotationScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;

  private void LateUpdate() => this.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
}
