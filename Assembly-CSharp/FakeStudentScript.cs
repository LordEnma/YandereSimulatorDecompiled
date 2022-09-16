// Decompiled with JetBrains decompiler
// Type: FakeStudentScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FakeStudentScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public DialogueWheelScript DialogueWheel;
  public SubtitleScript Subtitle;
  public YandereScript Yandere;
  public StudentScript Student;
  public PromptScript Prompt;
  public Quaternion targetRotation;
  public float RotationTimer;
  public bool Rotate;
  public ClubType Club;
  public string LeaderAnim;

  private void Start()
  {
    this.targetRotation = this.transform.rotation;
    this.Student.Club = this.Club;
  }

  private void Update()
  {
    if (!this.Student.Talking)
    {
      if (this.LeaderAnim != "")
        this.GetComponent<Animation>().CrossFade(this.LeaderAnim);
      if (this.Rotate)
      {
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
        this.RotationTimer += Time.deltaTime;
        if ((double) this.RotationTimer > 1.0)
        {
          this.RotationTimer = 0.0f;
          this.Rotate = false;
        }
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0 || this.Yandere.Chased || this.Yandere.Chasers != 0)
      return;
    this.Yandere.TargetStudent = this.Student;
    this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int) this.Student.Club, 4f);
    this.DialogueWheel.ClubLeader = true;
    this.StudentManager.DisablePrompts();
    this.DialogueWheel.HideShadows();
    this.DialogueWheel.Show = true;
    this.DialogueWheel.Panel.enabled = true;
    this.Student.Talking = true;
    this.Student.TalkTimer = 0.0f;
    this.Yandere.ShoulderCamera.OverShoulder = true;
    this.Yandere.WeaponMenu.KeyboardShow = false;
    this.Yandere.WeaponMenu.Show = false;
    this.Yandere.YandereVision = false;
    this.Yandere.CanMove = false;
    this.Yandere.Talking = true;
    this.RotationTimer = 0.0f;
    this.Rotate = true;
  }
}
