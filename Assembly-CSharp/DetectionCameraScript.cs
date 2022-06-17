// Decompiled with JetBrains decompiler
// Type: DetectionCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DetectionCameraScript : MonoBehaviour
{
  public Transform YandereChan;

  private void Update()
  {
    this.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
    this.transform.eulerAngles = new Vector3(90f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
  }
}
