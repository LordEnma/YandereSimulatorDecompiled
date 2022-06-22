// Decompiled with JetBrains decompiler
// Type: ConvoManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ConvoManagerScript : MonoBehaviour
{
  public StudentManagerScript SM;
  public int NearbyStudents;
  public int Week;
  public int ID;
  public bool Eighties;
  public string[] FemaleCombatAnims;
  public string[] MaleCombatAnims;
  public int CombatAnimID;
  public float CheckTimer;
  public bool Confirmed;
  public int Cycles;

  public void Start()
  {
    if (!MissionModeGlobals.MissionMode && DateGlobals.Week == 1)
      this.Week = 1;
    this.Eighties = GameGlobals.Eighties;
  }

  public void CheckMe(int StudentID)
  {
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
        case 11:
          this.SM.Students[11].Alone = !((Object) this.SM.Students[10] != (Object) null) || !this.SM.Students[10].Routine || (double) Vector3.Distance(this.SM.Students[11].transform.position, this.SM.Students[10].transform.position) >= 2.09999990463257;
          break;
        default:
          if (StudentID > 20 && StudentID < 26)
          {
            this.NearbyStudents = 0;
            this.ID = 21;
            while (this.ID < 26)
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
            break;
          }
          if (StudentID > 25 && StudentID < 31)
          {
            for (this.ID = 26; this.ID < 31; ++this.ID)
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
            }
            break;
          }
          if (StudentID > 35 && StudentID < 41)
          {
            this.NearbyStudents = 0;
            this.ID = 36;
            while (this.ID < 41)
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
            break;
          }
          if (StudentID > 45 && StudentID < 51)
          {
            for (this.ID = 46; this.ID < 51; ++this.ID)
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
            }
            break;
          }
          if (StudentID > 30 && StudentID < 36)
          {
            for (this.ID = 31; this.ID < 36; ++this.ID)
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
            }
            break;
          }
          switch (StudentID)
          {
            case 6:
              if ((Object) this.SM.Students[11] != (Object) null)
              {
                this.SM.Students[6].Alone = !this.SM.Students[11].Routine || (double) Vector3.Distance(this.SM.Students[6].transform.position, this.SM.Students[11].transform.position) >= 1.4;
                break;
              }
              break;
            case 11:
              this.SM.Students[11].Alone = !((Object) this.SM.Students[6] != (Object) null) || !this.SM.Students[6].Routine || (double) Vector3.Distance(this.SM.Students[11].transform.position, this.SM.Students[6].transform.position) >= 1.4;
              break;
            default:
              if (StudentID > 55 && StudentID < 61)
              {
                for (this.ID = 56; this.ID < 61; ++this.ID)
                {
                  if (this.ID != StudentID)
                  {
                    if ((Object) this.SM.Students[this.ID] != (Object) null)
                    {
                      if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.66666007041931)
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
                break;
              }
              if (StudentID > 60 && StudentID < 66)
              {
                for (this.ID = 61; this.ID < 66; ++this.ID)
                {
                  if (this.ID != StudentID)
                  {
                    if ((Object) this.SM.Students[this.ID] != (Object) null)
                    {
                      if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.66666007041931)
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
                break;
              }
              if (StudentID > 65 && StudentID < 71)
              {
                for (this.ID = 66; this.ID < 71; ++this.ID)
                {
                  if (this.ID != StudentID)
                  {
                    if ((Object) this.SM.Students[this.ID] != (Object) null)
                    {
                      if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.66666007041931)
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
                break;
              }
              if (StudentID > 75 && StudentID < 81)
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
                break;
              }
              if (StudentID > 80 && StudentID < 86)
              {
                for (this.ID = 81; this.ID < 86; ++this.ID)
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
                }
                break;
              }
              break;
          }
          break;
      }
      if (this.Week != 1)
        return;
      if (StudentID == 25)
        this.SM.Students[25].Alone = !((Object) this.SM.Students[30] != (Object) null) || !this.SM.Students[30].Routine || (double) Vector3.Distance(this.SM.Students[25].transform.position, this.SM.Students[30].transform.position) >= 1.4;
      else if (StudentID == 30)
        this.SM.Students[30].Alone = !((Object) this.SM.Students[25] != (Object) null) || !this.SM.Students[25].Routine || (double) Vector3.Distance(this.SM.Students[25].transform.position, this.SM.Students[25].transform.position) >= 1.4;
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
    else if (StudentID < 13)
    {
      for (this.ID = 2; this.ID < 13; ++this.ID)
      {
        if (this.ID != StudentID)
        {
          if ((Object) this.SM.Students[this.ID] != (Object) null)
          {
            if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.66666007041931)
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
    else
    {
      if (StudentID <= 75 || StudentID >= 86)
        return;
      for (this.ID = 75; this.ID < 86; ++this.ID)
      {
        if (this.ID != StudentID)
        {
          if ((Object) this.SM.Students[this.ID] != (Object) null)
          {
            if (this.SM.Students[this.ID].Routine && (double) Vector3.Distance(this.SM.Students[this.ID].transform.position, this.SM.Students[StudentID].transform.position) < 2.66666007041931)
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
    if ((double) this.CheckTimer <= 1.0 && !this.Confirmed || !((Object) this.SM.Students[47] != (Object) null) || !((Object) this.SM.Students[49] != (Object) null) || !this.SM.Students[47].Routine || !this.SM.Students[49].Routine || (double) this.SM.Students[47].DistanceToDestination >= 0.100000001490116 || (double) this.SM.Students[49].DistanceToDestination >= 0.100000001490116)
      return;
    this.Confirmed = true;
    ++this.CombatAnimID;
    if (this.CombatAnimID > 2)
      this.CombatAnimID = 1;
    this.SM.Students[47].ClubAnim = this.MaleCombatAnims[this.CombatAnimID];
    this.SM.Students[49].ClubAnim = this.FemaleCombatAnims[this.CombatAnimID];
    this.SM.Students[47].GetNewAnimation = false;
    this.SM.Students[49].GetNewAnimation = false;
    ++this.Cycles;
    if (this.Cycles != 10)
      return;
    this.SM.UpdateMartialArts();
    this.Cycles = 0;
  }

  public void LateUpdate()
  {
    this.CheckTimer = Mathf.MoveTowards(this.CheckTimer, 0.0f, Time.deltaTime);
    if (!this.Confirmed)
      return;
    if (this.SM.Students[47].Routine && this.SM.Students[49].Routine)
    {
      if ((double) this.SM.Students[47].DistanceToPlayer >= 1.5 && (double) this.SM.Students[49].DistanceToPlayer >= 1.5 && !this.SM.Students[47].Talking && !this.SM.Students[49].Talking && !this.SM.Students[47].Distracted && !this.SM.Students[49].Distracted && !this.SM.Students[47].TurnOffRadio && !this.SM.Students[49].TurnOffRadio)
        return;
      if ((double) this.SM.Students[47].DistanceToPlayer < 1.5 || (double) this.SM.Students[49].DistanceToPlayer < 1.5)
        this.SM.Students[47].Subtitle.UpdateLabel(SubtitleType.IntrusionReaction, 2, 5f);
      this.SM.Students[47].ClubAnim = "idle_20";
      this.SM.Students[49].ClubAnim = "f02_idle_20";
      this.Confirmed = false;
    }
    else
    {
      this.SM.Students[47].ClubAnim = "idle_20";
      this.SM.Students[49].ClubAnim = "f02_idle_20";
      this.Confirmed = false;
    }
  }
}
