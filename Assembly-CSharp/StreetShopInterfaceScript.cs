using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000447 RID: 1095
public class StreetShopInterfaceScript : MonoBehaviour
{
	// Token: 0x06001D06 RID: 7430 RVA: 0x00158CC0 File Offset: 0x00156EC0
	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.UpdateFakeID();
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x00158D38 File Offset: 0x00156F38
	private void Update()
	{
		if (this.Show)
		{
			this.Jukebox.volume = Mathf.Lerp(this.Jukebox.volume, 1f, Time.deltaTime * 10f);
			if (this.TransitionTimer < 5f)
			{
				this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3((float)this.ShopkeeperPosition, 0f, 0f), Time.deltaTime * 10f);
			}
			else
			{
				this.Speed += Time.deltaTime;
				this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(0f, -535f, 0f), Time.deltaTime * this.Speed);
				this.Shopkeeper.transform.localScale = Vector3.Lerp(this.Shopkeeper.transform.localScale, new Vector3(2.256f, 2.256f, 2.256f), Time.deltaTime * this.Speed);
			}
			this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(100f, 0f, 0f), Time.deltaTime * 10f);
			this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0f, Time.deltaTime * 10f);
			if (this.TransitionToCreepyCutscene)
			{
				this.TransitionTimer += Time.deltaTime;
				if (this.TransitionTimer > 9f)
				{
					this.CreepyCutscene.SetActive(true);
					this.Jukebox.Stop();
				}
				else if (this.TransitionTimer > 4f)
				{
					this.Shopkeeper.mainTexture = this.SalonSinister;
				}
				else if (this.TransitionTimer > 2f)
				{
					this.Shopkeeper.mainTexture = this.SalonSurprise;
				}
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
				if (this.Timer > 0.5f && Input.GetButtonUp("A") && this.Icons[this.Selected].spriteName != "Yes")
				{
					this.CheckStore();
					this.UpdateIcons();
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > this.Limit)
					{
						this.Selected = 1;
					}
					this.UpdateHighlight();
				}
				else if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = this.Limit;
					}
					this.UpdateHighlight();
				}
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f)
				{
					this.SpeechBubbleParent.localScale = Vector3.Lerp(this.SpeechBubbleParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				if (this.SpeechPhase == 0)
				{
					this.SpeechPhase++;
				}
				else if (!this.Patronized && this.Timer > 10f)
				{
					if (this.SpeechPhase == 1)
					{
						this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[2];
						this.Shopkeeper.mainTexture = this.IdlePortrait[0];
						this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
						this.SpeechPhase++;
					}
					else if (this.SpeechPhase == 2 && this.Timer > 10.1f)
					{
						int num = UnityEngine.Random.Range(0, this.IdlePortrait.Length);
						this.Shopkeeper.mainTexture = this.IdlePortrait[num];
						this.Timer = 10f;
					}
				}
			}
		}
		else
		{
			this.Jukebox.volume = Mathf.Lerp(this.Jukebox.volume, 0f, Time.deltaTime);
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.Shopkeeper.transform.localPosition = Vector3.Lerp(this.Shopkeeper.transform.localPosition, new Vector3(1604f, 0f, 0f), Time.deltaTime * 10f);
			this.Interface.localPosition = Vector3.Lerp(this.Interface.localPosition, new Vector3(-815.5f, 0f, 0f), Time.deltaTime * 10f);
			if (this.ShowMaid)
			{
				this.BlurAmount = Mathf.Lerp(this.BlurAmount, 0f, Time.deltaTime * 10f);
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
				this.MaidWindow.localScale = Vector3.Lerp(this.MaidWindow.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			}
		}
		this.AdjustBlur();
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x00159374 File Offset: 0x00157574
	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = this.BlurAmount;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x001593B0 File Offset: 0x001575B0
	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-50f, (float)(50 - 50 * this.Selected), 0f);
		if (this.Descs[this.Selected] != "")
		{
			this.DescriptionLabel.text = this.Descs[this.Selected];
		}
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x00159418 File Offset: 0x00157618
	public void CheckStore()
	{
		if (this.AdultProducts[this.Selected] && !PlayerGlobals.FakeID)
		{
			AudioSource.PlayClipAtPoint(this.Fail, base.transform.position);
			this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[3];
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.SpeechPhase = 0;
			this.Timer = 1f;
			this.Shopkeeper.mainTexture = this.IdlePortrait[0];
			this.Patronized = false;
			return;
		}
		if (PlayerGlobals.Money < this.Costs[this.Selected])
		{
			this.StreetManager.Clock.MoneyFail();
			this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[4];
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.SpeechPhase = 0;
			this.Timer = 1f;
			this.Shopkeeper.mainTexture = this.IdlePortrait[0];
			this.Patronized = false;
			return;
		}
		switch (this.CurrentStore)
		{
		case ShopType.Nonfunctional:
			this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
			this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			this.SpeechPhase = 0;
			this.Timer = 1f;
			return;
		case ShopType.Hardware:
		case ShopType.Maid:
		case ShopType.Games:
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
			break;
		case ShopType.Salon:
			this.PurchaseEffect();
			CollectibleGlobals.SetAdvicePurchased(this.Selected, true);
			this.Timer = 1f;
			break;
		case ShopType.Gift:
			this.PurchaseEffect();
			if (this.Selected < 6)
			{
				CollectibleGlobals.SenpaiGifts++;
			}
			else
			{
				CollectibleGlobals.MatchmakingGifts++;
			}
			CollectibleGlobals.SetGiftPurchased(this.Selected, true);
			return;
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
			default:
				this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[6];
				this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
				this.SpeechPhase = 0;
				this.Timer = 1f;
				return;
			}
			break;
		case ShopType.Electronics:
			this.PurchaseEffect();
			switch (this.Selected)
			{
			case 1:
			case 2:
			case 3:
				break;
			case 4:
				PlayerGlobals.Headset = true;
				return;
			case 5:
				PlayerGlobals.DirectionalMic = true;
				return;
			default:
				return;
			}
			break;
		case ShopType.Lingerie:
			this.PurchaseEffect();
			CollectibleGlobals.SetPantyPurchased(this.Selected, true);
			this.CountPanties();
			return;
		default:
			return;
		}
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0015979C File Offset: 0x0015799C
	public void PurchaseEffect()
	{
		this.Patronized = true;
		this.Shopkeeper.mainTexture = this.ThanksPortrait;
		this.SpeechBubbleLabel.text = this.ShopkeeperSpeeches[5];
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.SpeechPhase = 0;
		this.Timer = 1f;
		PlayerGlobals.Money -= this.Costs[this.Selected];
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
		this.StreetManager.Clock.UpdateMoneyLabel();
		this.MyAudio.Play();
	}

	// Token: 0x06001D0C RID: 7436 RVA: 0x00159864 File Offset: 0x00157A64
	public void UpdateFakeID()
	{
		this.FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	// Token: 0x06001D0D RID: 7437 RVA: 0x00159878 File Offset: 0x00157A78
	public void UpdateIcons()
	{
		for (int i = 1; i < 11; i++)
		{
			this.Icons[i].spriteName = "";
			this.Icons[i].gameObject.SetActive(false);
			this.ProductsLabel[i].color = new Color(1f, 1f, 1f, 1f);
		}
		for (int i = 1; i < 11; i++)
		{
			if (this.AdultProducts[i])
			{
				this.Icons[i].spriteName = "18+";
			}
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
			}
			break;
		case ShopType.Salon:
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetAdvicePurchased(i))
				{
					this.Icons[i].spriteName = "Yes";
					this.PricesLabel[i].text = "Bought";
				}
			}
			break;
		case ShopType.Gift:
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetGiftPurchased(i))
				{
					this.Icons[i].spriteName = "Yes";
					this.PricesLabel[i].text = "Owned";
				}
			}
			break;
		case ShopType.Convenience:
			if (!PlayerGlobals.GetCannotBringItem(4))
			{
				this.Icons[4].spriteName = "Yes";
				this.PricesLabel[4].text = "Owned";
			}
			break;
		case ShopType.Lingerie:
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetPantyPurchased(i))
				{
					this.Icons[i].spriteName = "Yes";
					this.PricesLabel[i].text = "Owned";
				}
			}
			break;
		}
		for (int i = 1; i < 11; i++)
		{
			if (this.Icons[i].spriteName != "")
			{
				this.Icons[i].gameObject.SetActive(true);
				if (this.Icons[i].spriteName == "Yes")
				{
					this.ProductsLabel[i].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
		}
		if (this.CurrentStore == ShopType.Salon && GameGlobals.Eighties && !GameGlobals.MetBarber)
		{
			this.TransitionToCreepyCutscene = true;
		}
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x00159C7C File Offset: 0x00157E7C
	private void CountPanties()
	{
		int num = 1;
		for (int i = 1; i < 11; i++)
		{
			if (CollectibleGlobals.GetPantyPurchased(i))
			{
				num++;
			}
		}
		if (num == 10 && !GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("PantyQueen", 1);
		}
	}

	// Token: 0x040034C3 RID: 13507
	public StreetManagerScript StreetManager;

	// Token: 0x040034C4 RID: 13508
	public InputManagerScript InputManager;

	// Token: 0x040034C5 RID: 13509
	public PostProcessingProfile Profile;

	// Token: 0x040034C6 RID: 13510
	public StalkerYandereScript Yandere;

	// Token: 0x040034C7 RID: 13511
	public PromptBarScript PromptBar;

	// Token: 0x040034C8 RID: 13512
	public UILabel SpeechBubbleLabel;

	// Token: 0x040034C9 RID: 13513
	public UILabel DescriptionLabel;

	// Token: 0x040034CA RID: 13514
	public UILabel StoreNameLabel;

	// Token: 0x040034CB RID: 13515
	public UILabel MoneyLabel;

	// Token: 0x040034CC RID: 13516
	public Texture[] ShopkeeperPortraits;

	// Token: 0x040034CD RID: 13517
	public string[] ShopkeeperSpeeches;

	// Token: 0x040034CE RID: 13518
	public Texture[] IdlePortrait;

	// Token: 0x040034CF RID: 13519
	public Texture ThanksPortrait;

	// Token: 0x040034D0 RID: 13520
	public UILabel[] ProductsLabel;

	// Token: 0x040034D1 RID: 13521
	public UILabel[] PricesLabel;

	// Token: 0x040034D2 RID: 13522
	public UISprite[] Icons;

	// Token: 0x040034D3 RID: 13523
	public bool[] AdultProducts;

	// Token: 0x040034D4 RID: 13524
	public string[] Descs;

	// Token: 0x040034D5 RID: 13525
	public float[] Costs;

	// Token: 0x040034D6 RID: 13526
	public UITexture Shopkeeper;

	// Token: 0x040034D7 RID: 13527
	public Transform SpeechBubbleParent;

	// Token: 0x040034D8 RID: 13528
	public Transform MaidWindow;

	// Token: 0x040034D9 RID: 13529
	public Transform Highlight;

	// Token: 0x040034DA RID: 13530
	public Transform Interface;

	// Token: 0x040034DB RID: 13531
	public GameObject DescriptionBox;

	// Token: 0x040034DC RID: 13532
	public GameObject FakeIDBox;

	// Token: 0x040034DD RID: 13533
	public AudioSource Jukebox;

	// Token: 0x040034DE RID: 13534
	public AudioSource MyAudio;

	// Token: 0x040034DF RID: 13535
	public int ShopkeeperPosition;

	// Token: 0x040034E0 RID: 13536
	public int SpeechPhase;

	// Token: 0x040034E1 RID: 13537
	public int Selected;

	// Token: 0x040034E2 RID: 13538
	public int Limit;

	// Token: 0x040034E3 RID: 13539
	public float TransitionTimer;

	// Token: 0x040034E4 RID: 13540
	public float BlurAmount;

	// Token: 0x040034E5 RID: 13541
	public float Speed;

	// Token: 0x040034E6 RID: 13542
	public float Timer;

	// Token: 0x040034E7 RID: 13543
	public bool TransitionToCreepyCutscene;

	// Token: 0x040034E8 RID: 13544
	public bool Patronized;

	// Token: 0x040034E9 RID: 13545
	public bool ShowMaid;

	// Token: 0x040034EA RID: 13546
	public bool Show;

	// Token: 0x040034EB RID: 13547
	public ShopType CurrentStore;

	// Token: 0x040034EC RID: 13548
	public GameObject CreepyCutscene;

	// Token: 0x040034ED RID: 13549
	public StreetShopScript Salon;

	// Token: 0x040034EE RID: 13550
	public AudioClip Fail;

	// Token: 0x040034EF RID: 13551
	public Texture SalonSurprise;

	// Token: 0x040034F0 RID: 13552
	public Texture SalonSinister;
}
