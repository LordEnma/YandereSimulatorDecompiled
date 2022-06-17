// Decompiled with JetBrains decompiler
// Type: GhostScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GhostScript : MonoBehaviour
{
  public Transform SmartphoneCamera;
  public Transform Neck;
  public Transform GhostEyeLocation;
  public Transform GhostEye;
  public int Frame;
  public bool Move;

  private void Update()
  {
    if ((double) Time.timeScale <= 9.99999974737875E-05)
      return;
    if (this.Frame > 0)
    {
      this.GetComponent<Animation>().enabled = false;
      this.gameObject.SetActive(false);
      this.Frame = 0;
    }
    ++this.Frame;
  }

  public void Look() => this.Neck.LookAt(this.SmartphoneCamera.position);
}
