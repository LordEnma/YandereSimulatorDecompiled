// Decompiled with JetBrains decompiler
// Type: AudioListenerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
