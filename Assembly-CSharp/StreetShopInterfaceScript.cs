using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200044E RID: 1102
public class StreetShopInterfaceScript : MonoBehaviour
{
	// Token: 0x06001D3F RID: 7487 RVA: 0x0015E6C0 File Offset: 0x0015C8C0
	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.UpdateFakeID();
	}

	// Token: 0x06001D40 RID: 7488 RVA: 0x0015E738 File Offset: 0x0015C938
	private void Update()
	{
		if (this.Show)
		{
			if (!this.StreetManager.Mute)
			{
				this.Jukebox.volume = Mathf.Lerp(this.Jukebox.volume, 1f, Time.deltaTime * 10f);
			}
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

	// Token: 0x06001D41 RID: 7489 RVA: 0x0015ED80 File Offset: 0x0015CF80
	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = this.BlurAmount;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001D42 RID: 7490 RVA: 0x0015EDBC File Offset: 0x0015CFBC
	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-50f, (float)(50 - 50 * this.Selected), 0f);
		if (this.Descs[this.Selected] != "")
		{
			this.DescriptionLabel.text = this.Descs[this.Selected];
		}
	}

	// Token: 0x06001D43 RID: 7491 RVA: 0x0015EE24 File Offset: 0x0015D024
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

	// Token: 0x06001D44 RID: 7492 RVA: 0x0015F1A8 File Offset: 0x0015D3A8
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

	// Token: 0x06001D45 RID: 7493 RVA: 0x0015F270 File Offset: 0x0015D470
	public void UpdateFakeID()
	{
		this.FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	// Token: 0x06001D46 RID: 7494 RVA: 0x0015F284 File Offset: 0x0015D484
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

	// Token: 0x06001D47 RID: 7495 RVA: 0x0015F734 File Offset: 0x0015D934
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

	// Token: 0x04003581 RID: 13697
	public StreetManagerScript StreetManager;

	// Token: 0x04003582 RID: 13698
	public InputManagerScript InputManager;

	// Token: 0x04003583 RID: 13699
	public PostProcessingProfile Profile;

	// Token: 0x04003584 RID: 13700
	public StalkerYandereScript Yandere;

	// Token: 0x04003585 RID: 13701
	public PromptBarScript PromptBar;

	// Token: 0x04003586 RID: 13702
	public UILabel SpeechBubbleLabel;

	// Token: 0x04003587 RID: 13703
	public UILabel DescriptionLabel;

	// Token: 0x04003588 RID: 13704
	public UILabel StoreNameLabel;

	// Token: 0x04003589 RID: 13705
	public UILabel MoneyLabel;

	// Token: 0x0400358A RID: 13706
	public Texture[] ShopkeeperPortraits;

	// Token: 0x0400358B RID: 13707
	public string[] ShopkeeperSpeeches;

	// Token: 0x0400358C RID: 13708
	public Texture[] IdlePortrait;

	// Token: 0x0400358D RID: 13709
	public Texture ThanksPortrait;

	// Token: 0x0400358E RID: 13710
	public UILabel[] ProductsLabel;

	// Token: 0x0400358F RID: 13711
	public UILabel[] PricesLabel;

	// Token: 0x04003590 RID: 13712
	public UISprite[] Icons;

	// Token: 0x04003591 RID: 13713
	public bool[] AdultProducts;

	// Token: 0x04003592 RID: 13714
	public string[] Descs;

	// Token: 0x04003593 RID: 13715
	public float[] Costs;

	// Token: 0x04003594 RID: 13716
	public UITexture Shopkeeper;

	// Token: 0x04003595 RID: 13717
	public Transform SpeechBubbleParent;

	// Token: 0x04003596 RID: 13718
	public Transform MaidWindow;

	// Token: 0x04003597 RID: 13719
	public Transform Highlight;

	// Token: 0x04003598 RID: 13720
	public Transform Interface;

	// Token: 0x04003599 RID: 13721
	public GameObject DescriptionBox;

	// Token: 0x0400359A RID: 13722
	public GameObject FakeIDBox;

	// Token: 0x0400359B RID: 13723
	public AudioSource Jukebox;

	// Token: 0x0400359C RID: 13724
	public AudioSource MyAudio;

	// Token: 0x0400359D RID: 13725
	public int ShopkeeperPosition;

	// Token: 0x0400359E RID: 13726
	public int SpeechPhase;

	// Token: 0x0400359F RID: 13727
	public int Selected;

	// Token: 0x040035A0 RID: 13728
	public int Limit;

	// Token: 0x040035A1 RID: 13729
	public float TransitionTimer;

	// Token: 0x040035A2 RID: 13730
	public float BlurAmount;

	// Token: 0x040035A3 RID: 13731
	public float Speed;

	// Token: 0x040035A4 RID: 13732
	public float Timer;

	// Token: 0x040035A5 RID: 13733
	public bool TransitionToCreepyCutscene;

	// Token: 0x040035A6 RID: 13734
	public bool Patronized;

	// Token: 0x040035A7 RID: 13735
	public bool ShowMaid;

	// Token: 0x040035A8 RID: 13736
	public bool Show;

	// Token: 0x040035A9 RID: 13737
	public ShopType CurrentStore;

	// Token: 0x040035AA RID: 13738
	public GameObject CreepyCutscene;

	// Token: 0x040035AB RID: 13739
	public StreetShopScript Salon;

	// Token: 0x040035AC RID: 13740
	public AudioClip Fail;

	// Token: 0x040035AD RID: 13741
	public Texture SalonSurprise;

	// Token: 0x040035AE RID: 13742
	public Texture SalonSinister;
}
