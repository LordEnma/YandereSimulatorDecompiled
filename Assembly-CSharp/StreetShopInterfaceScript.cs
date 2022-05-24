using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000454 RID: 1108
public class StreetShopInterfaceScript : MonoBehaviour
{
	// Token: 0x06001D62 RID: 7522 RVA: 0x0016126C File Offset: 0x0015F46C
	private void Start()
	{
		this.Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		this.Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		this.SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		this.UpdateFakeID();
	}

	// Token: 0x06001D63 RID: 7523 RVA: 0x001612E4 File Offset: 0x0015F4E4
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

	// Token: 0x06001D64 RID: 7524 RVA: 0x0016192C File Offset: 0x0015FB2C
	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = this.BlurAmount;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x06001D65 RID: 7525 RVA: 0x00161968 File Offset: 0x0015FB68
	public void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-50f, (float)(50 - 50 * this.Selected), 0f);
		if (this.Descs[this.Selected] != "")
		{
			this.DescriptionLabel.text = this.Descs[this.Selected];
		}
	}

	// Token: 0x06001D66 RID: 7526 RVA: 0x001619D0 File Offset: 0x0015FBD0
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

	// Token: 0x06001D67 RID: 7527 RVA: 0x00161D54 File Offset: 0x0015FF54
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

	// Token: 0x06001D68 RID: 7528 RVA: 0x00161E1C File Offset: 0x0016001C
	public void UpdateFakeID()
	{
		this.FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	// Token: 0x06001D69 RID: 7529 RVA: 0x00161E30 File Offset: 0x00160030
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

	// Token: 0x06001D6A RID: 7530 RVA: 0x001622E0 File Offset: 0x001604E0
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

	// Token: 0x040035D9 RID: 13785
	public StreetManagerScript StreetManager;

	// Token: 0x040035DA RID: 13786
	public InputManagerScript InputManager;

	// Token: 0x040035DB RID: 13787
	public PostProcessingProfile Profile;

	// Token: 0x040035DC RID: 13788
	public StalkerYandereScript Yandere;

	// Token: 0x040035DD RID: 13789
	public PromptBarScript PromptBar;

	// Token: 0x040035DE RID: 13790
	public UILabel SpeechBubbleLabel;

	// Token: 0x040035DF RID: 13791
	public UILabel DescriptionLabel;

	// Token: 0x040035E0 RID: 13792
	public UILabel StoreNameLabel;

	// Token: 0x040035E1 RID: 13793
	public UILabel MoneyLabel;

	// Token: 0x040035E2 RID: 13794
	public Texture[] ShopkeeperPortraits;

	// Token: 0x040035E3 RID: 13795
	public string[] ShopkeeperSpeeches;

	// Token: 0x040035E4 RID: 13796
	public Texture[] IdlePortrait;

	// Token: 0x040035E5 RID: 13797
	public Texture ThanksPortrait;

	// Token: 0x040035E6 RID: 13798
	public UILabel[] ProductsLabel;

	// Token: 0x040035E7 RID: 13799
	public UILabel[] PricesLabel;

	// Token: 0x040035E8 RID: 13800
	public UISprite[] Icons;

	// Token: 0x040035E9 RID: 13801
	public bool[] AdultProducts;

	// Token: 0x040035EA RID: 13802
	public string[] Descs;

	// Token: 0x040035EB RID: 13803
	public float[] Costs;

	// Token: 0x040035EC RID: 13804
	public UITexture Shopkeeper;

	// Token: 0x040035ED RID: 13805
	public Transform SpeechBubbleParent;

	// Token: 0x040035EE RID: 13806
	public Transform MaidWindow;

	// Token: 0x040035EF RID: 13807
	public Transform Highlight;

	// Token: 0x040035F0 RID: 13808
	public Transform Interface;

	// Token: 0x040035F1 RID: 13809
	public GameObject DescriptionBox;

	// Token: 0x040035F2 RID: 13810
	public GameObject FakeIDBox;

	// Token: 0x040035F3 RID: 13811
	public AudioSource Jukebox;

	// Token: 0x040035F4 RID: 13812
	public AudioSource MyAudio;

	// Token: 0x040035F5 RID: 13813
	public int ShopkeeperPosition;

	// Token: 0x040035F6 RID: 13814
	public int SpeechPhase;

	// Token: 0x040035F7 RID: 13815
	public int Selected;

	// Token: 0x040035F8 RID: 13816
	public int Limit;

	// Token: 0x040035F9 RID: 13817
	public float TransitionTimer;

	// Token: 0x040035FA RID: 13818
	public float BlurAmount;

	// Token: 0x040035FB RID: 13819
	public float Speed;

	// Token: 0x040035FC RID: 13820
	public float Timer;

	// Token: 0x040035FD RID: 13821
	public bool TransitionToCreepyCutscene;

	// Token: 0x040035FE RID: 13822
	public bool Patronized;

	// Token: 0x040035FF RID: 13823
	public bool ShowMaid;

	// Token: 0x04003600 RID: 13824
	public bool Show;

	// Token: 0x04003601 RID: 13825
	public ShopType CurrentStore;

	// Token: 0x04003602 RID: 13826
	public GameObject CreepyCutscene;

	// Token: 0x04003603 RID: 13827
	public StreetShopScript Salon;

	// Token: 0x04003604 RID: 13828
	public AudioClip Fail;

	// Token: 0x04003605 RID: 13829
	public Texture SalonSurprise;

	// Token: 0x04003606 RID: 13830
	public Texture SalonSinister;
}
