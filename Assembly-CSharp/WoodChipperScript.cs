// Decompiled with JetBrains decompiler
// Type: WoodChipperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WoodChipperScript : MonoBehaviour
{
  public ParticleSystem BloodSpray;
  public PromptScript BucketPrompt;
  public YandereScript Yandere;
  public PickUpScript Bucket;
  public PromptScript Prompt;
  public AudioClip CloseAudio;
  public AudioClip ShredAudio;
  public AudioClip OpenAudio;
  public Transform BucketPoint;
  public Transform DumpPoint;
  public Transform Lid;
  public float Rotation;
  public float Timer;
  public bool Shredding;
  public bool Occupied;
  public bool Acid;
  public bool Open;
  public int HiddenCorpses;
  public int VictimID;
  public int Victims;
  public int ID;
  public int[] VictimList;
  public AudioSource MyAudio;

  private void Start() => this.MyAudio = this.GetComponent<AudioSource>();

  private void Update()
  {
    if (!this.Acid)
    {
      if ((Object) this.Yandere.PickUp != (Object) null)
      {
        if ((Object) this.Yandere.PickUp.Bucket != (Object) null)
        {
          if (!this.Yandere.PickUp.Bucket.Full)
          {
            if ((Object) this.Bucket == (Object) null)
            {
              this.BucketPrompt.HideButton[0] = false;
              if ((double) this.BucketPrompt.Circle[0].fillAmount == 0.0)
              {
                this.Bucket = this.Yandere.PickUp;
                this.Yandere.EmptyHands();
                this.Bucket.transform.eulerAngles = this.BucketPoint.eulerAngles;
                this.Bucket.transform.position = this.BucketPoint.position;
                this.Bucket.MyRigidbody.useGravity = false;
                this.Bucket.MyCollider.enabled = false;
              }
            }
            else
              this.BucketPrompt.HideButton[0] = true;
          }
          else
            this.BucketPrompt.HideButton[0] = true;
        }
        else
          this.BucketPrompt.HideButton[0] = true;
      }
      else
        this.BucketPrompt.HideButton[0] = true;
      if (!this.BloodSpray.isPlaying)
      {
        if (!this.Occupied)
          this.Prompt.HideButton[3] = (Object) this.Yandere.Ragdoll == (Object) null;
        else
          this.Prompt.HideButton[0] = (Object) this.Bucket == (Object) null || this.Bucket.Bucket.Full;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.HideButton[3] = (Object) this.Yandere.Ragdoll == (Object) null;
      this.Prompt.HideButton[1] = (!this.Yandere.Armed || !this.Yandere.EquippedWeapon.Evidence) && (!((Object) this.Yandere.PickUp != (Object) null) || !this.Yandere.PickUp.Evidence) && (!((Object) this.Yandere.PickUp != (Object) null) || !this.Yandere.PickUp.ConcealedBodyPart);
    }
    if (!this.Open)
    {
      this.Rotation = Mathf.MoveTowards(this.Rotation, 0.0f, Time.deltaTime * 360f);
      if ((double) this.Rotation > -36.0)
      {
        if ((double) this.Rotation < 0.0)
        {
          this.MyAudio.clip = this.CloseAudio;
          this.MyAudio.Play();
        }
        this.Rotation = 0.0f;
      }
      this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
    }
    else
    {
      if ((double) this.Lid.transform.localEulerAngles.x == 0.0)
      {
        this.MyAudio.clip = this.OpenAudio;
        this.MyAudio.Play();
      }
      this.Rotation = Mathf.MoveTowards(this.Rotation, -90f, Time.deltaTime * 360f);
      this.Lid.transform.localEulerAngles = new Vector3(this.Rotation, this.Lid.transform.localEulerAngles.y, this.Lid.transform.localEulerAngles.z);
    }
    if ((double) this.Prompt.Circle[3].fillAmount == 0.0)
    {
      Debug.Log((object) ("As of now, Yandere-chan's ''Woodchipper'' is being set to: " + this.gameObject.name));
      this.Yandere.WoodChipper = this;
      Time.timeScale = 1f;
      if ((Object) this.Yandere.Ragdoll != (Object) null)
      {
        if (!this.Yandere.Carrying)
          this.Yandere.CharacterAnimation.CrossFade("f02_dragIdle_00");
        else
          this.Yandere.CharacterAnimation.CrossFade("f02_carryIdleA_00");
        this.Yandere.YandereVision = false;
        this.Yandere.Chipping = true;
        this.Yandere.CanMove = false;
        ++this.Victims;
        this.VictimList[this.Victims] = this.Yandere.Ragdoll.GetComponent<RagdollScript>().StudentID;
        this.Open = true;
        int num = this.Acid ? 1 : 0;
      }
    }
    if (this.Acid && (double) this.Prompt.Circle[1].fillAmount == 0.0)
    {
      this.Prompt.Circle[1].fillAmount = 1f;
      if (this.Yandere.Armed)
      {
        WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
        this.Yandere.EmptyHands();
        --this.Yandere.Police.BloodyWeapons;
        Object.Destroy((Object) equippedWeapon.gameObject);
      }
      else
      {
        PickUpScript pickUp = this.Yandere.PickUp;
        this.Yandere.EmptyHands();
        if (pickUp.Clothing)
          --this.Yandere.Police.BloodyClothing;
        if (pickUp.ConcealedBodyPart)
          --this.Yandere.Police.BodyParts;
        Object.Destroy((Object) pickUp.gameObject);
      }
      this.MyAudio.clip = this.ShredAudio;
      this.MyAudio.Play();
    }
    if (this.Acid && this.Occupied && this.VictimID > 0 || (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      Debug.Log((object) (this.gameObject.name + " is now disposing of a corpse."));
      if (!this.Acid)
      {
        this.MyAudio.clip = this.ShredAudio;
        this.MyAudio.Play();
        this.Prompt.HideButton[3] = false;
        this.Prompt.HideButton[0] = true;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
      this.Yandere.Police.HiddenCorpses -= this.HiddenCorpses;
      --this.Yandere.Police.Corpses;
      if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
        this.Yandere.Police.MurderScene = false;
      if (this.Yandere.Police.Corpses == 0)
        this.Yandere.Police.MurderScene = false;
      Debug.Log((object) ("The Student ID of the victim is: " + this.VictimID.ToString()));
      if ((Object) this.Yandere.StudentManager == (Object) null)
        Debug.Log((object) "StudentManager is null?!");
      if ((Object) this.Yandere.StudentManager.Students[this.VictimID] == (Object) null)
        Debug.Log((object) ("Student #" + this.VictimID.ToString() + " is null?!"));
      if (this.Yandere.StudentManager.Students[this.VictimID].Drowned)
        --this.Yandere.Police.DrownVictims;
      if (!this.Acid)
        this.Shredding = true;
      else
        this.Occupied = false;
      this.Yandere.StudentManager.Students[this.VictimID].Ragdoll.Disposed = true;
      if ((Object) this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID] != (Object) null && this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID].Ragdoll.Disposed)
      {
        Debug.Log((object) "Just shredded or dissolved the current rival's corpse.");
        this.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
      }
      this.Yandere.StudentManager.UpdateStudents();
      this.HiddenCorpses = 0;
      this.VictimID = 0;
    }
    if (!this.Shredding)
      return;
    if ((Object) this.Bucket != (Object) null)
      this.Bucket.Bucket.UpdateAppearance = true;
    this.Timer += Time.deltaTime;
    if ((double) this.Timer >= 10.0)
    {
      this.Prompt.enabled = true;
      this.Shredding = false;
      this.Occupied = false;
      this.Timer = 0.0f;
    }
    else if ((double) this.Timer >= 9.0)
    {
      if (!((Object) this.Bucket != (Object) null))
        return;
      this.Bucket.MyCollider.enabled = true;
      this.Bucket.Bucket.FillSpeed = 1f;
      this.Bucket = (PickUpScript) null;
      this.BloodSpray.Stop();
    }
    else
    {
      if ((double) this.Timer < 0.33333000540733337 || !((Object) this.Bucket != (Object) null) || this.Bucket.Bucket.Full)
        return;
      this.BloodSpray.GetComponent<AudioSource>().Play();
      this.BloodSpray.Play();
      this.Bucket.Bucket.Bloodiness = 100f;
      this.Bucket.Bucket.FillSpeed = 0.066666f;
      this.Bucket.Bucket.Blood.material.color = new Color(1f, 1f, 1f, 1f);
      this.Bucket.Bucket.Blood.gameObject.SetActive(true);
      this.Bucket.Bucket.UpdateAppearance = true;
      this.Bucket.Bucket.Full = true;
      this.Bucket.Outline[0].color = new Color(1f, 0.5f, 0.0f, 1f);
    }
  }

  public void SetVictimsMissing()
  {
    foreach (int victim in this.VictimList)
      StudentGlobals.SetStudentMissing(victim, true);
  }
}
