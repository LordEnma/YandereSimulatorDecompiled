// Decompiled with JetBrains decompiler
// Type: TranqCaseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TranqCaseScript : MonoBehaviour
{
  public YandereScript Yandere;
  public RagdollScript Ragdoll;
  public PromptScript Prompt;
  public DoorScript Door;
  public Transform Hinge;
  public bool Occupied;
  public bool Open;
  public int VictimID;
  public ClubType VictimClubType;
  public float Rotation;
  public bool Animate;

  private void Start() => this.Prompt.enabled = false;

  private void Update()
  {
    if ((double) this.Yandere.transform.position.x > (double) this.transform.position.x && (double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
    {
      if (this.Yandere.Dragging)
      {
        if ((Object) this.Ragdoll == (Object) null)
          this.Ragdoll = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
        if (this.Ragdoll.Tranquil)
        {
          if (!this.Prompt.enabled)
            this.Prompt.enabled = true;
        }
        else if (this.Prompt.enabled)
        {
          this.Prompt.Hide();
          this.Prompt.enabled = false;
        }
      }
      else if (this.Prompt.enabled)
      {
        this.Prompt.Hide();
        this.Prompt.enabled = false;
      }
    }
    else if (this.Prompt.enabled)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
    }
    if (this.Prompt.enabled && (double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.Yandere.TranquilHiding = true;
        this.Yandere.CanMove = false;
        this.Prompt.enabled = false;
        this.Prompt.Hide();
        this.Ragdoll.TranqCase = this;
        this.VictimClubType = this.Ragdoll.Student.Club;
        this.VictimID = this.Ragdoll.StudentID;
        this.Door.Prompt.enabled = true;
        this.Door.enabled = true;
        this.Occupied = true;
        this.Animate = true;
        this.Open = true;
        if (this.Ragdoll.Student.Club == ClubType.LightMusic && (Object) this.Ragdoll.Student.InstrumentBag[this.Ragdoll.Student.ClubMemberID] != (Object) null)
          this.Ragdoll.Student.InstrumentBag[this.Ragdoll.Student.ClubMemberID].gameObject.SetActive(false);
      }
    }
    if (!this.Animate)
      return;
    if (this.Open)
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 105f, Time.deltaTime * 10f);
    }
    else
    {
      this.Rotation = Mathf.Lerp(this.Rotation, 0.0f, Time.deltaTime * 10f);
      this.Ragdoll.Student.OsanaHairL.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairL.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      this.Ragdoll.Student.OsanaHairR.transform.localScale = Vector3.MoveTowards(this.Ragdoll.Student.OsanaHairR.transform.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      if ((double) this.Rotation < 1.0)
      {
        this.Animate = false;
        this.Rotation = 0.0f;
      }
    }
    this.Hinge.localEulerAngles = new Vector3(0.0f, 0.0f, this.Rotation);
  }
}
