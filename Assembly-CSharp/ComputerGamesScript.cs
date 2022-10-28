// Decompiled with JetBrains decompiler
// Type: ComputerGamesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ComputerGamesScript : MonoBehaviour
{
  public PromptScript[] ComputerGames;
  public Collider[] Chairs;
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public PromptBarScript PromptBar;
  public YandereScript Yandere;
  public PoliceScript Police;
  public PoisonScript Poison;
  public Quaternion targetRotation;
  public Transform GameWindow;
  public Transform MainCamera;
  public Transform Highlight;
  public bool ShowWindow;
  public bool Gaming;
  public float Timer;
  public int Subject = 1;
  public int GameID;
  public int ID = 1;
  public Color OriginalColor;
  public string[] Descriptions;
  public UITexture MyTexture;
  public Texture[] Textures;
  public UILabel DescLabel;

  private void Start()
  {
    this.GameWindow.gameObject.SetActive(false);
    this.UpdateHighlight();
    this.DeactivateAllBenefits();
    this.OriginalColor = this.Yandere.PowerUp.color;
    if (ClubGlobals.Club == ClubType.Gaming)
      this.EnableGames();
    else
      this.DisableGames();
  }

  private void Update()
  {
    if (this.ShowWindow)
    {
      this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      if (this.InputManager.TappedUp)
      {
        --this.Subject;
        this.UpdateHighlight();
      }
      else if (this.InputManager.TappedDown)
      {
        ++this.Subject;
        this.UpdateHighlight();
      }
      if (Input.GetButtonDown("A"))
      {
        this.ShowWindow = false;
        this.PlayGames();
        this.PromptBar.ClearButtons();
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = false;
      }
      if (Input.GetButtonDown("B"))
      {
        this.Yandere.CanMove = true;
        this.ShowWindow = false;
        this.PromptBar.ClearButtons();
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = false;
      }
    }
    else if ((double) this.GameWindow.localScale.x > 0.10000000149011612)
    {
      this.GameWindow.localScale = Vector3.Lerp(this.GameWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
    }
    else
    {
      this.GameWindow.localScale = Vector3.zero;
      this.GameWindow.gameObject.SetActive(false);
    }
    if (this.Gaming)
    {
      this.targetRotation = Quaternion.LookRotation(new Vector3(this.ComputerGames[this.GameID].transform.position.x, this.Yandere.transform.position.y, this.ComputerGames[this.GameID].transform.position.z) - this.Yandere.transform.position);
      this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
      this.Yandere.MoveTowardsTarget(new Vector3(24.32233f, 4f, 12.58998f));
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 5.0)
      {
        this.Yandere.PowerUp.transform.parent.gameObject.SetActive(true);
        this.Yandere.MyController.radius = 0.2f;
        this.Yandere.CanMove = true;
        this.Yandere.EmptyHands();
        this.Gaming = false;
        this.ActivateBenefit();
      }
    }
    else if ((double) this.Timer < 5.0)
    {
      for (this.ID = 1; this.ID < this.ComputerGames.Length; ++this.ID)
      {
        PromptScript computerGame = this.ComputerGames[this.ID];
        if ((double) computerGame.Circle[0].fillAmount == 0.0)
        {
          computerGame.Circle[0].fillAmount = 1f;
          if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
          {
            this.GameID = this.ID;
            if (this.ID == 1)
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.Label[4].text = "Select";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Yandere.Character.GetComponent<Animation>().Play(this.Yandere.IdleAnim);
              this.Yandere.CanMove = false;
              this.GameWindow.gameObject.SetActive(true);
              this.ShowWindow = true;
            }
            else
              this.PlayGames();
          }
        }
      }
    }
    if (!this.Yandere.PowerUp.gameObject.activeInHierarchy)
      return;
    this.Timer += Time.deltaTime;
    this.Yandere.PowerUp.transform.localPosition = new Vector3(this.Yandere.PowerUp.transform.localPosition.x, this.Yandere.PowerUp.transform.localPosition.y + Time.deltaTime, this.Yandere.PowerUp.transform.localPosition.z);
    this.Yandere.PowerUp.transform.LookAt(this.MainCamera.position);
    this.Yandere.PowerUp.transform.localEulerAngles = new Vector3(this.Yandere.PowerUp.transform.localEulerAngles.x, this.Yandere.PowerUp.transform.localEulerAngles.y + 180f, this.Yandere.PowerUp.transform.localEulerAngles.z);
    if (this.Yandere.PowerUp.color != new Color(1f, 1f, 1f, 1f))
      this.Yandere.PowerUp.color = this.OriginalColor;
    else
      this.Yandere.PowerUp.color = new Color(1f, 1f, 1f, 1f);
    if ((double) this.Timer <= 6.0)
      return;
    this.Yandere.PowerUp.transform.parent.gameObject.SetActive(false);
    this.gameObject.SetActive(false);
  }

  public void EnableGames()
  {
    for (int index = 1; index < this.ComputerGames.Length; ++index)
      this.ComputerGames[index].enabled = true;
    this.gameObject.SetActive(true);
  }

  private void PlayGames()
  {
    this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_00");
    this.Yandere.MyController.radius = 0.1f;
    this.Yandere.CanMove = false;
    this.Gaming = true;
    this.DisableGames();
    this.UpdateImage();
  }

  private void UpdateImage() => this.MyTexture.mainTexture = this.Textures[this.Subject];

  public void DisableGames()
  {
    for (int index = 1; index < this.ComputerGames.Length; ++index)
    {
      this.ComputerGames[index].enabled = false;
      this.ComputerGames[index].Hide();
    }
    if (this.Gaming)
      return;
    this.gameObject.SetActive(false);
  }

  private void EnableChairs()
  {
    for (int index = 1; index < this.Chairs.Length; ++index)
      this.Chairs[index].enabled = true;
    this.gameObject.SetActive(true);
  }

  private void DisableChairs()
  {
    for (int index = 1; index < this.Chairs.Length; ++index)
      this.Chairs[index].enabled = false;
  }

  private void ActivateBenefit()
  {
    if (this.Subject == 1)
      this.Yandere.Class.BiologyBonus = 1;
    else if (this.Subject == 2)
      this.Yandere.Class.ChemistryBonus = 1;
    else if (this.Subject == 3)
      this.Yandere.Class.LanguageBonus = 1;
    else if (this.Subject == 4)
      this.Yandere.Class.PsychologyBonus = 1;
    else if (this.Subject == 5)
      this.Yandere.Class.PhysicalBonus = 1;
    else if (this.Subject == 6)
      this.Yandere.Class.SeductionBonus = 1;
    else if (this.Subject == 7)
      this.Yandere.Class.NumbnessBonus = 1;
    else if (this.Subject == 8)
      this.Yandere.Class.SocialBonus = 1;
    else if (this.Subject == 9)
      this.Yandere.Class.StealthBonus = 1;
    else if (this.Subject == 10)
      this.Yandere.Class.SpeedBonus = 1;
    else if (this.Subject == 11)
      this.Yandere.Class.EnlightenmentBonus = 1;
    if ((Object) this.Poison != (Object) null)
      this.Poison.Start();
    this.StudentManager.UpdatePerception();
    this.Yandere.UpdateNumbness();
    this.Police.UpdateCorpses();
  }

  private void DeactivateBenefit()
  {
    if (this.Subject == 1)
      this.Yandere.Class.BiologyBonus = 0;
    else if (this.Subject == 2)
      this.Yandere.Class.ChemistryBonus = 0;
    else if (this.Subject == 3)
      this.Yandere.Class.LanguageBonus = 0;
    else if (this.Subject == 4)
      this.Yandere.Class.PsychologyBonus = 0;
    else if (this.Subject == 5)
      this.Yandere.Class.PhysicalBonus = 0;
    else if (this.Subject == 6)
      this.Yandere.Class.SeductionBonus = 0;
    else if (this.Subject == 7)
      this.Yandere.Class.NumbnessBonus = 0;
    else if (this.Subject == 8)
      this.Yandere.Class.SocialBonus = 0;
    else if (this.Subject == 9)
      this.Yandere.Class.StealthBonus = 0;
    else if (this.Subject == 10)
      this.Yandere.Class.SpeedBonus = 0;
    else if (this.Subject == 11)
      this.Yandere.Class.EnlightenmentBonus = 0;
    if ((Object) this.Poison != (Object) null)
      this.Poison.Start();
    this.StudentManager.UpdatePerception();
    this.Yandere.UpdateNumbness();
    this.Police.UpdateCorpses();
  }

  public void DeactivateAllBenefits()
  {
    this.Yandere.Class.BiologyBonus = 0;
    this.Yandere.Class.ChemistryBonus = 0;
    this.Yandere.Class.LanguageBonus = 0;
    this.Yandere.Class.PsychologyBonus = 0;
    this.Yandere.Class.PhysicalBonus = 0;
    this.Yandere.Class.SeductionBonus = 0;
    this.Yandere.Class.NumbnessBonus = 0;
    this.Yandere.Class.SocialBonus = 0;
    this.Yandere.Class.StealthBonus = 0;
    this.Yandere.Class.SpeedBonus = 0;
    this.Yandere.Class.EnlightenmentBonus = 0;
    if (!((Object) this.Poison != (Object) null))
      return;
    this.Poison.Start();
  }

  private void UpdateHighlight()
  {
    if (this.Subject < 1)
      this.Subject = 11;
    else if (this.Subject > 11)
      this.Subject = 1;
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (250.0 - (double) this.Subject * 50.0), this.Highlight.localPosition.z);
    this.DescLabel.text = this.Descriptions[this.Subject];
  }
}
