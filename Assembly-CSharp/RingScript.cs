// Decompiled with JetBrains decompiler
// Type: RingScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RingScript : MonoBehaviour
{
  public RingEventScript RingEvent;
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
    if (!this.Prompt.Yandere.StudentManager.YandereVisible)
    {
      SchemeGlobals.SetSchemeStage(2, 5);
      this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
      this.Prompt.Yandere.Inventory.Ring = true;
      this.Prompt.Yandere.TheftTimer = 0.1f;
      this.RingEvent.RingStolen = true;
      this.gameObject.SetActive(false);
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }
}
