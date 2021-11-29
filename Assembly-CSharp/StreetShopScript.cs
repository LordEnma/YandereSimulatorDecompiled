using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000448 RID: 1096
public class StreetShopScript : MonoBehaviour
{
	// Token: 0x06001D10 RID: 7440 RVA: 0x00159CC4 File Offset: 0x00157EC4
	private void Start()
	{
		this.MyLabel.color = new Color(1f, 1f, 1f, 0f);
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
				return;
			}
			if (this.StoreType == ShopType.Manga)
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
				return;
			}
			if (this.StoreType == ShopType.Games)
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
				return;
			}
			if (this.StoreType == ShopType.Gift)
			{
				this.Products[2] = "City Pop Vinyl";
				this.Costs[2] = 6.99f;
				this.Products[6] = "Trendy Bracelet";
				this.Products[7] = "Trendy Hair Clip";
				this.Products[8] = "Trendy Necklace";
				this.Products[9] = "Trendy Ring";
				return;
			}
			if (this.StoreType == ShopType.Salon)
			{
				this.ShopkeeperPosition = 580;
				if (GameGlobals.MetBarber)
				{
					this.EightiesBarber();
					return;
				}
			}
		}
		else if (this.StoreType == ShopType.Salon)
		{
			this.StoreType = ShopType.Nonfunctional;
		}
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x00159FA0 File Offset: 0x001581A0
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.transform.position, base.transform.position) < 1f)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 10f);
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 10f);
		}
		this.MyLabel.color = new Color(1f, 0.75f, 1f, this.Alpha);
		if (this.Alpha == 1f && Input.GetButtonDown("A"))
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
			else if (PlayerGlobals.Money >= 0.25f)
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
				this.Yandere.transform.position = new Vector3(5f, 0f, 3f);
				this.Yandere.CanMove = false;
				this.MyAudio.Play();
			}
			else
			{
				this.HomeClock.MoneyFail();
			}
		}
		if (this.Binoculars && this.BinocularCamera.gameObject.activeInHierarchy)
		{
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
			this.BinocularCamera.transform.eulerAngles = new Vector3(this.RotationX, this.RotationY + 90f, 0f);
			if (this.RotationX > 45f)
			{
				this.RotationX = 45f;
			}
			if (this.RotationX < -45f)
			{
				this.RotationX = -45f;
			}
			if (this.RotationY > 90f)
			{
				this.RotationY = 90f;
			}
			if (this.RotationY < -90f)
			{
				this.RotationY = -90f;
			}
			this.Zoom -= Input.GetAxis("Mouse ScrollWheel") * 10f;
			this.Zoom -= Input.GetAxis("Vertical") * 0.1f;
			if (this.Zoom > 60f)
			{
				this.Zoom = 60f;
			}
			else if (this.Zoom < 1f)
			{
				this.Zoom = 1f;
			}
			this.BinocularCamera.fieldOfView = Mathf.Lerp(this.BinocularCamera.fieldOfView, this.Zoom, Time.deltaTime * 10f);
			this.StreetManager.CurrentlyActiveJukebox.volume = this.BinocularCamera.fieldOfView / 60f * 0.5f;
			if (Input.GetButtonUp("B"))
			{
				this.BinocularCamera.gameObject.SetActive(false);
				this.BinocularRenderer.enabled = true;
				this.BinocularOverlay.SetActive(false);
				this.RotationX = 0f;
				this.RotationY = 0f;
				this.Zoom = 60f;
				this.StreetManager.CurrentlyActiveJukebox.volume = 0.5f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Yandere.CanMove = true;
			}
		}
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x0015A558 File Offset: 0x00158758
	private void UpdateShopInterface()
	{
		if (this.Descs[1] != "")
		{
			this.StreetShopInterface.DescriptionBox.SetActive(true);
			this.StreetShopInterface.DescriptionLabel.text = this.Descs[1];
		}
		else
		{
			this.StreetShopInterface.DescriptionBox.SetActive(false);
		}
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
		this.StreetShopInterface.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
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
		this.StreetShopInterface.Timer = 0f;
		this.StreetShopInterface.Jukebox.clip = this.StoreTheme;
		this.StreetShopInterface.Jukebox.Play();
		this.StreetShopInterface.UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			this.StreetShopInterface.ProductsLabel[i].text = this.Products[i];
			this.StreetShopInterface.PricesLabel[i].text = "$" + this.Costs[i].ToString();
			if (this.StreetShopInterface.PricesLabel[i].text == "$0")
			{
				this.StreetShopInterface.PricesLabel[i].text = "";
			}
		}
		this.StreetShopInterface.UpdateIcons();
	}

	// Token: 0x06001D13 RID: 7443 RVA: 0x0015A828 File Offset: 0x00158A28
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
		for (int i = 1; i < 11; i++)
		{
			this.StreetShopInterface.ProductsLabel[i].text = this.Products[i];
		}
	}

	// Token: 0x040034F1 RID: 13553
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x040034F2 RID: 13554
	public StreetManagerScript StreetManager;

	// Token: 0x040034F3 RID: 13555
	public InputDeviceScript InputDevice;

	// Token: 0x040034F4 RID: 13556
	public StalkerYandereScript Yandere;

	// Token: 0x040034F5 RID: 13557
	public PromptBarScript PromptBar;

	// Token: 0x040034F6 RID: 13558
	public HomeClockScript HomeClock;

	// Token: 0x040034F7 RID: 13559
	public GameObject BinocularOverlay;

	// Token: 0x040034F8 RID: 13560
	public Renderer BinocularRenderer;

	// Token: 0x040034F9 RID: 13561
	public Camera BinocularCamera;

	// Token: 0x040034FA RID: 13562
	public AudioSource MyAudio;

	// Token: 0x040034FB RID: 13563
	public AudioClip EightiesTheme;

	// Token: 0x040034FC RID: 13564
	public AudioClip StoreTheme;

	// Token: 0x040034FD RID: 13565
	public AudioClip InsertCoin;

	// Token: 0x040034FE RID: 13566
	public AudioClip Fail;

	// Token: 0x040034FF RID: 13567
	public UILabel MyLabel;

	// Token: 0x04003500 RID: 13568
	public Texture[] ShopkeeperPortraits;

	// Token: 0x04003501 RID: 13569
	public Texture[] EightiesPortraits;

	// Token: 0x04003502 RID: 13570
	public Texture WelcomePortrait;

	// Token: 0x04003503 RID: 13571
	public Texture[] IdlePortrait;

	// Token: 0x04003504 RID: 13572
	public Texture ThanksPortrait;

	// Token: 0x04003505 RID: 13573
	public Texture EightiesWelcomePortrait;

	// Token: 0x04003506 RID: 13574
	public Texture[] EightiesIdlePortrait;

	// Token: 0x04003507 RID: 13575
	public Texture EightiesThanksPortrait;

	// Token: 0x04003508 RID: 13576
	public Texture EightiesWelcomePortraitAlt;

	// Token: 0x04003509 RID: 13577
	public Texture[] EightiesIdlePortraitAlt;

	// Token: 0x0400350A RID: 13578
	public Texture EightiesThanksPortraitAlt;

	// Token: 0x0400350B RID: 13579
	public string[] ShopkeeperSpeeches;

	// Token: 0x0400350C RID: 13580
	public string[] EightiesSpeeches;

	// Token: 0x0400350D RID: 13581
	public bool[] AdultProducts;

	// Token: 0x0400350E RID: 13582
	public string[] Descs;

	// Token: 0x0400350F RID: 13583
	public string[] Products;

	// Token: 0x04003510 RID: 13584
	public float[] Costs;

	// Token: 0x04003511 RID: 13585
	public float RotationX;

	// Token: 0x04003512 RID: 13586
	public float RotationY;

	// Token: 0x04003513 RID: 13587
	public float Alpha;

	// Token: 0x04003514 RID: 13588
	public float Timer;

	// Token: 0x04003515 RID: 13589
	public float Zoom;

	// Token: 0x04003516 RID: 13590
	public int ShopkeeperPosition = 500;

	// Token: 0x04003517 RID: 13591
	public int Limit;

	// Token: 0x04003518 RID: 13592
	public bool Binoculars;

	// Token: 0x04003519 RID: 13593
	public bool MaidCafe;

	// Token: 0x0400351A RID: 13594
	public bool Exit;

	// Token: 0x0400351B RID: 13595
	public string StoreName;

	// Token: 0x0400351C RID: 13596
	public ShopType StoreType;
}
