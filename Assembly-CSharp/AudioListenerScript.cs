// Decompiled with JetBrains decompiler
// Type: AudioListenerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
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
