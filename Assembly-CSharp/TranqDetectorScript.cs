// Decompiled with JetBrains decompiler
// Type: TranqDetectorScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TranqDetectorScript : MonoBehaviour
{
  public YandereScript Yandere;
  public DoorScript Door;
  public UIPanel Checklist;
  public Collider MyCollider;
  public UILabel KidnappingLabel;
  public UISprite TranquilizerIcon;
  public UISprite FollowerIcon;
  public UISprite BiologyIcon;
  public UISprite SyringeIcon;
  public UISprite DoorIcon;
  public bool StopChecking;
  public bool CannotKidnap;
  public int BasementPrisoners;
  public AudioClip[] TranqClips;

  private void Start()
  {
    this.Checklist.alpha = 0.0f;
    this.BasementPrisoners = StudentGlobals.Prisoners;
  }

  private void Update()
  {
    if (!this.StopChecking)
    {
      if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
      {
        if (this.BasementPrisoners > 9)
        {
          this.KidnappingLabel.text = "There is no room for another prisoner in your basement.";
          this.CannotKidnap = true;
        }
        else
        {
          this.TranquilizerIcon.spriteName = this.Yandere.Inventory.SedativePoisons <= 0 ? "No" : "Yes";
          if (this.Yandere.Followers != 1)
            this.FollowerIcon.spriteName = "No";
          else if (this.Yandere.Follower.Male)
          {
            this.KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
            this.FollowerIcon.spriteName = "No";
            this.CannotKidnap = true;
          }
          else
          {
            this.KidnappingLabel.text = "Kidnapping Checklist";
            this.FollowerIcon.spriteName = "Yes";
            this.CannotKidnap = false;
          }
          this.BiologyIcon.spriteName = this.Yandere.Class.BiologyGrade + this.Yandere.Class.BiologyBonus != 0 ? "Yes" : "No";
          this.SyringeIcon.spriteName = this.Yandere.Armed ? (this.Yandere.EquippedWeapon.WeaponID == 3 ? "Yes" : "No") : "No";
          this.DoorIcon.spriteName = this.Door.Open || (double) this.Door.Timer < 1.0 ? "No" : "Yes";
        }
        this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 1f, Time.deltaTime);
      }
      else
      {
        if ((double) this.Checklist.alpha == 0.0)
          return;
        this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0.0f, Time.deltaTime);
      }
    }
    else
    {
      this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0.0f, Time.deltaTime);
      if ((double) this.Checklist.alpha != 0.0)
        return;
      this.enabled = false;
    }
  }

  public void TranqCheck()
  {
    if (this.StopChecking || this.CannotKidnap || !(this.TranquilizerIcon.spriteName == "Yes") || !(this.FollowerIcon.spriteName == "Yes") || !(this.BiologyIcon.spriteName == "Yes") || !(this.SyringeIcon.spriteName == "Yes") || !(this.DoorIcon.spriteName == "Yes"))
      return;
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.TranqClips[Random.Range(0, this.TranqClips.Length)];
    component.Play();
    this.Door.Prompt.Hide();
    this.Door.Prompt.enabled = false;
    this.Door.enabled = false;
    --this.Yandere.Inventory.SedativePoisons;
    if (!this.Yandere.Follower.Male)
      this.Yandere.CanTranq = true;
    this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
    this.Yandere.AttackManager.Stealth = true;
    this.StopChecking = true;
  }

  public void GarroteAttack()
  {
    AudioSource component = this.GetComponent<AudioSource>();
    component.clip = this.TranqClips[Random.Range(0, this.TranqClips.Length)];
    component.Play();
    this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
    this.Yandere.AttackManager.Stealth = true;
    this.StopChecking = true;
  }
}
