// Decompiled with JetBrains decompiler
// Type: SecuritySystemScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SecuritySystemScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Evidence;
  public bool Masked;
  public SecurityCameraScript[] Cameras;
  public MetalDetectorScript[] Detectors;

  private void Start()
  {
    if (PlayerGlobals.Kills != 0 || SchoolGlobals.HighSecurity)
      return;
    this.enabled = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Prompt.Yandere.Inventory.IDCard)
    {
      for (int index = 0; index < this.Cameras.Length; ++index)
      {
        this.Cameras[index].transform.parent.transform.parent.gameObject.GetComponent<AudioSource>().Stop();
        this.Cameras[index].gameObject.SetActive(false);
      }
      for (int index = 0; index < this.Detectors.Length; ++index)
      {
        this.Detectors[index].MyCollider.enabled = false;
        this.Detectors[index].enabled = false;
      }
      this.GetComponent<AudioSource>().Play();
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Evidence = false;
      this.enabled = false;
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "Faculty ID card required!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }
}
