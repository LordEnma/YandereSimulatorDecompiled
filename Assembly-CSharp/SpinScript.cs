// Decompiled with JetBrains decompiler
// Type: SpinScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpinScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;
  private float RotationX;
  private float RotationY;
  private float RotationZ;

  private void Update()
  {
    this.RotationX += this.X * Time.deltaTime;
    this.RotationY += this.Y * Time.deltaTime;
    this.RotationZ += this.Z * Time.deltaTime;
    this.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
  }
}
