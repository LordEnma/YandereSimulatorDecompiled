// Decompiled with JetBrains decompiler
// Type: ClubWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ClubWindowScript : MonoBehaviour
{
  public ClubManagerScript ClubManager;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public Transform ActivityWindow;
  public GameObject ClubInfo;
  public GameObject Window;
  public GameObject Warning;
  public string[] ActivityDescs;
  public string[] ClubNames;
  public string[] ClubDescs;
  public string MedAtmosphereDesc;
  public string LowAtmosphereDesc;
  public UILabel ActivityLabel;
  public UILabel BottomLabel;
  public UILabel ClubName;
  public UILabel ClubDesc;
  public bool PerformingActivity;
  public bool Activity;
  public bool Quitting;
  public float Timer;
  public ClubType Club;

  private void Start()
  {
    this.Window.SetActive(false);
    if (GameGlobals.Eighties)
    {
      this.ActivityDescs[7] = "The Photography Club review each others' photographs and share advice on how to improve.";
      this.ClubDescs[8] = "If you join the Science Club, you will have easy access to an emergency shower that can be used for changing out of a bloody outfit, and a vat of acid that can be used for disposing of corpses.";
    }
    if ((double) SchoolGlobals.SchoolAtmosphere <= 0.899999976158142)
    {
      this.ActivityDescs[7] = this.LowAtmosphereDesc;
    }
    else
    {
      if ((double) SchoolGlobals.SchoolAtmosphere > 0.800000011920929)
        return;
      this.ActivityDescs[7] = this.MedAtmosphereDesc;
    }
  }

  private void Update()
  {
    if (this.Window.activeInHierarchy)
    {
      if ((double) this.Timer > 0.5)
      {
        if (Input.GetButtonDown("A"))
        {
          if (!this.Quitting && !this.Activity)
          {
            this.Yandere.Club = this.Club;
            this.Yandere.ClubAccessory();
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
            this.ClubManager.ActivateClubBenefit();
          }
          else if (this.Quitting)
          {
            this.ClubManager.DeactivateClubBenefit();
            this.ClubManager.QuitClub[(int) this.Club] = true;
            this.Yandere.Club = ClubType.None;
            this.Yandere.ClubAccessory();
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
            this.Quitting = false;
            this.Yandere.StudentManager.UpdateBooths();
          }
          else if (this.Activity)
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
          this.Yandere.TargetStudent.TalkTimer = 100f;
          this.Yandere.TargetStudent.ClubPhase = 2;
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
          this.Window.SetActive(false);
        }
        if (Input.GetButtonDown("B"))
        {
          if (!this.Quitting && !this.Activity)
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubJoin;
          else if (this.Quitting)
          {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubQuit;
            this.Quitting = false;
          }
          else if (this.Activity)
          {
            this.Yandere.TargetStudent.Interaction = StudentInteractionType.ClubActivity;
            this.Activity = false;
          }
          this.Yandere.TargetStudent.TalkTimer = 100f;
          this.Yandere.TargetStudent.ClubPhase = 3;
          this.PromptBar.ClearButtons();
          this.PromptBar.Show = false;
          this.Window.SetActive(false);
        }
        if (Input.GetButtonDown("X") && !this.Quitting && !this.Activity)
        {
          if (!this.Warning.activeInHierarchy)
          {
            this.ClubInfo.SetActive(false);
            this.Warning.SetActive(true);
          }
          else
          {
            this.ClubInfo.SetActive(true);
            this.Warning.SetActive(false);
          }
        }
      }
      this.Timer += Time.deltaTime;
    }
    if (this.PerformingActivity)
      this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    else if ((double) this.ActivityWindow.localScale.x > 0.100000001490116)
    {
      this.ActivityWindow.localScale = Vector3.Lerp(this.ActivityWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else
    {
      if ((double) this.ActivityWindow.localScale.x == 0.0)
        return;
      this.ActivityWindow.localScale = Vector3.zero;
    }
  }

  public void UpdateWindow()
  {
    this.ClubName.text = this.ClubNames[(int) this.Club];
    if (!this.Quitting && !this.Activity)
    {
      this.ClubDesc.text = this.ClubDescs[(int) this.Club];
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Accept";
      this.PromptBar.Label[1].text = "Refuse";
      this.PromptBar.Label[2].text = "More Info";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you join the " + this.ClubNames[(int) this.Club] + "?";
    }
    else if (this.Activity)
    {
      this.ClubDesc.text = "Club activities last until 6:00 PM. If you choose to participate in club activities now, the day will end.\n\nIf you don't join by 5:30 PM, you won't be able to participate in club activities today.\n\nIf you don't participate in club activities at least once a week, you will be removed from the club.";
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Yes";
      this.PromptBar.Label[1].text = "No";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you participate in club activities?";
    }
    else if (this.Quitting)
    {
      this.ClubDesc.text = "Are you sure you want to quit this club? If you quit, you will never be allowed to return.";
      this.PromptBar.ClearButtons();
      this.PromptBar.Label[0].text = "Confirm";
      this.PromptBar.Label[1].text = "Deny";
      this.PromptBar.UpdateButtons();
      this.PromptBar.Show = true;
      this.BottomLabel.text = "Will you quit the " + this.ClubNames[(int) this.Club] + "?";
    }
    this.ClubInfo.SetActive(true);
    this.Warning.SetActive(false);
    this.Window.SetActive(true);
    this.Timer = 0.0f;
  }
}
