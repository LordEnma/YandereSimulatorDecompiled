// Decompiled with JetBrains decompiler
// Type: PrayScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PrayScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public WeaponManagerScript WeaponManager;
  public DebugEnablerScript DebugEnabler;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public StudentScript Student;
  public YandereScript Yandere;
  public PoliceScript Police;
  public UILabel SanityLabel;
  public UILabel VictimLabel;
  public PromptScript GenderPrompt;
  public PromptScript Prompt;
  public Transform PrayWindow;
  public Transform SummonSpot;
  public Transform Highlight;
  public Transform[] WeaponSpot;
  public GameObject[] Weapon;
  public GameObject FemaleTurtle;
  public int StudentNumber;
  public int StudentID;
  public int Selected;
  public int Victims;
  public int Uses;
  public bool FemaleVictimChecked;
  public bool MaleVictimChecked;
  public bool JustSummoned;
  public bool SpawnOsana;
  public bool SpawnMale;
  public bool Show;

  private void Start()
  {
    if (StudentGlobals.GetStudentDead(39))
      this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 0.5f);
    this.GenderPrompt.gameObject.SetActive(true);
    this.PrayWindow.localScale = Vector3.zero;
    this.Prompt.enabled = true;
  }

  private void Update()
  {
    if (!this.FemaleVictimChecked)
    {
      if ((Object) this.StudentManager.Students[39] != (Object) null && !this.StudentManager.Students[39].Alive)
      {
        this.FemaleVictimChecked = true;
        ++this.Victims;
      }
    }
    else if ((Object) this.StudentManager.Students[39] == (Object) null)
    {
      this.FemaleVictimChecked = false;
      --this.Victims;
    }
    if (!this.MaleVictimChecked)
    {
      if ((Object) this.StudentManager.Students[37] != (Object) null && !this.StudentManager.Students[37].Alive)
      {
        this.MaleVictimChecked = true;
        ++this.Victims;
      }
    }
    else if ((Object) this.StudentManager.Students[37] == (Object) null)
    {
      this.MaleVictimChecked = false;
      --this.Victims;
    }
    if (this.JustSummoned)
    {
      this.StudentManager.UpdateMe(this.StudentID);
      this.JustSummoned = false;
    }
    if ((double) this.GenderPrompt.Circle[0].fillAmount == 0.0)
    {
      this.GenderPrompt.Circle[0].fillAmount = 1f;
      if (!this.SpawnMale)
      {
        this.GenderPrompt.Label[0].text = "     Male Victim";
        this.SpawnMale = true;
      }
      else
      {
        this.GenderPrompt.Label[0].text = "     Female Victim";
        this.SpawnMale = false;
      }
    }
    if ((double) this.Prompt.Circle[0].fillAmount == 0.0)
    {
      this.Prompt.Circle[0].fillAmount = 1f;
      if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        this.Yandere.TargetStudent = this.Student;
        this.StudentManager.DisablePrompts();
        this.PrayWindow.gameObject.SetActive(true);
        this.Show = true;
        this.Yandere.ShoulderCamera.OverShoulder = true;
        this.Yandere.WeaponMenu.KeyboardShow = false;
        this.Yandere.WeaponMenu.Show = false;
        this.Yandere.YandereVision = false;
        this.Yandere.CanMove = false;
        this.Yandere.Talking = true;
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[0].text = "Accept";
        this.PromptBar.Label[4].text = "Choose";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.StudentNumber = this.SpawnMale ? 37 : 39;
        this.VictimLabel.color = new Color(this.VictimLabel.color.r, this.VictimLabel.color.g, this.VictimLabel.color.b, 1f);
      }
    }
    if (!this.Show)
    {
      if (!this.PrayWindow.gameObject.activeInHierarchy)
        return;
      if ((double) this.PrayWindow.localScale.x > 0.10000000149011612)
      {
        this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
      }
      else
      {
        this.PrayWindow.localScale = Vector3.zero;
        this.PrayWindow.gameObject.SetActive(false);
      }
    }
    else
    {
      this.PrayWindow.localScale = Vector3.Lerp(this.PrayWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.InputManager.TappedUp)
      {
        --this.Selected;
        if (this.Selected == 7)
          this.Selected = 6;
        this.UpdateHighlight();
      }
      if (this.InputManager.TappedDown)
      {
        ++this.Selected;
        if (this.Selected == 7)
          this.Selected = 8;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        if (this.Selected == 1)
        {
          if (!this.Yandere.SanityBased)
          {
            this.SanityLabel.text = "Disable Sanity Anims";
            this.Yandere.SanityBased = true;
          }
          else
          {
            this.SanityLabel.text = "Enable Sanity Anims";
            this.Yandere.SanityBased = false;
          }
          this.Exit();
        }
        else if (this.Selected == 2)
        {
          this.Yandere.Sanity -= 50f;
          this.Exit();
        }
        else if (this.Selected == 3)
        {
          if ((double) this.VictimLabel.color.a == 1.0 && this.StudentManager.NPCsSpawned >= this.StudentManager.NPCsTotal)
          {
            if (this.SpawnMale)
            {
              this.MaleVictimChecked = false;
              this.StudentID = 37;
            }
            else
            {
              this.FemaleVictimChecked = false;
              this.StudentID = 39;
            }
            if (this.SpawnOsana)
              this.StudentID = 11;
            if ((Object) this.StudentManager.Students[this.StudentID] != (Object) null)
              Object.Destroy((Object) this.StudentManager.Students[this.StudentID].gameObject);
            this.StudentManager.Students[this.StudentID] = (StudentScript) null;
            this.StudentManager.ForceSpawn = true;
            this.StudentManager.SpawnPositions[this.StudentID] = this.SummonSpot;
            this.StudentManager.SpawnID = this.StudentID;
            this.StudentManager.SpawnStudent(this.StudentManager.SpawnID);
            this.StudentManager.SpawnID = 0;
            this.Police.Corpses -= this.Victims;
            this.Victims = 0;
            this.JustSummoned = true;
            this.Exit();
          }
        }
        else if (this.Selected == 4)
        {
          this.SpawnWeapons();
          this.Exit();
        }
        else if (this.Selected == 5)
        {
          if (this.Yandere.Gloved)
            this.Yandere.Gloves.Blood.enabled = false;
          if (this.Yandere.CurrentUniformOrigin == 1)
            ++this.StudentManager.OriginalUniforms;
          else
            ++this.StudentManager.NewUniforms;
          this.Police.BloodyClothing = 0;
          this.Yandere.Bloodiness = 0.0f;
          this.Yandere.Sanity = 100f;
          this.Exit();
        }
        else if (this.Selected == 6)
        {
          this.WeaponManager.CleanWeapons();
          this.Exit();
        }
        else if (this.Selected == 8)
        {
          this.DebugEnabler.EnableDebug();
          this.Exit();
        }
      }
      if (Input.GetKeyDown("b"))
      {
        foreach (Component component in this.Police.BloodParent.transform)
          Object.Destroy((Object) component.gameObject);
      }
      if (!Input.GetKeyDown("o"))
        return;
      this.SpawnOsana = true;
    }
  }

  private void UpdateHighlight()
  {
    if (this.Selected < 1)
      this.Selected = 8;
    else if (this.Selected > 8)
      this.Selected = 1;
    this.Highlight.transform.localPosition = new Vector3(this.Highlight.transform.localPosition.x, (float) (225.0 - 50.0 * (double) this.Selected), this.Highlight.transform.localPosition.z);
  }

  private void Exit()
  {
    this.Yandere.CameraEffects.UpdateDOF(2f);
    this.Selected = 1;
    this.UpdateHighlight();
    this.Yandere.ShoulderCamera.OverShoulder = false;
    this.StudentManager.EnablePrompts();
    this.Yandere.TargetStudent = (StudentScript) null;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Show = false;
    ++this.Uses;
    if (this.Uses <= 9)
      return;
    this.FemaleTurtle.SetActive(true);
  }

  public void SpawnWeapons()
  {
    for (int index = 1; index < 6; ++index)
    {
      if ((Object) this.Weapon[index] != (Object) null)
        this.Weapon[index].transform.position = this.WeaponSpot[index].position;
    }
  }
}
