// Decompiled with JetBrains decompiler
// Type: SnapStudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SnapStudentScript : MonoBehaviour
{
  public SnappedYandereScript Yandere;
  public Quaternion targetRotation;
  public StudentScript Student;
  public Animation MyAnim;
  public string FearAnim;
  public string[] AttackAnims;
  public bool VoicedConcern;
  public AudioClip[] StudentFear;
  public AudioClip SenpaiFear;

  private void Start()
  {
    this.MyAnim.enabled = false;
    this.MyAnim[this.FearAnim].time = Random.Range(0.0f, this.MyAnim[this.FearAnim].length);
    this.MyAnim.enabled = true;
  }

  private void Update()
  {
    if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 1.0)
    {
      if (this.Yandere.CanMove)
      {
        if (this.Student.StudentID == 1)
        {
          if (this.Yandere.Armed && !this.Yandere.KillingSenpai)
          {
            this.Yandere.Knife.transform.localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
            this.Yandere.MyAudio.clip = this.Yandere.EndSNAP;
            this.Yandere.MyAudio.loop = false;
            this.Yandere.MyAudio.volume = 1f;
            this.Yandere.MyAudio.pitch = 1f;
            this.Yandere.MyAudio.Play();
            this.Yandere.Speed = 0.0f;
            this.Yandere.MyAnim.CrossFade("f02_snapKill_00");
            this.MyAnim.CrossFade("snapDie_00");
            this.Yandere.TargetStudent = this;
            this.Yandere.KillingSenpai = true;
            this.Yandere.CanMove = false;
            this.enabled = false;
          }
        }
        else if (!this.Yandere.Attacking)
        {
          this.Yandere.transform.position = this.transform.position + this.transform.forward;
          this.Yandere.transform.LookAt(this.transform.position);
          this.Yandere.TargetStudent = this;
          this.Yandere.Attacking = true;
          this.Yandere.CanMove = false;
          this.Yandere.StaticNoise.volume = 0.0f;
          this.Yandere.Static.Fade = 0.0f;
          this.Yandere.HurryTimer = 0.0f;
          this.Yandere.ChooseAttack();
          this.Student.Pathfinding.enabled = false;
          this.enabled = false;
        }
      }
    }
    else if ((double) Vector3.Distance(this.transform.position, this.Yandere.transform.position) < 4.0)
    {
      if (!this.VoicedConcern && this.Yandere.CanMove && !this.Yandere.SnapVoice.isPlaying)
      {
        if (this.Student.StudentID == 1)
        {
          this.Yandere.SnapVoice.clip = this.SenpaiFear;
          this.Yandere.SnapVoice.Play();
          this.Yandere.ListenTimer = 10f;
        }
        else
        {
          int voiceId = this.Yandere.VoiceID;
          while (this.Yandere.VoiceID == voiceId)
            this.Yandere.VoiceID = Random.Range(0, 5);
          this.Yandere.SnapVoice.clip = this.StudentFear[this.Yandere.VoiceID];
          this.Yandere.SnapVoice.Play();
          this.Yandere.ListenTimer = 1f;
        }
        this.VoicedConcern = true;
      }
      this.MyAnim.Play(this.FearAnim);
    }
    else
      this.MyAnim.Play(this.FearAnim);
    if (this.Yandere.Attacking)
      return;
    this.transform.LookAt(new Vector3(this.Yandere.transform.position.x, this.transform.position.y, this.Yandere.transform.position.z));
  }
}
