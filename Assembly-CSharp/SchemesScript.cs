// Decompiled with JetBrains decompiler
// Type: SchemesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class SchemesScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public SchemeManagerScript SchemeManager;
  public InputManagerScript InputManager;
  public InventoryScript Inventory;
  public PromptBarScript PromptBar;
  public GameObject NextStepInput;
  public GameObject FavorMenu;
  public Transform Highlight;
  public Transform Arrow;
  public UILabel SchemeInstructions;
  public UITexture SchemeIcon;
  public UILabel PantyCount;
  public UILabel SchemeDesc;
  public UILabel[] SchemeDeadlineLabels;
  public UILabel[] SchemeCostLabels;
  public UILabel[] SchemeNameLabels;
  public UISprite[] Exclamations;
  public Texture[] SchemeIcons;
  public int[] SchemeCosts;
  public Transform[] SchemeDestinations;
  public string[] SchemeDeadlines;
  public string[] SchemeSkills;
  public string[] SchemeDescs;
  public string[] SchemeNames;
  [Multiline]
  [SerializeField]
  public string[] SchemeSteps;
  public int ListPosition = 1;
  public int Limit = 20;
  public int ID = 1;
  public string[] Steps;
  public AudioClip InfoPurchase;
  public AudioClip InfoAfford;
  public Transform[] Scheme1Destinations;
  public Transform[] Scheme2Destinations;
  public Transform[] Scheme3Destinations;
  public Transform[] Scheme4Destinations;
  public Transform[] Scheme5Destinations;
  public bool[] DisableScheme;
  public float HeldDown;
  public float HeldUp;
  public GameObject HUDIcon;
  public UILabel HUDInstructions;

  private void Start()
  {
    for (int schemeID = 1; schemeID < this.SchemeNameLabels.Length; ++schemeID)
    {
      if (!SchemeGlobals.GetSchemeStatus(schemeID))
      {
        this.SchemeDeadlineLabels[schemeID].text = this.SchemeDeadlines[schemeID];
        this.SchemeNameLabels[schemeID].text = this.SchemeNames[schemeID];
      }
    }
    this.DisableScheme[1] = true;
    this.DisableScheme[2] = true;
    this.DisableScheme[3] = true;
    this.DisableScheme[4] = true;
    this.DisableScheme[5] = true;
    this.DisableScheme[21] = true;
    this.DisableScheme[22] = true;
    this.DisableScheme[23] = true;
    this.DisableScheme[24] = true;
    this.DisableScheme[25] = true;
    if (DateGlobals.Weekday == DayOfWeek.Monday)
    {
      this.DisableScheme[1] = false;
      this.DisableScheme[21] = false;
    }
    if (DateGlobals.Weekday == DayOfWeek.Tuesday)
    {
      this.DisableScheme[2] = false;
      this.DisableScheme[22] = false;
      this.DisableScheme[27] = true;
    }
    if (DateGlobals.Weekday == DayOfWeek.Wednesday)
    {
      this.DisableScheme[3] = false;
      this.DisableScheme[23] = false;
    }
    if (DateGlobals.Weekday == DayOfWeek.Thursday)
    {
      this.DisableScheme[4] = false;
      this.DisableScheme[24] = false;
    }
    if (DateGlobals.Weekday == DayOfWeek.Friday)
    {
      this.DisableScheme[5] = false;
      this.DisableScheme[25] = false;
    }
    if (DateGlobals.Weekday != DayOfWeek.Monday)
      this.DisableScheme[6] = true;
    if (DateGlobals.Weekday != DayOfWeek.Thursday)
      this.DisableScheme[20] = true;
    if ((UnityEngine.Object) this.NextStepInput != (UnityEngine.Object) null)
      this.NextStepInput.SetActive(false);
    this.UpdateSchemeInfo();
    if (!this.StudentManager.MissionMode)
      return;
    this.SchemeInstructions.color = Color.white;
    this.SchemeDesc.color = Color.white;
  }

  private void Update()
  {
    if (this.InputManager.DPadUp || this.InputManager.StickUp || Input.GetKey("w") || Input.GetKey("up"))
      this.HeldUp += Time.unscaledDeltaTime;
    else
      this.HeldUp = 0.0f;
    if (this.InputManager.DPadDown || this.InputManager.StickDown || Input.GetKey("s") || Input.GetKey("down"))
      this.HeldDown += Time.unscaledDeltaTime;
    else
      this.HeldDown = 0.0f;
    if (this.InputManager.TappedUp || (double) this.HeldUp > 0.5)
    {
      if ((double) this.HeldUp > 0.5)
        this.HeldUp = 0.45f;
      if (this.ID == 1)
      {
        --this.ListPosition;
        if (this.ListPosition < 0)
        {
          this.ListPosition = this.Limit - 15;
          this.ID = 15;
        }
      }
      else
        --this.ID;
      this.UpdateSchemeInfo();
    }
    if (this.InputManager.TappedDown || (double) this.HeldDown > 0.5)
    {
      if ((double) this.HeldDown > 0.5)
        this.HeldDown = 0.45f;
      if (this.ID == 15)
      {
        ++this.ListPosition;
        if (this.ID + this.ListPosition > this.Limit)
        {
          this.ListPosition = 0;
          this.ID = 1;
        }
      }
      else
        ++this.ID;
      this.UpdateSchemeInfo();
    }
    if (Input.GetButtonDown("A"))
    {
      AudioSource component = this.GetComponent<AudioSource>();
      if (this.PromptBar.Label[0].text != string.Empty)
      {
        if ((double) this.SchemeNameLabels[this.ID].color.a == 1.0)
        {
          this.SchemeManager.enabled = true;
          this.SchemeManager.CurrentScheme = this.ID + this.ListPosition;
          if (this.ID == 5)
            this.SchemeManager.ClockCheck = true;
          if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
          {
            if (this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition])
            {
              this.Inventory.PantyShots -= this.SchemeCosts[this.ID + this.ListPosition];
              SchemeGlobals.SetSchemeUnlocked(this.ID + this.ListPosition, true);
              SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
              if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) == 0)
                SchemeGlobals.SetSchemeStage(this.ID + this.ListPosition, 1);
              this.UpdateSchemeDestinations();
              this.UpdateInstructions();
              this.UpdateSchemeList();
              this.UpdateSchemeInfo();
              component.clip = this.InfoPurchase;
              component.Play();
            }
          }
          else
          {
            if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
            {
              SchemeGlobals.CurrentScheme = 0;
              this.SchemeManager.CurrentScheme = 0;
              this.SchemeManager.enabled = false;
            }
            else
              SchemeGlobals.CurrentScheme = this.ID + this.ListPosition;
            this.UpdateSchemeDestinations();
            this.UpdateInstructions();
            this.UpdateSchemeInfo();
          }
        }
      }
      else if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100 && this.Inventory.PantyShots < this.SchemeCosts[this.ID + this.ListPosition])
      {
        component.clip = this.InfoAfford;
        component.Play();
      }
    }
    if (!Input.GetButtonDown("B"))
      return;
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Accept";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[5].text = "Choose";
    this.PromptBar.UpdateButtons();
    this.FavorMenu.SetActive(true);
    this.gameObject.SetActive(false);
  }

  public void UpdateSchemeList()
  {
    for (int schemeID = 1; schemeID < this.SchemeNameLabels.Length; ++schemeID)
    {
      if (SchemeGlobals.GetSchemeStage(schemeID + this.ListPosition) == 100)
      {
        UILabel schemeNameLabel = this.SchemeNameLabels[schemeID];
        schemeNameLabel.color = new Color(schemeNameLabel.color.r, schemeNameLabel.color.g, schemeNameLabel.color.b, 0.5f);
        this.SchemeCostLabels[schemeID].text = string.Empty;
      }
      else
      {
        this.SchemeCostLabels[schemeID].text = !SchemeGlobals.GetSchemeUnlocked(schemeID) ? string.Empty : this.SchemeCosts[schemeID].ToString();
        if (SchemeGlobals.GetSchemeStage(schemeID) > SchemeGlobals.GetSchemePreviousStage(schemeID))
          SchemeGlobals.SetSchemePreviousStage(schemeID, SchemeGlobals.GetSchemeStage(schemeID));
      }
    }
  }

  public void UpdateSchemeInfo()
  {
    if (SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100)
    {
      if (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition))
      {
        this.Arrow.gameObject.SetActive(false);
        if ((UnityEngine.Object) this.Inventory != (UnityEngine.Object) null)
          this.PromptBar.Label[0].text = this.Inventory.PantyShots >= this.SchemeCosts[this.ID + this.ListPosition] ? "Purchase" : string.Empty;
        this.PromptBar.UpdateButtons();
      }
      else if (SchemeGlobals.CurrentScheme == this.ID + this.ListPosition)
      {
        this.Arrow.gameObject.SetActive(true);
        this.Arrow.localPosition = new Vector3(this.Arrow.localPosition.x, (float) (-10.0 - 21.0 * (double) SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition)), this.Arrow.localPosition.z);
        this.PromptBar.Label[0].text = "Stop Tracking";
        this.PromptBar.UpdateButtons();
      }
      else
      {
        this.Arrow.gameObject.SetActive(false);
        this.PromptBar.Label[0].text = "Start Tracking";
        this.PromptBar.UpdateButtons();
      }
    }
    else
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (200.0 - 25.0 * (double) this.ID), this.Highlight.localPosition.z);
    for (int index = 1; index < this.SchemeNameLabels.Length; ++index)
    {
      this.SchemeNameLabels[index].text = this.SchemeNames[index + this.ListPosition];
      this.SchemeCostLabels[index].text = this.SchemeCosts[index + this.ListPosition].ToString() ?? "";
      this.SchemeDeadlineLabels[index].text = this.SchemeDeadlines[index + this.ListPosition];
      if (this.DisableScheme[index + this.ListPosition])
        this.SchemeNameLabels[index].color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
      else
        this.SchemeNameLabels[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      if ((UnityEngine.Object) this.SchemeManager != (UnityEngine.Object) null)
      {
        if (this.SchemeManager.CurrentScheme == index + this.ListPosition)
          this.Exclamations[index].enabled = true;
        else
          this.Exclamations[index].enabled = false;
      }
    }
    this.SchemeIcon.mainTexture = this.SchemeIcons[this.ID + this.ListPosition];
    this.SchemeDesc.text = this.SchemeDescs[this.ID + this.ListPosition];
    this.SchemeInstructions.text = SchemeGlobals.GetSchemeStage(this.ID + this.ListPosition) != 100 ? (!SchemeGlobals.GetSchemeUnlocked(this.ID + this.ListPosition) ? "Skills Required:\n" + this.SchemeSkills[this.ID + this.ListPosition] : this.SchemeSteps[this.ID + this.ListPosition]) : "This scheme is no longer available.";
    this.UpdatePantyCount();
  }

  public void UpdatePantyCount()
  {
    if (!((UnityEngine.Object) this.Inventory != (UnityEngine.Object) null))
      return;
    this.PantyCount.text = this.Inventory.PantyShots.ToString();
  }

  public void UpdateInstructions()
  {
    this.Steps = this.SchemeSteps[SchemeGlobals.CurrentScheme].Split('\n');
    if (SchemeGlobals.CurrentScheme > 0)
    {
      if (SchemeGlobals.CurrentScheme == 4 && SchemeGlobals.GetSchemeStage(4) == 1 && ((UnityEngine.Object) this.StudentManager.Yandere.Weapon[1] != (UnityEngine.Object) null && this.StudentManager.Yandere.Weapon[1].WeaponID == 6 || (UnityEngine.Object) this.StudentManager.Yandere.Weapon[2] != (UnityEngine.Object) null && this.StudentManager.Yandere.Weapon[2].WeaponID == 6))
        SchemeGlobals.SetSchemeStage(4, 2);
      if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 100)
      {
        if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) < 1)
          SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, this.Steps.Length);
        else if (SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) > this.Steps.Length)
          SchemeGlobals.SetSchemeStage(SchemeGlobals.CurrentScheme, 1);
        this.HUDIcon.SetActive(true);
        this.HUDInstructions.text = this.Steps[SchemeGlobals.GetSchemeStage(SchemeGlobals.CurrentScheme) - 1].ToString();
      }
      else
      {
        this.Arrow.gameObject.SetActive(false);
        this.HUDIcon.gameObject.SetActive(false);
        this.HUDInstructions.text = string.Empty;
        this.SchemeManager.CurrentScheme = 0;
      }
    }
    else
    {
      this.HUDIcon.SetActive(false);
      this.HUDInstructions.text = string.Empty;
    }
    if (SchemeGlobals.CurrentScheme < 7)
      this.NextStepInput.SetActive(false);
    else
      this.NextStepInput.SetActive(true);
  }

  public void UpdateSchemeDestinations()
  {
    if ((UnityEngine.Object) this.StudentManager.Students[this.StudentManager.RivalID] != (UnityEngine.Object) null)
    {
      this.Scheme1Destinations[3] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
      this.Scheme1Destinations[7] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
      this.Scheme4Destinations[5] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
      this.Scheme4Destinations[6] = this.StudentManager.Students[this.StudentManager.RivalID].transform;
    }
    if ((UnityEngine.Object) this.StudentManager.Students[2] != (UnityEngine.Object) null)
      this.Scheme2Destinations[3] = this.StudentManager.Students[2].transform;
    if ((UnityEngine.Object) this.StudentManager.Students[97] != (UnityEngine.Object) null)
      this.Scheme5Destinations[3] = this.StudentManager.Students[97].transform;
    switch (SchemeGlobals.CurrentScheme)
    {
      case 1:
        this.SchemeDestinations = this.Scheme1Destinations;
        break;
      case 2:
        this.SchemeDestinations = this.Scheme2Destinations;
        break;
      case 3:
        this.SchemeDestinations = this.Scheme3Destinations;
        break;
      case 4:
        this.SchemeDestinations = this.Scheme4Destinations;
        break;
      case 5:
        this.SchemeDestinations = this.Scheme5Destinations;
        break;
    }
  }
}
