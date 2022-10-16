// Decompiled with JetBrains decompiler
// Type: SmoothLookAtScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmoothLookAtScript : MonoBehaviour
{
  public Transform Target;
  public float Speed;

  private void LateUpdate() => this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(this.Target.transform.position - this.transform.position), Time.deltaTime * this.Speed);
}
