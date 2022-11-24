// Decompiled with JetBrains decompiler
// Type: AudioListenerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
