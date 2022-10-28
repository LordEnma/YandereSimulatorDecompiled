// Decompiled with JetBrains decompiler
// Type: ServicesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ServicesScript : MonoBehaviour
{
  public TextMessageManagerScript TextMessageManager;
  public StudentManagerScript StudentManager;
  public InputManagerScript InputManager;
  public ReputationScript Reputation;
  public InventoryScript Inventory;
  public PromptBarScript PromptBar;
  public SchemesScript Schemes;
  public YandereScript Yandere;
  public GameObject FavorMenu;
  public Transform Highlight;
  public AudioSource MyAudio;
  public PoliceScript Police;
  public UITexture ServiceIcon;
  public UILabel ServiceLimit;
  public UILabel ServiceDesc;
  public UILabel PantyCount;
  public UILabel[] CostLabels;
  public UILabel[] NameLabels;
  public Texture[] ServiceIcons;
  public string[] ServiceLimits;
  public string[] ServiceDescs;
  public string[] ServiceNames;
  public bool[] ServiceAvailable;
  public bool[] ServicePurchased;
  public int[] ServiceCosts;
  public int Selected = 1;
  public int ID = 1;
  public AudioClip InfoUnavailable;
  public AudioClip InfoPurchase;
  public AudioClip InfoAfford;
  public float HeldDown;
  public float HeldUp;

  private void Start()
  {
    for (int serviceID = 1; serviceID < this.ServiceNames.Length; ++serviceID)
    {
      this.ServicePurchased[serviceID] = SchemeGlobals.GetServicePurchased(serviceID);
      this.NameLabels[serviceID].text = this.ServiceNames[serviceID];
    }
    if (MissionModeGlobals.MissionMode)
    {
      this.ServiceLimit.color = new Color(1f, 1f, 1f, 1f);
      this.ServiceDesc.color = new Color(1f, 1f, 1f, 1f);
    }
    else
    {
      this.ServiceDescs[9] = "This service is not available right now.";
      this.ServiceNames[9] = "?????";
      this.NameLabels[9].text = this.ServiceNames[9];
    }
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
      --this.Selected;
      if (this.Selected < 1)
        this.Selected = this.ServiceNames.Length - 1;
      this.UpdateDesc();
    }
    if (this.InputManager.TappedDown || (double) this.HeldDown > 0.5)
    {
      if ((double) this.HeldDown > 0.5)
        this.HeldDown = 0.45f;
      ++this.Selected;
      if (this.Selected > this.ServiceNames.Length - 1)
        this.Selected = 1;
      this.UpdateDesc();
    }
    if (Input.GetButtonDown("A"))
    {
      if (!this.ServicePurchased[this.Selected] && (double) this.NameLabels[this.Selected].color.a == 1.0)
      {
        if (this.PromptBar.Label[0].text != string.Empty)
        {
          if (this.Inventory.PantyShots < this.ServiceCosts[this.Selected])
            return;
          if (this.Selected == 1)
          {
            this.Yandere.PauseScreen.StudentInfoMenu.GettingInfo = true;
            this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.Yandere.PauseScreen.Sideways = true;
            this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.Yandere.PauseScreen.StudentInfoMenu.GrabPortraitsNextFrame = true;
            this.Yandere.PromptBar.ClearButtons();
            this.Yandere.PromptBar.Label[1].text = "Cancel";
            this.Yandere.PromptBar.UpdateButtons();
            this.Yandere.PromptBar.Show = true;
            this.gameObject.SetActive(false);
          }
          else if (this.Selected == 2)
          {
            this.Reputation.PendingRep += 5f;
            this.Purchase();
          }
          else if (this.Selected == 3)
          {
            this.StudentManager.StudentReps[this.StudentManager.RivalID] -= 5f;
            this.Purchase();
          }
          else if (this.Selected == 4)
          {
            this.ServicePurchased[this.Selected] = true;
            this.StudentManager.EmbarassingSecret = true;
            this.Purchase();
          }
          else if (this.Selected == 5)
          {
            this.Yandere.PauseScreen.StudentInfoMenu.SendingHome = true;
            this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.Yandere.PauseScreen.Sideways = true;
            this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
            this.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
            this.Yandere.PromptBar.ClearButtons();
            this.Yandere.PromptBar.Label[1].text = "Cancel";
            this.Yandere.PromptBar.UpdateButtons();
            this.Yandere.PromptBar.Show = true;
            this.gameObject.SetActive(false);
          }
          else if (this.Selected == 6)
          {
            this.Police.Timer += 300f;
            this.Police.Delayed = true;
            this.Purchase();
          }
          else if (this.Selected == 7)
          {
            this.ServicePurchased[this.Selected] = true;
            this.StudentManager.Police.EndOfDay.Counselor.CounselorTape = 1;
            this.Purchase();
          }
          else if (this.Selected == 8)
          {
            this.Yandere.PauseScreen.StudentInfoMenu.GettingOpinions = true;
            this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.Yandere.PauseScreen.Sideways = true;
            this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
            this.Yandere.PromptBar.ClearButtons();
            this.Yandere.PromptBar.Label[0].text = "Get Opinions";
            this.Yandere.PromptBar.Label[1].text = "Cancel";
            this.Yandere.PromptBar.UpdateButtons();
            this.Yandere.PromptBar.Show = true;
            this.gameObject.SetActive(false);
          }
          else if (this.Selected == 9)
          {
            this.Yandere.PauseScreen.StudentInfoMenu.FiringCouncilMember = true;
            this.Yandere.PauseScreen.StudentInfoMenu.Column = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.Row = 0;
            this.Yandere.PauseScreen.StudentInfoMenu.UpdateHighlight();
            this.Yandere.PauseScreen.Sideways = true;
            this.Yandere.PauseScreen.StudentInfoMenu.gameObject.SetActive(true);
            this.Yandere.PauseScreen.StudentInfoMenu.GrabbedPortraits = false;
            this.StartCoroutine(this.Yandere.PauseScreen.StudentInfoMenu.UpdatePortraits());
            this.Yandere.PromptBar.ClearButtons();
            this.Yandere.PromptBar.Label[1].text = "Cancel";
            this.Yandere.PromptBar.UpdateButtons();
            this.Yandere.PromptBar.Show = true;
            this.gameObject.SetActive(false);
          }
          else
          {
            if (this.Selected != 10)
              return;
            this.ServicePurchased[this.Selected] = true;
            this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
            this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
            if (SchemeGlobals.GetSchemeStage(6) == 1 || SchemeGlobals.GetSchemeStage(6) == 2)
            {
              SchemeGlobals.SetSchemeStage(6, 3);
              this.Yandere.PauseScreen.Schemes.UpdateInstructions();
            }
            this.Purchase();
          }
        }
        else if (this.Inventory.PantyShots < this.ServiceCosts[this.Selected])
        {
          this.MyAudio.clip = this.InfoAfford;
          this.MyAudio.Play();
        }
        else
        {
          this.MyAudio.clip = this.InfoUnavailable;
          this.MyAudio.Play();
        }
      }
      else
      {
        this.MyAudio.clip = this.InfoUnavailable;
        this.MyAudio.Play();
      }
    }
    else
    {
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
  }

  public void UpdateList()
  {
    for (this.ID = 1; this.ID < this.ServiceNames.Length; ++this.ID)
    {
      this.CostLabels[this.ID].text = this.ServiceCosts[this.ID].ToString();
      this.ServiceAvailable[this.ID] = false;
      if (this.ID == 1 || this.ID == 2 || this.ID == 3)
        this.ServiceAvailable[this.ID] = true;
      else if (this.ID == 4)
      {
        if (!this.StudentManager.EmbarassingSecret)
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 5)
      {
        if (!this.ServicePurchased[this.ID])
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 6)
      {
        if (this.Police.Show && !this.Police.Delayed)
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 7)
      {
        if (this.StudentManager.Police.EndOfDay.Counselor.CounselorTape == 0)
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 8)
      {
        if (!this.ServicePurchased[8])
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 9)
      {
        if (MissionModeGlobals.MissionMode)
          this.ServiceAvailable[this.ID] = true;
      }
      else if (this.ID == 10 && (!this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 || !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2))
        this.ServiceAvailable[this.ID] = true;
      if ((Object) this.StudentManager != (Object) null && this.StudentManager.MissionMode)
        this.ServiceAvailable[5] = false;
      UILabel nameLabel = this.NameLabels[this.ID];
      nameLabel.color = new Color(nameLabel.color.r, nameLabel.color.g, nameLabel.color.b, this.ServiceAvailable[this.ID] ? 1f : 0.5f);
    }
  }

  public void UpdateDesc()
  {
    if (this.ServiceAvailable[this.Selected] && !this.ServicePurchased[this.Selected])
    {
      this.PromptBar.Label[0].text = this.Inventory.PantyShots >= this.ServiceCosts[this.Selected] ? "Purchase" : string.Empty;
      this.PromptBar.UpdateButtons();
    }
    else
    {
      this.PromptBar.Label[0].text = string.Empty;
      this.PromptBar.UpdateButtons();
    }
    this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, (float) (200.0 - 25.0 * (double) this.Selected), this.Highlight.localPosition.z);
    this.ServiceIcon.mainTexture = this.ServiceIcons[this.Selected];
    this.ServiceLimit.text = this.ServiceLimits[this.Selected];
    this.ServiceDesc.text = this.ServiceDescs[this.Selected];
    if (this.Selected == 5)
      this.ServiceDesc.text = this.ServiceDescs[this.Selected] + "\n\nIf student portraits don't appear, back out of the menu, load the Student Info menu, then return to this screen.";
    this.UpdatePantyCount();
  }

  public void UpdatePantyCount() => this.PantyCount.text = this.Inventory.PantyShots.ToString();

  public void Purchase()
  {
    this.TextMessageManager.SpawnMessage(this.Selected);
    this.Inventory.PantyShots -= this.ServiceCosts[this.Selected];
    AudioSource.PlayClipAtPoint(this.InfoPurchase, this.transform.position);
    this.UpdateList();
    this.UpdateDesc();
    this.PromptBar.Label[0].text = string.Empty;
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.UpdateButtons();
  }

  public void SaveServicesPurchased()
  {
    for (int serviceID = 1; serviceID < this.ServiceNames.Length; ++serviceID)
      SchemeGlobals.SetServicePurchased(serviceID, this.ServicePurchased[serviceID]);
  }
}
