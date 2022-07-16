// Decompiled with JetBrains decompiler
// Type: WeekSelectScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class WeekSelectScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public EightiesStatsScript Stats;
  public GameObject[] Shadow;
  public UISprite Darkness;
  public UILabel StartLabel;
  public UILabel EditLabel;
  public UILabel WeekLabel;
  public Transform Arrow;
  public bool SettingDetails;
  public bool SettingRivals;
  public bool SettingWeek;
  public bool Fading;
  public int DetailID = 1;
  public int RivalID = 1;
  public int WeekID = 1;
  public int FadeID = 1;
  public int Row = 1;
  public int Column = 1;
  public int[] Specifics;
  public int CurrentWeek;
  public Vector3[] StartingPosition;
  public Transform[] Sleeve;
  public Transform[] Tape;

  private void Start()
  {
    this.transform.position = new Vector3(0.0f, 2.31f, 0.0f);
    this.EditLabel.gameObject.SetActive(false);
    this.StartLabel.text = "NEXT";
    this.Darkness.alpha = 1f;
    this.UpdateArrow();
    this.UpdateText();
    for (int index = 1; index < 11; ++index)
      this.StartingPosition[index] = this.Sleeve[index].position;
    this.DetermineSelectedWeek();
    StudentGlobals.Prisoners = 0;
  }

  private void Update()
  {
    if (this.Fading)
    {
      if (this.FadeID == 1)
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0.0f, Time.deltaTime);
        if ((double) this.Darkness.alpha == 0.0)
        {
          this.Fading = false;
          ++this.FadeID;
        }
      }
      else
      {
        this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime);
        if ((double) this.Darkness.alpha == 1.0)
        {
          for (int index = 1; index < 11; ++index)
          {
            if (GameGlobals.GetSpecificEliminations(index) == 1 || GameGlobals.GetSpecificEliminations(index) == 5 || GameGlobals.GetSpecificEliminations(index) == 6 || GameGlobals.GetSpecificEliminations(index) == 7 || GameGlobals.GetSpecificEliminations(index) == 8 || GameGlobals.GetSpecificEliminations(index) == 10 || GameGlobals.GetSpecificEliminations(index) == 14 || GameGlobals.GetSpecificEliminations(index) == 15 || GameGlobals.GetSpecificEliminations(index) == 16 || GameGlobals.GetSpecificEliminations(index) == 17 || GameGlobals.GetSpecificEliminations(index) == 19 || GameGlobals.GetSpecificEliminations(index) == 20)
            {
              Debug.Log((object) ("Rival #" + index.ToString() + " is dead."));
              StudentGlobals.SetStudentDead(index + 10, true);
            }
            else
            {
              StudentGlobals.SetStudentDead(index + 10, false);
              if (GameGlobals.GetSpecificEliminations(index) == 3 || GameGlobals.GetSpecificEliminations(index) == 4)
              {
                StudentGlobals.SetStudentMissing(index + 10, true);
                if (GameGlobals.GetSpecificEliminations(index) == 3)
                {
                  Debug.Log((object) ("Rival #" + index.ToString() + " was betrayed, so she will appear in the basement as a prisoner."));
                  ++StudentGlobals.Prisoners;
                  this.AssignPrisoner(index);
                }
              }
              else if (GameGlobals.GetSpecificEliminations(index) == 9)
                StudentGlobals.SetStudentExpelled(index + 10, true);
              else if (GameGlobals.GetSpecificEliminations(index) == 11)
                StudentGlobals.SetStudentArrested(index + 10, true);
              else if (GameGlobals.GetSpecificEliminations(index) == 12)
              {
                Debug.Log((object) ("Rival #" + index.ToString() + " was kidnapped, so she will appear in the basement as a prisoner."));
                StudentGlobals.SetStudentKidnapped(index + 10, true);
                ++StudentGlobals.Prisoners;
                this.AssignPrisoner(index);
              }
            }
          }
          ClassGlobals.BonusStudyPoints = DateGlobals.Week * 50 - 50;
          GameGlobals.EightiesCutsceneID = DateGlobals.Week;
          DateGlobals.PassDays = 0;
          SceneManager.LoadScene("EightiesCutsceneScene");
        }
      }
    }
    if (this.SettingWeek)
    {
      if (this.InputManager.TappedDown || this.InputManager.TappedUp)
      {
        this.Row = this.Row != 1 ? 1 : 2;
        this.DetermineSelectedWeek();
      }
      else if (this.InputManager.TappedRight)
      {
        ++this.Column;
        if (this.Column > 5)
          this.Column = 1;
        this.DetermineSelectedWeek();
      }
      else if (this.InputManager.TappedLeft)
      {
        --this.Column;
        if (this.Column < 1)
          this.Column = 5;
        this.DetermineSelectedWeek();
      }
    }
    else if (this.SettingRivals)
    {
      if (this.InputManager.TappedDown)
      {
        if (this.RivalID == 5 || this.RivalID == 10)
        {
          this.SettingRivals = false;
          this.SettingDetails = true;
          this.DetailID = this.RivalID != 5 ? 5 : 1;
        }
        else
          ++this.RivalID;
        this.UpdateArrow();
      }
      else if (this.InputManager.TappedUp)
      {
        if (this.RivalID != 1 && this.RivalID != 6)
          --this.RivalID;
        this.UpdateArrow();
      }
      else if (this.InputManager.TappedRight)
      {
        if (this.RivalID < 6)
          this.RivalID += 5;
        else
          this.RivalID -= 5;
        this.UpdateArrow();
      }
      else if (this.InputManager.TappedLeft)
      {
        if (this.RivalID > 5)
          this.RivalID -= 5;
        else
          this.RivalID += 5;
        this.UpdateArrow();
      }
      else if (Input.GetButtonDown("Y"))
      {
        GameGlobals.SetSpecificEliminations(this.RivalID, GameGlobals.GetSpecificEliminations(this.RivalID) + 1);
        if (GameGlobals.GetSpecificEliminations(this.RivalID) > 20)
          GameGlobals.SetSpecificEliminations(this.RivalID, 1);
        GameGlobals.SetRivalEliminations(this.RivalID, this.Specifics[GameGlobals.GetSpecificEliminations(this.RivalID)]);
        Debug.Log((object) ("Rival #" + this.RivalID.ToString() + "'s SpecificElimination is now " + GameGlobals.GetSpecificEliminations(this.RivalID).ToString()));
        Debug.Log((object) ("Rival #" + this.RivalID.ToString() + "'s Elimination is now " + GameGlobals.GetRivalEliminations(this.RivalID).ToString()));
        this.UpdateText();
      }
      else if (Input.GetButtonDown("X"))
      {
        GameGlobals.SetSpecificEliminations(this.RivalID, GameGlobals.GetSpecificEliminations(this.RivalID) - 1);
        if (GameGlobals.GetSpecificEliminations(this.RivalID) < 1)
          GameGlobals.SetSpecificEliminations(this.RivalID, 20);
        GameGlobals.SetRivalEliminations(this.RivalID, this.Specifics[GameGlobals.GetSpecificEliminations(this.RivalID)]);
        this.UpdateText();
      }
    }
    else if (this.InputManager.TappedDown)
    {
      if (this.DetailID != 4 && this.DetailID != 8)
        ++this.DetailID;
      this.UpdateArrow();
    }
    else if (this.InputManager.TappedUp)
    {
      if (this.DetailID == 1 || this.DetailID == 5)
      {
        this.SettingDetails = false;
        this.SettingRivals = true;
        this.RivalID = this.DetailID != 1 ? 10 : 5;
      }
      else
        --this.DetailID;
      this.UpdateArrow();
    }
    else if (this.InputManager.TappedRight)
    {
      if (this.DetailID < 5)
        this.DetailID += 4;
      else
        this.DetailID -= 4;
      this.UpdateArrow();
    }
    else if (this.InputManager.TappedLeft)
    {
      if (this.DetailID > 4)
        this.DetailID -= 4;
      else
        this.DetailID += 4;
      this.UpdateArrow();
    }
    else if (Input.GetButtonDown("Y") || Input.GetButtonDown("X"))
    {
      if (this.DetailID == 1)
        PlayerGlobals.PoliceVisits = PlayerGlobals.PoliceVisits != 0 ? 0 : 10;
      else if (this.DetailID == 2)
        PlayerGlobals.CorpsesDiscovered = PlayerGlobals.CorpsesDiscovered != 0 ? 0 : 10;
      else if (this.DetailID == 3)
        PlayerGlobals.Reputation = (double) PlayerGlobals.Reputation != 0.0 ? 0.0f : 100f;
      else if (this.DetailID == 4)
      {
        if (!StudentGlobals.GetStudentGrudge(2))
          this.SetGrudges(true);
        else
          this.SetGrudges(false);
      }
      else if (this.DetailID == 5)
      {
        if (PlayerGlobals.Friends == 0)
          this.MakeFriends(true);
        else
          this.MakeFriends(false);
      }
      else if (this.DetailID == 6)
        PlayerGlobals.Alerts = PlayerGlobals.Alerts != 0 ? 0 : 10;
      else if (this.DetailID == 7)
        PlayerGlobals.WeaponWitnessed = PlayerGlobals.WeaponWitnessed != 0 ? 0 : 10;
      else if (this.DetailID == 8)
        PlayerGlobals.BloodWitnessed = PlayerGlobals.BloodWitnessed != 0 ? 0 : 10;
      this.UpdateText();
    }
    if (this.SettingWeek)
    {
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 2.31f, 0.0f), Time.deltaTime * 10f);
      if (Input.GetButtonDown("A"))
      {
        this.SettingWeek = false;
        this.SettingRivals = true;
        this.EditLabel.gameObject.SetActive(true);
        this.StartLabel.text = "START";
        this.RivalID = 1;
        this.UpdateArrow();
      }
    }
    else
    {
      this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      if (Input.GetButtonDown("A"))
        this.Fading = true;
      if (Input.GetButtonDown("B"))
      {
        this.SettingWeek = true;
        this.SettingRivals = false;
        this.SettingDetails = false;
        this.EditLabel.gameObject.SetActive(false);
        this.StartLabel.text = "NEXT";
        this.UpdateArrow();
      }
    }
    for (int index = 1; index < 11; ++index)
    {
      if (index == this.CurrentWeek)
      {
        this.Sleeve[index].transform.position = Vector3.Lerp(this.Sleeve[index].transform.position, this.StartingPosition[index] + this.transform.up * 0.05f + this.transform.right * -0.05f, Time.deltaTime * 10f);
        this.Tape[index].transform.localPosition = Vector3.Lerp(this.Tape[index].transform.localPosition, new Vector3(0.0f, -0.0003f, 0.0f), Time.deltaTime * 10f);
      }
      else
      {
        this.Sleeve[index].transform.position = Vector3.Lerp(this.Sleeve[index].transform.position, this.StartingPosition[index], Time.deltaTime * 10f);
        this.Tape[index].transform.localPosition = Vector3.Lerp(this.Tape[index].transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
      }
    }
  }

  private void UpdateArrow()
  {
    if (this.SettingWeek)
      this.Arrow.localPosition = new Vector3(0.0f, 610f, 0.0f);
    else if (this.SettingRivals)
    {
      if (this.RivalID < 6)
        this.Arrow.localPosition = new Vector3(-820f, (float) (495 - 120 * this.RivalID), 0.0f);
      else
        this.Arrow.localPosition = new Vector3(-15f, (float) (495 - 120 * (this.RivalID - 5)), 0.0f);
    }
    else if (this.DetailID < 5)
      this.Arrow.localPosition = new Vector3(-800f, (float) (-257 - 33 * this.DetailID), 0.0f);
    else
      this.Arrow.localPosition = new Vector3(0.0f, (float) (-257 - 33 * (this.DetailID - 4)), 0.0f);
  }

  private void UpdateText()
  {
    this.WeekLabel.text = "STARTING WEEK: " + this.CurrentWeek.ToString();
    for (int elimID = 1; elimID < 11; ++elimID)
    {
      if (elimID < DateGlobals.Week)
      {
        this.Shadow[elimID].SetActive(false);
      }
      else
      {
        this.Shadow[elimID].SetActive(true);
        GameGlobals.SetRivalEliminations(elimID, 0);
        GameGlobals.SetSpecificEliminations(elimID, 0);
      }
    }
    this.Stats.Start();
  }

  private void SetGrudges(bool Grudge)
  {
    for (int studentID = 2; studentID < 12; ++studentID)
      StudentGlobals.SetStudentGrudge(studentID, Grudge);
  }

  private void MakeFriends(bool Friend)
  {
    for (int studentID = 2; studentID < 86; ++studentID)
      PlayerGlobals.SetStudentFriend(studentID, Friend);
    if (Friend)
    {
      PlayerGlobals.Friends = 84;
      GameGlobals.YakuzaPhase = 1;
    }
    else
    {
      PlayerGlobals.Friends = 0;
      GameGlobals.YakuzaPhase = 0;
    }
  }

  private void DetermineSelectedWeek()
  {
    this.CurrentWeek = this.Column + (this.Row - 1) * 5;
    for (int elimID = 1; elimID < 10; ++elimID)
    {
      GameGlobals.SetRivalEliminations(elimID, 0);
      GameGlobals.SetSpecificEliminations(elimID, 0);
    }
    for (int elimID = 1; elimID < this.CurrentWeek; ++elimID)
    {
      GameGlobals.SetRivalEliminations(elimID, 1);
      GameGlobals.SetSpecificEliminations(elimID, 1);
    }
    DateGlobals.Week = this.CurrentWeek;
    this.UpdateText();
  }

  private void AssignPrisoner(int ID)
  {
    switch (StudentGlobals.Prisoners)
    {
      case 1:
        StudentGlobals.Prisoner1 = 10 + ID;
        break;
      case 2:
        StudentGlobals.Prisoner2 = 10 + ID;
        break;
      case 3:
        StudentGlobals.Prisoner3 = 10 + ID;
        break;
      case 4:
        StudentGlobals.Prisoner4 = 10 + ID;
        break;
      case 5:
        StudentGlobals.Prisoner5 = 10 + ID;
        break;
      case 6:
        StudentGlobals.Prisoner6 = 10 + ID;
        break;
      case 7:
        StudentGlobals.Prisoner7 = 10 + ID;
        break;
      case 8:
        StudentGlobals.Prisoner8 = 10 + ID;
        break;
      case 9:
        StudentGlobals.Prisoner9 = 10 + ID;
        break;
      case 10:
        StudentGlobals.Prisoner10 = 10 + ID;
        break;
    }
  }
}
