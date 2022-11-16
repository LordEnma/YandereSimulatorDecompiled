// Decompiled with JetBrains decompiler
// Type: TrashCanScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
  public WeaponScript ConcealedWeapon;
  public ContainerScript Container;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public Transform TrashPosition;
  public Rigidbody MyRigidbody;
  public GameObject Item;
  public bool Occupied;
  public bool Wearable;
  public bool Weapon;
  public bool Foil;
  public bool Worn;
  public float KinematicTimer;
  public int BagID;

  private void Start() => Physics.IgnoreCollision(this.Yandere.GetComponent<Collider>(), (Collider) this.gameObject.GetComponent<BoxCollider>());

  private void Update()
  {
    if (!this.Occupied)
    {
      if (this.Prompt.HideButton[0])
      {
        if (this.Yandere.Armed)
          this.UpdatePrompt();
      }
      else
      {
        if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
        {
          this.Prompt.Circle[0].fillAmount = 1f;
          if ((Object) this.Yandere.PickUp != (Object) null && (Object) this.Yandere.PickUp.TrashCan != (Object) null)
          {
            this.Yandere.NotificationManager.CustomText = "You can't fit that in there.";
            this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
          }
          else
            this.StashItem();
        }
        if (!this.Yandere.Armed)
          this.UpdatePrompt();
      }
    }
    else if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      this.RemoveContents();
    if ((Object) this.Item != (Object) null)
    {
      if (this.Weapon)
      {
        if ((Object) this.ConcealedWeapon != (Object) null && this.ConcealedWeapon.WeaponID == 23)
        {
          if (this.Wearable)
          {
            this.Item.transform.localPosition = new Vector3(-0.05f, 0.25f, 0.0066666f);
            this.Item.transform.localEulerAngles = new Vector3(-90f, 0.0f, 0.0f);
            this.Item.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
          }
          else
          {
            this.Item.transform.localPosition = new Vector3(-0.1f, 0.29f, 0.0f);
            this.Item.transform.localEulerAngles = new Vector3(-90f, 0.0f, 0.0f);
          }
        }
        else
        {
          this.Item.transform.localPosition = new Vector3(0.0f, 0.29f, 0.0f);
          this.Item.transform.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
        }
        if ((Object) this.Item.transform.parent != (Object) this.TrashPosition)
        {
          this.Item = (GameObject) null;
          this.Weapon = false;
        }
      }
      else
      {
        this.Item.transform.localPosition = new Vector3(0.0f, 0.0f, -0.021f);
        this.Item.transform.localEulerAngles = Vector3.zero;
      }
    }
    if (!this.Wearable)
      return;
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      if ((Object) this.Prompt.Yandere.Container != (Object) null)
      {
        this.Prompt.Yandere.NotificationManager.CustomText = "You're already wearing something on your back!";
        this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      }
      else
        this.AttachToBack();
    }
    if ((Object) this.Yandere.PickUp != (Object) null && this.Yandere.PickUp.Tinfoil)
    {
      this.Prompt.HideButton[1] = false;
      if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
      {
        this.Prompt.Circle[1].fillAmount = 1f;
        this.Foil = true;
        GameObject gameObject = this.Yandere.PickUp.gameObject;
        this.Yandere.EmptyHands();
        gameObject.SetActive(false);
      }
    }
    else
      this.Prompt.HideButton[1] = true;
    if (this.MyRigidbody.isKinematic)
      return;
    this.KinematicTimer = Mathf.MoveTowards(this.KinematicTimer, 5f, Time.deltaTime);
    if ((double) this.KinematicTimer == 5.0)
    {
      this.MyRigidbody.isKinematic = true;
      this.KinematicTimer = 0.0f;
    }
    if ((double) this.transform.position.x > -71.0 && (double) this.transform.position.x < -61.0 && (double) this.transform.position.z > -37.5 && (double) this.transform.position.z < -27.5)
    {
      this.Yandere.NotificationManager.CustomText = "You can't drop that there!";
      this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      this.transform.position = new Vector3(-63f, 1f, -26.5f);
      this.KinematicTimer = 0.0f;
    }
    if ((double) this.transform.position.x > -21.0 && (double) this.transform.position.x < 21.0 && (double) this.transform.position.z > 100.0 && (double) this.transform.position.z < 135.0)
    {
      this.transform.position = new Vector3(0.0f, 1f, 100f);
      this.KinematicTimer = 0.0f;
    }
    if ((double) this.transform.position.x <= -46.0 || (double) this.transform.position.x >= -18.0 || (double) this.transform.position.z <= 66.0 || (double) this.transform.position.z >= 78.0)
      return;
    this.transform.position = new Vector3(-16f, 5f, 72f);
    this.KinematicTimer = 0.0f;
  }

  public void UpdatePrompt()
  {
    if (!this.Occupied)
    {
      if (this.Yandere.Armed)
      {
        this.Prompt.Label[0].text = "     Insert";
        this.Prompt.HideButton[0] = false;
      }
      else if ((Object) this.Yandere.PickUp != (Object) null)
      {
        if (!(bool) (Object) this.Yandere.PickUp.Bucket && !(bool) (Object) this.Yandere.PickUp.Mop)
        {
          if (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Suspicious)
          {
            this.Prompt.Label[0].text = "     Insert";
            this.Prompt.HideButton[0] = false;
          }
          else
            this.Prompt.HideButton[0] = true;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else
        this.Prompt.HideButton[0] = true;
    }
    else
    {
      this.Prompt.Label[0].text = "     Remove";
      this.Prompt.HideButton[0] = false;
    }
  }

  public void RemoveContents()
  {
    this.Prompt.Circle[0].fillAmount = 1f;
    this.Item.GetComponent<PromptScript>().Circle[3].fillAmount = -1f;
    this.Item.GetComponent<PromptScript>().enabled = true;
    if ((Object) this.Item.GetComponent<PickUpScript>() != (Object) null)
      this.Item.transform.localScale = this.Item.GetComponent<PickUpScript>().OriginalScale;
    this.Item = (GameObject) null;
    this.ConcealedWeapon = (WeaponScript) null;
    this.Occupied = false;
    this.Weapon = false;
    this.UpdatePrompt();
  }

  public void StashItem()
  {
    if ((Object) this.Yandere.PickUp != (Object) null)
    {
      this.Item = this.Yandere.PickUp.gameObject;
      this.Yandere.EmptyHands();
    }
    else
    {
      Debug.Log((object) "Concealing a weapon in the weapon bag.");
      this.ConcealedWeapon = this.Yandere.EquippedWeapon;
      this.Yandere.DropTimer[this.Yandere.Equipped] = 0.5f;
      this.Yandere.DropWeapon(this.Yandere.Equipped);
      this.PutWeaponInBag();
    }
    this.PositionItem();
  }

  public void PositionItem()
  {
    this.Item.transform.parent = this.TrashPosition;
    this.Item.GetComponent<Rigidbody>().useGravity = false;
    this.Item.GetComponent<Collider>().enabled = false;
    this.Item.GetComponent<PromptScript>().Hide();
    this.Item.GetComponent<PromptScript>().enabled = false;
    this.Occupied = true;
    this.UpdatePrompt();
    this.Item.transform.localScale = new Vector3(0.33333f, 0.5f, 0.5f);
    if (!((Object) this.ConcealedWeapon != (Object) null) || this.ConcealedWeapon.Type == WeaponType.Bat || this.ConcealedWeapon.Type == WeaponType.Katana)
      return;
    this.Item.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
  }

  public void AttachToBack()
  {
    Debug.Log((object) "The weapon bag is now being attached to the player's back.");
    this.transform.parent = this.Prompt.Yandere.Backpack;
    this.transform.localPosition = Vector3.zero;
    this.transform.localEulerAngles = new Vector3(90f, -154f, 0.0f);
    if ((Object) this.Prompt.Yandere.Container != (Object) null)
      this.Prompt.Yandere.Container.Drop();
    this.Prompt.Yandere.Container = this.Container;
    this.Prompt.Yandere.WeaponMenu.UpdateSprites();
    this.Prompt.MyCollider.enabled = false;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.MyRigidbody.isKinematic = true;
    this.MyRigidbody.useGravity = false;
    this.Worn = true;
  }

  public void PutWeaponInBag()
  {
    this.Item = this.ConcealedWeapon.gameObject;
    this.ConcealedWeapon.MyRigidbody.isKinematic = true;
    this.ConcealedWeapon.InBag = true;
    this.ConcealedWeapon.BagID = this.BagID;
    this.Weapon = true;
    this.PositionItem();
  }
}
