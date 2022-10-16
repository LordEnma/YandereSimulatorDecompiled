// Decompiled with JetBrains decompiler
// Type: CarryableCardboardBoxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CarryableCardboardBoxScript : MonoBehaviour
{
  public WeaponScript MyCutter;
  public PickUpScript PickUp;
  public PromptScript Prompt;
  public MeshFilter MyRenderer;
  public Mesh ClosedMesh;
  public bool Closed;

  private void Update()
  {
    if (!this.Closed)
    {
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Label[0].text = "     Insert Box Cutter";
      this.MyRenderer.mesh = this.ClosedMesh;
      this.Prompt.HideButton[0] = true;
      this.Closed = true;
    }
    else if ((Object) this.MyCutter == (Object) null)
    {
      this.Prompt.HideButton[0] = true;
      if (this.Prompt.Yandere.Armed)
      {
        if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 5 && !this.Prompt.Yandere.EquippedWeapon.Blood.enabled)
        {
          this.Prompt.HideButton[0] = false;
          if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
            return;
          this.MyCutter = this.Prompt.Yandere.EquippedWeapon;
          Physics.IgnoreCollision(this.GetComponent<Collider>(), this.MyCutter.MyCollider);
          this.Prompt.Yandere.DropTimer[this.Prompt.Yandere.Equipped] = 0.5f;
          this.Prompt.Yandere.DropWeapon(this.Prompt.Yandere.Equipped);
          this.MyCutter.MyRigidbody.useGravity = false;
          this.MyCutter.MyRigidbody.isKinematic = true;
          this.MyCutter.MyCollider.isTrigger = true;
          this.MyCutter.transform.parent = this.transform;
          this.MyCutter.transform.localPosition = new Vector3(0.0f, 0.24f, 0.0f);
          this.MyCutter.transform.localEulerAngles = new Vector3(90f, 0.0f, 0.0f);
          this.MyCutter.Prompt.Hide();
          this.MyCutter.Prompt.enabled = false;
          this.MyCutter.enabled = false;
          this.MyCutter.gameObject.SetActive(true);
          this.Prompt.HideButton[0] = true;
          this.Prompt.HideButton[3] = false;
          this.PickUp.StuckBoxCutter = this.MyCutter;
          this.PickUp.enabled = true;
        }
        else
          this.Prompt.HideButton[0] = true;
      }
      else
        this.Prompt.HideButton[0] = true;
    }
    else
    {
      if (!((Object) this.MyCutter.transform.parent != (Object) this.transform))
        return;
      this.MyCutter = (WeaponScript) null;
    }
  }
}
