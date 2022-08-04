// Decompiled with JetBrains decompiler
// Type: GloveScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GloveScript : MonoBehaviour
{
  public PromptScript Prompt;
  public PickUpScript PickUp;
  public Collider MyCollider;
  public Projector Blood;
  public bool Raincoat;
  public int GloveID;

  private void Start()
  {
    Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<YandereScript>().GetComponent<Collider>(), this.MyCollider);
    if ((double) this.transform.position.y <= 1000.0)
      return;
    this.transform.position = new Vector3(12f, 0.0f, 28f);
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (this.Prompt.Yandere.Invisible)
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Can't wear this while invisible!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else if (this.Prompt.Yandere.WearingRaincoat || this.Prompt.Yandere.Gloved)
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "Can't combine clothing!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else
      {
        this.transform.parent = this.Prompt.Yandere.transform;
        this.transform.localPosition = new Vector3(0.0f, 1f, 0.25f);
        if (this.Raincoat)
          this.Prompt.Yandere.WearingRaincoat = true;
        this.Prompt.Yandere.StudentManager.GloveID = this.GloveID;
        Debug.Log((object) ("The StudentManager was just informed that GloveID should be: " + this.GloveID.ToString()));
        this.Prompt.Yandere.Gloves = this;
        this.Prompt.Yandere.WearGloves();
        this.gameObject.SetActive(false);
      }
    }
    this.Prompt.HideButton[0] = this.Prompt.Yandere.Schoolwear != 1 || this.Prompt.Yandere.ClubAttire;
  }
}
