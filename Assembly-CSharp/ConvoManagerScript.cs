// Decompiled with JetBrains decompiler
// Type: ConvoManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConvoManagerScript : MonoBehaviour
{
  public StudentManagerScript SM;
  public int Week;
  public int ID;
  public bool Eighties;
  public string[] FemaleCombatAnims;
  public string[] MaleCombatAnims;
  public bool BothCharactersInPosition;
  public float PatienceTimer;
  public float CheckTimer;
  public float KickTimer;
  public int CombatAnimID;
  public int Cycles;
  public int[] MartialArtist;

  public void Start()
  {
    if (!MissionModeGlobals.MissionMode && DateGlobals.Week == 1)
      this.Week = 1;
    this.Eighties = GameGlobals.Eighties;
  }

  public void CheckMe(int StudentID)
  {
    if (StudentID > 20 && StudentID < 26)
      this.CheckGroup(StudentID, 21, 26);
    else if (StudentID > 25 && StudentID < 31)
      this.CheckGroup(StudentID, 26, 31);
    else if (StudentID > 30 && StudentID < 36)
      this.CheckGroup(StudentID, 31, 36);
    else if (StudentID > 35 && StudentID < 41)
      this.CheckGroup(StudentID, 36, 41);
    else if (StudentID > 40 && StudentID < 46)
      this.CheckGroup(StudentID, 41, 46);
    else if (StudentID > 45 && StudentID < 51)
      this.CheckGroup(StudentID, 46, 51);
    else if (StudentID > 50 && StudentID < 56)
      this.CheckGroup(StudentID, 51, 56);
    else if (StudentID > 55 && StudentID < 61)
      this.CheckGroup(StudentID, 56, 61);
    else if (StudentID > 60 && StudentID < 66)
      this.CheckGroup(StudentID, 61, 66);
    else if (StudentID > 65 && StudentID < 71)
      this.CheckGroup(StudentID, 66, 71);
    else if (StudentID > 70 && StudentID < 76)
      this.CheckGroup(StudentID, 71, 76);
    else if (StudentID > 75 && StudentID < 81)
    {
      for (this.ID = 76; this.ID < 81; ++this.ID)
      {
        if (this.ID != StudentID)
        {
          if ((Object) this.SM.Students[this.ID] != (Object) null)
          {
            if ((double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
            {
              this.SM.Students[StudentID].TrueAlone = false;
              if (this.SM.Students[this.ID].Routine)
              {
                this.SM.Students[StudentID].Alone = false;
                break;
              }
              this.SM.Students[StudentID].Alone = true;
            }
            else
            {
              this.SM.Students[StudentID].TrueAlone = true;
              this.SM.Students[StudentID].Alone = true;
            }
          }
          else
          {
            this.SM.Students[StudentID].TrueAlone = true;
            this.SM.Students[StudentID].Alone = true;
          }
        }
      }
    }
    else if (StudentID > 80 && StudentID < 86)
      this.CheckGroup(StudentID, 81, 86);
    if (!this.Eighties)
    {
      switch (StudentID)
      {
        case 2:
          this.SM.Students[2].Alone = !this.SM.Students[3].Routine || (double) Vector3.Distance(this.SM.Students[2].transform.position, this.SM.Students[3].transform.position) >= 1.4;
          break;
        case 3:
          this.SM.Students[3].Alone = !this.SM.Students[2].Routine || (double) Vector3.Distance(this.SM.Students[3].transform.position, this.SM.Students[2].transform.position) >= 1.4;
          break;
        case 10:
          this.SM.Students[10].Alone = !((Object) this.SM.Students[11] != (Object) null) || !this.SM.Students[11].Routine || (double) Vector3.Distance(this.SM.Students[10].transform.position, this.SM.Students[11].transform.position) >= 2.0999999046325684;
          break;
        case 11:
          this.SM.Students[11].Alone = !((Object) this.SM.Students[10] != (Object) null) || !this.SM.Students[10].Routine || (double) Vector3.Distance(this.SM.Students[11].transform.position, this.SM.Students[10].transform.position) >= 2.0999999046325684;
          break;
      }
      if (this.Week != 1)
        return;
      if (StudentID == 25)
        this.SM.Students[25].Alone = !((Object) this.SM.Students[30] != (Object) null) || !this.SM.Students[30].Routine || (double) Vector3.Distance(this.SM.Students[25].transform.position, this.SM.Students[30].transform.position) >= 1.4;
      else if (StudentID == 30)
        this.SM.Students[30].Alone = !((Object) this.SM.Students[25] != (Object) null) || !this.SM.Students[25].Routine || (double) Vector3.Distance(this.SM.Students[30].transform.position, this.SM.Students[25].transform.position) >= 1.4;
      if (StudentID == 55)
        this.SM.Students[55].Alone = !((Object) this.SM.Students[54] != (Object) null) || !this.SM.Students[54].Routine || (double) Vector3.Distance(this.SM.Students[55].transform.position, this.SM.Students[54].transform.position) >= 1.4;
      else if (StudentID == 54)
        this.SM.Students[54].Alone = !((Object) this.SM.Students[55] != (Object) null) || !this.SM.Students[55].Routine || (double) Vector3.Distance(this.SM.Students[54].transform.position, this.SM.Students[55].transform.position) >= 1.4;
      if (StudentID == 72)
        this.SM.Students[72].Alone = !((Object) this.SM.Students[73] != (Object) null) || !this.SM.Students[73].Routine || (double) Vector3.Distance(this.SM.Students[72].transform.position, this.SM.Students[73].transform.position) >= 1.4;
      else if (StudentID == 73)
        this.SM.Students[73].Alone = !((Object) this.SM.Students[72] != (Object) null) || !this.SM.Students[72].Routine || (double) Vector3.Distance(this.SM.Students[73].transform.position, this.SM.Students[72].transform.position) >= 1.4;
      if (StudentID == 74)
        this.SM.Students[74].Alone = !((Object) this.SM.Students[75] != (Object) null) || !this.SM.Students[75].Routine || (double) Vector3.Distance(this.SM.Students[75].transform.position, this.SM.Students[74].transform.position) >= 1.4;
      else if (StudentID == 75)
        this.SM.Students[75].Alone = !((Object) this.SM.Students[74] != (Object) null) || !this.SM.Students[74].Routine || (double) Vector3.Distance(this.SM.Students[75].transform.position, this.SM.Students[74].transform.position) >= 1.4;
      if (StudentID == 24)
      {
        if ((Object) this.SM.Students[27] != (Object) null && this.SM.Students[27].Routine && (double) Vector3.Distance(this.SM.Students[24].transform.position, this.SM.Students[27].transform.position) < 1.4)
          this.SM.Students[24].Alone = false;
        else
          this.SM.Students[24].Alone = true;
      }
      else
      {
        if (StudentID != 27)
          return;
        if ((Object) this.SM.Students[24] != (Object) null && this.SM.Students[24].Routine && (double) Vector3.Distance(this.SM.Students[24].transform.position, this.SM.Students[27].transform.position) < 1.4)
          this.SM.Students[27].Alone = false;
        else
          this.SM.Students[27].Alone = true;
      }
    }
    else
    {
      if (StudentID >= 13)
        return;
      for (this.ID = 2; this.ID < 13; ++this.ID)
      {
        if (this.ID != StudentID)
        {
          if ((Object) this.SM.Students[this.ID] != (Object) null)
          {
            if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.6666600704193115)
            {
              this.SM.Students[StudentID].Alone = false;
              break;
            }
            this.SM.Students[StudentID].Alone = true;
          }
          else
            this.SM.Students[StudentID].Alone = true;
        }
      }
    }
  }

  public void MartialArtsCheck()
  {
    this.CheckTimer += Time.deltaTime;
    if ((double) this.CheckTimer <= 1.0 && !this.BothCharactersInPosition || !((Object) this.SM.Students[this.MartialArtist[1]] != (Object) null) || !((Object) this.SM.Students[this.MartialArtist[2]] != (Object) null) || !this.SM.Students[this.MartialArtist[1]].Routine || !this.SM.Students[this.MartialArtist[2]].Routine || (double) this.SM.Students[this.MartialArtist[1]].DistanceToDestination >= 0.10000000149011612 || (double) this.SM.Students[this.MartialArtist[2]].DistanceToDestination >= 0.10000000149011612)
      return;
    this.BothCharactersInPosition = true;
    this.PatienceTimer = 0.0f;
    ++this.CombatAnimID;
    if (this.CombatAnimID > 2)
      this.CombatAnimID = 1;
    this.SM.Students[this.MartialArtist[1]].ClubAnim = this.MaleCombatAnims[this.CombatAnimID];
    this.SM.Students[this.MartialArtist[2]].ClubAnim = this.FemaleCombatAnims[this.CombatAnimID];
    this.SM.Students[this.MartialArtist[1]].GetNewAnimation = false;
    this.SM.Students[this.MartialArtist[2]].GetNewAnimation = false;
    ++this.Cycles;
    if (this.Cycles != 10)
      return;
    this.SM.UpdateMartialArts();
    this.KickTimer = 0.0f;
    this.Cycles = 0;
  }

  public void LateUpdate()
  {
    StudentScript student1 = this.SM.Students[this.MartialArtist[1]];
    StudentScript student2 = this.SM.Students[this.MartialArtist[2]];
    this.CheckTimer = Mathf.MoveTowards(this.CheckTimer, 0.0f, Time.deltaTime);
    if (this.BothCharactersInPosition)
    {
      if (this.SM.Students[this.MartialArtist[1]].Routine && this.SM.Students[this.MartialArtist[2]].Routine)
      {
        if ((double) this.SM.Students[this.MartialArtist[1]].DistanceToPlayer >= 1.5 && (double) this.SM.Students[this.MartialArtist[2]].DistanceToPlayer >= 1.5 && !this.SM.Students[this.MartialArtist[1]].Talking && !this.SM.Students[this.MartialArtist[2]].Talking && !this.SM.Students[this.MartialArtist[1]].Distracted && !this.SM.Students[this.MartialArtist[2]].Distracted && !this.SM.Students[this.MartialArtist[1]].TurnOffRadio && !this.SM.Students[this.MartialArtist[2]].TurnOffRadio)
          return;
        if ((double) this.SM.Students[this.MartialArtist[1]].DistanceToPlayer < 1.5 || (double) this.SM.Students[this.MartialArtist[2]].DistanceToPlayer < 1.5)
          this.SM.Students[this.MartialArtist[1]].Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
        this.SM.Students[this.MartialArtist[1]].ClubAnim = "idle_20";
        this.SM.Students[this.MartialArtist[2]].ClubAnim = "f02_idle_20";
        this.BothCharactersInPosition = false;
      }
      else
      {
        this.SM.Students[this.MartialArtist[1]].ClubAnim = "idle_20";
        this.SM.Students[this.MartialArtist[2]].ClubAnim = "f02_idle_20";
        this.BothCharactersInPosition = false;
      }
    }
    else
    {
      if ((Object) student1 != (Object) null && student1.ClubAttire && student1.Actions[student1.Phase] == StudentActionType.ClubAction && (double) Vector3.Distance(student1.transform.position, this.SM.Clubs.List[this.MartialArtist[1]].position) < 1.5)
      {
        if (student1.Talking || student1.Distracted || student1.TurnOffRadio)
        {
          student1.ClubAnim = "idle_20";
          if ((Object) student2 != (Object) null)
            student2.ClubAnim = "f02_idle_20";
          this.PatienceTimer = 0.0f;
        }
        else if ((double) student1.DistanceToPlayer < 1.5)
        {
          student1.Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
          student1.ClubAnim = "idle_20";
          if ((Object) student2 != (Object) null)
            student2.ClubAnim = "f02_idle_20";
          this.PatienceTimer = 0.0f;
        }
        else
        {
          this.PatienceTimer += Time.deltaTime;
          if ((double) this.PatienceTimer < 5.0)
          {
            student1.ClubAnim = "idle_20";
            if ((Object) student2 != (Object) null)
              student2.ClubAnim = "f02_idle_20";
          }
          else
          {
            student1.ClubAnim = "loopingKick";
            if ((Object) student2 != (Object) null)
              student2.ClubAnim = "f02_loopingKick";
            if ((double) student1.DistanceToDestination < 1.0)
            {
              this.KickTimer += Time.deltaTime;
              if ((double) this.KickTimer >= 60.0)
              {
                this.SM.UpdateMartialArts();
                this.KickTimer = 0.0f;
                this.Cycles = 0;
              }
            }
          }
        }
      }
      if (!((Object) student2 != (Object) null) || !student2.ClubAttire || student2.Actions[student2.Phase] != StudentActionType.ClubAction || (double) Vector3.Distance(student2.transform.position, this.SM.Clubs.List[this.MartialArtist[2]].position) >= 1.5)
        return;
      if (student2.Talking || student2.Distracted || student2.TurnOffRadio)
      {
        student1.ClubAnim = "f02_idle_20";
        if ((Object) student1 != (Object) null)
          student1.ClubAnim = "idle_20";
        this.PatienceTimer = 0.0f;
      }
      else if ((double) student2.DistanceToPlayer < 1.5)
      {
        student2.Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
        student2.ClubAnim = "f02_idle_20";
        if ((Object) student1 != (Object) null)
          student1.ClubAnim = "idle_20";
        this.PatienceTimer = 0.0f;
      }
      else
      {
        this.PatienceTimer += Time.deltaTime;
        if ((double) this.PatienceTimer < 5.0)
        {
          student2.ClubAnim = "f02_idle_20";
          if (!((Object) student1 != (Object) null))
            return;
          student1.ClubAnim = "idle_20";
        }
        else
        {
          student2.ClubAnim = "f02_loopingKick";
          if ((Object) student1 != (Object) null)
            student1.ClubAnim = "loopingKick";
          if ((double) student2.DistanceToDestination >= 1.0)
            return;
          this.KickTimer += Time.deltaTime;
          if ((double) this.KickTimer < 60.0)
            return;
          this.SM.UpdateMartialArts();
          this.KickTimer = 0.0f;
          this.Cycles = 0;
        }
      }
    }
  }

  public void CheckGroup(int StudentID, int StartID, int EndID)
  {
    this.ID = StartID;
    while (this.ID < EndID)
    {
      if (this.ID != StudentID)
      {
        if ((Object) this.SM.Students[this.ID] != (Object) null)
        {
          if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.5)
          {
            this.SM.Students[StudentID].Alone = false;
            break;
          }
          this.SM.Students[StudentID].Alone = true;
        }
        else
          this.SM.Students[StudentID].Alone = true;
      }
      ++this.ID;
      if (this.ID == StudentID)
        this.SM.Students[StudentID].Alone = true;
    }
  }
}
