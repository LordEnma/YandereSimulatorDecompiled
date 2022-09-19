// Decompiled with JetBrains decompiler
// Type: StreetShopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Globalization;
using UnityEngine;

public class StreetShopScript : MonoBehaviour
{
  public StreetShopInterfaceScript StreetShopInterface;
  public StreetManagerScript StreetManager;
  public InputDeviceScript InputDevice;
  public StalkerYandereScript Yandere;
  public PromptBarScript PromptBar;
  public HomeClockScript HomeClock;
  public GameObject BinocularOverlay;
  public Renderer BinocularRenderer;
  public Camera BinocularCamera;
  public AudioSource MyAudio;
  public AudioClip EightiesTheme;
  public AudioClip StoreTheme;
  public AudioClip InsertCoin;
  public AudioClip Fail;
  public UILabel MyLabel;
  public Texture[] ShopkeeperPortraits;
  public Texture[] EightiesPortraits;
  public Texture WelcomePortrait;
  public Texture[] IdlePortrait;
  public Texture ThanksPortrait;
  public Texture EightiesWelcomePortrait;
  public Texture[] EightiesIdlePortrait;
  public Texture EightiesThanksPortrait;
  public Texture EightiesWelcomePortraitAlt;
  public Texture[] EightiesIdlePortraitAlt;
  public Texture EightiesThanksPortraitAlt;
  public string[] ShopkeeperSpeeches;
  public string[] EightiesSpeeches;
  public bool[] AdultProducts;
  public string[] Descs;
  public string[] Products;
  public float[] Costs;
  public float RotationX;
  public float RotationY;
  public float Alpha;
  public float Timer;
  public float Zoom;
  public int ShopkeeperPosition = 500;
  public int Limit;
  public bool Binoculars;
  public bool MaidCafe;
  public bool Exit;
  public string StoreName;
  public ShopType StoreType;

  private void Start()
  {
    this.MyLabel.color = new Color(1f, 1f, 1f, 0.0f);
    if (GameGlobals.Eighties)
    {
      this.StoreTheme = this.EightiesTheme;
      this.ShopkeeperPortraits = this.EightiesPortraits;
      this.ShopkeeperSpeeches = this.EightiesSpeeches;
      this.WelcomePortrait = this.EightiesWelcomePortrait;
      this.IdlePortrait = this.EightiesIdlePortrait;
      this.ThanksPortrait = this.EightiesThanksPortrait;
      if (this.StoreType == ShopType.Electronics)
      {
        this.Costs[1] = 999.99f;
        this.Costs[2] = 29.81f;
        this.Products[3] = "Remote-Controlled Toy Car";
        this.Costs[3] = 9.95f;
        this.Products[4] = "Tape Player With Headphones";
        this.Descs[4] = "No functionality in the demo.";
        this.Costs[4] = 34.97f;
        this.Descs[5] = "No functionality in the demo.";
        this.Costs[5] = 66.28f;
      }
      else if (this.StoreType == ShopType.Manga)
      {
        this.Products[1] = "Ahmya Volume 1";
        this.Products[2] = "Ahmya Volume 2";
        this.Products[3] = "Ahmya Volume 3";
        this.Products[4] = "Ahmya Volume 4";
        this.Products[5] = "Ahmya Volume 5";
        this.Products[6] = "Enchanting Petals Volume 1";
        this.Products[7] = "Enchanting Petals Volume 2";
        this.Products[8] = "Enchanting Petals Volume 3";
        this.Products[9] = "Enchanting Petals Volume 4";
        this.Products[10] = "Enchanting Petals Volume 5";
        this.AdultProducts[6] = false;
        this.AdultProducts[7] = false;
        this.AdultProducts[8] = false;
        this.AdultProducts[9] = false;
        this.AdultProducts[10] = false;
      }
      else if (this.StoreType == ShopType.Games)
      {
        this.Products[1] = "Yanvania III: Dracula-chan's Curse";
        this.Products[2] = "Sammy the Witch";
        this.Products[3] = "Super Kubz Land";
        this.Products[4] = "Scrub Tales";
        this.Products[5] = "Razztris";
        this.Costs[1] = 49.99f;
        this.Costs[2] = 49.99f;
        this.Costs[3] = 49.99f;
        this.Costs[4] = 49.99f;
        this.Costs[5] = 49.99f;
      }
      else if (this.StoreType == ShopType.Gift)
      {
        this.Products[2] = "City Pop Vinyl";
        this.Costs[2] = 6.99f;
        this.Products[6] = "Trendy Bracelet";
        this.Products[7] = "Trendy Hair Clip";
        this.Products[8] = "Trendy Necklace";
        this.Products[9] = "Trendy Ring";
      }
      else
      {
        if (this.StoreType != ShopType.Salon)
          return;
        this.ShopkeeperPosition = 580;
        if (!GameGlobals.MetBarber)
          return;
        this.EightiesBarber();
      }
    }
    else
    {
      if (this.StoreType != ShopType.Salon)
        return;
      this.StoreType = ShopType.Nonfunctional;
    }
  }

  private void Update()
  {
    this.Alpha = (double) Vector3.Distance(this.Yandere.transform.position, this.transform.position) >= 1.0 ? Mathf.MoveTowards(this.Alpha, 0.0f, Time.deltaTime * 10f) : Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 10f);
    this.MyLabel.color = new Color(1f, 0.75f, 1f, this.Alpha);
    if ((double) this.Alpha == 1.0 && Input.GetButtonDown("A"))
    {
      if (this.Exit)
      {
        this.StreetManager.FadeOut = true;
        this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
        this.Yandere.CanMove = false;
      }
      else if (this.MaidCafe)
      {
        this.StreetShopInterface.ShowMaid = true;
        this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
        this.Yandere.RPGCamera.enabled = false;
        this.Yandere.CanMove = false;
      }
      else if (!this.Binoculars)
      {
        if (!this.StreetShopInterface.Show)
        {
          this.StreetShopInterface.CurrentStore = this.StoreType;
          this.StreetShopInterface.Show = true;
          this.PromptBar.ClearButtons();
          this.PromptBar.Label[0].text = "Purchase";
          this.PromptBar.Label[1].text = "Exit";
          this.PromptBar.UpdateButtons();
          this.PromptBar.Show = true;
          this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
          this.Yandere.CanMove = false;
          this.UpdateShopInterface();
        }
      }
      else if ((double) PlayerGlobals.Money >= 0.25)
      {
        this.MyAudio.clip = this.InsertCoin;
        PlayerGlobals.Money -= 0.25f;
        this.HomeClock.UpdateMoneyLabel();
        this.BinocularCamera.gameObject.SetActive(true);
        this.BinocularRenderer.enabled = false;
        this.BinocularOverlay.SetActive(true);
        this.PromptBar.ClearButtons();
        this.PromptBar.Label[1].text = "Exit";
        this.PromptBar.UpdateButtons();
        this.PromptBar.Show = true;
        this.Yandere.MyAnimation.CrossFade(this.Yandere.IdleAnim);
        this.Yandere.transform.position = new Vector3(5f, 0.0f, 3f);
        this.Yandere.CanMove = false;
        this.MyAudio.Play();
      }
      else
        this.HomeClock.MoneyFail();
    }
    if (!this.Binoculars || !this.BinocularCamera.gameObject.activeInHierarchy)
      return;
    if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
    {
      this.RotationX -= Input.GetAxis("Mouse Y") * (this.BinocularCamera.fieldOfView / 60f);
      this.RotationY += Input.GetAxis("Mouse X") * (this.BinocularCamera.fieldOfView / 60f);
    }
    else
    {
      this.RotationX -= Input.GetAxis("Mouse Y") * (this.BinocularCamera.fieldOfView / 60f);
      this.RotationY += Input.GetAxis("Mouse X") * (this.BinocularCamera.fieldOfView / 60f);
    }
    this.BinocularCamera.transform.eulerAngles = new Vector3(this.RotationX, this.RotationY + 90f, 0.0f);
    if ((double) this.RotationX > 45.0)
      this.RotationX = 45f;
    if ((double) this.RotationX < -45.0)
      this.RotationX = -45f;
    if ((double) this.RotationY > 90.0)
      this.RotationY = 90f;
    if ((double) this.RotationY < -90.0)
      this.RotationY = -90f;
    this.Zoom -= Input.GetAxis("Mouse ScrollWheel") * 10f;
    this.Zoom -= Input.GetAxis("Vertical") * 0.1f;
    if ((double) this.Zoom > 60.0)
      this.Zoom = 60f;
    else if ((double) this.Zoom < 1.0)
      this.Zoom = 1f;
    this.BinocularCamera.fieldOfView = Mathf.Lerp(this.BinocularCamera.fieldOfView, this.Zoom, Time.deltaTime * 10f);
    this.StreetManager.CurrentlyActiveJukebox.volume = (float) ((double) this.BinocularCamera.fieldOfView / 60.0 * 0.5);
    if (!Input.GetButtonUp("B"))
      return;
    this.BinocularCamera.gameObject.SetActive(false);
    this.BinocularRenderer.enabled = true;
    this.BinocularOverlay.SetActive(false);
    this.RotationX = 0.0f;
    this.RotationY = 0.0f;
    this.Zoom = 60f;
    this.StreetManager.CurrentlyActiveJukebox.volume = 0.5f;
    this.PromptBar.ClearButtons();
    this.PromptBar.Show = false;
    this.Yandere.CanMove = true;
  }

  private void UpdateShopInterface()
  {
    if (this.Descs[1] != "")
    {
      this.StreetShopInterface.DescriptionBox.SetActive(true);
      this.StreetShopInterface.DescriptionLabel.text = this.Descs[1];
    }
    else
      this.StreetShopInterface.DescriptionBox.SetActive(false);
    this.Yandere.MainCamera.GetComponent<RPG_Camera>().enabled = false;
    if (this.Yandere.Eighties && this.StoreType == ShopType.Convenience)
    {
      if (UnityEngine.Random.Range(1, 3) == 1)
      {
        this.WelcomePortrait = this.EightiesWelcomePortrait;
        this.IdlePortrait = this.EightiesIdlePortrait;
        this.ThanksPortrait = this.EightiesThanksPortrait;
      }
      else
      {
        this.WelcomePortrait = this.EightiesWelcomePortraitAlt;
        this.IdlePortrait = this.EightiesIdlePortraitAlt;
        this.ThanksPortrait = this.EightiesThanksPortraitAlt;
      }
    }
    this.StreetShopInterface.StoreNameLabel.text = this.StoreName;
    this.StreetShopInterface.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", (IFormatProvider) NumberFormatInfo.InvariantInfo);
    this.StreetShopInterface.Shopkeeper.mainTexture = this.WelcomePortrait;
    this.StreetShopInterface.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[1];
    this.StreetShopInterface.IdlePortrait = this.IdlePortrait;
    this.StreetShopInterface.ThanksPortrait = this.ThanksPortrait;
    this.StreetShopInterface.ShopkeeperSpeeches = this.ShopkeeperSpeeches;
    this.StreetShopInterface.ShopkeeperPosition = this.ShopkeeperPosition;
    this.StreetShopInterface.AdultProducts = this.AdultProducts;
    this.StreetShopInterface.SpeechPhase = 0;
    this.StreetShopInterface.Costs = this.Costs;
    this.StreetShopInterface.Descs = this.Descs;
    this.StreetShopInterface.Limit = this.Limit;
    this.StreetShopInterface.Selected = 1;
    this.StreetShopInterface.Timer = 0.0f;
    this.StreetShopInterface.Jukebox.clip = this.StoreTheme;
    this.StreetShopInterface.Jukebox.Play();
    this.StreetShopInterface.UpdateHighlight();
    for (int index = 1; index < 11; ++index)
    {
      this.StreetShopInterface.ProductsLabel[index].text = this.Products[index];
      this.StreetShopInterface.PricesLabel[index].text = "$" + this.Costs[index].ToString();
      if (this.StreetShopInterface.PricesLabel[index].text == "$0")
        this.StreetShopInterface.PricesLabel[index].text = "";
    }
    this.StreetShopInterface.UpdateIcons();
    this.StreetShopInterface.UpdateFakeID();
  }

  public void EightiesBarber()
  {
    this.Products[1] = "The Benefits of Manga";
    this.Products[2] = "Cauterizing Wounds";
    this.Products[3] = "Hiding Bodies";
    this.Products[4] = "Distractions";
    this.Products[5] = "Notes in Lockers";
    this.Products[6] = "Student Personas";
    this.Products[7] = "Cleaning Weapons";
    this.Products[8] = "Emergency Showers";
    this.Products[9] = "Raincoat Advice";
    this.Products[10] = "School Atmosphere";
    for (int index = 1; index < 11; ++index)
      this.StreetShopInterface.ProductsLabel[index].text = this.Products[index];
  }
}
