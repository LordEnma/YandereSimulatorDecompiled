// Decompiled with JetBrains decompiler
// Type: SmokeBombScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SmokeBombScript : MonoBehaviour
{
  public StudentScript[] Students;
  public float TimeLimit = 15f;
  public float Timer;
  public bool BigStink;
  public bool Amnesia;
  public bool Stink;
  public int ID;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.TimeLimit)
      return;
    if (!this.Stink)
    {
      foreach (StudentScript student in this.Students)
      {
        if ((Object) student != (Object) null)
          student.Blind = false;
      }
    }
    Object.Destroy((Object) this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null))
      return;
    if (this.Stink)
    {
      if (!((Object) component != (Object) null) || component.Yandere.Noticed || component.Guarding || component.Fleeing)
        return;
      this.GoAway(component);
    }
    else
    {
      if (this.Amnesia && !component.Chasing)
        component.ReturnToNormal();
      Debug.Log((object) (component.Name + " has been blinded."));
      this.Students[this.ID] = component;
      component.Blind = true;
      ++this.ID;
    }
  }

  private void OnTriggerStay(Collider other)
  {
    if (this.Stink)
    {
      if (other.gameObject.layer != 9)
        return;
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (!((Object) component != (Object) null) || component.Yandere.Noticed || component.Guarding || component.Fleeing)
        return;
      this.GoAway(component);
    }
    else
    {
      if (!this.Amnesia || other.gameObject.layer != 9)
        return;
      StudentScript component = other.gameObject.GetComponent<StudentScript>();
      if (!((Object) component != (Object) null) || !component.Alarmed || component.Chasing)
        return;
      component.ReturnToNormal();
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (this.Stink || this.Amnesia || other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null))
      return;
    Debug.Log((object) (component.Name + " left a smoke cloud and stopped being blind."));
    component.Blind = false;
  }

  private void GoAway(StudentScript Student)
  {
    if (Student.Chasing || Student.WitnessedMurder || Student.WitnessedCorpse || Student.Fleeing || Student.Yandere.Noticed || Student.Hunting || Student.Confessing)
      return;
    Debug.Log((object) (Student.Name + " just smelled a stink bomb!"));
    if (Student.Investigating)
      Student.StopInvestigating();
    if (Student.Following)
    {
      Student.Yandere.Follower = (StudentScript) null;
      --Student.Yandere.Followers;
      Student.Hearts.emission.enabled = false;
      Student.FollowCountdown.gameObject.SetActive(false);
      Student.Following = false;
    }
    if (Student.SolvingPuzzle)
    {
      Student.PuzzleTimer = 0.0f;
      Student.DropPuzzle();
    }
    if (Student.InEvent && Student.StinkBombSpecialCase > 0)
    {
      Debug.Log((object) "Hit a student who was in an event with a stink bomb special case.");
      Student.Subtitle.CustomText = "Ew! Something STINKS! Gonna hold my breath until it's gone...";
      Student.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
      Student.CharacterAnimation.CrossFade("f02_idleShame_00");
      Student.Pathfinding.canSearch = false;
      Student.Pathfinding.canMove = false;
      Student.StinkBombSpecialCase = 2;
    }
    else
    {
      Student.CurrentDestination = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
      Student.Pathfinding.target = Student.StudentManager.GoAwaySpots.List[Student.StudentID];
      Student.Pathfinding.canSearch = true;
      Student.Pathfinding.canMove = true;
      Student.CharacterAnimation.CrossFade(Student.SprintAnim);
      Student.DistanceToDestination = 100f;
      Student.Pathfinding.speed = 4f;
      Student.AmnesiaTimer = 10f;
      Student.GoAway = true;
    }
    Student.FocusOnYandere = false;
    Student.Distracted = true;
    Student.Alarmed = false;
    Student.Routine = false;
    if (this.BigStink)
      Student.GoAwayLimit = 60f;
    Student.AlarmTimer = 0.0f;
  }
}
