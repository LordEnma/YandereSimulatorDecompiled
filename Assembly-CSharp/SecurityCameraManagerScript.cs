// Decompiled with JetBrains decompiler
// Type: SecurityCameraManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SecurityCameraManagerScript : MonoBehaviour
{
  public GameObject[] Cameras;

  private void Start()
  {
    for (int index = !SchoolGlobals.HighSecurity ? PlayerGlobals.CorpsesDiscovered : this.Cameras.Length; index > 0; --index)
    {
      if (index < this.Cameras.Length)
        this.Cameras[index].SetActive(true);
    }
  }

  public void ActivateAllCameras()
  {
    for (int length = this.Cameras.Length; length > 0; --length)
    {
      if (length < this.Cameras.Length)
        this.Cameras[length].SetActive(true);
    }
  }
}
