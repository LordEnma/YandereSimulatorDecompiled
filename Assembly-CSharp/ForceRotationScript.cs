// Decompiled with JetBrains decompiler
// Type: ForceRotationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ForceRotationScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;

  private void LateUpdate() => this.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
}
