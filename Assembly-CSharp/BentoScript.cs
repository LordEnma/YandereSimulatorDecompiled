// Decompiled with JetBrains decompiler
// Type: BentoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BentoScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public Transform PoisonSpot;
  public PromptScript Prompt;
  public bool BeingPoisoned;
  public int Poison;
  public int ID;

  private void Start()
  {
    if (!((Object) this.Prompt.Yandere != (Object) null))
      return;
    this.Yandere = this.Prompt.Yandere;
  }

  private void Update()
  {
    if ((Object) this.Yandere == (Object) null)
    {
      if (!((Object) this.Prompt.Yandere != (Object) null))
        return;
      this.Yandere = this.Prompt.Yandere;
    }
    else if (this.Yandere.Inventory.EmeticPoisons > 0 || this.Yandere.Inventory.LethalPoisons > 0)
    {
      this.Prompt.enabled = true;
      this.Prompt.HideButton[0] = this.Yandere.Inventory.EmeticPoisons <= 0;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          --this.Yandere.Inventory.EmeticPoisons;
          this.Yandere.PoisonType = 1;
          this.StudentManager.Students[this.ID].MyBento.Tampered = true;
          this.StudentManager.Students[this.ID].MyBento.Emetic = true;
          this.StudentManager.Students[this.ID].Emetic = true;
          this.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
          this.Yandere.PoisonSpot = this.PoisonSpot;
          this.Yandere.Poisoning = true;
          this.Yandere.CanMove = false;
          this.enabled = false;
          this.Poison = 1;
          if (this.ID != 1)
            this.StudentManager.Students[this.ID].Emetic = true;
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.Prompt.Yandere.StudentManager.UpdateAllBentos();
          this.BeingPoisoned = true;
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
      if (this.ID != 11 && this.ID != 6)
        return;
      this.Prompt.HideButton[1] = this.Prompt.Yandere.Inventory.LethalPoisons <= 0;
      if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
        return;
      this.Yandere.Sanity -= (PlayerGlobals.PantiesEquipped == 10 ? 10f : 20f) * this.Yandere.Numbness;
      --this.Prompt.Yandere.Inventory.LethalPoisons;
      this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
      this.StudentManager.Students[this.ID].MyBento.Tampered = true;
      this.StudentManager.Students[this.ID].MyBento.Lethal = true;
      this.StudentManager.Students[this.ID].Lethal = true;
      this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
      this.Prompt.Yandere.Poisoning = true;
      this.Prompt.Yandere.CanMove = false;
      this.Prompt.Yandere.PoisonType = 2;
      this.enabled = false;
      this.Poison = 2;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Yandere.StudentManager.UpdateAllBentos();
      this.BeingPoisoned = true;
    }
    else
      this.Prompt.enabled = false;
  }
}
