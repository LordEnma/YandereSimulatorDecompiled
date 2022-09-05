// Decompiled with JetBrains decompiler
// Type: GateScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GateScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public PromptScript Prompt;
  public ClockScript Clock;
  public Collider EmergencyDoor;
  public Collider GateCollider;
  public Transform RightGate;
  public Transform LeftGate;
  public bool ManuallyAdjusted;
  public bool AudioPlayed;
  public bool UpdateGates;
  public bool Crushing;
  public bool Closed;
  public AudioSource RightGateAudio;
  public AudioSource LeftGateAudio;
  public AudioSource RightGateLoop;
  public AudioSource LeftGateLoop;
  public AudioClip Start;
  public AudioClip StopOpen;
  public AudioClip StopClose;

  private void Update()
  {
    if (!this.ManuallyAdjusted)
    {
      if ((double) this.Clock.PresentTime / 60.0 > 8.0 && (double) this.Clock.PresentTime / 60.0 < 15.5)
      {
        if (!this.Closed)
        {
          this.PlayAudio();
          this.Closed = true;
          if (this.EmergencyDoor.enabled)
            this.EmergencyDoor.enabled = false;
        }
      }
      else if (this.Closed)
      {
        this.PlayAudio();
        this.Closed = false;
        if (!this.EmergencyDoor.enabled)
          this.EmergencyDoor.enabled = true;
      }
    }
    if ((Object) this.StudentManager.Students[97] != (Object) null)
    {
      if (this.StudentManager.Students[97].CurrentAction == StudentActionType.AtLocker && this.StudentManager.Students[97].Routine && this.StudentManager.Students[97].Alive)
      {
        if ((double) Vector3.Distance(this.StudentManager.Students[97].transform.position, this.StudentManager.Podiums.List[0].position) < 0.10000000149011612)
        {
          if (this.ManuallyAdjusted)
            this.ManuallyAdjusted = false;
          this.Prompt.enabled = false;
          this.Prompt.Hide();
        }
        else
          this.Prompt.enabled = true;
      }
      else
        this.Prompt.enabled = true;
    }
    else
      this.Prompt.enabled = true;
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      this.PlayAudio();
      this.EmergencyDoor.enabled = !this.EmergencyDoor.enabled;
      this.ManuallyAdjusted = true;
      this.Closed = !this.Closed;
      if ((Object) this.StudentManager.Students[97] != (Object) null && this.StudentManager.Students[97].Investigating)
        this.StudentManager.Students[97].StopInvestigating();
    }
    if (!this.Closed)
    {
      if ((double) this.RightGate.localPosition.x == 7.0)
        return;
      this.RightGate.localPosition = new Vector3(Mathf.MoveTowards(this.RightGate.localPosition.x, 7f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
      this.LeftGate.localPosition = new Vector3(Mathf.MoveTowards(this.LeftGate.localPosition.x, -7f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
      if (this.AudioPlayed || (double) this.RightGate.localPosition.x != 7.0)
        return;
      this.RightGateAudio.clip = this.StopOpen;
      this.LeftGateAudio.clip = this.StopOpen;
      this.RightGateAudio.Play();
      this.LeftGateAudio.Play();
      this.RightGateLoop.Stop();
      this.LeftGateLoop.Stop();
      this.AudioPlayed = true;
    }
    else
    {
      if ((double) this.RightGate.localPosition.x == 2.3250000476837158)
        return;
      if ((double) this.RightGate.localPosition.x < 2.4000000953674316)
        this.Crushing = true;
      this.RightGate.localPosition = new Vector3(Mathf.MoveTowards(this.RightGate.localPosition.x, 2.325f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
      this.LeftGate.localPosition = new Vector3(Mathf.MoveTowards(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
      if (this.AudioPlayed || (double) this.RightGate.localPosition.x != 2.3250000476837158)
        return;
      this.RightGateAudio.clip = this.StopOpen;
      this.LeftGateAudio.clip = this.StopOpen;
      this.RightGateAudio.Play();
      this.LeftGateAudio.Play();
      this.RightGateLoop.Stop();
      this.LeftGateLoop.Stop();
      this.AudioPlayed = true;
      this.Crushing = false;
    }
  }

  public void PlayAudio()
  {
    this.RightGateAudio.clip = this.Start;
    this.LeftGateAudio.clip = this.Start;
    this.RightGateAudio.Play();
    this.LeftGateAudio.Play();
    this.RightGateLoop.Play();
    this.LeftGateLoop.Play();
    this.AudioPlayed = false;
  }
}
