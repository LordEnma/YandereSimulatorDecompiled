// Decompiled with JetBrains decompiler
// Type: GradingPaperScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GradingPaperScript : MonoBehaviour
{
  public StudentScript Teacher;
  public GameObject Character;
  public Transform LeftHand;
  public Transform Chair;
  public Transform Paper;
  public float PickUpTime1;
  public float SetDownTime1;
  public float PickUpTime2;
  public float SetDownTime2;
  public Vector3 OriginalPosition;
  public Vector3 PickUpPosition1;
  public Vector3 SetDownPosition1;
  public Vector3 PickUpPosition2;
  public Vector3 PickUpRotation1;
  public Vector3 SetDownRotation1;
  public Vector3 PickUpRotation2;
  public int Phase = 1;
  public float Speed = 1f;
  public bool Writing;
  public int ID;

  private void Start()
  {
    this.OriginalPosition = this.Chair.position;
    this.Paper.localScale = new Vector3(0.9090909f, 0.9090909f, 0.9090909f);
    if (this.ID != 8 || !GameGlobals.Eighties || DateGlobals.Week != 1)
      return;
    this.enabled = false;
  }

  private void Update()
  {
    if (!((Object) this.Teacher != (Object) null) || (double) this.Teacher.DistanceToPlayer >= 10.0 || !this.Writing || !((Object) this.Character != (Object) null))
      return;
    if ((double) this.Teacher.DistanceToDestination < 1.0)
    {
      switch (this.Phase)
      {
        case 1:
          if ((double) this.Teacher.CharacterAnimation["f02_deskWrite"].time > (double) this.PickUpTime1)
          {
            this.Teacher.CharacterAnimation["f02_deskWrite"].speed = this.Speed;
            this.Paper.parent = this.LeftHand;
            this.Paper.localPosition = this.PickUpPosition1;
            this.Paper.localEulerAngles = this.PickUpRotation1;
            this.Paper.gameObject.SetActive(true);
            ++this.Phase;
            break;
          }
          break;
        case 2:
          if ((double) this.Teacher.CharacterAnimation["f02_deskWrite"].time > (double) this.SetDownTime1)
          {
            this.Paper.parent = this.Character.transform;
            this.Paper.localPosition = this.SetDownPosition1;
            this.Paper.localEulerAngles = this.SetDownRotation1;
            ++this.Phase;
            break;
          }
          break;
        case 3:
          if ((double) this.Teacher.CharacterAnimation["f02_deskWrite"].time > (double) this.PickUpTime2)
          {
            this.Paper.parent = this.LeftHand;
            this.Paper.localPosition = this.PickUpPosition2;
            this.Paper.localEulerAngles = this.PickUpRotation2;
            ++this.Phase;
            break;
          }
          break;
        case 4:
          if ((double) this.Teacher.CharacterAnimation["f02_deskWrite"].time > (double) this.SetDownTime2)
          {
            this.Paper.parent = this.Character.transform;
            this.Paper.gameObject.SetActive(false);
            ++this.Phase;
            break;
          }
          break;
        case 5:
          if ((double) this.Teacher.CharacterAnimation["f02_deskWrite"].time >= (double) this.Teacher.CharacterAnimation["f02_deskWrite"].length)
          {
            this.Teacher.CharacterAnimation["f02_deskWrite"].time = 0.0f;
            this.Teacher.CharacterAnimation.Play("f02_deskWrite");
            this.Phase = 1;
            break;
          }
          break;
      }
      if ((this.Phase == 1 || this.Teacher.Actions[this.Teacher.Phase] == StudentActionType.GradePapers) && this.Teacher.Routine && !this.Teacher.Stop)
        return;
      this.RemoveProps();
    }
    else
      this.RemoveProps();
  }

  public void RemoveProps()
  {
    if (!this.Paper.gameObject.activeInHierarchy)
      return;
    this.Paper.gameObject.SetActive(false);
    this.Teacher.Obstacle.enabled = false;
    this.Teacher.Pen.SetActive(false);
    this.Writing = false;
    this.Phase = 1;
  }
}
