// Decompiled with JetBrains decompiler
// Type: YakuzaMenuScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YakuzaMenuScript : MonoBehaviour
{
  public InputManagerScript InputManager;
  public StalkerYandereScript Yandere;
  public HomeClockScript HomeClock;
  public PromptBarScript PromptBar;
  public UISprite AssassinationMenu;
  public UISprite ContrabandMenu;
  public UISprite KidnappingMenu;
  public UISprite ServicesMenu;
  public AudioClip[] DialogueClip;
  public string[] DialogueText;
  public AudioSource Dialogue;
  public AudioSource Jukebox;
  public UIPanel TimeDayPanel;
  public UIPanel Panel;
  public UILabel ButtonPrompt;
  public UILabel MoneyLabel;
  public Renderer Background;
  public Renderer[] Scales;
  public Transform Yakuza;
  public UILabel Subtitle;
  public int RivalsToDisable;
  public int CutscenePhase = 1;
  public int Menu = 1;
  public float Alpha;
  public float Speed;
  public bool Cutscene;
  public bool Fail;
  public bool Show;
  public UILabel[] BulletLabel;
  public UITexture[] Bullet;
  public AudioClip BulletSFX;
  public int Selected = 1;
  public int Limit = 4;
  public GameObject ConfirmationWindow;
  public GameObject ResultWindow;
  public Transform CrosshairGraphic;
  public Transform Crosshair;
  public UITexture[] RivalPortraits;
  public UILabel[] RivalNameLabels;
  public UILabel ConfirmationLabel;
  public UILabel ResultLabel;
  public Vector3 TargetPosition;
  public Vector3 WobblePosition;
  public Texture BlankPortrait;
  public string[] RivalNames;
  public int TargetSelected = 1;
  public int Column = 1;
  public int Row = 1;
  public int[] Costs;
  public GameObject ItemConfirmationWindow;
  public UILabel ItemConfirmationLabel;
  public int ItemSelected = 1;
  public int ItemLimit = 5;
  public UILabel[] PriceLabel;
  public UISprite[] PriceBG;
  public UILabel[] ItemLabel;
  public UISprite[] ItemBG;
  public string[] ItemName;
  public int[] OriginalItemPrice;
  public int[] ItemPrice;
  public GameObject RansomConfirmationWindow;
  public UILabel RansomConfirmationLabel;
  public UITexture[] RansomPortrait;
  public UILabel PrisonerLabel;
  public int[] KidnapTargets;
  public int[] PrisonerList;
  public int[] Ransom;
  public int Prisoners;
  public int Payout;
  public AudioClip[] Greeting;
  public AudioClip AssassinationPurchase;
  public AudioClip OpenAssassinationMenu;
  public AudioClip ContrabandPurchase;
  public AudioClip OpenContrabandMenu;
  public AudioClip Confirmation;
  public AudioClip BackOut;
  public AudioClip Exit;
  public int[] RansomIDs;

  private void Start()
  {
    this.UpdateMoneyLabel();
    this.RansomConfirmationWindow.SetActive(false);
    this.ConfirmationWindow.SetActive(false);
    this.ResultWindow.SetActive(false);
    this.AssassinationMenu.alpha = 0.0f;
    this.ContrabandMenu.alpha = 0.0f;
    this.KidnappingMenu.alpha = 0.0f;
    this.ServicesMenu.alpha = 1f;
    this.UpdateRansomPortraits();
    this.UpdateCrosshair();
    this.UpdateBullet();
    this.UpdateItem();
    int index1 = 1;
    WWW www1 = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_1.png");
    for (; index1 < 11; ++index1)
    {
      WWW www2 = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + (index1 + 10).ToString() + ".png");
      this.RivalPortraits[index1].mainTexture = (Texture) www2.texture;
      if (StudentGlobals.GetStudentDead(10 + index1) || StudentGlobals.GetStudentKidnapped(10 + index1) || StudentGlobals.GetStudentArrested(10 + index1))
        this.RivalPortraits[index1].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.RivalNameLabels[index1].text = this.RivalNames[index1];
      this.RivalPortraits[index1].transform.parent.localEulerAngles = new Vector3(0.0f, 0.0f, Random.Range(-5f, 5f));
    }
    this.RansomPortrait[30].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_30.png").texture;
    this.RansomPortrait[35].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_35.png").texture;
    this.RansomPortrait[40].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_40.png").texture;
    this.RansomPortrait[45].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_45.png").texture;
    this.RansomPortrait[50].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_50.png").texture;
    this.RansomPortrait[55].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_55.png").texture;
    this.RansomPortrait[60].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_60.png").texture;
    this.RansomPortrait[65].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_65.png").texture;
    this.RansomPortrait[70].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_70.png").texture;
    this.RansomPortrait[75].mainTexture = (Texture) new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_75.png").texture;
    for (int index2 = DateGlobals.Week + 1; index2 < 11; ++index2)
    {
      this.RivalPortraits[index2].color = new Color(0.5f, 0.5f, 0.5f, 1f);
      this.RivalPortraits[index2].mainTexture = this.BlankPortrait;
      this.RivalNameLabels[index2].text = "?????";
    }
    this.Panel.alpha = 0.0f;
    this.Alpha = 0.0f;
    for (int index3 = 1; index3 < this.Scales.Length; ++index3)
      this.Scales[index3].material.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
    this.Background.material.color = new Color(1f, 0.0f, 0.0f, 0.0f);
    if (GameGlobals.YakuzaPhase == 0 || !HomeGlobals.Night || StudentGlobals.GetStudentDead(79))
    {
      this.gameObject.SetActive(false);
      this.ButtonPrompt.alpha = 0.0f;
      if (StudentGlobals.GetStudentDead(79))
        this.Yakuza.gameObject.SetActive(false);
    }
    this.CountPrisoners();
    this.PrisonerLabel.text = this.Prisoners != 0 ? (this.Prisoners != 1 ? "Some of these girls are currently in your basement." : "One of these girls is currently in your basement.") : "Come back after kidnapping one of these girls.";
    this.OriginalItemPrice[3] += DateGlobals.Week * 100;
    this.OriginalItemPrice[5] += DateGlobals.Week * 100;
    this.ItemPrice[3] += DateGlobals.Week * 100;
    this.ItemPrice[5] += DateGlobals.Week * 100;
  }

  private void Update()
  {
    if (this.Show)
    {
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
      this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
      for (int index = 1; index < this.Scales.Length; ++index)
        this.Scales[index].material.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
      this.Background.material.color = new Color(1f, 0.0f, 0.0f, this.Alpha * 0.25f);
      if (this.Menu == 1)
      {
        this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 1f, Time.deltaTime * 10f);
        this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0.0f, Time.deltaTime * 10f);
        if ((double) this.ServicesMenu.alpha == 1.0)
        {
          if (this.InputManager.TappedDown)
          {
            ++this.Selected;
            this.UpdateBullet();
          }
          else if (this.InputManager.TappedUp)
          {
            --this.Selected;
            this.UpdateBullet();
          }
          if (Input.GetButtonDown("A"))
          {
            if (this.Selected == 1)
            {
              if (!GameGlobals.IntroducedAbduction)
              {
                GameGlobals.IntroducedAbduction = true;
                GameGlobals.YakuzaPhase = 6;
                this.CutscenePhase = 24;
                this.StartCutscene();
                this.Show = false;
              }
              else
              {
                AudioSource.PlayClipAtPoint(this.OpenAssassinationMenu, this.Yandere.MainCamera.transform.position);
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Abduct";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.Label[4].text = "Change Selection";
                this.PromptBar.Label[5].text = "Change Selection";
                this.PromptBar.UpdateButtons();
                this.Menu = 2;
              }
            }
            else if (this.Selected == 2)
            {
              AudioSource.PlayClipAtPoint(this.OpenContrabandMenu, this.Yandere.MainCamera.transform.position);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Purchase";
              this.PromptBar.Label[1].text = "Back";
              this.PromptBar.Label[5].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.Menu = 3;
              this.UpdateItem();
            }
            else if (this.Selected == 3)
            {
              if (!GameGlobals.IntroducedRansom)
              {
                GameGlobals.IntroducedRansom = true;
                GameGlobals.YakuzaPhase = 8;
                this.CutscenePhase = 33;
                this.StartCutscene();
                this.Show = false;
              }
              else
              {
                this.PromptBar.ClearButtons();
                if (this.Prisoners > 0)
                  this.PromptBar.Label[0].text = "Sell";
                this.PromptBar.Label[1].text = "Back";
                this.PromptBar.UpdateButtons();
                this.Menu = 4;
              }
            }
            else if (this.Selected == 4)
            {
              AudioSource.PlayClipAtPoint(this.Exit, this.Yandere.MainCamera.transform.position);
              this.Quit();
            }
          }
          else if (Input.GetButtonDown("B"))
          {
            AudioSource.PlayClipAtPoint(this.Exit, this.Yandere.MainCamera.transform.position);
            this.Quit();
          }
        }
      }
      else if (this.Menu == 2)
      {
        this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 1f, Time.deltaTime * 10f);
        if ((double) this.AssassinationMenu.alpha == 1.0)
        {
          if (!this.ConfirmationWindow.activeInHierarchy && !this.ResultWindow.activeInHierarchy)
          {
            if (this.InputManager.TappedDown || this.InputManager.TappedUp)
            {
              ++this.Row;
              this.UpdateCrosshair();
            }
            if (this.InputManager.TappedRight)
            {
              ++this.Column;
              this.UpdateCrosshair();
            }
            else if (this.InputManager.TappedLeft)
            {
              --this.Column;
              this.UpdateCrosshair();
            }
            if (Input.GetButtonDown("A"))
            {
              if (this.RivalPortraits[this.TargetSelected].color == new Color(1f, 1f, 1f, 1f))
              {
                AudioSource.PlayClipAtPoint(this.Confirmation, this.Yandere.MainCamera.transform.position);
                this.ConfirmationWindow.SetActive(true);
                this.ConfirmationLabel.text = "Do you want " + this.RivalNames[this.TargetSelected] + " to disappear forever? It will cost $" + this.Costs[this.TargetSelected].ToString() + ".";
                this.PromptBar.Show = false;
              }
            }
            else if (Input.GetButtonDown("B"))
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              GameGlobals.YakuzaPhase = 100;
              this.Menu = 1;
            }
          }
          else if (this.ConfirmationWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              if ((double) PlayerGlobals.Money > (double) this.Costs[this.TargetSelected])
              {
                AudioSource.PlayClipAtPoint(this.AssassinationPurchase, this.Yandere.MainCamera.transform.position);
                StudentGlobals.SetStudentKidnapped(this.TargetSelected + 10, true);
                StudentGlobals.SetStudentMissing(this.TargetSelected + 10, true);
                StudentGlobals.SetStudentKidnapped(this.TargetSelected + 10, true);
                StudentGlobals.SetStudentMissing(this.TargetSelected + 10, true);
                if (this.TargetSelected == DateGlobals.Week)
                {
                  GameGlobals.RivalEliminationID = 11;
                  GameGlobals.SpecificEliminationID = 12;
                }
                this.ResultLabel.text = "This girl will be abducted before school tomorrow.";
                this.RivalPortraits[this.TargetSelected].color = new Color(0.5f, 0.5f, 0.5f, 1f);
                PlayerGlobals.Money -= (float) this.Costs[this.TargetSelected];
                this.UpdateMoneyLabel();
                GameGlobals.AbductionTarget = this.TargetSelected + 10;
                GameGlobals.ShowAbduction = true;
              }
              else
              {
                this.ResultLabel.text = "You don't have enough money to pay for her abduction!";
                this.Fail = true;
              }
              this.ConfirmationWindow.SetActive(false);
              this.ResultWindow.SetActive(true);
            }
            else if (Input.GetButtonDown("B"))
            {
              AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.ConfirmationWindow.SetActive(false);
            }
          }
          else if (Input.GetButtonDown("A"))
          {
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Confirm";
            this.PromptBar.Label[1].text = "Exit";
            this.PromptBar.Label[4].text = "Change Selection";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.ResultWindow.SetActive(false);
            if (!this.Fail && GameGlobals.YakuzaPhase == 6)
            {
              GameGlobals.YakuzaPhase = 7;
              this.CutscenePhase = 28;
              this.StartCutscene();
              this.Show = false;
            }
            this.Fail = false;
          }
        }
      }
      else if (this.Menu == 3)
      {
        this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 1f, Time.deltaTime * 10f);
        this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0.0f, Time.deltaTime * 10f);
        if ((double) this.ContrabandMenu.alpha == 1.0)
        {
          if (!this.ItemConfirmationWindow.activeInHierarchy)
          {
            if (this.InputManager.TappedDown)
            {
              ++this.ItemSelected;
              this.UpdateItem();
            }
            else if (this.InputManager.TappedUp)
            {
              --this.ItemSelected;
              this.UpdateItem();
            }
            if (Input.GetButtonDown("A"))
            {
              if (GameGlobals.YakuzaPhase < 4)
              {
                if (this.ItemSelected == 1)
                  PlayerGlobals.BoughtLockpick = true;
                else if (this.ItemSelected == 2)
                  PlayerGlobals.FakeID = true;
                else if (this.ItemSelected == 3)
                  PlayerGlobals.BoughtNarcotics = true;
                else if (this.ItemSelected == 4)
                  PlayerGlobals.BoughtPoison = true;
                else if (this.ItemSelected == 5)
                  PlayerGlobals.BoughtExplosive = true;
                GameGlobals.YakuzaPhase = 4;
                this.CutscenePhase = 12;
                this.StartCutscene();
                this.Show = false;
              }
              else if ((double) this.ItemBG[this.ItemSelected].alpha == 1.0)
              {
                AudioSource.PlayClipAtPoint(this.Confirmation, this.Yandere.MainCamera.transform.position);
                this.ItemConfirmationLabel.text = "Would you like to purchase " + this.ItemName[this.ItemSelected] + " for $" + this.ItemPrice[this.ItemSelected].ToString() + "?";
                this.ItemConfirmationWindow.SetActive(true);
                this.PromptBar.Show = false;
              }
            }
            else if (Input.GetButtonDown("B"))
            {
              if (GameGlobals.YakuzaPhase < 4)
              {
                GameGlobals.YakuzaPhase = 2;
                this.CutscenePhase = 8;
                this.StartCutscene();
                this.Show = false;
              }
              else
              {
                this.PromptBar.ClearButtons();
                this.PromptBar.Label[0].text = "Confirm";
                this.PromptBar.Label[1].text = "Exit";
                this.PromptBar.Label[4].text = "Change Selection";
                this.PromptBar.UpdateButtons();
                this.PromptBar.Show = true;
                this.Menu = 1;
              }
            }
          }
          else if (Input.GetButtonDown("A"))
          {
            AudioSource.PlayClipAtPoint(this.ContrabandPurchase, this.Yandere.MainCamera.transform.position);
            if (this.ItemSelected == 1)
              PlayerGlobals.BoughtLockpick = true;
            else if (this.ItemSelected == 2)
              PlayerGlobals.FakeID = true;
            else if (this.ItemSelected == 3)
              PlayerGlobals.BoughtNarcotics = true;
            else if (this.ItemSelected == 4)
              PlayerGlobals.BoughtPoison = true;
            else if (this.ItemSelected == 5)
              PlayerGlobals.BoughtExplosive = true;
            PlayerGlobals.Money -= (float) this.ItemPrice[this.ItemSelected];
            this.UpdateMoneyLabel();
            this.UpdateItem();
            this.ItemConfirmationWindow.SetActive(false);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Purchase";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[5].text = "Change Selection";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
          }
          else if (Input.GetButtonDown("B"))
          {
            AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
            this.ItemConfirmationWindow.SetActive(false);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Purchase";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.Label[5].text = "Change Selection";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
          }
        }
      }
      else if (this.Menu == 4)
      {
        this.ServicesMenu.alpha = Mathf.MoveTowards(this.ServicesMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.ContrabandMenu.alpha = Mathf.MoveTowards(this.ContrabandMenu.alpha, 0.0f, Time.deltaTime * 10f);
        this.KidnappingMenu.alpha = Mathf.MoveTowards(this.KidnappingMenu.alpha, 1f, Time.deltaTime * 10f);
        this.AssassinationMenu.alpha = Mathf.MoveTowards(this.AssassinationMenu.alpha, 0.0f, Time.deltaTime * 10f);
        if ((double) this.KidnappingMenu.alpha == 1.0)
        {
          if (!this.RansomConfirmationWindow.activeInHierarchy)
          {
            if (Input.GetButtonDown("A"))
            {
              if (this.Prisoners > 0)
              {
                this.RansomConfirmationWindow.SetActive(true);
                this.RansomConfirmationLabel.text = this.Prisoners != 1 ? "Give some kidnapped prisoners to the yakuza in exchange for $" + this.Payout.ToString() + "?" : "Give a kidnapped prisoner to the yakuza in exchange for $" + this.Payout.ToString() + "?";
                this.PromptBar.Show = false;
              }
            }
            else if (Input.GetButtonDown("B"))
            {
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Menu = 1;
            }
          }
          else if (Input.GetButtonDown("A"))
          {
            AudioSource.PlayClipAtPoint(this.ContrabandPurchase, this.Yandere.MainCamera.transform.position);
            for (; this.Prisoners > 0; --this.Prisoners)
            {
              StudentGlobals.SetStudentKidnapped(this.PrisonerList[this.Prisoners], false);
              StudentGlobals.SetStudentMissing(this.PrisonerList[this.Prisoners], false);
              StudentGlobals.SetStudentRansomed(this.PrisonerList[this.Prisoners], true);
              StudentGlobals.SetStudentBroken(this.PrisonerList[this.Prisoners], true);
            }
            PlayerGlobals.Money += (float) this.Payout;
            this.UpdateMoneyLabel();
            if ((double) PlayerGlobals.Money > 1000.0)
              PlayerPrefs.SetInt("RichGirl", 1);
            this.DeprisonStudents();
            this.CountPrisoners();
            this.UpdateRansomPortraits();
            this.RansomConfirmationWindow.SetActive(false);
            this.PrisonerLabel.text = "Come back after kidnapping one of these girls.";
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
          }
          else if (Input.GetButtonDown("B"))
          {
            AudioSource.PlayClipAtPoint(this.BackOut, this.Yandere.MainCamera.transform.position);
            this.PromptBar.ClearButtons();
            this.PromptBar.Label[0].text = "Sell";
            this.PromptBar.Label[1].text = "Back";
            this.PromptBar.UpdateButtons();
            this.PromptBar.Show = true;
            this.RansomConfirmationWindow.SetActive(false);
          }
        }
      }
      this.BulletLabel[this.Selected].transform.parent.localScale = Vector3.Lerp(this.BulletLabel[this.Selected].transform.parent.localScale, new Vector3(1.05f, 1.05f, 1.05f), Time.deltaTime * 10f);
      for (int index = 1; index < this.Bullet.Length; ++index)
      {
        if (index != this.Selected)
          this.BulletLabel[index].transform.parent.localScale = Vector3.Lerp(this.BulletLabel[index].transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      }
      this.Crosshair.localPosition = Vector3.Lerp(this.Crosshair.localPosition, this.TargetPosition, Time.deltaTime * 10f);
      if (this.CrosshairGraphic.localPosition != this.WobblePosition)
      {
        this.CrosshairGraphic.localPosition = Vector3.MoveTowards(this.CrosshairGraphic.localPosition, this.WobblePosition, Time.deltaTime * 50f);
        if (!(this.CrosshairGraphic.localPosition == this.WobblePosition))
          return;
        this.WobblePosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0.0f);
      }
      else
        this.WobblePosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0.0f);
    }
    else
    {
      this.Jukebox.volume = this.Cutscene ? Mathf.MoveTowards(this.Jukebox.volume, 0.1f, Time.deltaTime) : Mathf.MoveTowards(this.Jukebox.volume, 0.0f, Time.deltaTime);
      this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0.0f, Time.deltaTime);
      this.Alpha = Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime);
      for (int index = 1; index < this.Scales.Length; ++index)
        this.Scales[index].material.color = new Color(1f, 0.0f, 0.0f, this.Alpha);
      this.Background.material.color = new Color(1f, 0.0f, 0.0f, this.Alpha * 0.25f);
      if (!this.Cutscene)
      {
        if ((double) Vector3.Distance(this.Yandere.transform.position, this.Yakuza.position) < 2.0)
        {
          this.ButtonPrompt.alpha = Mathf.MoveTowards(this.ButtonPrompt.alpha, 1f, Time.deltaTime * 2f);
          if (!Input.GetButtonDown("A") || (double) this.Alpha != 0.0)
            return;
          switch (GameGlobals.YakuzaPhase)
          {
            case 1:
              this.CutscenePhase = 1;
              this.StartCutscene();
              break;
            case 3:
              this.CutscenePhase = 10;
              this.StartCutscene();
              break;
            case 5:
              this.CutscenePhase = 16;
              this.StartCutscene();
              break;
            default:
              AudioSource.PlayClipAtPoint(this.Greeting[Random.Range(1, 4)], this.Yandere.MainCamera.transform.position);
              this.PromptBar.ClearButtons();
              this.PromptBar.Label[0].text = "Confirm";
              this.PromptBar.Label[1].text = "Exit";
              this.PromptBar.Label[4].text = "Change Selection";
              this.PromptBar.UpdateButtons();
              this.PromptBar.Show = true;
              this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
              this.Yandere.RPGCamera.enabled = false;
              this.Yandere.CanMove = false;
              this.Jukebox.volume = 1f;
              this.Jukebox.Play();
              this.TimeDayPanel.alpha = 0.0f;
              this.Show = true;
              break;
          }
        }
        else
          this.ButtonPrompt.alpha = Mathf.MoveTowards(this.ButtonPrompt.alpha, 0.0f, Time.deltaTime * 2f);
      }
      else
      {
        if (!this.Jukebox.isPlaying)
          this.Jukebox.Play();
        this.Speed += Time.deltaTime;
        this.Yandere.MainCamera.transform.position = Vector3.Lerp(this.Yandere.MainCamera.transform.position, new Vector3(-2.25f, 1.5f, -5.5f), (float) ((double) Time.deltaTime * (double) this.Speed * 0.0099999997764825821));
        if (this.Dialogue.isPlaying && !Input.GetButtonDown("A"))
          return;
        ++this.CutscenePhase;
        switch (GameGlobals.YakuzaPhase)
        {
          case 1:
            if (this.CutscenePhase < 8)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            this.SummonContrabandMenu();
            break;
          case 2:
            if (this.CutscenePhase < 10)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            GameGlobals.YakuzaPhase = 3;
            this.Quit();
            break;
          case 3:
            if (this.CutscenePhase < 12)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            this.SummonContrabandMenu();
            break;
          case 4:
            if (this.CutscenePhase < 16)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            GameGlobals.YakuzaPhase = 5;
            this.Quit();
            break;
          case 5:
            if (this.CutscenePhase < 24)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            GameGlobals.YakuzaPhase = 100;
            this.SummonServicesMenu();
            break;
          case 6:
            if (this.CutscenePhase < 28)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            this.SummonAssassinationMenu();
            break;
          case 7:
            if (this.CutscenePhase < 33)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            GameGlobals.YakuzaPhase = 100;
            this.Quit();
            break;
          case 8:
            if (this.CutscenePhase < 41)
            {
              this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
              this.Dialogue.Play();
              this.Subtitle.text = this.DialogueText[this.CutscenePhase];
              break;
            }
            GameGlobals.YakuzaPhase = 100;
            this.SummonKidnappingMenu();
            break;
        }
      }
    }
  }

  private void UpdateBullet()
  {
    if (this.Selected > this.Limit)
      this.Selected = 1;
    else if (this.Selected < 1)
      this.Selected = this.Limit;
    for (int index = 1; index < this.Bullet.Length; ++index)
    {
      this.BulletLabel[index].color = new Color(1f, 1f, 1f, 1f);
      this.Bullet[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    this.BulletLabel[this.Selected].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.Bullet[this.Selected].color = new Color(1f, 1f, 1f, 1f);
    if (!this.Show)
      return;
    AudioSource.PlayClipAtPoint(this.BulletSFX, Camera.main.transform.position);
  }

  private void UpdateCrosshair()
  {
    if (this.Row > 2)
      this.Row = 1;
    else if (this.Row < 1)
      this.Row = 2;
    if (this.Column > 5)
      this.Column = 1;
    else if (this.Column < 1)
      this.Column = 5;
    this.TargetPosition = new Vector3((float) (500 * this.Column - 1500), (float) (340 - (this.Row - 1) * 600), 0.0f);
    this.TargetSelected = this.Column + (this.Row - 1) * 5;
  }

  private void UpdateItem()
  {
    if (this.ItemSelected > this.ItemLimit)
      this.ItemSelected = 1;
    else if (this.ItemSelected < 1)
      this.ItemSelected = this.ItemLimit;
    for (int index = 1; index < this.ItemBG.Length; ++index)
    {
      this.ItemLabel[index].color = new Color(1f, 1f, 1f, 1f);
      this.ItemBG[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
      this.PriceLabel[index].color = new Color(1f, 1f, 1f, 1f);
      this.PriceBG[index].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    }
    this.ItemLabel[this.ItemSelected].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.ItemBG[this.ItemSelected].color = new Color(1f, 1f, 1f, 1f);
    this.PriceLabel[this.ItemSelected].color = new Color(0.0f, 0.0f, 0.0f, 1f);
    this.PriceBG[this.ItemSelected].color = new Color(1f, 1f, 1f, 1f);
    if (PlayerGlobals.BoughtLockpick)
    {
      this.ItemLabel[1].alpha = 0.5f;
      this.ItemBG[1].alpha = 0.5f;
      this.PriceLabel[1].alpha = 0.5f;
      this.PriceBG[1].alpha = 0.5f;
    }
    if (PlayerGlobals.FakeID)
    {
      this.ItemLabel[2].alpha = 0.5f;
      this.ItemBG[2].alpha = 0.5f;
      this.PriceLabel[2].alpha = 0.5f;
      this.PriceBG[2].alpha = 0.5f;
    }
    if (PlayerGlobals.BoughtNarcotics)
    {
      this.ItemLabel[3].alpha = 0.5f;
      this.ItemBG[3].alpha = 0.5f;
      this.PriceLabel[3].alpha = 0.5f;
      this.PriceBG[3].alpha = 0.5f;
    }
    if (PlayerGlobals.BoughtPoison)
    {
      this.ItemLabel[4].alpha = 0.5f;
      this.ItemBG[4].alpha = 0.5f;
      this.PriceLabel[4].alpha = 0.5f;
      this.PriceBG[4].alpha = 0.5f;
    }
    if (PlayerGlobals.BoughtExplosive)
    {
      this.ItemLabel[5].alpha = 0.5f;
      this.ItemBG[5].alpha = 0.5f;
      this.PriceLabel[5].alpha = 0.5f;
      this.PriceBG[5].alpha = 0.5f;
    }
    for (int index = 1; index < this.ItemBG.Length; ++index)
    {
      if (GameGlobals.YakuzaPhase < 4)
      {
        this.ItemPrice[index] = 0;
        this.PriceLabel[index].text = "FREE";
      }
      else
      {
        this.ItemPrice[index] = this.OriginalItemPrice[index];
        this.PriceLabel[index].text = "$" + this.ItemPrice[index].ToString();
      }
      if ((double) PlayerGlobals.Money < (double) this.ItemPrice[index])
      {
        this.ItemLabel[index].alpha = 0.5f;
        this.ItemBG[index].alpha = 0.5f;
        this.PriceLabel[index].alpha = 0.5f;
        this.PriceBG[index].alpha = 0.5f;
      }
    }
  }

  private void UpdateRansomPortraits()
  {
    for (int index = 1; index < this.RansomIDs.Length; ++index)
    {
      if (StudentGlobals.GetStudentRansomed(this.RansomIDs[index]))
        this.RansomPortrait[this.RansomIDs[index]].color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
  }

  private void Quit()
  {
    this.Yandere.RPGCamera.enabled = true;
    this.Yandere.CanMove = true;
    this.TimeDayPanel.alpha = 1f;
    this.Subtitle.text = "";
    this.Cutscene = false;
    this.Show = false;
    this.Menu = 1;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.HomeClock.UpdateMoneyLabel();
  }

  private void StartCutscene()
  {
    this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
    this.Yandere.RPGCamera.enabled = false;
    this.Yandere.CanMove = false;
    this.Yandere.MainCamera.transform.position = new Vector3(-2.25f, 0.1f, -5.5f);
    this.Yandere.MainCamera.transform.eulerAngles = new Vector3(0.0f, 30f, 0.0f);
    this.Yandere.transform.position = new Vector3(-2f, 0.0f, -4f);
    this.Yandere.transform.eulerAngles = new Vector3(0.0f, 150f, 0.0f);
    this.ButtonPrompt.alpha = 0.0f;
    this.TimeDayPanel.alpha = 0.0f;
    this.Dialogue.clip = this.DialogueClip[this.CutscenePhase];
    this.Dialogue.Play();
    this.Subtitle.text = this.DialogueText[this.CutscenePhase];
    this.Cutscene = true;
    this.Speed = 0.0f;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
  }

  private void SummonContrabandMenu()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Purchase";
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.Label[5].text = "Change Selection";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.MoneyLabel.transform.parent.gameObject.SetActive(false);
    this.ContrabandMenu.alpha = 1f;
    this.ServicesMenu.alpha = 0.0f;
    this.Jukebox.volume = 1f;
    this.Jukebox.Play();
    this.Subtitle.text = "";
    this.Cutscene = false;
    this.Show = true;
    this.Menu = 3;
  }

  private void SummonAssassinationMenu()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Abduct";
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.Label[4].text = "Change Selection";
    this.PromptBar.Label[5].text = "Change Selection";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.MoneyLabel.transform.parent.gameObject.SetActive(true);
    this.AssassinationMenu.alpha = 1f;
    this.ServicesMenu.alpha = 0.0f;
    this.Jukebox.volume = 1f;
    this.Jukebox.Play();
    this.Subtitle.text = "";
    this.Cutscene = false;
    this.Show = true;
    this.Menu = 2;
  }

  private void SummonServicesMenu()
  {
    this.PromptBar.ClearButtons();
    this.PromptBar.Label[0].text = "Confirm";
    this.PromptBar.Label[1].text = "Exit";
    this.PromptBar.Label[4].text = "Change Selection";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.MoneyLabel.transform.parent.gameObject.SetActive(true);
    this.AssassinationMenu.alpha = 0.0f;
    this.ServicesMenu.alpha = 1f;
    this.Jukebox.volume = 1f;
    this.Jukebox.Play();
    this.Subtitle.text = "";
    this.Cutscene = false;
    this.Show = true;
    this.Menu = 1;
  }

  private void SummonKidnappingMenu()
  {
    this.PromptBar.ClearButtons();
    if (this.Prisoners > 0)
      this.PromptBar.Label[0].text = "Sell";
    this.PromptBar.Label[1].text = "Back";
    this.PromptBar.UpdateButtons();
    this.PromptBar.Show = true;
    this.MoneyLabel.transform.parent.gameObject.SetActive(true);
    this.AssassinationMenu.alpha = 0.0f;
    this.ServicesMenu.alpha = 1f;
    this.Jukebox.volume = 1f;
    this.Jukebox.Play();
    this.Subtitle.text = "";
    this.Cutscene = false;
    this.Show = true;
    this.Menu = 4;
  }

  private void UpdateMoneyLabel() => this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");

  private void CountPrisoners()
  {
    if (StudentGlobals.Prisoners == 0)
    {
      this.Prisoners = 0;
    }
    else
    {
      for (int index = 1; index < 11; ++index)
      {
        if (StudentGlobals.Prisoner1 == this.KidnapTargets[index] || StudentGlobals.Prisoner2 == this.KidnapTargets[index] || StudentGlobals.Prisoner3 == this.KidnapTargets[index] || StudentGlobals.Prisoner4 == this.KidnapTargets[index] || StudentGlobals.Prisoner5 == this.KidnapTargets[index] || StudentGlobals.Prisoner6 == this.KidnapTargets[index] || StudentGlobals.Prisoner7 == this.KidnapTargets[index] || StudentGlobals.Prisoner8 == this.KidnapTargets[index] || StudentGlobals.Prisoner9 == this.KidnapTargets[index] || StudentGlobals.Prisoner10 == this.KidnapTargets[index])
        {
          this.Payout += this.Ransom[this.KidnapTargets[index]];
          ++this.Prisoners;
          Debug.Log((object) ("We have counted " + this.Prisoners.ToString() + " prisoners."));
          this.PrisonerList[this.Prisoners] = this.KidnapTargets[index];
        }
      }
    }
  }

  private void DeprisonStudents()
  {
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner1))
    {
      StudentGlobals.Prisoner1 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner2))
    {
      StudentGlobals.Prisoner2 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner3))
    {
      StudentGlobals.Prisoner3 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner4))
    {
      StudentGlobals.Prisoner4 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner5))
    {
      StudentGlobals.Prisoner5 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner6))
    {
      StudentGlobals.Prisoner6 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner7))
    {
      StudentGlobals.Prisoner7 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner8))
    {
      StudentGlobals.Prisoner8 = 0;
      --StudentGlobals.Prisoners;
    }
    if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner9))
    {
      StudentGlobals.Prisoner9 = 0;
      --StudentGlobals.Prisoners;
    }
    if (!StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner10))
      return;
    StudentGlobals.Prisoner10 = 0;
    --StudentGlobals.Prisoners;
  }
}
