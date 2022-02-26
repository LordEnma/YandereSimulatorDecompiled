using System;
using System.Globalization;
using UnityEngine;

// Token: 0x0200044E RID: 1102
public class StreetShopScript : MonoBehaviour
{
	// Token: 0x06001D39 RID: 7481 RVA: 0x0015DF8C File Offset: 0x0015C18C
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

	// Token: 0x06001D3A RID: 7482 RVA: 0x0015E268 File Offset: 0x0015C468
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

	// Token: 0x06001D3B RID: 7483 RVA: 0x0015E820 File Offset: 0x0015CA20
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
		this.StreetShopInterface.UpdateFakeID();
	}

	// Token: 0x06001D3C RID: 7484 RVA: 0x0015EAF8 File Offset: 0x0015CCF8
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

	// Token: 0x0400355D RID: 13661
	public StreetShopInterfaceScript StreetShopInterface;

	// Token: 0x0400355E RID: 13662
	public StreetManagerScript StreetManager;

	// Token: 0x0400355F RID: 13663
	public InputDeviceScript InputDevice;

	// Token: 0x04003560 RID: 13664
	public StalkerYandereScript Yandere;

	// Token: 0x04003561 RID: 13665
	public PromptBarScript PromptBar;

	// Token: 0x04003562 RID: 13666
	public HomeClockScript HomeClock;

	// Token: 0x04003563 RID: 13667
	public GameObject BinocularOverlay;

	// Token: 0x04003564 RID: 13668
	public Renderer BinocularRenderer;

	// Token: 0x04003565 RID: 13669
	public Camera BinocularCamera;

	// Token: 0x04003566 RID: 13670
	public AudioSource MyAudio;

	// Token: 0x04003567 RID: 13671
	public AudioClip EightiesTheme;

	// Token: 0x04003568 RID: 13672
	public AudioClip StoreTheme;

	// Token: 0x04003569 RID: 13673
	public AudioClip InsertCoin;

	// Token: 0x0400356A RID: 13674
	public AudioClip Fail;

	// Token: 0x0400356B RID: 13675
	public UILabel MyLabel;

	// Token: 0x0400356C RID: 13676
	public Texture[] ShopkeeperPortraits;

	// Token: 0x0400356D RID: 13677
	public Texture[] EightiesPortraits;

	// Token: 0x0400356E RID: 13678
	public Texture WelcomePortrait;

	// Token: 0x0400356F RID: 13679
	public Texture[] IdlePortrait;

	// Token: 0x04003570 RID: 13680
	public Texture ThanksPortrait;

	// Token: 0x04003571 RID: 13681
	public Texture EightiesWelcomePortrait;

	// Token: 0x04003572 RID: 13682
	public Texture[] EightiesIdlePortrait;

	// Token: 0x04003573 RID: 13683
	public Texture EightiesThanksPortrait;

	// Token: 0x04003574 RID: 13684
	public Texture EightiesWelcomePortraitAlt;

	// Token: 0x04003575 RID: 13685
	public Texture[] EightiesIdlePortraitAlt;

	// Token: 0x04003576 RID: 13686
	public Texture EightiesThanksPortraitAlt;

	// Token: 0x04003577 RID: 13687
	public string[] ShopkeeperSpeeches;

	// Token: 0x04003578 RID: 13688
	public string[] EightiesSpeeches;

	// Token: 0x04003579 RID: 13689
	public bool[] AdultProducts;

	// Token: 0x0400357A RID: 13690
	public string[] Descs;

	// Token: 0x0400357B RID: 13691
	public string[] Products;

	// Token: 0x0400357C RID: 13692
	public float[] Costs;

	// Token: 0x0400357D RID: 13693
	public float RotationX;

	// Token: 0x0400357E RID: 13694
	public float RotationY;

	// Token: 0x0400357F RID: 13695
	public float Alpha;

	// Token: 0x04003580 RID: 13696
	public float Timer;

	// Token: 0x04003581 RID: 13697
	public float Zoom;

	// Token: 0x04003582 RID: 13698
	public int ShopkeeperPosition = 500;

	// Token: 0x04003583 RID: 13699
	public int Limit;

	// Token: 0x04003584 RID: 13700
	public bool Binoculars;

	// Token: 0x04003585 RID: 13701
	public bool MaidCafe;

	// Token: 0x04003586 RID: 13702
	public bool Exit;

	// Token: 0x04003587 RID: 13703
	public string StoreName;

	// Token: 0x04003588 RID: 13704
	public ShopType StoreType;
}
