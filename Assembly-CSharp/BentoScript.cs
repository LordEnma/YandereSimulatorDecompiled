// Decompiled with JetBrains decompiler
// Type: BentoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BentoScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public YandereScript Yandere;
  public Transform PoisonSpot;
  public PromptScript Prompt;
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
    else if (this.Yandere.Inventory.EmeticPoison || this.Yandere.Inventory.RatPoison || this.Yandere.Inventory.LethalPoison || this.Yandere.Inventory.ChemicalPoison)
    {
      this.Prompt.enabled = true;
      this.Prompt.HideButton[0] = !this.Yandere.Inventory.EmeticPoison && !this.Yandere.Inventory.RatPoison;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
        if (!this.Prompt.Yandere.StudentManager.YandereVisible)
        {
          if (this.Yandere.Inventory.EmeticPoison)
          {
            this.Yandere.Inventory.EmeticPoison = false;
            this.Yandere.PoisonType = 1;
          }
          else
          {
            this.Yandere.Inventory.RatPoison = false;
            this.Yandere.PoisonType = 3;
          }
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
        }
        else
        {
          this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
          this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
        }
      }
      if (this.ID != 11 && this.ID != 6)
        return;
      this.Prompt.HideButton[1] = !this.Prompt.Yandere.Inventory.LethalPoison && !this.Prompt.Yandere.Inventory.ChemicalPoison;
      if ((double) this.Prompt.Circle[1].fillAmount != 0.0)
        return;
      if (this.Yandere.Inventory.LethalPoison)
        this.Yandere.Inventory.LethalPoison = false;
      else
        this.Yandere.Inventory.ChemicalPoison = false;
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
    }
    else
      this.Prompt.enabled = false;
  }
}
