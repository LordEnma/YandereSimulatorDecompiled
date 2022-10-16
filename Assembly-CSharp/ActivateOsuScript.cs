// Decompiled with JetBrains decompiler
// Type: ActivateOsuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ActivateOsuScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public OsuScript[] OsuScripts;
  public StudentScript Student;
  public ClockScript Clock;
  public GameObject Music;
  public Transform Mouse;
  public GameObject Osu;
  public int PlayerID;
  public Vector3 OriginalMousePosition;
  public Vector3 OriginalMouseRotation;

  private void Start()
  {
    this.OsuScripts = this.Osu.GetComponents<OsuScript>();
    this.OriginalMouseRotation = this.Mouse.transform.eulerAngles;
    this.OriginalMousePosition = this.Mouse.transform.position;
  }

  private void Update()
  {
    if ((Object) this.Student == (Object) null)
      this.Student = this.StudentManager.Students[this.PlayerID];
    else if (!this.Osu.activeInHierarchy)
    {
      if ((double) Vector3.Distance(this.transform.position, this.Student.transform.position) >= 0.10000000149011612 || !this.Student.Routine || !((Object) this.Student.CurrentDestination == (Object) this.Student.Destinations[this.Student.Phase]) || this.Student.Actions[this.Student.Phase] != StudentActionType.Gaming)
        return;
      this.ActivateOsu();
    }
    else
    {
      this.Mouse.transform.eulerAngles = this.OriginalMouseRotation;
      if (this.Student.Routine && !((Object) this.Student.CurrentDestination != (Object) this.Student.Destinations[this.Student.Phase]) && this.Student.Actions[this.Student.Phase] == StudentActionType.Gaming)
        return;
      this.DeactivateOsu();
    }
  }

  private void ActivateOsu()
  {
    this.Osu.transform.parent.gameObject.SetActive(true);
    this.Student.SmartPhone.SetActive(false);
    this.Music.SetActive(true);
    this.Mouse.parent = this.Student.RightHand;
    this.Mouse.transform.localPosition = Vector3.zero;
  }

  private void DeactivateOsu()
  {
    this.Osu.transform.parent.gameObject.SetActive(false);
    this.Music.SetActive(false);
    foreach (OsuScript osuScript in this.OsuScripts)
      osuScript.Timer = 0.0f;
    this.Mouse.parent = this.transform.parent;
    this.Mouse.transform.position = this.OriginalMousePosition;
  }
}
