// Decompiled with JetBrains decompiler
// Type: BookbagScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BookbagScript : MonoBehaviour
{
  public PickUpScript ConcealedPickup;
  public Rigidbody MyRigidbody;
  public PromptScript Prompt;
  public Texture EightiesBookBagTexture;
  public Mesh EightiesBookBag;
  public Renderer MyRenderer;
  public MeshFilter MyMesh;
  public bool Worn;

  private void Start()
  {
    this.MyRigidbody.useGravity = false;
    this.MyRigidbody.isKinematic = true;
    if (!GameGlobals.Eighties)
      return;
    this.MyRenderer.material.mainTexture = this.EightiesBookBagTexture;
    this.MyMesh.mesh = this.EightiesBookBag;
  }

  private void Update()
  {
    if ((Object) this.Prompt.Yandere.PickUp != (Object) null || (Object) this.ConcealedPickup != (Object) null)
    {
      this.Prompt.HideButton[0] = false;
      if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
      {
        this.Prompt.Circle[0].fillAmount = 1f;
        if ((Object) this.ConcealedPickup == (Object) null)
          this.TryToStashItem();
        else
          this.RemoveContents();
      }
    }
    else
      this.Prompt.HideButton[0] = true;
    if ((double) this.Prompt.Circle[3].fillAmount != 0.0)
      return;
    this.Wear();
  }

  public void TryToStashItem()
  {
    if (this.Prompt.Yandere.PickUp.OpenFlame)
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "That's too dangerous!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
    else if ((Object) this.Prompt.Yandere.PickUp.TrashCan == (Object) null && !this.Prompt.Yandere.PickUp.JerryCan && !(bool) (Object) this.Prompt.Yandere.PickUp.Mop && !(bool) (Object) this.Prompt.Yandere.PickUp.Bucket && !this.Prompt.Yandere.PickUp.Bleach && !this.Prompt.Yandere.PickUp.TooBig)
    {
      this.Prompt.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
      this.Prompt.Yandere.ReachWeight = 1f;
      this.ConcealedPickup = this.Prompt.Yandere.PickUp;
      this.ConcealedPickup.InsideBookbag = true;
      this.ConcealedPickup.Drop();
      this.ConcealedPickup.gameObject.SetActive(false);
      if (this.ConcealedPickup.Prompt.Text[3] != "")
        this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.Prompt.Text[3];
      else
        this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.name;
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "That wouldn't fit!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    }
  }

  public void RemoveContents()
  {
    this.Prompt.Yandere.CharacterAnimation["f02_reachForWeapon_00"].time = 0.0f;
    this.Prompt.Yandere.ReachWeight = 1f;
    this.ConcealedPickup.transform.position = this.transform.position;
    this.ConcealedPickup.gameObject.SetActive(true);
    this.ConcealedPickup.Prompt.Circle[3].fillAmount = -1f;
    this.ConcealedPickup.InsideBookbag = false;
    this.ConcealedPickup = (PickUpScript) null;
    this.Prompt.Label[0].text = "     Conceal Item";
  }

  public void Drop()
  {
    this.Worn = false;
    this.Prompt.Yandere.Bookbag = (BookbagScript) null;
    this.transform.parent = (Transform) null;
    this.Prompt.MyCollider.enabled = true;
    this.MyRigidbody.useGravity = true;
    this.MyRigidbody.isKinematic = false;
    this.Prompt.enabled = true;
    this.enabled = true;
  }

  public void Wear()
  {
    this.Worn = true;
    this.Prompt.Yandere.Bookbag = this;
    this.transform.parent = this.Prompt.Yandere.BookBagParent;
    this.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    this.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    this.transform.localScale = new Vector3(1f, 1f, 1f);
    this.Prompt.MyCollider.enabled = false;
    this.MyRigidbody.useGravity = false;
    this.MyRigidbody.isKinematic = true;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
    this.enabled = true;
  }
}
