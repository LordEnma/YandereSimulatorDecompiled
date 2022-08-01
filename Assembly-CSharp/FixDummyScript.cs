// Decompiled with JetBrains decompiler
// Type: FixDummyScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FixDummyScript : MonoBehaviour
{
  public GameObject FixedDummy;
  public PromptScript Prompt;

  private void Start()
  {
    this.FixedDummy.SetActive(false);
    if (!GameGlobals.Eighties)
      return;
    this.Fix();
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.WeaponID == 24)
    {
      this.Fix();
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "Wrench required!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  private void Fix()
  {
    this.gameObject.SetActive(false);
    this.FixedDummy.SetActive(true);
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }
}
