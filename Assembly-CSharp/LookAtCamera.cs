// Decompiled with JetBrains decompiler
// Type: LookAtCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
  public Camera cameraToLookAt;

  private void Start()
  {
    if (!((Object) this.cameraToLookAt == (Object) null))
      return;
    this.cameraToLookAt = Camera.main;
  }

  private void Update() => this.transform.LookAt(this.cameraToLookAt.transform.position - new Vector3(0.0f, this.cameraToLookAt.transform.position.y - this.transform.position.y, 0.0f));
}
