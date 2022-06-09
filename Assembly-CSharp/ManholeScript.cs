// Decompiled with JetBrains decompiler
// Type: ManholeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ManholeScript : MonoBehaviour
{
  public GameObject BigSewerWaterSplash;
  public GameObject SewerCamera;
  public RagdollScript Corpse;
  public PromptScript Prompt;
  public AudioClip MoveCover;
  public float AnimateTimer;
  public float SewerTimer;
  public bool Open;

  private void Update()
  {
    if (!this.Open)
    {
      if ((Object) this.Prompt.Yandere.EquippedWeapon != (Object) null)
      {
        if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 19 || this.Prompt.Yandere.EquippedWeapon.WeaponID == 29)
        {
          this.Prompt.Text[0] = this.Prompt.Yandere.EquippedWeapon.WeaponID != 19 ? "Use Tool" : "Use Crowbar";
          if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
          {
            this.Prompt.Text[0] = "Dump Body";
            AudioSource.PlayClipAtPoint(this.MoveCover, this.transform.position);
            this.AnimateTimer = 1f;
            this.Open = true;
          }
        }
        else
          this.Prompt.Text[0] = "Need Crowbar or Manhole Tool";
      }
      else
        this.Prompt.Text[0] = "Need Crowbar or Manhole Tool";
      this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
    }
    else
    {
      if ((double) this.AnimateTimer > 0.0)
      {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(34.1f, 0.0f, 24.1f), Time.deltaTime);
        this.AnimateTimer -= Time.deltaTime;
      }
      if ((double) this.SewerTimer > 0.0)
      {
        if ((double) this.Corpse.Student.Hips.transform.position.y < -5.0)
        {
          if ((double) this.Corpse.Student.Hips.transform.position.y > -5.0)
            this.Corpse.Student.Hips.transform.position = new Vector3(this.Corpse.Student.Hips.transform.position.x, -5f, this.Corpse.Student.Hips.transform.position.z);
          if (this.Corpse.AllRigidbodies[0].useGravity)
          {
            Object.Instantiate<GameObject>(this.BigSewerWaterSplash, this.Corpse.Student.Hips.transform.position, Quaternion.identity).transform.eulerAngles = new Vector3(-90f, 0.0f, 0.0f);
            for (int index = 0; index < this.Corpse.AllRigidbodies.Length; ++index)
              this.Corpse.AllRigidbodies[index].useGravity = false;
          }
          this.Corpse.AllRigidbodies[0].AddForce(new Vector3(-100f, -50f, 0.0f));
        }
        this.SewerTimer -= Time.deltaTime;
        if ((double) this.SewerTimer <= 0.0)
        {
          if (this.Corpse.Concealed)
            --this.Prompt.Yandere.Police.HiddenCorpses;
          --this.Prompt.Yandere.Police.Corpses;
          this.Corpse.gameObject.SetActive(false);
          this.Corpse.Disposed = true;
          if (this.Corpse.StudentID == this.Prompt.Yandere.StudentManager.RivalID)
          {
            Debug.Log((object) "Just dumped Osana's corpse into the sewer.");
            this.Prompt.Yandere.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
          }
          this.SewerCamera.SetActive(false);
          this.Prompt.Yandere.StudentManager.UpdateStudents();
        }
      }
      if ((Object) this.Prompt.Yandere.Ragdoll != (Object) null)
      {
        this.Prompt.Label[0].text = "     Dump Body";
        this.Prompt.HideButton[0] = false;
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        this.Corpse = this.Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
        this.Prompt.Yandere.EmptyHands();
        this.Corpse.Student.Hips.transform.position = this.transform.position + new Vector3(0.0f, -1f, 0.0f);
        this.Corpse.BloodPoolSpawner.enabled = false;
        Physics.SyncTransforms();
        this.SewerCamera.SetActive(true);
        this.SewerTimer = 5f;
      }
      else if (this.Prompt.Yandere.Armed && this.Prompt.Yandere.EquippedWeapon.Evidence || (Object) this.Prompt.Yandere.PickUp != (Object) null && this.Prompt.Yandere.PickUp.Evidence || (Object) this.Prompt.Yandere.PickUp != (Object) null && this.Prompt.Yandere.PickUp.ConcealedBodyPart)
      {
        this.Prompt.Label[0].text = "     Dump Evidence";
        this.Prompt.HideButton[0] = false;
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        if (this.Prompt.Yandere.Armed)
        {
          WeaponScript equippedWeapon = this.Prompt.Yandere.EquippedWeapon;
          this.Prompt.Yandere.EmptyHands();
          --this.Prompt.Yandere.Police.BloodyWeapons;
          Object.Destroy((Object) equippedWeapon.gameObject);
        }
        else
        {
          PickUpScript pickUp = this.Prompt.Yandere.PickUp;
          this.Prompt.Yandere.EmptyHands();
          if (pickUp.Clothing)
            --this.Prompt.Yandere.Police.BloodyClothing;
          if (pickUp.ConcealedBodyPart)
            --this.Prompt.Yandere.Police.BodyParts;
          Object.Destroy((Object) pickUp.gameObject);
        }
      }
      else
        this.Prompt.HideButton[0] = true;
    }
  }
}
