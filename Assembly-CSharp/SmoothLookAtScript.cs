// Decompiled with JetBrains decompiler
// Type: SmoothLookAtScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmoothLookAtScript : MonoBehaviour
{
  public Transform Target;
  public float Speed;

  private void LateUpdate() => this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Target.transform.position - this.transform.position), Time.deltaTime * this.Speed);
}
