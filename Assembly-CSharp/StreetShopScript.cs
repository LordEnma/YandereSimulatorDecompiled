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

	public bool[] Unavailable;

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
		MyLabel.color = new Color(1f, 1f, 1f, 0f);
		if (GameGlobals.Eighties)
		{
			StoreTheme = EightiesTheme;
			ShopkeeperPortraits = EightiesPortraits;
			ShopkeeperSpeeches = EightiesSpeeches;
			WelcomePortrait = EightiesWelcomePortrait;
			IdlePortrait = EightiesIdlePortrait;
			ThanksPortrait = EightiesThanksPortrait;
			if (StoreType == ShopType.Electronics)
			{
				Costs[1] = 999.99f;
				Costs[2] = 29.81f;
				Products[3] = "Remote-Controlled Toy Car";
				Costs[3] = 9.95f;
				Unavailable[4] = true;
				Products[4] = "Tape Player With Headphones";
				Descs[4] = "No functionality in 1980s Mode.";
				Costs[4] = 34.97f;
				Unavailable[5] = true;
				Descs[5] = "No functionality in 1980s Mode.";
				Costs[5] = 66.28f;
			}
			else if (StoreType == ShopType.Manga)
			{
				Products[1] = "Ahmya Volume 1";
				Products[2] = "Ahmya Volume 2";
				Products[3] = "Ahmya Volume 3";
				Products[4] = "Ahmya Volume 4";
				Products[5] = "Ahmya Volume 5";
				Products[6] = "Enchanting Petals Volume 1";
				Products[7] = "Enchanting Petals Volume 2";
				Products[8] = "Enchanting Petals Volume 3";
				Products[9] = "Enchanting Petals Volume 4";
				Products[10] = "Enchanting Petals Volume 5";
			}
			else if (StoreType == ShopType.Games)
			{
				Products[1] = "Yanvania III: Dracula-chan's Curse";
				Products[2] = "Sammy the Witch";
				Products[3] = "Super Maria Land";
				Products[4] = "Quack Tales";
				Products[5] = "Tetromino Tennis";
				Costs[1] = 49.99f;
				Costs[2] = 49.99f;
				Costs[3] = 49.99f;
				Costs[4] = 49.99f;
				Costs[5] = 49.99f;
			}
			else if (StoreType == ShopType.Gift)
			{
				Products[2] = "City Pop Vinyl";
				Costs[2] = 6.99f;
				Products[6] = "Trendy Bracelet";
				Products[7] = "Trendy Hair Clip";
				Products[8] = "Trendy Necklace";
				Products[9] = "Trendy Ring";
			}
			else if (StoreType == ShopType.Salon)
			{
				ShopkeeperPosition = 580;
				if (GameGlobals.MetBarber)
				{
					EightiesBarber();
				}
				if (GameGlobals.CustomMode)
				{
					EightiesSpeeches[4] = "Sorry, I can't give credit. Come back when you're a little, mmm... richer.";
				}
			}
		}
		else
		{
			if (StoreType == ShopType.Salon)
			{
				StoreType = ShopType.Nonfunctional;
			}
			if (StoreType == ShopType.Gift && DateGlobals.Week == 2)
			{
				Products[6] = "Cupcake Bracelet";
				Products[7] = "Cupcake Hair Clip";
				Products[8] = "Cupcake Necklace";
				Products[9] = "Cupcake Ring";
			}
		}
	}

	private void Update()
	{
		if (Vector3.Distance(Yandere.transform.position, base.transform.position) < 1f)
		{
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * 10f);
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime * 10f);
		}
		MyLabel.color = new Color(1f, 0.75f, 1f, Alpha);
		if (Alpha == 1f && Input.GetButtonDown(InputNames.Xbox_A) && !Yandere.PauseScreen.activeInHierarchy)
		{
			if (Exit)
			{
				StreetManager.FadeOut = true;
				Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.CanMove = false;
			}
			else if (MaidCafe)
			{
				StreetShopInterface.ShowMaid = true;
				Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.RPGCamera.enabled = false;
				Yandere.CanMove = false;
			}
			else if (!Binoculars)
			{
				if (!StreetShopInterface.Show)
				{
					StreetShopInterface.CurrentStore = StoreType;
					StreetShopInterface.Show = true;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Purchase";
					PromptBar.Label[1].text = "Exit";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
					Yandere.CanMove = false;
					UpdateShopInterface();
				}
			}
			else if (PlayerGlobals.Money >= 0.25f)
			{
				MyAudio.clip = InsertCoin;
				PlayerGlobals.Money -= 0.25f;
				HomeClock.UpdateMoneyLabel();
				BinocularCamera.gameObject.SetActive(value: true);
				BinocularRenderer.enabled = false;
				BinocularOverlay.SetActive(value: true);
				PromptBar.ClearButtons();
				PromptBar.Label[1].text = "Exit";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
				Yandere.transform.position = new Vector3(5f, 0f, 3f);
				Yandere.CanMove = false;
				MyAudio.Play();
			}
			else
			{
				HomeClock.MoneyFail();
			}
		}
		if (Binoculars && BinocularCamera.gameObject.activeInHierarchy)
		{
			string axisName = "Mouse X";
			string axisName2 = "Mouse Y";
			if (InputDevice.Type == InputDeviceType.Gamepad)
			{
				axisName = InputNames.Xbox_JoyX;
				axisName2 = InputNames.Xbox_JoyY;
			}
			if (InputDevice.Type == InputDeviceType.MouseAndKeyboard)
			{
				RotationX -= Input.GetAxis(axisName2) * (BinocularCamera.fieldOfView / 60f);
				RotationY += Input.GetAxis(axisName) * (BinocularCamera.fieldOfView / 60f);
			}
			else
			{
				RotationX -= Input.GetAxis(axisName2) * (BinocularCamera.fieldOfView / 60f);
				RotationY += Input.GetAxis(axisName) * (BinocularCamera.fieldOfView / 60f);
			}
			BinocularCamera.transform.eulerAngles = new Vector3(RotationX, RotationY + 90f, 0f);
			if (RotationX > 45f)
			{
				RotationX = 45f;
			}
			if (RotationX < -45f)
			{
				RotationX = -45f;
			}
			if (RotationY > 90f)
			{
				RotationY = 90f;
			}
			if (RotationY < -90f)
			{
				RotationY = -90f;
			}
			Zoom -= Input.GetAxis("Mouse ScrollWheel") * 10f;
			Zoom -= Input.GetAxis("Vertical") * 0.1f;
			if (Zoom > 60f)
			{
				Zoom = 60f;
			}
			else if (Zoom < 1f)
			{
				Zoom = 1f;
			}
			BinocularCamera.fieldOfView = Mathf.Lerp(BinocularCamera.fieldOfView, Zoom, Time.deltaTime * 10f);
			StreetManager.CurrentlyActiveJukebox.volume = BinocularCamera.fieldOfView / 60f * 0.5f;
			if (Input.GetButtonUp(InputNames.Xbox_B))
			{
				BinocularCamera.gameObject.SetActive(value: false);
				BinocularRenderer.enabled = true;
				BinocularOverlay.SetActive(value: false);
				RotationX = 0f;
				RotationY = 0f;
				Zoom = 60f;
				StreetManager.CurrentlyActiveJukebox.volume = 0.5f;
				PromptBar.ClearButtons();
				PromptBar.Show = false;
				Yandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				Yandere.RPGCamera.ResetStreetCamera();
				Yandere.CanMove = true;
			}
		}
	}

	public void UpdateShopInterface()
	{
		if (Descs[1] != "")
		{
			StreetShopInterface.DescriptionBox.SetActive(value: true);
			StreetShopInterface.DescriptionLabel.text = Descs[1];
		}
		else
		{
			StreetShopInterface.DescriptionBox.SetActive(value: false);
		}
		Yandere.MainCamera.GetComponent<RPG_Camera>().enabled = false;
		if (Yandere.Eighties && StoreType == ShopType.Convenience)
		{
			if (Random.Range(1, 3) == 1)
			{
				WelcomePortrait = EightiesWelcomePortrait;
				IdlePortrait = EightiesIdlePortrait;
				ThanksPortrait = EightiesThanksPortrait;
			}
			else
			{
				WelcomePortrait = EightiesWelcomePortraitAlt;
				IdlePortrait = EightiesIdlePortraitAlt;
				ThanksPortrait = EightiesThanksPortraitAlt;
			}
		}
		StreetShopInterface.StoreNameLabel.text = StoreName;
		StreetShopInterface.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
		StreetShopInterface.Shopkeeper.mainTexture = WelcomePortrait;
		StreetShopInterface.SpeechBubbleLabel.text = ShopkeeperSpeeches[1];
		StreetShopInterface.IdlePortrait = IdlePortrait;
		StreetShopInterface.ThanksPortrait = ThanksPortrait;
		StreetShopInterface.ShopkeeperSpeeches = ShopkeeperSpeeches;
		StreetShopInterface.ShopkeeperPosition = ShopkeeperPosition;
		StreetShopInterface.AdultProducts = AdultProducts;
		StreetShopInterface.Unavailable = Unavailable;
		StreetShopInterface.SpeechPhase = 0;
		StreetShopInterface.Costs = Costs;
		StreetShopInterface.Descs = Descs;
		StreetShopInterface.Limit = Limit;
		StreetShopInterface.Selected = 1;
		StreetShopInterface.Timer = 0f;
		StreetShopInterface.Jukebox.clip = StoreTheme;
		StreetShopInterface.Jukebox.Play();
		StreetShopInterface.UpdateHighlight();
		for (int i = 1; i < 11; i++)
		{
			StreetShopInterface.ProductsLabel[i].text = Products[i];
			StreetShopInterface.PricesLabel[i].text = "$" + Costs[i];
			if (StreetShopInterface.PricesLabel[i].text == "$0")
			{
				StreetShopInterface.PricesLabel[i].text = "";
			}
		}
		StreetShopInterface.UpdateIcons();
		StreetShopInterface.UpdateFakeID();
	}

	public void EightiesBarber()
	{
		Products[1] = "The Benefits of Manga";
		Products[2] = "Cauterizing Wounds";
		Products[3] = "Hiding Bodies";
		Products[4] = "Distractions";
		Products[5] = "Notes in Lockers";
		Products[6] = "Student Personas";
		Products[7] = "Cleaning Weapons";
		Products[8] = "Emergency Showers";
		Products[9] = "Raincoat Advice";
		Products[10] = "School Atmosphere";
		for (int i = 1; i < 11; i++)
		{
			StreetShopInterface.ProductsLabel[i].text = Products[i];
			StreetShopInterface.PricesLabel[i].text = "$" + Costs[i];
			Unavailable[i] = false;
		}
	}
}
