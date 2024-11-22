using UnityEngine;

public class CharacterCustomizationScript : MonoBehaviour
{
	public HomeInteractionScript HomeInteraction;

	public InputManagerScript InputManager;

	public InputDeviceScript InputDevice;

	public HomeYandereScript Yandere;

	public GameObject DefaultHair;

	public GameObject CustomHair;

	public Transform Highlight;

	public Transform[] Windows;

	public Texture BlondeLoose;

	public Texture BlondeHair;

	public Renderer[] Heart;

	public UILabel[] Labels;

	public int[] Category;

	public string[] HairNames;

	public string[] BangNames;

	public string[] FrontNames;

	public string[] BackNames;

	public string[] MiscNames;

	public int Selected;

	[Header("Bangs")]
	public SkinnedMeshRenderer DefaultBangs;

	public SkinnedMeshRenderer StraightBangs;

	public SkinnedMeshRenderer CenterBangs;

	public SkinnedMeshRenderer NoBangs;

	public Renderer KjechBangs;

	[Header("Front")]
	public SkinnedMeshRenderer DefaultFront;

	public Renderer KjechFront;

	public Renderer ShortFront;

	[Header("Back")]
	public SkinnedMeshRenderer KjechPonytail;

	public Renderer DefaultPonytail;

	public Renderer DefaultBack;

	public Renderer GyaruPonytail;

	public Renderer RightPigtail;

	public Renderer LeftPigtail;

	public Renderer Pigtails;

	public Renderer HairTie;

	public Renderer Loose;

	public Renderer Bun;

	[Header("Optional")]
	public Renderer Braid;

	public void Start()
	{
		if (Heart[1] != null)
		{
			Heart[1].material.color = new Color(1f, 1f, 1f, 0.05f);
			Heart[2].material.color = new Color(1f, 1f, 1f, 0.075f);
			Heart[3].material.color = new Color(1f, 1f, 1f, 0.1f);
		}
		if (PlayerGlobals.CustomHair == 0)
		{
			PlayerGlobals.CustomBangs = 1;
			PlayerGlobals.CustomLocks = 1;
			PlayerGlobals.CustomBack = 1;
			PlayerGlobals.CustomMisc = 1;
		}
		else
		{
			Category[1] = PlayerGlobals.CustomHair;
			Category[2] = PlayerGlobals.CustomBangs;
			Category[3] = PlayerGlobals.CustomLocks;
			Category[4] = PlayerGlobals.CustomBack;
			Category[5] = PlayerGlobals.CustomMisc;
		}
		if (GameGlobals.BlondeHair)
		{
			DefaultBangs.material.mainTexture = BlondeHair;
			StraightBangs.material.mainTexture = BlondeHair;
			CenterBangs.material.mainTexture = BlondeHair;
			NoBangs.material.mainTexture = BlondeHair;
			KjechBangs.material.mainTexture = BlondeHair;
			DefaultFront.material.mainTexture = BlondeHair;
			KjechFront.material.mainTexture = BlondeHair;
			ShortFront.material.mainTexture = BlondeHair;
			KjechPonytail.material.mainTexture = BlondeHair;
			DefaultPonytail.material.mainTexture = BlondeHair;
			DefaultBack.material.mainTexture = BlondeHair;
			GyaruPonytail.material.mainTexture = BlondeHair;
			RightPigtail.material.mainTexture = BlondeHair;
			LeftPigtail.material.mainTexture = BlondeHair;
			HairTie.material.mainTexture = BlondeHair;
			Loose.material.mainTexture = BlondeLoose;
			Bun.material.mainTexture = BlondeHair;
			Pigtails.materials[0].mainTexture = BlondeHair;
			Pigtails.materials[1].mainTexture = BlondeHair;
			Pigtails.materials[2].mainTexture = BlondeHair;
			Braid.material.mainTexture = BlondeHair;
		}
		UpdateHair();
	}

	private void Update()
	{
		string axisName = "Mouse X";
		if (InputDevice.Type == InputDeviceType.Gamepad)
		{
			axisName = InputNames.Xbox_JoyX;
		}
		Yandere.transform.Rotate(Vector3.up * Input.GetAxis(axisName) * -360f * Time.deltaTime);
		if (Category[1] == 1)
		{
			if (InputManager.TappedDown)
			{
				Selected++;
				UpdateHighlight();
			}
			if (InputManager.TappedUp)
			{
				Selected--;
				UpdateHighlight();
			}
		}
		if (InputManager.TappedRight)
		{
			Category[Selected]++;
			UpdateHair();
		}
		if (InputManager.TappedLeft)
		{
			Category[Selected]--;
			UpdateHair();
		}
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			PlayerGlobals.CustomHair = Category[1];
			PlayerGlobals.CustomBangs = Category[2];
			PlayerGlobals.CustomLocks = Category[3];
			PlayerGlobals.CustomBack = Category[4];
			PlayerGlobals.CustomMisc = Category[5];
			base.gameObject.SetActive(value: false);
			if (!HomeGlobals.Night)
			{
				Yandere.HomeCamera.DayLight.SetActive(value: true);
			}
			Yandere.HomeCamera.PromptBar.ClearButtons();
			Yandere.HomeCamera.PromptBar.Show = false;
			Yandere.CanMove = true;
			Yandere.HomeCamera.enabled = true;
			Yandere.MyController.enabled = true;
			Yandere.HomeCamera.RoomJukebox.volume = 1f;
			Yandere.transform.position = HomeInteraction.OriginalPos;
			Yandere.transform.eulerAngles = HomeInteraction.OriginalRot;
			Physics.SyncTransforms();
		}
	}

	private void UpdateHighlight()
	{
		if (Selected < 1)
		{
			Selected = 5;
		}
		else if (Selected > 5)
		{
			Selected = 1;
		}
		Highlight.position = Windows[Selected].position;
	}

	public void UpdateHair()
	{
		if (Labels[Selected] != null)
		{
			if (Selected == 1)
			{
				if (Category[Selected] == HairNames.Length)
				{
					Category[Selected] = 0;
				}
				if (Category[Selected] < 0)
				{
					Category[Selected] = HairNames.Length - 1;
				}
				Labels[Selected].text = HairNames[Category[Selected]];
			}
			else if (Selected == 2)
			{
				if (Category[Selected] == BangNames.Length)
				{
					Category[Selected] = 1;
				}
				if (Category[Selected] < 1)
				{
					Category[Selected] = BangNames.Length - 1;
				}
				Labels[Selected].text = BangNames[Category[Selected]];
			}
			else if (Selected == 3)
			{
				if (Category[Selected] == FrontNames.Length)
				{
					Category[Selected] = 1;
				}
				if (Category[Selected] < 1)
				{
					Category[Selected] = FrontNames.Length - 1;
				}
				Labels[Selected].text = FrontNames[Category[Selected]];
			}
			else if (Selected == 4)
			{
				if (Category[Selected] == BackNames.Length)
				{
					Category[Selected] = 1;
				}
				if (Category[Selected] < 1)
				{
					Category[Selected] = BackNames.Length - 1;
				}
				Labels[Selected].text = BackNames[Category[Selected]];
			}
			else if (Selected == 5)
			{
				if (Category[Selected] == MiscNames.Length)
				{
					Category[Selected] = 1;
				}
				if (Category[Selected] < 1)
				{
					Category[Selected] = MiscNames.Length - 1;
				}
				Labels[Selected].text = MiscNames[Category[Selected]];
			}
		}
		DefaultHair.SetActive(value: false);
		CustomHair.SetActive(value: false);
		if (Windows[2] != null)
		{
			Windows[2].gameObject.SetActive(value: false);
			Windows[3].gameObject.SetActive(value: false);
			Windows[4].gameObject.SetActive(value: false);
			Windows[5].gameObject.SetActive(value: false);
		}
		DefaultBangs.SetBlendShapeWeight(0, 0f);
		DefaultBangs.SetBlendShapeWeight(1, 0f);
		DefaultBangs.SetBlendShapeWeight(2, 0f);
		StraightBangs.SetBlendShapeWeight(0, 0f);
		CenterBangs.SetBlendShapeWeight(0, 0f);
		NoBangs.SetBlendShapeWeight(0, 0f);
		DefaultFront.SetBlendShapeWeight(0, 0f);
		DefaultFront.SetBlendShapeWeight(1, 0f);
		KjechPonytail.SetBlendShapeWeight(0, 0f);
		KjechPonytail.SetBlendShapeWeight(1, 0f);
		DefaultBangs.gameObject.SetActive(value: false);
		StraightBangs.gameObject.SetActive(value: false);
		CenterBangs.gameObject.SetActive(value: false);
		NoBangs.gameObject.SetActive(value: false);
		KjechBangs.gameObject.SetActive(value: false);
		DefaultFront.gameObject.SetActive(value: false);
		KjechFront.gameObject.SetActive(value: false);
		ShortFront.gameObject.SetActive(value: false);
		KjechPonytail.gameObject.SetActive(value: false);
		DefaultPonytail.gameObject.SetActive(value: false);
		DefaultBack.gameObject.SetActive(value: false);
		GyaruPonytail.gameObject.SetActive(value: false);
		RightPigtail.gameObject.SetActive(value: false);
		LeftPigtail.gameObject.SetActive(value: false);
		Pigtails.gameObject.SetActive(value: false);
		HairTie.gameObject.SetActive(value: false);
		Loose.gameObject.SetActive(value: false);
		Bun.gameObject.SetActive(value: false);
		Braid.gameObject.SetActive(value: false);
		if (Category[1] == 0)
		{
			DefaultHair.SetActive(value: true);
			return;
		}
		CustomHair.SetActive(value: true);
		if (Windows[2] != null)
		{
			Windows[2].gameObject.SetActive(value: true);
			Windows[3].gameObject.SetActive(value: true);
			Windows[4].gameObject.SetActive(value: true);
			Windows[5].gameObject.SetActive(value: true);
		}
		if (Category[2] == 1)
		{
			DefaultBangs.gameObject.SetActive(value: true);
		}
		else if (Category[2] == 2)
		{
			DefaultBangs.gameObject.SetActive(value: true);
			DefaultBangs.SetBlendShapeWeight(0, 100f);
		}
		else if (Category[2] == 3)
		{
			DefaultBangs.gameObject.SetActive(value: true);
			DefaultBangs.SetBlendShapeWeight(1, 100f);
		}
		else if (Category[2] == 4)
		{
			DefaultBangs.gameObject.SetActive(value: true);
			DefaultBangs.SetBlendShapeWeight(2, 100f);
		}
		else if (Category[2] == 5)
		{
			StraightBangs.gameObject.SetActive(value: true);
		}
		else if (Category[2] == 6)
		{
			StraightBangs.gameObject.SetActive(value: true);
			StraightBangs.SetBlendShapeWeight(0, 100f);
		}
		else if (Category[2] == 7)
		{
			CenterBangs.gameObject.SetActive(value: true);
		}
		else if (Category[2] == 8)
		{
			CenterBangs.gameObject.SetActive(value: true);
			CenterBangs.SetBlendShapeWeight(0, 100f);
		}
		else if (Category[2] == 9)
		{
			NoBangs.gameObject.SetActive(value: true);
		}
		else if (Category[2] == 10)
		{
			NoBangs.gameObject.SetActive(value: true);
			NoBangs.SetBlendShapeWeight(0, 100f);
		}
		else if (Category[2] == 11)
		{
			KjechBangs.gameObject.SetActive(value: true);
		}
		if (Category[3] == 1)
		{
			DefaultFront.gameObject.SetActive(value: true);
		}
		else if (Category[3] == 2)
		{
			DefaultFront.gameObject.SetActive(value: true);
			DefaultFront.SetBlendShapeWeight(0, 100f);
		}
		else if (Category[3] == 3)
		{
			DefaultFront.gameObject.SetActive(value: true);
			DefaultFront.SetBlendShapeWeight(1, 100f);
		}
		else if (Category[3] == 4)
		{
			KjechFront.gameObject.SetActive(value: true);
		}
		else if (Category[3] == 5)
		{
			ShortFront.gameObject.SetActive(value: true);
		}
		if (Category[4] == 1)
		{
			DefaultPonytail.gameObject.SetActive(value: true);
			DefaultBack.gameObject.SetActive(value: true);
			HairTie.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 2)
		{
			KjechPonytail.gameObject.SetActive(value: true);
			DefaultBack.gameObject.SetActive(value: true);
			HairTie.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 3)
		{
			KjechPonytail.SetBlendShapeWeight(0, 100f);
			KjechPonytail.gameObject.SetActive(value: true);
			DefaultBack.gameObject.SetActive(value: true);
			HairTie.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 4)
		{
			KjechPonytail.SetBlendShapeWeight(1, 100f);
			KjechPonytail.gameObject.SetActive(value: true);
			DefaultBack.gameObject.SetActive(value: true);
			HairTie.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 5)
		{
			RightPigtail.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 6)
		{
			LeftPigtail.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 7)
		{
			Pigtails.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 8)
		{
			Loose.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 9)
		{
			DefaultBack.gameObject.SetActive(value: true);
			Bun.gameObject.SetActive(value: true);
		}
		else if (Category[4] == 10)
		{
			DefaultBack.gameObject.SetActive(value: true);
			GyaruPonytail.gameObject.SetActive(value: true);
		}
		if (Category[5] != 1 && Category[5] == 2)
		{
			Braid.gameObject.SetActive(value: true);
		}
	}
}
