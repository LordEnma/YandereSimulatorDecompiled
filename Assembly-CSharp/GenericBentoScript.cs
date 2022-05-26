// Decompiled with JetBrains decompiler
// Type: GenericBentoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GenericBentoScript : MonoBehaviour
{
  public GameObject EmptyGameObject;
  public GameObject Lid;
  public Transform PoisonSpot;
  public PromptScript Prompt;
  public bool Emetic;
  public bool Tranquil;
  public bool Headache;
  public bool Lethal;
  public bool Tampered;
  public int StudentID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0 && (double) this.Prompt.Circle[1].fillAmount != 0.0 && (double) this.Prompt.Circle[2].fillAmount != 0.0 && (double) this.Prompt.Circle[3].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
    if (!this.Prompt.Yandere.StudentManager.YandereVisible)
    {
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        if (this.Prompt.Yandere.Inventory.EmeticPoison)
        {
          this.Prompt.Yandere.Inventory.EmeticPoison = false;
          this.Prompt.Yandere.PoisonType = 1;
        }
        else
        {
          this.Prompt.Yandere.Inventory.RatPoison = false;
          this.Prompt.Yandere.PoisonType = 3;
        }
        this.Emetic = true;
        this.ShutOff();
      }
      else if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      {
        if (this.Prompt.Yandere.Inventory.Sedative)
          this.Prompt.Yandere.Inventory.Sedative = false;
        else
          this.Prompt.Yandere.Inventory.Tranquilizer = false;
        this.Prompt.Yandere.PoisonType = 4;
        this.Tranquil = true;
        this.ShutOff();
      }
      else if ((double) this.Prompt.Circle[2].fillAmount == 0.0)
      {
        if (this.Prompt.Yandere.Inventory.LethalPoison)
        {
          this.Prompt.Yandere.Inventory.LethalPoison = false;
          --this.Prompt.Yandere.Inventory.LethalPoisons;
          this.Prompt.Yandere.PoisonType = 2;
        }
        else
        {
          this.Prompt.Yandere.Inventory.ChemicalPoison = false;
          --this.Prompt.Yandere.Inventory.LethalPoisons;
          this.Prompt.Yandere.PoisonType = 2;
        }
        this.Lethal = true;
        this.ShutOff();
      }
      else
      {
        if ((double) this.Prompt.Circle[3].fillAmount != 0.0)
          return;
        this.Prompt.Yandere.Inventory.HeadachePoison = false;
        this.Prompt.Yandere.PoisonType = 5;
        this.Headache = true;
        this.ShutOff();
      }
    }
    else
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Prompt.Circle[1].fillAmount = 1f;
      this.Prompt.Circle[2].fillAmount = 1f;
      this.Prompt.Circle[3].fillAmount = 1f;
      this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  private void ShutOff()
  {
    Debug.Log((object) "Shutting off a bento. This bento should be inaccessible from now on...");
    this.PoisonSpot = Object.Instantiate<GameObject>(this.EmptyGameObject, this.transform.position, Quaternion.identity).transform;
    this.PoisonSpot.position = new Vector3(this.PoisonSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PoisonSpot.position.z);
    this.PoisonSpot.LookAt(this.Prompt.Yandere.transform.position);
    this.PoisonSpot.Translate(Vector3.forward * 0.25f);
    this.Prompt.Yandere.CharacterAnimation["f02_poisoning_00"].speed = 2f;
    this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
    this.Prompt.Yandere.StudentManager.UpdateAllBentos();
    this.Prompt.Yandere.TargetBento = this;
    this.Prompt.Yandere.Poisoning = true;
    this.Prompt.Yandere.CanMove = false;
    this.Tampered = true;
    this.enabled = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  public void UpdatePrompts()
  {
    if (this.Tampered)
      return;
    this.Prompt.HideButton[0] = true;
    this.Prompt.HideButton[1] = true;
    this.Prompt.HideButton[2] = true;
    this.Prompt.HideButton[3] = true;
    if (this.Prompt.Yandere.Inventory.EmeticPoison || this.Prompt.Yandere.Inventory.RatPoison)
      this.Prompt.HideButton[0] = false;
    if (this.Prompt.Yandere.Inventory.Tranquilizer || this.Prompt.Yandere.Inventory.Sedative)
      this.Prompt.HideButton[1] = false;
    if (this.Prompt.Yandere.Inventory.LethalPoison || this.Prompt.Yandere.Inventory.ChemicalPoison)
      this.Prompt.HideButton[2] = false;
    if (this.Prompt.Yandere.Inventory.HeadachePoison)
      this.Prompt.HideButton[3] = false;
    this.Prompt.Yandere.EmptyHands();
  }
}
