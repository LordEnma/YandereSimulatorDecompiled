// Decompiled with JetBrains decompiler
// Type: PoisonBottleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PoisonBottleScript : MonoBehaviour
{
  public PromptScript Prompt;
  public bool Theft;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 1f;
    if (this.Theft)
      this.Prompt.Yandere.TheftTimer = 0.1f;
    if (this.ID == 1)
      this.Prompt.Yandere.Inventory.EmeticPoison = true;
    else if (this.ID == 2)
    {
      this.Prompt.Yandere.Inventory.LethalPoison = true;
      ++this.Prompt.Yandere.Inventory.LethalPoisons;
    }
    else if (this.ID == 3)
    {
      if (!this.Prompt.Yandere.Inventory.RatPoison)
      {
        this.Prompt.Yandere.Inventory.RatPoison = true;
      }
      else
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "You're already carrying some of that";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
    }
    else if (this.ID == 4)
      this.Prompt.Yandere.Inventory.HeadachePoison = true;
    else if (this.ID == 5)
      this.Prompt.Yandere.Inventory.Tranquilizer = true;
    else if (this.ID == 6)
      this.Prompt.Yandere.Inventory.Sedative = true;
    this.Prompt.Yandere.StudentManager.UpdateAllBentos();
    Object.Destroy((Object) this.gameObject);
  }
}
