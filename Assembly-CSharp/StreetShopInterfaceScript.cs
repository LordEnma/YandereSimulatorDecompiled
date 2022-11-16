// Decompiled with JetBrains decompiler
// Type: StreetShopInterfaceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.PostProcessing;

public class StreetShopInterfaceScript : MonoBehaviour
{
  public StreetManagerScript StreetManager;
  public InputManagerScript InputManager;
  public PostProcessingProfile Profile;
  public StalkerYandereScript Yandere;
  public PromptBarScript PromptBar;
  public UILabel SpeechBubbleLabel;
  public UILabel DescriptionLabel;
  public UILabel StoreNameLabel;
  public UILabel MoneyLabel;
  public Texture[] ShopkeeperPortraits;
  public string[] ShopkeeperSpeeches;
  public Texture[] IdlePortrait;
  public Texture ThanksPortrait;
  public UILabel[] ProductsLabel;
  public UILabel[] PricesLabel;
  public UISprite[] Icons;
  public bool[] AdultProducts;
  public string[] Descs;
  public float[] Costs;
  public UITexture Shopkeeper;
  public Transform SpeechBubbleParent;
  public Transform MaidWindow;
  public Transform Highlight;
  public Transform Interface;
  public GameObject DescriptionBox;
  public GameObject FakeIDBox;
  public AudioSource Jukebox;
  public AudioSource MyAudio;
  public int ShopkeeperPosition;
  public int SpeechPhase;
  public int Selected;
  public int Limit;
  public float TransitionTimer;
  public float BlurAmount;
  public float Speed;
  public float Timer;
  public bool TransitionToCreepyCutscene;
  public bool Patronized;
  public bool ShowMaid;
  public bool Show;
  public ShopType CurrentStore;
  public GameObject CreepyCutscene;
  public StreetShopScript Salon;
  public AudioClip Fail;
  public Texture SalonSurprise;
  public Texture SalonSinister;

  private void Start()
  {
    this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0.0f, 0.0f);
    this.Interface.localPosition = new Vector3(-815.5f, 0.0f, 0.0f);
    this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.UpdateFakeID();
  }

  private void Update()
  {
    if (this.Show)
    {
      if (!this.StreetManager.Mute)
        this.Jukebox.volume = Mathf.Lerp(this.Jukebox.volume, 1f, Time.deltaTime * 10f);
      if ((double) this.TransitionTimer < 5.0)
      {
        this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3((float) this.ShopkeeperPosition, 0.0f, 0.0f), Time.deltaTime * 10f);
      }
      else
      {
        this.Speed += Time.deltaTime;
        this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(0.0f, -535f, 0.0f), Time.deltaTime * this.Speed);
        this.Shopkeeper.transform.localScale = Vector3.Lerp(this.Shopkeeper.transform.localScale, new Vector3(2.256f, 2.256f, 2.256f), Time.deltaTime * this.Speed);
      }
      this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(100f, 0.0f, 0.0f), Time.deltaTime * 10f);
      this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0.0f, Time.deltaTime * 10f);
      if (this.TransitionToCreepyCutscene)
      {
        this.TransitionTimer += Time.deltaTime;
        if ((double) this.TransitionTimer > 9.0)
        {
          this.CreepyCutscene.SetActive(true);
          this.Jukebox.Stop();
        }
        else if ((double) this.TransitionTimer > 4.0)
          this.Shopkeeper.mainTexture = this.SalonSinister;
        else if ((double) this.TransitionTimer > 2.0)
          this.Shopkeeper.mainTexture = this.SalonSurprise;
      }
      else
      {
        if (Input.GetButtonUp("B"))
        {
          this.Yandere.RPGCamera.enabled = true;
          this.PromptBar.Show = false;
          this.Yandere.CanMove = true;
          this.Patronized = false;
          this.Show = false;
        }
        if ((double) this.Timer > 0.5 && Input.GetButtonUp("A") && this.Icons[this.Selected].spriteName != "Yes")
        {
          this.CheckStore();
          this.UpdateIcons();
        }
        if (this.InputManager.TappedDown)
        {
          ++this.Selected;
          if (this.Selected > this.Limit)
            this.Selected = 1;
          this.UpdateHighlight();
        }
        else if (this.InputManager.TappedUp)
        {
          --this.Selected;
          if (this.Selected < 1)
            this.Selected = this.Limit;
          this.UpdateHighlight();
        }
        this.Timer += Time.deltaTime;
        if ((double) this.Timer > 0.5)
          this.SpeechBubbleParent.localScale = Vector3.Lerp(this.SpeechBubbleParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (this.SpeechPhase == 0)
          ++this.SpeechPhase;
        else if (!this.Patronized && (double) this.Timer > 10.0)
        {
          if (this.SpeechPhase == 1)
          {
            this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[2];
            this.Shopkeeper.mainTexture = this.IdlePortrait[0];
            this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
            ++this.SpeechPhase;
          }
          else if (this.SpeechPhase == 2 && (double) this.Timer > 10.100000381469727)
          {
            this.Shopkeeper.mainTexture = this.IdlePortrait[UnityEngine.Random.Range(0, this.IdlePortrait.Length)];
            this.Timer = 10f;
          }
        }
      }
    }
    else
    {
      this.Jukebox.volume = Mathf.Lerp(this.Jukebox.volume, 0.0f, Time.deltaTime);
      this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(1604f, 0.0f, 0.0f), Time.deltaTime * 10f);
      this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(-815.5f, 0.0f, 0.0f), Time.deltaTime * 10f);
      if (this.ShowMaid)
      {
        this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0.0f, Time.deltaTime * 10f);
        this.MaidWindow.localScale = Vector3.Lerp(this.MaidWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
        if (Input.GetButtonDown("A"))
        {
          this.StreetManager.FadeOut = true;
          this.StreetManager.GoToCafe = true;
        }
        else if (Input.GetButtonDown("B"))
        {
          this.Yandere.RPGCamera.enabled = true;
          this.Yandere.CanMove = true;
          this.ShowMaid = false;
        }
      }
      else
      {
        this.BlurAmount = Mathf.Lerp(this.BlurAmount, 2f, Time.deltaTime * 10f);
        this.MaidWindow.localScale = Vector3.Lerp(this.MaidWindow.localScale, new Vector3(0.0f, 0.0f, 0.0f), Time.deltaTime * 10f);
      }
    }
    this.AdjustBlur();
  }

  private void AdjustBlur() => this.Profile.depthOfField.settings = this.Profile.depthOfField.settings with
  {
    focusDistance = this.BlurAmount
  };

  public void UpdateHighlight()
  {
    this.Highlight.localPosition = new Vector3(-50f, (float) (50 - 50 * this.Selected), 0.0f);
    if (!(this.Descs[this.Selected] != ""))
      return;
    this.DescriptionLabel.text = this.Descs[this.Selected];
  }

  public void CheckStore()
  {
    if (this.AdultProducts[this.Selected] && !PlayerGlobals.FakeID)
    {
      AudioSource.PlayClipAtPoint(this.Fail, this.transform.position);
      this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[3];
      this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      this.SpeechPhase = 0;
      this.Timer = 1f;
      this.Shopkeeper.mainTexture = this.IdlePortrait[0];
      this.Patronized = false;
    }
    else if ((double) PlayerGlobals.Money < (double) this.Costs[this.Selected])
    {
      this.StreetManager.Clock.MoneyFail();
      this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[4];
      this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
      this.SpeechPhase = 0;
      this.Timer = 1f;
      this.Shopkeeper.mainTexture = this.IdlePortrait[0];
      this.Patronized = false;
    }
    else
    {
      switch (this.CurrentStore)
      {
        case ShopType.Nonfunctional:
          this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
          this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
          this.SpeechPhase = 0;
          this.Timer = 1f;
          break;
        case ShopType.Manga:
          this.PurchaseEffect();
          switch (this.Selected)
          {
            case 1:
              CollectibleGlobals.SetMangaCollected(6, true);
              return;
            case 2:
              CollectibleGlobals.SetMangaCollected(7, true);
              return;
            case 3:
              CollectibleGlobals.SetMangaCollected(8, true);
              return;
            case 4:
              CollectibleGlobals.SetMangaCollected(9, true);
              return;
            case 5:
              CollectibleGlobals.SetMangaCollected(10, true);
              return;
            case 6:
              CollectibleGlobals.SetMangaCollected(1, true);
              return;
            case 7:
              CollectibleGlobals.SetMangaCollected(2, true);
              return;
            case 8:
              CollectibleGlobals.SetMangaCollected(3, true);
              return;
            case 9:
              CollectibleGlobals.SetMangaCollected(4, true);
              return;
            case 10:
              CollectibleGlobals.SetMangaCollected(5, true);
              return;
            default:
              return;
          }
        case ShopType.Salon:
          this.PurchaseEffect();
          CollectibleGlobals.SetAdvicePurchased(this.Selected, true);
          this.Timer = 1f;
          break;
        case ShopType.Gift:
          this.PurchaseEffect();
          if (this.Selected < 6)
            ++CollectibleGlobals.SenpaiGifts;
          else
            ++CollectibleGlobals.MatchmakingGifts;
          CollectibleGlobals.SetGiftPurchased(this.Selected, true);
          break;
        case ShopType.Convenience:
          switch (this.Selected)
          {
            case 1:
              this.PurchaseEffect();
              PlayerGlobals.SetCannotBringItem(6, false);
              return;
            case 2:
              this.PurchaseEffect();
              PlayerGlobals.SetCannotBringItem(5, false);
              return;
            case 3:
              this.PurchaseEffect();
              PlayerGlobals.SetCannotBringItem(7, false);
              return;
            case 4:
              this.PurchaseEffect();
              PlayerGlobals.SetCannotBringItem(4, false);
              return;
            case 5:
              this.PurchaseEffect();
              PlayerGlobals.BoughtSedative = true;
              PlayerGlobals.SetCannotBringItem(9, false);
              return;
            case 6:
              this.PurchaseEffect();
              ++PlayerGlobals.Meals;
              return;
            default:
              this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
              this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
              this.SpeechPhase = 0;
              this.Timer = 1f;
              return;
          }
        case ShopType.Electronics:
          this.PurchaseEffect();
          switch (this.Selected)
          {
            case 1:
              return;
            case 2:
              return;
            case 3:
              return;
            case 4:
              PlayerGlobals.Headset = true;
              return;
            case 5:
              PlayerGlobals.DirectionalMic = true;
              return;
            default:
              return;
          }
        case ShopType.Lingerie:
          this.PurchaseEffect();
          CollectibleGlobals.SetPantyPurchased(this.Selected, true);
          this.CountPanties();
          break;
      }
    }
  }

  public void PurchaseEffect()
  {
    this.Patronized = true;
    this.Shopkeeper.mainTexture = this.ThanksPortrait;
    this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[5];
    this.SpeechBubbleParent.localScale = new Vector3(0.0f, 0.0f, 0.0f);
    this.SpeechPhase = 0;
    this.Timer = 1f;
    PlayerGlobals.Money -= this.Costs[this.Selected];
    this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
    this.StreetManager.Clock.UpdateMoneyLabel();
    this.MyAudio.Play();
  }

  public void UpdateFakeID() => this.FakeIDBox.SetActive(PlayerGlobals.FakeID);

  public void UpdateIcons()
  {
    for (int index = 1; index < 11; ++index)
    {
      this.Icons[index].spriteName = "";
      this.Icons[index].gameObject.SetActive(false);
      this.ProductsLabel[index].color = new Color(1f, 1f, 1f, 1f);
    }
    for (int index = 1; index < 11; ++index)
    {
      if (this.AdultProducts[index])
        this.Icons[index].spriteName = "18+";
    }
    switch (this.CurrentStore)
    {
      case ShopType.Manga:
        if (CollectibleGlobals.GetMangaCollected(1))
        {
          this.Icons[6].spriteName = "Yes";
          this.PricesLabel[6].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(2))
        {
          this.Icons[7].spriteName = "Yes";
          this.PricesLabel[7].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(3))
        {
          this.Icons[8].spriteName = "Yes";
          this.PricesLabel[8].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(4))
        {
          this.Icons[9].spriteName = "Yes";
          this.PricesLabel[9].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(5))
        {
          this.Icons[10].spriteName = "Yes";
          this.PricesLabel[10].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(6))
        {
          this.Icons[1].spriteName = "Yes";
          this.PricesLabel[1].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(7))
        {
          this.Icons[2].spriteName = "Yes";
          this.PricesLabel[2].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(8))
        {
          this.Icons[3].spriteName = "Yes";
          this.PricesLabel[3].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(9))
        {
          this.Icons[4].spriteName = "Yes";
          this.PricesLabel[4].text = "Owned";
        }
        if (CollectibleGlobals.GetMangaCollected(10))
        {
          this.Icons[5].spriteName = "Yes";
          this.PricesLabel[5].text = "Owned";
          break;
        }
        break;
      case ShopType.Salon:
        for (int giftID = 1; giftID < 11; ++giftID)
        {
          if (CollectibleGlobals.GetAdvicePurchased(giftID))
          {
            this.Icons[giftID].spriteName = "Yes";
            this.PricesLabel[giftID].text = "Bought";
          }
        }
        break;
      case ShopType.Gift:
        for (int giftID = 1; giftID < 11; ++giftID)
        {
          if (CollectibleGlobals.GetGiftPurchased(giftID))
          {
            this.Icons[giftID].spriteName = "Yes";
            this.PricesLabel[giftID].text = "Owned";
          }
        }
        break;
      case ShopType.Convenience:
        if (!PlayerGlobals.GetCannotBringItem(6))
        {
          this.Icons[1].spriteName = "Yes";
          this.PricesLabel[1].text = "Owned";
        }
        if (!PlayerGlobals.GetCannotBringItem(5))
        {
          this.Icons[2].spriteName = "Yes";
          this.PricesLabel[2].text = "Owned";
        }
        if (!PlayerGlobals.GetCannotBringItem(7))
        {
          this.Icons[3].spriteName = "Yes";
          this.PricesLabel[3].text = "Owned";
        }
        if (!PlayerGlobals.GetCannotBringItem(4))
        {
          this.Icons[4].spriteName = "Yes";
          this.PricesLabel[4].text = "Owned";
        }
        if (PlayerGlobals.BoughtSedative)
        {
          this.Icons[5].spriteName = "Yes";
          this.PricesLabel[5].text = "Owned";
          break;
        }
        break;
      case ShopType.Lingerie:
        for (int giftID = 1; giftID < 11; ++giftID)
        {
          if (CollectibleGlobals.GetPantyPurchased(giftID))
          {
            this.Icons[giftID].spriteName = "Yes";
            this.PricesLabel[giftID].text = "Owned";
          }
        }
        break;
    }
    for (int index = 1; index < 11; ++index)
    {
      if (this.Icons[index].spriteName != "")
      {
        this.Icons[index].gameObject.SetActive(true);
        if (this.Icons[index].spriteName == "Yes")
          this.ProductsLabel[index].color = new Color(1f, 1f, 1f, 0.5f);
      }
    }
    if (this.CurrentStore != ShopType.Salon || !GameGlobals.Eighties || GameGlobals.MetBarber)
      return;
    this.TransitionToCreepyCutscene = true;
  }

  private void CountPanties()
  {
    int num = 1;
    for (int giftID = 1; giftID < 11; ++giftID)
    {
      if (CollectibleGlobals.GetPantyPurchased(giftID))
        ++num;
    }
    if (num != 10)
      return;
    if (!GameGlobals.Debug)
      PlayerPrefs.SetInt("PantyQueen", 1);
    if (GameGlobals.Debug)
      return;
    PlayerPrefs.SetInt("a", 1);
  }
}
