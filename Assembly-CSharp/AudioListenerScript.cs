// Decompiled with JetBrains decompiler
// Type: AudioListenerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AudioListenerScript : MonoBehaviour
{
  public Transform Target;
  public Camera mainCamera;

  private void Start() => this.mainCamera = Camera.main;

  private void Update()
  {
    this.transform.position = this.Target.position;
    this.transform.eulerAngles = this.mainCamera.transform.eulerAngles;
  }
}
