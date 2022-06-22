// Decompiled with JetBrains decompiler
// Type: BodyHidingLockerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BodyHidingLockerScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public OutlineScript Outline;
  public RagdollScript Corpse;
  public PromptScript Prompt;
  public AudioClip LockerClose;
  public AudioClip LockerOpen;
  public float Rotation;
  public float Speed;
  public Transform Door;
  public int StudentID;
  public bool ABC;

  private void Start() => this.Outline = this.GetComponentInChildren<OutlineScript>();

  private void Update()
  {
    if ((double) this.Rotation != 0.0)
    {
      this.Speed += Time.deltaTime * 100f;
      this.Rotation = Mathf.MoveTowards(this.Rotation, 0.0f, this.Speed * Time.deltaTime);
      if ((double) this.Rotation > -1.0)
      {
        AudioSource.PlayClipAtPoint(this.LockerClose, this.Prompt.Yandere.MainCamera.transform.position);
        if ((Object) this.Corpse != (Object) null)
          this.Corpse.gameObject.SetActive(false);
        this.Prompt.enabled = true;
        this.Rotation = 0.0f;
        this.Speed = 0.0f;
        if (this.ABC)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
          this.enabled = false;
        }
      }
      this.Door.transform.localEulerAngles = new Vector3(0.0f, this.Rotation, 0.0f);
    }
    if ((Object) this.Corpse == (Object) null)
    {
      if (this.Prompt.Yandere.Carrying || this.Prompt.Yandere.Dragging)
      {
        this.Prompt.enabled = true;
        if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
          return;
        this.Prompt.Circle[0].fillAmount = 1f;
        AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
        this.Corpse = !this.Prompt.Yandere.Carrying ? this.Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>() : this.Prompt.Yandere.CurrentRagdoll;
        this.Prompt.Label[0].text = "     Remove Corpse";
        this.Prompt.Hide();
        this.Prompt.enabled = false;
        this.Prompt.Yandere.EmptyHands();
        if (this.Corpse.AddingToCount)
        {
          --this.Prompt.Yandere.NearBodies;
          this.Corpse.AddingToCount = false;
        }
        this.Prompt.Yandere.NearestCorpseID = 0;
        this.Prompt.Yandere.CorpseWarning = false;
        this.Prompt.Yandere.StudentManager.UpdateStudents();
        this.Corpse.transform.parent = this.transform;
        this.Corpse.transform.position = this.transform.position + new Vector3(0.0f, 0.1f, 0.0f);
        this.Corpse.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.0f);
        if (!this.Corpse.Concealed)
        {
          if ((Object) this.Corpse.Police == (Object) null)
            this.Corpse.Police = this.Corpse.Student.Police;
          ++this.Corpse.Police.HiddenCorpses;
        }
        this.Corpse.enabled = false;
        this.Corpse.Hidden = true;
        this.StudentID = this.Corpse.StudentID;
        if (this.ABC)
        {
          this.Corpse.DestroyRigidbodies();
        }
        else
        {
          this.Corpse.BloodSpawnerCollider.enabled = false;
          this.Corpse.Prompt.MyCollider.enabled = false;
          this.Corpse.BloodPoolSpawner.enabled = false;
          this.Corpse.DisableRigidbodies();
        }
        this.Corpse.Student.CharacterAnimation.enabled = true;
        this.Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
        this.Rotation = -180f;
        this.Outline.color = new Color(1f, 0.5f, 0.0f, 1f);
      }
      else
      {
        if (!this.Prompt.enabled)
          return;
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else
    {
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.Prompt.Label[0].text = "     Hide Corpse";
      AudioSource.PlayClipAtPoint(this.LockerOpen, this.Prompt.Yandere.MainCamera.transform.position);
      this.Corpse.enabled = true;
      this.Corpse.gameObject.SetActive(true);
      this.Corpse.CharacterAnimation.enabled = false;
      this.Corpse.transform.localPosition = new Vector3(0.0f, 0.0f, 0.5f);
      this.Corpse.transform.localEulerAngles = new Vector3(0.0f, -90f, 0.5f);
      this.Corpse.transform.parent = (Transform) null;
      this.Corpse.BloodSpawnerCollider.enabled = true;
      this.Corpse.Prompt.MyCollider.enabled = true;
      this.Corpse.BloodPoolSpawner.NearbyBlood = 0;
      this.Corpse.AddingToCount = false;
      this.Corpse.EnableRigidbodies();
      if (!this.Corpse.Cauterized && !this.Corpse.Concealed)
        this.Corpse.BloodPoolSpawner.enabled = true;
      for (int index = 0; index < this.Corpse.Student.FireEmitters.Length; ++index)
        this.Corpse.Student.FireEmitters[index].gameObject.SetActive(false);
      this.Corpse = (RagdollScript) null;
      this.Rotation = -180f;
      this.Outline.color = new Color(0.0f, 1f, 1f, 1f);
      this.StudentID = 0;
    }
  }

  public void UpdateCorpse()
  {
    this.Corpse = this.StudentManager.Students[this.StudentID].Ragdoll;
    this.Corpse.transform.parent = this.transform;
    this.Prompt.Label[0].text = "     Remove Corpse";
    this.Prompt.enabled = true;
  }
}
