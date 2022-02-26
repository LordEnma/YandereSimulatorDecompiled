using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200044D RID: 1101
public class StreetShopInterfaceScript : MonoBehaviour
{
	// Token: 0x06001D2F RID: 7471 RVA: 0x0015CEDC File Offset: 0x0015B0DC
	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.UpdateFakeID();
	}

	// Token: 0x06001D30 RID: 7472 RVA: 0x0015CF54 File Offset: 0x0015B154
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

	// Token: 0x06001D31 RID: 7473 RVA: 0x0015D590 File Offset: 0x0015B790
	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = this.BlurAmount;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001D32 RID: 7474 RVA: 0x0015D5CC File Offset: 0x0015B7CC
	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-50f, (float)(50 - 50 * this.Selected), 0f);
		if (this.Descs[this.Selected] != "")
		{
			this.DescriptionLabel.text = this.Descs[this.Selected];
		}
	}

	// Token: 0x06001D33 RID: 7475 RVA: 0x0015D634 File Offset: 0x0015B834
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

	// Token: 0x06001D34 RID: 7476 RVA: 0x0015D9B8 File Offset: 0x0015BBB8
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

	// Token: 0x06001D35 RID: 7477 RVA: 0x0015DA80 File Offset: 0x0015BC80
	public void UpdateFakeID()
	{
		this.FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	// Token: 0x06001D36 RID: 7478 RVA: 0x0015DA94 File Offset: 0x0015BC94
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

	// Token: 0x06001D37 RID: 7479 RVA: 0x0015DF44 File Offset: 0x0015C144
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

	// Token: 0x0400352F RID: 13615
	public StreetManagerScript StreetManager;

	// Token: 0x04003530 RID: 13616
	public InputManagerScript InputManager;

	// Token: 0x04003531 RID: 13617
	public PostProcessingProfile Profile;

	// Token: 0x04003532 RID: 13618
	public StalkerYandereScript Yandere;

	// Token: 0x04003533 RID: 13619
	public PromptBarScript PromptBar;

	// Token: 0x04003534 RID: 13620
	public UILabel SpeechBubbleLabel;

	// Token: 0x04003535 RID: 13621
	public UILabel DescriptionLabel;

	// Token: 0x04003536 RID: 13622
	public UILabel StoreNameLabel;

	// Token: 0x04003537 RID: 13623
	public UILabel MoneyLabel;

	// Token: 0x04003538 RID: 13624
	public Texture[] ShopkeeperPortraits;

	// Token: 0x04003539 RID: 13625
	public string[] ShopkeeperSpeeches;

	// Token: 0x0400353A RID: 13626
	public Texture[] IdlePortrait;

	// Token: 0x0400353B RID: 13627
	public Texture ThanksPortrait;

	// Token: 0x0400353C RID: 13628
	public UILabel[] ProductsLabel;

	// Token: 0x0400353D RID: 13629
	public UILabel[] PricesLabel;

	// Token: 0x0400353E RID: 13630
	public UISprite[] Icons;

	// Token: 0x0400353F RID: 13631
	public bool[] AdultProducts;

	// Token: 0x04003540 RID: 13632
	public string[] Descs;

	// Token: 0x04003541 RID: 13633
	public float[] Costs;

	// Token: 0x04003542 RID: 13634
	public UITexture Shopkeeper;

	// Token: 0x04003543 RID: 13635
	public Transform SpeechBubbleParent;

	// Token: 0x04003544 RID: 13636
	public Transform MaidWindow;

	// Token: 0x04003545 RID: 13637
	public Transform Highlight;

	// Token: 0x04003546 RID: 13638
	public Transform Interface;

	// Token: 0x04003547 RID: 13639
	public GameObject DescriptionBox;

	// Token: 0x04003548 RID: 13640
	public GameObject FakeIDBox;

	// Token: 0x04003549 RID: 13641
	public AudioSource Jukebox;

	// Token: 0x0400354A RID: 13642
	public AudioSource MyAudio;

	// Token: 0x0400354B RID: 13643
	public int ShopkeeperPosition;

	// Token: 0x0400354C RID: 13644
	public int SpeechPhase;

	// Token: 0x0400354D RID: 13645
	public int Selected;

	// Token: 0x0400354E RID: 13646
	public int Limit;

	// Token: 0x0400354F RID: 13647
	public float TransitionTimer;

	// Token: 0x04003550 RID: 13648
	public float BlurAmount;

	// Token: 0x04003551 RID: 13649
	public float Speed;

	// Token: 0x04003552 RID: 13650
	public float Timer;

	// Token: 0x04003553 RID: 13651
	public bool TransitionToCreepyCutscene;

	// Token: 0x04003554 RID: 13652
	public bool Patronized;

	// Token: 0x04003555 RID: 13653
	public bool ShowMaid;

	// Token: 0x04003556 RID: 13654
	public bool Show;

	// Token: 0x04003557 RID: 13655
	public ShopType CurrentStore;

	// Token: 0x04003558 RID: 13656
	public GameObject CreepyCutscene;

	// Token: 0x04003559 RID: 13657
	public StreetShopScript Salon;

	// Token: 0x0400355A RID: 13658
	public AudioClip Fail;

	// Token: 0x0400355B RID: 13659
	public Texture SalonSurprise;

	// Token: 0x0400355C RID: 13660
	public Texture SalonSinister;
}
