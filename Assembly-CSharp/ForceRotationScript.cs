// Decompiled with JetBrains decompiler
// Type: ForceRotationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ForceRotationScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;

  private void LateUpdate() => this.transform.eulerAngles = new Vector3(this.X, this.Y, this.Z);
}
