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

	public bool[] Unavailable;

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

	public bool Eaten;

	public bool Show;

	public ShopType CurrentStore;

	public GameObject CreepyCutscene;

	public StreetShopScript Salon;

	public AudioClip Fail;

	public Texture SalonSurprise;

	public Texture SalonSinister;

	private void Start()
	{
		Shopkeeper.transform.localPosition = new Vector3(1485f, 0f, 0f);
		Interface.localPosition = new Vector3(-815.5f, 0f, 0f);
		SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		UpdateFakeID();
	}

	private void Update()
	{
		if (Show)
		{
			if (!StreetManager.Mute)
			{
				Jukebox.volume = Mathf.Lerp(Jukebox.volume, 1f, Time.deltaTime * 10f);
			}
			if (TransitionTimer < 5f)
			{
				Shopkeeper.transform.localPosition = Vector3.Lerp(Shopkeeper.transform.localPosition, new Vector3(ShopkeeperPosition, 0f, 0f), Time.deltaTime * 10f);
			}
			else
			{
				Speed += Time.deltaTime;
				Shopkeeper.transform.localPosition = Vector3.Lerp(Shopkeeper.transform.localPosition, new Vector3(0f, -535f, 0f), Time.deltaTime * Speed);
				Shopkeeper.transform.localScale = Vector3.Lerp(Shopkeeper.transform.localScale, new Vector3(2.256f, 2.256f, 2.256f), Time.deltaTime * Speed);
			}
			Interface.localPosition = Vector3.Lerp(Interface.localPosition, new Vector3(100f, 0f, 0f), Time.deltaTime * 10f);
			BlurAmount = Mathf.Lerp(BlurAmount, 0f, Time.deltaTime * 10f);
			if (TransitionToCreepyCutscene)
			{
				TransitionTimer += Time.deltaTime;
				if (TransitionTimer > 9f)
				{
					CreepyCutscene.SetActive(value: true);
					Jukebox.Stop();
				}
				else if (TransitionTimer > 4f)
				{
					Shopkeeper.mainTexture = SalonSinister;
					Jukebox.pitch -= Time.deltaTime * 0.1f;
				}
				else if (TransitionTimer > 2f)
				{
					Shopkeeper.mainTexture = SalonSurprise;
					Jukebox.pitch -= Time.deltaTime * 0.1f;
				}
			}
			else
			{
				if (Input.GetButtonUp(InputNames.Xbox_B))
				{
					Yandere.RPGCamera.enabled = true;
					PromptBar.Show = false;
					Yandere.CanMove = true;
					Patronized = false;
					Show = false;
				}
				if (Timer > 0.5f && Input.GetButtonUp(InputNames.Xbox_A) && Icons[Selected].spriteName != "Yes" && PricesLabel[Selected].text != "Not Hungry" && PricesLabel[Selected].text != "Sold Out")
				{
					CheckStore();
					UpdateIcons();
				}
				if (InputManager.TappedDown)
				{
					Selected++;
					if (Selected > Limit)
					{
						Selected = 1;
					}
					UpdateHighlight();
				}
				else if (InputManager.TappedUp)
				{
					Selected--;
					if (Selected < 1)
					{
						Selected = Limit;
					}
					UpdateHighlight();
				}
				Timer += Time.deltaTime;
				if (Timer > 0.5f)
				{
					SpeechBubbleParent.localScale = Vector3.Lerp(SpeechBubbleParent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
				if (SpeechPhase == 0)
				{
					SpeechPhase++;
				}
				else if (!Patronized && Timer > 10f)
				{
					if (SpeechPhase == 1)
					{
						SpeechBubbleLabel.text = ShopkeeperSpeeches[2];
						Shopkeeper.mainTexture = IdlePortrait[0];
						SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
						SpeechPhase++;
					}
					else if (SpeechPhase == 2 && Timer > 10.1f)
					{
						int num = Random.Range(0, IdlePortrait.Length);
						Shopkeeper.mainTexture = IdlePortrait[num];
						Timer = 10f;
					}
				}
			}
		}
		else
		{
			Jukebox.volume = Mathf.Lerp(Jukebox.volume, 0f, Time.deltaTime);
			SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			Shopkeeper.transform.localPosition = Vector3.Lerp(Shopkeeper.transform.localPosition, new Vector3(1604f, 0f, 0f), Time.deltaTime * 10f);
			Interface.localPosition = Vector3.Lerp(Interface.localPosition, new Vector3(-815.5f, 0f, 0f), Time.deltaTime * 10f);
			if (ShowMaid)
			{
				BlurAmount = Mathf.Lerp(BlurAmount, 0f, Time.deltaTime * 10f);
				MaidWindow.localScale = Vector3.Lerp(MaidWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					StreetManager.FadeOut = true;
					StreetManager.GoToCafe = true;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					Yandere.RPGCamera.enabled = true;
					Yandere.CanMove = true;
					ShowMaid = false;
				}
			}
			else
			{
				BlurAmount = Mathf.Lerp(BlurAmount, 2f, Time.deltaTime * 10f);
				MaidWindow.localScale = Vector3.Lerp(MaidWindow.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			}
		}
		AdjustBlur();
	}

	private void AdjustBlur()
	{
		DepthOfFieldModel.Settings settings = Profile.depthOfField.settings;
		settings.focusDistance = BlurAmount;
		Profile.depthOfField.settings = settings;
	}

	public void UpdateHighlight()
	{
		Highlight.localPosition = new Vector3(-50f, 50 - 50 * Selected, 0f);
		if (Descs[Selected] != "")
		{
			DescriptionLabel.text = Descs[Selected];
		}
	}

	public void CheckStore()
	{
		if (AdultProducts[Selected] && !PlayerGlobals.FakeID)
		{
			AudioSource.PlayClipAtPoint(Fail, base.transform.position);
			SpeechBubbleLabel.text = ShopkeeperSpeeches[3];
			SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			SpeechPhase = 0;
			Timer = 1f;
			Shopkeeper.mainTexture = IdlePortrait[0];
			Patronized = false;
			return;
		}
		if (PlayerGlobals.Money < Costs[Selected])
		{
			StreetManager.Clock.MoneyFail();
			SpeechBubbleLabel.text = ShopkeeperSpeeches[4];
			SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			SpeechPhase = 0;
			Timer = 1f;
			Shopkeeper.mainTexture = IdlePortrait[0];
			Patronized = false;
			return;
		}
		switch (CurrentStore)
		{
		case ShopType.Nonfunctional:
			SpeechBubbleLabel.text = ShopkeeperSpeeches[6];
			SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
			SpeechPhase = 0;
			Timer = 1f;
			break;
		case ShopType.Convenience:
			switch (Selected)
			{
			case 1:
				PurchaseEffect();
				PlayerGlobals.SetCannotBringItem(6, value: false);
				break;
			case 2:
				PurchaseEffect();
				PlayerGlobals.SetCannotBringItem(5, value: false);
				break;
			case 3:
				PurchaseEffect();
				PlayerGlobals.SetCannotBringItem(7, value: false);
				break;
			case 4:
				PurchaseEffect();
				PlayerGlobals.SetCannotBringItem(4, value: false);
				break;
			case 5:
				PurchaseEffect();
				PlayerGlobals.BoughtSedative = true;
				PlayerGlobals.SetCannotBringItem(9, value: false);
				break;
			case 6:
				PurchaseEffect();
				PlayerGlobals.Meals++;
				break;
			default:
				SpeechBubbleLabel.text = ShopkeeperSpeeches[6];
				SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
				SpeechPhase = 0;
				Timer = 1f;
				break;
			}
			break;
		case ShopType.Electronics:
			PurchaseEffect();
			switch (Selected)
			{
			case 4:
				PlayerGlobals.Headset = true;
				break;
			case 5:
				PlayerGlobals.DirectionalMic = true;
				break;
			case 1:
			case 2:
			case 3:
				break;
			}
			break;
		case ShopType.Manga:
			PurchaseEffect();
			switch (Selected)
			{
			case 1:
				CollectibleGlobals.SetMangaCollected(6, value: true);
				break;
			case 2:
				CollectibleGlobals.SetMangaCollected(7, value: true);
				break;
			case 3:
				CollectibleGlobals.SetMangaCollected(8, value: true);
				break;
			case 4:
				CollectibleGlobals.SetMangaCollected(9, value: true);
				break;
			case 5:
				CollectibleGlobals.SetMangaCollected(10, value: true);
				break;
			case 6:
				CollectibleGlobals.SetMangaCollected(1, value: true);
				break;
			case 7:
				CollectibleGlobals.SetMangaCollected(2, value: true);
				break;
			case 8:
				CollectibleGlobals.SetMangaCollected(3, value: true);
				break;
			case 9:
				CollectibleGlobals.SetMangaCollected(4, value: true);
				break;
			case 10:
				CollectibleGlobals.SetMangaCollected(5, value: true);
				break;
			}
			break;
		case ShopType.Gift:
			PurchaseEffect();
			if (Selected < 6)
			{
				CollectibleGlobals.SenpaiGifts++;
			}
			else
			{
				CollectibleGlobals.MatchmakingGifts++;
			}
			CollectibleGlobals.SetGiftPurchased(Selected, value: true);
			break;
		case ShopType.Lingerie:
			PurchaseEffect();
			CollectibleGlobals.SetPantyPurchased(Selected, value: true);
			CountPanties();
			break;
		case ShopType.Salon:
			PurchaseEffect();
			CollectibleGlobals.SetAdvicePurchased(Selected, value: true);
			break;
		case ShopType.Hardware:
			PurchaseEffect();
			CollectibleGlobals.SetHardwarePurchased(Selected, value: true);
			if (Selected == 1)
			{
				PlayerGlobals.SetCannotBringItem(3, value: false);
			}
			break;
		case ShopType.Ramen:
			PurchaseEffect();
			GameGlobals.Dream = Selected;
			Eaten = true;
			UpdateIcons();
			break;
		case ShopType.Maid:
		case ShopType.Games:
			break;
		}
	}

	public void PurchaseEffect()
	{
		Patronized = true;
		Shopkeeper.mainTexture = ThanksPortrait;
		SpeechBubbleLabel.text = ShopkeeperSpeeches[5];
		SpeechBubbleParent.localScale = new Vector3(0f, 0f, 0f);
		SpeechPhase = 0;
		Timer = 1f;
		PlayerGlobals.Money -= Costs[Selected];
		MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
		StreetManager.Clock.UpdateMoneyLabel();
		MyAudio.Play();
	}

	public void UpdateFakeID()
	{
		FakeIDBox.SetActive(PlayerGlobals.FakeID);
	}

	public void UpdateIcons()
	{
		for (int i = 1; i < 11; i++)
		{
			Icons[i].spriteName = "";
			Icons[i].gameObject.SetActive(value: false);
			ProductsLabel[i].color = new Color(1f, 1f, 1f, 1f);
		}
		for (int i = 1; i < 11; i++)
		{
			if (AdultProducts[i])
			{
				Icons[i].spriteName = "18+";
			}
		}
		switch (CurrentStore)
		{
		case ShopType.Convenience:
			if (!PlayerGlobals.GetCannotBringItem(6))
			{
				Icons[1].spriteName = "Yes";
				PricesLabel[1].text = "Owned";
			}
			if (!PlayerGlobals.GetCannotBringItem(5))
			{
				Icons[2].spriteName = "Yes";
				PricesLabel[2].text = "Owned";
			}
			if (!PlayerGlobals.GetCannotBringItem(7))
			{
				Icons[3].spriteName = "Yes";
				PricesLabel[3].text = "Owned";
			}
			if (!PlayerGlobals.GetCannotBringItem(4))
			{
				Icons[4].spriteName = "Yes";
				PricesLabel[4].text = "Owned";
			}
			if (PlayerGlobals.BoughtSedative)
			{
				Icons[5].spriteName = "Yes";
				PricesLabel[5].text = "Owned";
			}
			break;
		case ShopType.Manga:
			if (CollectibleGlobals.GetMangaCollected(1))
			{
				Icons[6].spriteName = "Yes";
				PricesLabel[6].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(2))
			{
				Icons[7].spriteName = "Yes";
				PricesLabel[7].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(3))
			{
				Icons[8].spriteName = "Yes";
				PricesLabel[8].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(4))
			{
				Icons[9].spriteName = "Yes";
				PricesLabel[9].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(5))
			{
				Icons[10].spriteName = "Yes";
				PricesLabel[10].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(6))
			{
				Icons[1].spriteName = "Yes";
				PricesLabel[1].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(7))
			{
				Icons[2].spriteName = "Yes";
				PricesLabel[2].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(8))
			{
				Icons[3].spriteName = "Yes";
				PricesLabel[3].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(9))
			{
				Icons[4].spriteName = "Yes";
				PricesLabel[4].text = "Owned";
			}
			if (CollectibleGlobals.GetMangaCollected(10))
			{
				Icons[5].spriteName = "Yes";
				PricesLabel[5].text = "Owned";
			}
			break;
		case ShopType.Gift:
		{
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetGiftPurchased(i))
				{
					Icons[i].spriteName = "Yes";
					PricesLabel[i].text = "Sold Out";
				}
			}
			break;
		}
		case ShopType.Lingerie:
		{
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetPantyPurchased(i))
				{
					Icons[i].spriteName = "Yes";
					PricesLabel[i].text = "Owned";
				}
			}
			break;
		}
		case ShopType.Salon:
		{
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetAdvicePurchased(i))
				{
					Icons[i].spriteName = "Yes";
					PricesLabel[i].text = "Bought";
				}
			}
			break;
		}
		case ShopType.Hardware:
		{
			for (int i = 1; i < 11; i++)
			{
				if (CollectibleGlobals.GetHardwarePurchased(i))
				{
					Icons[i].spriteName = "Yes";
					PricesLabel[i].text = "Bought";
				}
			}
			break;
		}
		case ShopType.Ramen:
		{
			if (Eaten)
			{
				PricesLabel[1].text = "Not Hungry";
				Icons[1].spriteName = "Yes";
			}
			for (int i = 2; i < 6; i++)
			{
				PricesLabel[i].text = "Sold Out";
			}
			break;
		}
		}
		for (int i = 1; i < 11; i++)
		{
			if (Icons[i].spriteName != "")
			{
				Icons[i].gameObject.SetActive(value: true);
				if (Icons[i].spriteName == "Yes")
				{
					ProductsLabel[i].color = new Color(1f, 1f, 1f, 0.5f);
				}
			}
			if (Unavailable[i])
			{
				ProductsLabel[i].alpha = 0.5f;
				PricesLabel[i].text = "Sold Out";
			}
		}
		if (CurrentStore == ShopType.Salon && GameGlobals.Eighties && !GameGlobals.MetBarber)
		{
			TransitionToCreepyCutscene = true;
		}
	}

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
		if (num == 10)
		{
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("PantyQueen", 1);
			}
			if (!GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("a", 1);
			}
		}
	}
}
