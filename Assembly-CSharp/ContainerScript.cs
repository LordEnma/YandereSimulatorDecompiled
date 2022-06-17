// Decompiled with JetBrains decompiler
// Type: ContainerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ContainerScript : MonoBehaviour
{
  public TrashCanScript TrashCan;
  public WeaponScript Weapon;
  public PromptScript Prompt;
  public Transform[] BodyPartPositions;
  public Transform WeaponSpot;
  public Transform Lid;
  public Collider GardenArea;
  public Collider NEStairs;
  public Collider NWStairs;
  public Collider SEStairs;
  public Collider SWStairs;
  public PickUpScript[] BodyParts;
  public PickUpScript BodyPart;
  public string SpriteName = string.Empty;
  public bool CelloCase;
  public bool CanDrop;
  public bool Open;
  public int Contents;
  public int ID;

  public void Start()
  {
    this.GardenArea = GameObject.Find("GardenArea").GetComponent<Collider>();
    this.NEStairs = GameObject.Find("NEStairs").GetComponent<Collider>();
    this.NWStairs = GameObject.Find("NWStairs").GetComponent<Collider>();
    this.SEStairs = GameObject.Find("SEStairs").GetComponent<Collider>();
    this.SWStairs = GameObject.Find("SWStairs").GetComponent<Collider>();
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.Open = !this.Open;
      this.UpdatePrompts();
    }
    if ((double) this.Prompt.Circle[1].fillAmount == 0.0)
    {
      this.Prompt.Circle[1].fillAmount = 1f;
      if (this.Prompt.Yandere.Armed)
      {
        this.Weapon = this.Prompt.Yandere.EquippedWeapon;
        this.Prompt.Yandere.EmptyHands();
        this.Weapon.transform.parent = this.WeaponSpot;
        this.Weapon.transform.localPosition = Vector3.zero;
        this.Weapon.transform.localEulerAngles = Vector3.zero;
        this.Weapon.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.Weapon.MyCollider.isTrigger = true;
        this.Weapon.Prompt.Hide();
        this.Weapon.Prompt.enabled = false;
      }
      else
      {
        this.BodyPart = this.Prompt.Yandere.PickUp;
        this.Prompt.Yandere.EmptyHands();
        this.BodyPart.transform.parent = this.BodyPartPositions[this.BodyPart.GetComponent<BodyPartScript>().Type];
        this.BodyPart.transform.localPosition = Vector3.zero;
        this.BodyPart.transform.localEulerAngles = Vector3.zero;
        this.BodyPart.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.BodyPart.MyCollider.isTrigger = true;
        this.BodyParts[this.BodyPart.GetComponent<BodyPartScript>().Type] = this.BodyPart;
      }
      ++this.Contents;
      this.UpdatePrompts();
    }
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      this.Prompt.Circle[3].fillAmount = 1f;
      if (!this.Open)
      {
        this.transform.parent = this.Prompt.Yandere.Backpack;
        this.transform.localPosition = Vector3.zero;
        this.transform.localEulerAngles = Vector3.zero;
        if ((Object) this.Prompt.Yandere.Container != (Object) null)
          this.Prompt.Yandere.Container.Drop();
        this.Prompt.Yandere.Container = this;
        this.Prompt.Yandere.WeaponMenu.UpdateSprites();
        this.Prompt.MyCollider.enabled = false;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        Rigidbody component = this.GetComponent<Rigidbody>();
        component.isKinematic = true;
        component.useGravity = false;
      }
      else
      {
        if ((Object) this.Weapon != (Object) null)
        {
          this.Weapon.Prompt.Circle[3].fillAmount = -1f;
          this.Weapon.Prompt.enabled = true;
          this.Weapon = (WeaponScript) null;
        }
        else
        {
          this.BodyPart = (PickUpScript) null;
          this.ID = 1;
          while ((Object) this.BodyPart == (Object) null)
          {
            this.BodyPart = this.BodyParts[this.ID];
            this.BodyParts[this.ID] = (PickUpScript) null;
            ++this.ID;
          }
          this.BodyPart.Prompt.Circle[3].fillAmount = -1f;
        }
        --this.Contents;
        this.UpdatePrompts();
      }
    }
    this.Lid.localEulerAngles = new Vector3(this.Lid.localEulerAngles.x, this.Lid.localEulerAngles.y, Mathf.Lerp(this.Lid.localEulerAngles.z, this.Open ? 90f : 0.0f, Time.deltaTime * 10f));
    if ((Object) this.Weapon != (Object) null)
    {
      this.Weapon.transform.localPosition = Vector3.zero;
      this.Weapon.transform.localEulerAngles = Vector3.zero;
    }
    for (this.ID = 1; this.ID < this.BodyParts.Length; ++this.ID)
    {
      if ((Object) this.BodyParts[this.ID] != (Object) null)
      {
        this.BodyParts[this.ID].transform.localPosition = Vector3.zero;
        this.BodyParts[this.ID].transform.localEulerAngles = Vector3.zero;
      }
    }
  }

  public void Drop()
  {
    Debug.Log((object) "A container was just dropped.");
    this.transform.parent = (Transform) null;
    if (this.enabled)
    {
      this.transform.position = this.Prompt.Yandere.ObstacleDetector.transform.position + new Vector3(0.0f, 0.5f, 0.0f);
      this.transform.eulerAngles = this.Prompt.Yandere.ObstacleDetector.transform.eulerAngles;
    }
    this.Prompt.Yandere.Container = (ContainerScript) null;
    this.Prompt.MyCollider.enabled = true;
    this.Prompt.enabled = true;
    Rigidbody component = this.GetComponent<Rigidbody>();
    component.isKinematic = false;
    component.useGravity = true;
    if (!((Object) this.TrashCan != (Object) null))
      return;
    this.TrashCan.Worn = false;
  }

  public void UpdatePrompts()
  {
    if ((Object) this.Weapon != (Object) null)
      this.Weapon.MyCollider.enabled = this.Open;
    for (this.ID = 0; this.ID < this.BodyParts.Length; ++this.ID)
    {
      if ((Object) this.BodyParts[this.ID] != (Object) null)
        this.BodyParts[this.ID].MyCollider.enabled = this.Open;
    }
    if (this.Open)
    {
      this.Prompt.Label[0].text = "     Close";
      if (this.Contents > 0)
      {
        this.Prompt.Label[3].text = "     Remove";
        this.Prompt.HideButton[3] = false;
      }
      else
        this.Prompt.HideButton[3] = true;
      if (this.Prompt.Yandere.Armed)
      {
        if (!this.Prompt.Yandere.EquippedWeapon.Concealable)
        {
          if ((Object) this.Weapon == (Object) null)
          {
            this.Prompt.Label[1].text = "     Insert";
            this.Prompt.HideButton[1] = false;
          }
          else
            this.Prompt.HideButton[1] = true;
        }
        else
          this.Prompt.HideButton[1] = true;
      }
      else if ((Object) this.Prompt.Yandere.PickUp != (Object) null)
      {
        if ((Object) this.Prompt.Yandere.PickUp.BodyPart != (Object) null)
        {
          if ((Object) this.BodyParts[this.Prompt.Yandere.PickUp.gameObject.GetComponent<BodyPartScript>().Type] == (Object) null)
          {
            this.Prompt.Label[1].text = "     Insert";
            this.Prompt.HideButton[1] = false;
          }
          else
            this.Prompt.HideButton[1] = true;
        }
        else
          this.Prompt.HideButton[1] = true;
      }
      else
        this.Prompt.HideButton[1] = true;
    }
    else
    {
      if (!((Object) this.Prompt.Label[0] != (Object) null))
        return;
      this.Prompt.Label[0].text = "     Open";
      this.Prompt.HideButton[1] = true;
      this.Prompt.Label[3].text = "     Wear";
      this.Prompt.HideButton[3] = false;
    }
  }
}
