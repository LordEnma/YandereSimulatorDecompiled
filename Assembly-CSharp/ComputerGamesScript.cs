using UnityEngine;

public class ComputerGamesScript : MonoBehaviour
{
	public PromptScript[] ComputerGames;

	public Collider[] Chairs;

	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public PromptBarScript PromptBar;

	public YandereScript Yandere;

	public PoliceScript Police;

	public PoisonScript Poison;

	public Quaternion targetRotation;

	public Transform GameWindow;

	public Transform MainCamera;

	public Transform Highlight;

	public bool ShowWindow;

	public bool Gaming;

	public float Timer;

	public int Subject = 1;

	public int GameID;

	public int ID = 1;

	public Color OriginalColor;

	public string[] Descriptions;

	public UITexture MyTexture;

	public Texture[] Textures;

	public UILabel DescLabel;

	private void Start()
	{
		GameWindow.gameObject.SetActive(false);
		UpdateHighlight();
		DeactivateAllBenefits();
		OriginalColor = Yandere.PowerUp.color;
		if (ClubGlobals.Club == ClubType.Gaming)
		{
			EnableGames();
		}
		else
		{
			DisableGames();
		}
	}

	private void Update()
	{
		if (ShowWindow)
		{
			GameWindow.localScale = Vector3.Lerp(GameWindow.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (InputManager.TappedUp)
			{
				Subject--;
				UpdateHighlight();
			}
			else if (InputManager.TappedDown)
			{
				Subject++;
				UpdateHighlight();
			}
			if (Input.GetButtonDown("A"))
			{
				ShowWindow = false;
				PlayGames();
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
			}
			if (Input.GetButtonDown("B"))
			{
				Yandere.CanMove = true;
				ShowWindow = false;
				PromptBar.ClearButtons();
				PromptBar.UpdateButtons();
				PromptBar.Show = false;
			}
		}
		else if (GameWindow.localScale.x > 0.1f)
		{
			GameWindow.localScale = Vector3.Lerp(GameWindow.localScale, Vector3.zero, Time.deltaTime * 10f);
		}
		else
		{
			GameWindow.localScale = Vector3.zero;
			GameWindow.gameObject.SetActive(false);
		}
		if (Gaming)
		{
			targetRotation = Quaternion.LookRotation(new Vector3(ComputerGames[GameID].transform.position.x, Yandere.transform.position.y, ComputerGames[GameID].transform.position.z) - Yandere.transform.position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, targetRotation, Time.deltaTime * 10f);
			Yandere.MoveTowardsTarget(new Vector3(24.32233f, 4f, 12.58998f));
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				Yandere.PowerUp.transform.parent.gameObject.SetActive(true);
				Yandere.MyController.radius = 0.2f;
				Yandere.CanMove = true;
				Yandere.EmptyHands();
				Gaming = false;
				ActivateBenefit();
			}
		}
		else if (Timer < 5f)
		{
			for (ID = 1; ID < ComputerGames.Length; ID++)
			{
				PromptScript promptScript = ComputerGames[ID];
				if (promptScript.Circle[0].fillAmount == 0f)
				{
					promptScript.Circle[0].fillAmount = 1f;
					if (!Yandere.Chased && Yandere.Chasers == 0)
					{
						GameID = ID;
						if (ID == 1)
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[4].text = "Select";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							Yandere.Character.GetComponent<Animation>().Play(Yandere.IdleAnim);
							Yandere.CanMove = false;
							GameWindow.gameObject.SetActive(true);
							ShowWindow = true;
						}
						else
						{
							PlayGames();
						}
					}
				}
			}
		}
		if (Yandere.PowerUp.gameObject.activeInHierarchy)
		{
			Timer += Time.deltaTime;
			Yandere.PowerUp.transform.localPosition = new Vector3(Yandere.PowerUp.transform.localPosition.x, Yandere.PowerUp.transform.localPosition.y + Time.deltaTime, Yandere.PowerUp.transform.localPosition.z);
			Yandere.PowerUp.transform.LookAt(MainCamera.position);
			Yandere.PowerUp.transform.localEulerAngles = new Vector3(Yandere.PowerUp.transform.localEulerAngles.x, Yandere.PowerUp.transform.localEulerAngles.y + 180f, Yandere.PowerUp.transform.localEulerAngles.z);
			if (Yandere.PowerUp.color != new Color(1f, 1f, 1f, 1f))
			{
				Yandere.PowerUp.color = OriginalColor;
			}
			else
			{
				Yandere.PowerUp.color = new Color(1f, 1f, 1f, 1f);
			}
			if (Timer > 6f)
			{
				Yandere.PowerUp.transform.parent.gameObject.SetActive(false);
				base.gameObject.SetActive(false);
			}
		}
	}

	public void EnableGames()
	{
		for (int i = 1; i < ComputerGames.Length; i++)
		{
			ComputerGames[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	private void PlayGames()
	{
		Yandere.Character.GetComponent<Animation>().CrossFade("f02_playingGames_00");
		Yandere.MyController.radius = 0.1f;
		Yandere.CanMove = false;
		Gaming = true;
		DisableGames();
		UpdateImage();
	}

	private void UpdateImage()
	{
		MyTexture.mainTexture = Textures[Subject];
	}

	public void DisableGames()
	{
		for (int i = 1; i < ComputerGames.Length; i++)
		{
			ComputerGames[i].enabled = false;
			ComputerGames[i].Hide();
		}
		if (!Gaming)
		{
			base.gameObject.SetActive(false);
		}
	}

	private void EnableChairs()
	{
		for (int i = 1; i < Chairs.Length; i++)
		{
			Chairs[i].enabled = true;
		}
		base.gameObject.SetActive(true);
	}

	private void DisableChairs()
	{
		for (int i = 1; i < Chairs.Length; i++)
		{
			Chairs[i].enabled = false;
		}
	}

	private void ActivateBenefit()
	{
		if (Subject == 1)
		{
			Yandere.Class.BiologyBonus = 1;
		}
		else if (Subject == 2)
		{
			Yandere.Class.ChemistryBonus = 1;
		}
		else if (Subject == 3)
		{
			Yandere.Class.LanguageBonus = 1;
		}
		else if (Subject == 4)
		{
			Yandere.Class.PsychologyBonus = 1;
		}
		else if (Subject == 5)
		{
			Yandere.Class.PhysicalBonus = 1;
		}
		else if (Subject == 6)
		{
			Yandere.Class.SeductionBonus = 1;
		}
		else if (Subject == 7)
		{
			Yandere.Class.NumbnessBonus = 1;
		}
		else if (Subject == 8)
		{
			Yandere.Class.SocialBonus = 1;
		}
		else if (Subject == 9)
		{
			Yandere.Class.StealthBonus = 1;
		}
		else if (Subject == 10)
		{
			Yandere.Class.SpeedBonus = 1;
		}
		else if (Subject == 11)
		{
			Yandere.Class.EnlightenmentBonus = 1;
		}
		if (Poison != null)
		{
			Poison.Start();
		}
		StudentManager.UpdatePerception();
		Yandere.UpdateNumbness();
		Police.UpdateCorpses();
	}

	private void DeactivateBenefit()
	{
		if (Subject == 1)
		{
			Yandere.Class.BiologyBonus = 0;
		}
		else if (Subject == 2)
		{
			Yandere.Class.ChemistryBonus = 0;
		}
		else if (Subject == 3)
		{
			Yandere.Class.LanguageBonus = 0;
		}
		else if (Subject == 4)
		{
			Yandere.Class.PsychologyBonus = 0;
		}
		else if (Subject == 5)
		{
			Yandere.Class.PhysicalBonus = 0;
		}
		else if (Subject == 6)
		{
			Yandere.Class.SeductionBonus = 0;
		}
		else if (Subject == 7)
		{
			Yandere.Class.NumbnessBonus = 0;
		}
		else if (Subject == 8)
		{
			Yandere.Class.SocialBonus = 0;
		}
		else if (Subject == 9)
		{
			Yandere.Class.StealthBonus = 0;
		}
		else if (Subject == 10)
		{
			Yandere.Class.SpeedBonus = 0;
		}
		else if (Subject == 11)
		{
			Yandere.Class.EnlightenmentBonus = 0;
		}
		if (Poison != null)
		{
			Poison.Start();
		}
		StudentManager.UpdatePerception();
		Yandere.UpdateNumbness();
		Police.UpdateCorpses();
	}

	public void DeactivateAllBenefits()
	{
		Yandere.Class.BiologyBonus = 0;
		Yandere.Class.ChemistryBonus = 0;
		Yandere.Class.LanguageBonus = 0;
		Yandere.Class.PsychologyBonus = 0;
		Yandere.Class.PhysicalBonus = 0;
		Yandere.Class.SeductionBonus = 0;
		Yandere.Class.NumbnessBonus = 0;
		Yandere.Class.SocialBonus = 0;
		Yandere.Class.StealthBonus = 0;
		Yandere.Class.SpeedBonus = 0;
		Yandere.Class.EnlightenmentBonus = 0;
		if (Poison != null)
		{
			Poison.Start();
		}
	}

	private void UpdateHighlight()
	{
		if (Subject < 1)
		{
			Subject = 11;
		}
		else if (Subject > 11)
		{
			Subject = 1;
		}
		Highlight.localPosition = new Vector3(Highlight.localPosition.x, 250f - (float)Subject * 50f, Highlight.localPosition.z);
		DescLabel.text = Descriptions[Subject];
	}
}
