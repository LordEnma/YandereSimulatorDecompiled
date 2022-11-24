// Decompiled with JetBrains decompiler
// Type: ForceRotationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ForceRotationScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;

  private void LateUpdate() => this.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
}
