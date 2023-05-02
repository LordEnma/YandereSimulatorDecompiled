using UnityEngine;

public class YakuzaMenuScript : MonoBehaviour
{
	public InputManagerScript InputManager;

	public StalkerYandereScript Yandere;

	public HomeClockScript HomeClock;

	public PromptBarScript PromptBar;

	public UISprite AssassinationMenu;

	public UISprite ContrabandMenu;

	public UISprite KidnappingMenu;

	public UISprite ServicesMenu;

	public AudioClip[] DialogueClip;

	public string[] DialogueText;

	public AudioSource Dialogue;

	public AudioSource Jukebox;

	public UIPanel TimeDayPanel;

	public UIPanel Panel;

	public UILabel ButtonPrompt;

	public UILabel MoneyLabel;

	public Renderer Background;

	public Renderer[] Scales;

	public Transform Yakuza;

	public UILabel Subtitle;

	public int RivalsToDisable;

	public int CutscenePhase = 1;

	public int Menu = 1;

	public float Alpha;

	public float Speed;

	public bool Cutscene;

	public bool Fail;

	public bool Show;

	public UILabel[] BulletLabel;

	public UITexture[] Bullet;

	public AudioClip BulletSFX;

	public int Selected = 1;

	public int Limit = 4;

	public GameObject ConfirmationWindow;

	public GameObject ResultWindow;

	public Transform CrosshairGraphic;

	public Transform Crosshair;

	public UITexture[] RivalPortraits;

	public UILabel[] RivalNameLabels;

	public UILabel ConfirmationLabel;

	public UILabel ResultLabel;

	public Vector3 TargetPosition;

	public Vector3 WobblePosition;

	public Texture BlankPortrait;

	public string[] RivalNames;

	public int TargetSelected = 1;

	public int Column = 1;

	public int Row = 1;

	public int[] Costs;

	public GameObject ItemConfirmationWindow;

	public UILabel ItemConfirmationLabel;

	public int ItemSelected = 1;

	public int ItemLimit = 5;

	public UILabel[] PriceLabel;

	public UISprite[] PriceBG;

	public UILabel[] ItemLabel;

	public UISprite[] ItemBG;

	public string[] ItemName;

	public int[] OriginalItemPrice;

	public int[] ItemPrice;

	public GameObject RansomConfirmationWindow;

	public UILabel RansomConfirmationLabel;

	public UITexture[] RansomPortrait;

	public UILabel PrisonerLabel;

	public int[] KidnapTargets;

	public int[] PrisonerList;

	public int[] Ransom;

	public int Prisoners;

	public int Payout;

	public AudioClip[] Greeting;

	public AudioClip AssassinationPurchase;

	public AudioClip OpenAssassinationMenu;

	public AudioClip ContrabandPurchase;

	public AudioClip OpenContrabandMenu;

	public AudioClip Confirmation;

	public AudioClip BackOut;

	public AudioClip Exit;

	public int[] RansomIDs;

	private void Start()
	{
		UpdateMoneyLabel();
		RansomConfirmationWindow.SetActive(value: false);
		ConfirmationWindow.SetActive(value: false);
		ResultWindow.SetActive(value: false);
		AssassinationMenu.alpha = 0f;
		ContrabandMenu.alpha = 0f;
		KidnappingMenu.alpha = 0f;
		ServicesMenu.alpha = 1f;
		UpdateRansomPortraits();
		UpdateCrosshair();
		UpdateBullet();
		UpdateItem();
		int i = 1;
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_1.png");
		for (; i < 11; i++)
		{
			wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_" + (i + 10) + ".png");
			RivalPortraits[i].mainTexture = wWW.texture;
			if (StudentGlobals.GetStudentDead(10 + i) || StudentGlobals.GetStudentKidnapped(10 + i) || StudentGlobals.GetStudentArrested(10 + i))
			{
				RivalPortraits[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
			RivalNameLabels[i].text = RivalNames[i];
			RivalPortraits[i].transform.parent.localEulerAngles = new Vector3(0f, 0f, Random.Range(-5f, 5f));
		}
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_30.png");
		RansomPortrait[30].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_35.png");
		RansomPortrait[35].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_40.png");
		RansomPortrait[40].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_45.png");
		RansomPortrait[45].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_50.png");
		RansomPortrait[50].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_55.png");
		RansomPortrait[55].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_60.png");
		RansomPortrait[60].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_65.png");
		RansomPortrait[65].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_70.png");
		RansomPortrait[70].mainTexture = wWW.texture;
		wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits1989/Student_75.png");
		RansomPortrait[75].mainTexture = wWW.texture;
		for (i = DateGlobals.Week + 1; i < 11; i++)
		{
			RivalPortraits[i].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			RivalPortraits[i].mainTexture = BlankPortrait;
			RivalNameLabels[i].text = "?????";
		}
		Panel.alpha = 0f;
		Alpha = 0f;
		for (int j = 1; j < Scales.Length; j++)
		{
			Scales[j].material.color = new Color(1f, 0f, 0f, Alpha);
		}
		Background.material.color = new Color(1f, 0f, 0f, 0f);
		if (GameGlobals.YakuzaPhase == 0 || !HomeGlobals.Night || StudentGlobals.GetStudentDead(79) || ChallengeGlobals.NoInfo)
		{
			base.gameObject.SetActive(value: false);
			ButtonPrompt.alpha = 0f;
			if (StudentGlobals.GetStudentDead(79))
			{
				Yakuza.gameObject.SetActive(value: false);
			}
		}
		CountPrisoners();
		if (Prisoners == 0)
		{
			PrisonerLabel.text = "Come back after kidnapping one of these girls.";
		}
		else if (Prisoners == 1)
		{
			PrisonerLabel.text = "One of these girls is currently in your basement.";
		}
		else
		{
			PrisonerLabel.text = "Some of these girls are currently in your basement.";
		}
		OriginalItemPrice[3] += DateGlobals.Week * 100;
		OriginalItemPrice[5] += DateGlobals.Week * 100;
		ItemPrice[3] += DateGlobals.Week * 100;
		ItemPrice[5] += DateGlobals.Week * 100;
	}

	private void Update()
	{
		if (Show)
		{
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 1f, Time.deltaTime);
			Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime);
			for (int i = 1; i < Scales.Length; i++)
			{
				Scales[i].material.color = new Color(1f, 0f, 0f, Alpha);
			}
			Background.material.color = new Color(1f, 0f, 0f, Alpha * 0.25f);
			if (Menu == 1)
			{
				ServicesMenu.alpha = Mathf.MoveTowards(ServicesMenu.alpha, 1f, Time.deltaTime * 10f);
				ContrabandMenu.alpha = Mathf.MoveTowards(ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				KidnappingMenu.alpha = Mathf.MoveTowards(KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				AssassinationMenu.alpha = Mathf.MoveTowards(AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (ServicesMenu.alpha == 1f)
				{
					if (InputManager.TappedDown)
					{
						Selected++;
						UpdateBullet();
					}
					else if (InputManager.TappedUp)
					{
						Selected--;
						UpdateBullet();
					}
					if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						if (Selected == 1)
						{
							if (!GameGlobals.IntroducedAbduction)
							{
								GameGlobals.IntroducedAbduction = true;
								GameGlobals.YakuzaPhase = 6;
								CutscenePhase = 24;
								StartCutscene();
								Show = false;
							}
							else
							{
								AudioSource.PlayClipAtPoint(OpenAssassinationMenu, Yandere.MainCamera.transform.position);
								PromptBar.ClearButtons();
								PromptBar.Label[0].text = "Abduct";
								PromptBar.Label[1].text = "Back";
								PromptBar.Label[4].text = "Change Selection";
								PromptBar.Label[5].text = "Change Selection";
								PromptBar.UpdateButtons();
								Menu = 2;
							}
						}
						else if (Selected == 2)
						{
							AudioSource.PlayClipAtPoint(OpenContrabandMenu, Yandere.MainCamera.transform.position);
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Purchase";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[5].text = "Change Selection";
							PromptBar.UpdateButtons();
							Menu = 3;
							UpdateItem();
						}
						else if (Selected == 3)
						{
							if (!GameGlobals.IntroducedRansom)
							{
								GameGlobals.IntroducedRansom = true;
								GameGlobals.YakuzaPhase = 8;
								CutscenePhase = 33;
								StartCutscene();
								Show = false;
							}
							else
							{
								PromptBar.ClearButtons();
								if (Prisoners > 0)
								{
									PromptBar.Label[0].text = "Sell";
								}
								PromptBar.Label[1].text = "Back";
								PromptBar.UpdateButtons();
								Menu = 4;
							}
						}
						else if (Selected == 4)
						{
							AudioSource.PlayClipAtPoint(Exit, Yandere.MainCamera.transform.position);
							Quit();
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						AudioSource.PlayClipAtPoint(Exit, Yandere.MainCamera.transform.position);
						Quit();
					}
				}
			}
			else if (Menu == 2)
			{
				ServicesMenu.alpha = Mathf.MoveTowards(ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				ContrabandMenu.alpha = Mathf.MoveTowards(ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				KidnappingMenu.alpha = Mathf.MoveTowards(KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				AssassinationMenu.alpha = Mathf.MoveTowards(AssassinationMenu.alpha, 1f, Time.deltaTime * 10f);
				if (AssassinationMenu.alpha == 1f)
				{
					if (!ConfirmationWindow.activeInHierarchy && !ResultWindow.activeInHierarchy)
					{
						if (InputManager.TappedDown || InputManager.TappedUp)
						{
							Row++;
							UpdateCrosshair();
						}
						if (InputManager.TappedRight)
						{
							Column++;
							UpdateCrosshair();
						}
						else if (InputManager.TappedLeft)
						{
							Column--;
							UpdateCrosshair();
						}
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							if (RivalPortraits[TargetSelected].color == new Color(1f, 1f, 1f, 1f))
							{
								AudioSource.PlayClipAtPoint(Confirmation, Yandere.MainCamera.transform.position);
								ConfirmationWindow.SetActive(value: true);
								ConfirmationLabel.text = "Do you want " + RivalNames[TargetSelected] + " to disappear forever? It will cost $" + Costs[TargetSelected] + ".";
								PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Exit";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							GameGlobals.YakuzaPhase = 100;
							Menu = 1;
						}
					}
					else if (ConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							if (PlayerGlobals.Money > (float)Costs[TargetSelected])
							{
								AudioSource.PlayClipAtPoint(AssassinationPurchase, Yandere.MainCamera.transform.position);
								StudentGlobals.SetStudentKidnapped(TargetSelected + 10, value: true);
								StudentGlobals.SetStudentMissing(TargetSelected + 10, value: true);
								StudentGlobals.SetStudentKidnapped(TargetSelected + 10, value: true);
								StudentGlobals.SetStudentMissing(TargetSelected + 10, value: true);
								if (TargetSelected == DateGlobals.Week)
								{
									GameGlobals.RivalEliminationID = 11;
									GameGlobals.SpecificEliminationID = 12;
								}
								ResultLabel.text = "This girl will be abducted before school tomorrow.";
								RivalPortraits[TargetSelected].color = new Color(0.5f, 0.5f, 0.5f, 1f);
								PlayerGlobals.Money -= Costs[TargetSelected];
								UpdateMoneyLabel();
								GameGlobals.AbductionTarget = TargetSelected + 10;
								GameGlobals.ShowAbduction = true;
							}
							else
							{
								ResultLabel.text = "You don't have enough money to pay for her abduction!";
								Fail = true;
							}
							ConfirmationWindow.SetActive(value: false);
							ResultWindow.SetActive(value: true);
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							AudioSource.PlayClipAtPoint(BackOut, Yandere.MainCamera.transform.position);
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Exit";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							ConfirmationWindow.SetActive(value: false);
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Confirm";
						PromptBar.Label[1].text = "Exit";
						PromptBar.Label[4].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						ResultWindow.SetActive(value: false);
						if (!Fail && GameGlobals.YakuzaPhase == 6)
						{
							GameGlobals.YakuzaPhase = 7;
							CutscenePhase = 28;
							StartCutscene();
							Show = false;
						}
						Fail = false;
					}
				}
			}
			else if (Menu == 3)
			{
				ServicesMenu.alpha = Mathf.MoveTowards(ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				ContrabandMenu.alpha = Mathf.MoveTowards(ContrabandMenu.alpha, 1f, Time.deltaTime * 10f);
				KidnappingMenu.alpha = Mathf.MoveTowards(KidnappingMenu.alpha, 0f, Time.deltaTime * 10f);
				AssassinationMenu.alpha = Mathf.MoveTowards(AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (ContrabandMenu.alpha == 1f)
				{
					if (!ItemConfirmationWindow.activeInHierarchy)
					{
						if (InputManager.TappedDown)
						{
							ItemSelected++;
							UpdateItem();
						}
						else if (InputManager.TappedUp)
						{
							ItemSelected--;
							UpdateItem();
						}
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							if (GameGlobals.YakuzaPhase < 4)
							{
								if (ItemSelected == 1)
								{
									PlayerGlobals.BoughtLockpick = true;
								}
								else if (ItemSelected == 2)
								{
									PlayerGlobals.FakeID = true;
								}
								else if (ItemSelected == 3)
								{
									PlayerGlobals.BoughtNarcotics = true;
								}
								else if (ItemSelected == 4)
								{
									PlayerGlobals.BoughtPoison = true;
								}
								else if (ItemSelected == 5)
								{
									PlayerGlobals.BoughtExplosive = true;
								}
								GameGlobals.YakuzaPhase = 4;
								CutscenePhase = 12;
								StartCutscene();
								Show = false;
							}
							else if (ItemBG[ItemSelected].alpha == 1f)
							{
								AudioSource.PlayClipAtPoint(Confirmation, Yandere.MainCamera.transform.position);
								ItemConfirmationLabel.text = "Would you like to purchase " + ItemName[ItemSelected] + " for $" + ItemPrice[ItemSelected] + "?";
								ItemConfirmationWindow.SetActive(value: true);
								PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							if (GameGlobals.YakuzaPhase < 4)
							{
								GameGlobals.YakuzaPhase = 2;
								CutscenePhase = 8;
								StartCutscene();
								Show = false;
							}
							else
							{
								PromptBar.ClearButtons();
								PromptBar.Label[0].text = "Confirm";
								PromptBar.Label[1].text = "Exit";
								PromptBar.Label[4].text = "Change Selection";
								PromptBar.UpdateButtons();
								PromptBar.Show = true;
								Menu = 1;
							}
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						AudioSource.PlayClipAtPoint(ContrabandPurchase, Yandere.MainCamera.transform.position);
						if (ItemSelected == 1)
						{
							PlayerGlobals.BoughtLockpick = true;
						}
						else if (ItemSelected == 2)
						{
							PlayerGlobals.FakeID = true;
						}
						else if (ItemSelected == 3)
						{
							PlayerGlobals.BoughtNarcotics = true;
						}
						else if (ItemSelected == 4)
						{
							PlayerGlobals.BoughtPoison = true;
						}
						else if (ItemSelected == 5)
						{
							PlayerGlobals.BoughtExplosive = true;
						}
						PlayerGlobals.Money -= ItemPrice[ItemSelected];
						UpdateMoneyLabel();
						UpdateItem();
						ItemConfirmationWindow.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Purchase";
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[5].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						AudioSource.PlayClipAtPoint(BackOut, Yandere.MainCamera.transform.position);
						ItemConfirmationWindow.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Purchase";
						PromptBar.Label[1].text = "Back";
						PromptBar.Label[5].text = "Change Selection";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
				}
			}
			else if (Menu == 4)
			{
				ServicesMenu.alpha = Mathf.MoveTowards(ServicesMenu.alpha, 0f, Time.deltaTime * 10f);
				ContrabandMenu.alpha = Mathf.MoveTowards(ContrabandMenu.alpha, 0f, Time.deltaTime * 10f);
				KidnappingMenu.alpha = Mathf.MoveTowards(KidnappingMenu.alpha, 1f, Time.deltaTime * 10f);
				AssassinationMenu.alpha = Mathf.MoveTowards(AssassinationMenu.alpha, 0f, Time.deltaTime * 10f);
				if (KidnappingMenu.alpha == 1f)
				{
					if (!RansomConfirmationWindow.activeInHierarchy)
					{
						if (Input.GetButtonDown(InputNames.Xbox_A))
						{
							if (Prisoners > 0)
							{
								RansomConfirmationWindow.SetActive(value: true);
								if (Prisoners == 1)
								{
									RansomConfirmationLabel.text = "Give a kidnapped prisoner to the yakuza in exchange for $" + Payout + "?";
								}
								else
								{
									RansomConfirmationLabel.text = "Give some kidnapped prisoners to the yakuza in exchange for $" + Payout + "?";
								}
								PromptBar.Show = false;
							}
						}
						else if (Input.GetButtonDown(InputNames.Xbox_B))
						{
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Exit";
							PromptBar.Label[4].text = "Change Selection";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							Menu = 1;
						}
					}
					else if (Input.GetButtonDown(InputNames.Xbox_A))
					{
						AudioSource.PlayClipAtPoint(ContrabandPurchase, Yandere.MainCamera.transform.position);
						while (Prisoners > 0)
						{
							StudentGlobals.SetStudentKidnapped(PrisonerList[Prisoners], value: false);
							StudentGlobals.SetStudentMissing(PrisonerList[Prisoners], value: false);
							StudentGlobals.SetStudentRansomed(PrisonerList[Prisoners], value: true);
							StudentGlobals.SetStudentBroken(PrisonerList[Prisoners], value: true);
							Prisoners--;
						}
						PlayerGlobals.Money += Payout;
						UpdateMoneyLabel();
						if (PlayerGlobals.Money > 1000f)
						{
							if (!GameGlobals.Debug)
							{
								PlayerPrefs.SetInt("RichGirl", 1);
							}
							if (!GameGlobals.Debug)
							{
								PlayerPrefs.SetInt("a", 1);
							}
						}
						DeprisonStudents();
						CountPrisoners();
						UpdateRansomPortraits();
						RansomConfirmationWindow.SetActive(value: false);
						PrisonerLabel.text = "Come back after kidnapping one of these girls.";
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
					}
					else if (Input.GetButtonDown(InputNames.Xbox_B))
					{
						AudioSource.PlayClipAtPoint(BackOut, Yandere.MainCamera.transform.position);
						PromptBar.ClearButtons();
						PromptBar.Label[0].text = "Sell";
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						PromptBar.Show = true;
						RansomConfirmationWindow.SetActive(value: false);
					}
				}
			}
			BulletLabel[Selected].transform.parent.localScale = Vector3.Lerp(BulletLabel[Selected].transform.parent.localScale, new Vector3(1.05f, 1.05f, 1.05f), Time.deltaTime * 10f);
			for (int j = 1; j < Bullet.Length; j++)
			{
				if (j != Selected)
				{
					BulletLabel[j].transform.parent.localScale = Vector3.Lerp(BulletLabel[j].transform.parent.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				}
			}
			Crosshair.localPosition = Vector3.Lerp(Crosshair.localPosition, TargetPosition, Time.deltaTime * 10f);
			if (CrosshairGraphic.localPosition != WobblePosition)
			{
				CrosshairGraphic.localPosition = Vector3.MoveTowards(CrosshairGraphic.localPosition, WobblePosition, Time.deltaTime * 50f);
				if (CrosshairGraphic.localPosition == WobblePosition)
				{
					WobblePosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
				}
			}
			else
			{
				WobblePosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
			}
			return;
		}
		if (!Cutscene)
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0f, Time.deltaTime);
		}
		else
		{
			Jukebox.volume = Mathf.MoveTowards(Jukebox.volume, 0.1f, Time.deltaTime);
		}
		Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime);
		Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		for (int k = 1; k < Scales.Length; k++)
		{
			Scales[k].material.color = new Color(1f, 0f, 0f, Alpha);
		}
		Background.material.color = new Color(1f, 0f, 0f, Alpha * 0.25f);
		if (!Cutscene)
		{
			if (Vector3.Distance(Yandere.transform.position, Yakuza.position) < 2f)
			{
				ButtonPrompt.alpha = Mathf.MoveTowards(ButtonPrompt.alpha, 1f, Time.deltaTime * 2f);
				if (Input.GetButtonDown(InputNames.Xbox_A) && Alpha == 0f)
				{
					if (GameGlobals.YakuzaPhase == 1)
					{
						CutscenePhase = 1;
						StartCutscene();
						return;
					}
					if (GameGlobals.YakuzaPhase == 3)
					{
						CutscenePhase = 10;
						StartCutscene();
						return;
					}
					if (GameGlobals.YakuzaPhase == 5)
					{
						CutscenePhase = 16;
						StartCutscene();
						return;
					}
					int num = 0;
					num = Random.Range(1, 4);
					AudioSource.PlayClipAtPoint(Greeting[num], Yandere.MainCamera.transform.position);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Confirm";
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
					Yandere.RPGCamera.enabled = false;
					Yandere.CanMove = false;
					Jukebox.volume = 1f;
					Jukebox.Play();
					TimeDayPanel.alpha = 0f;
					Show = true;
				}
			}
			else
			{
				ButtonPrompt.alpha = Mathf.MoveTowards(ButtonPrompt.alpha, 0f, Time.deltaTime * 2f);
			}
			return;
		}
		if (!Jukebox.isPlaying)
		{
			Jukebox.Play();
		}
		Speed += Time.deltaTime;
		Yandere.MainCamera.transform.position = Vector3.Lerp(Yandere.MainCamera.transform.position, new Vector3(-2.25f, 1.5f, -5.5f), Time.deltaTime * Speed * 0.01f);
		if (Dialogue.isPlaying && !Input.GetButtonDown(InputNames.Xbox_A))
		{
			return;
		}
		CutscenePhase++;
		if (GameGlobals.YakuzaPhase == 1)
		{
			if (CutscenePhase < 8)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				SummonContrabandMenu();
			}
		}
		else if (GameGlobals.YakuzaPhase == 2)
		{
			if (CutscenePhase < 10)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				GameGlobals.YakuzaPhase = 3;
				Quit();
			}
		}
		else if (GameGlobals.YakuzaPhase == 3)
		{
			if (CutscenePhase < 12)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				SummonContrabandMenu();
			}
		}
		else if (GameGlobals.YakuzaPhase == 4)
		{
			if (CutscenePhase < 16)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				GameGlobals.YakuzaPhase = 5;
				Quit();
			}
		}
		else if (GameGlobals.YakuzaPhase == 5)
		{
			if (CutscenePhase < 24)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				GameGlobals.YakuzaPhase = 100;
				SummonServicesMenu();
			}
		}
		else if (GameGlobals.YakuzaPhase == 6)
		{
			if (CutscenePhase < 28)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				SummonAssassinationMenu();
			}
		}
		else if (GameGlobals.YakuzaPhase == 7)
		{
			if (CutscenePhase < 33)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				GameGlobals.YakuzaPhase = 100;
				Quit();
			}
		}
		else if (GameGlobals.YakuzaPhase == 8)
		{
			if (CutscenePhase < 41)
			{
				Dialogue.clip = DialogueClip[CutscenePhase];
				Dialogue.Play();
				Subtitle.text = DialogueText[CutscenePhase];
			}
			else
			{
				GameGlobals.YakuzaPhase = 100;
				SummonKidnappingMenu();
			}
		}
	}

	private void UpdateBullet()
	{
		if (Selected > Limit)
		{
			Selected = 1;
		}
		else if (Selected < 1)
		{
			Selected = Limit;
		}
		for (int i = 1; i < Bullet.Length; i++)
		{
			BulletLabel[i].color = new Color(1f, 1f, 1f, 1f);
			Bullet[i].color = new Color(0f, 0f, 0f, 1f);
		}
		BulletLabel[Selected].color = new Color(0f, 0f, 0f, 1f);
		Bullet[Selected].color = new Color(1f, 1f, 1f, 1f);
		if (Show)
		{
			AudioSource.PlayClipAtPoint(BulletSFX, Camera.main.transform.position);
		}
	}

	private void UpdateCrosshair()
	{
		if (Row > 2)
		{
			Row = 1;
		}
		else if (Row < 1)
		{
			Row = 2;
		}
		if (Column > 5)
		{
			Column = 1;
		}
		else if (Column < 1)
		{
			Column = 5;
		}
		TargetPosition = new Vector3(-1500 + 500 * Column, 340 - (Row - 1) * 600, 0f);
		TargetSelected = Column + (Row - 1) * 5;
	}

	private void UpdateItem()
	{
		if (ItemSelected > ItemLimit)
		{
			ItemSelected = 1;
		}
		else if (ItemSelected < 1)
		{
			ItemSelected = ItemLimit;
		}
		for (int i = 1; i < ItemBG.Length; i++)
		{
			ItemLabel[i].color = new Color(1f, 1f, 1f, 1f);
			ItemBG[i].color = new Color(0f, 0f, 0f, 1f);
			PriceLabel[i].color = new Color(1f, 1f, 1f, 1f);
			PriceBG[i].color = new Color(0f, 0f, 0f, 1f);
		}
		ItemLabel[ItemSelected].color = new Color(0f, 0f, 0f, 1f);
		ItemBG[ItemSelected].color = new Color(1f, 1f, 1f, 1f);
		PriceLabel[ItemSelected].color = new Color(0f, 0f, 0f, 1f);
		PriceBG[ItemSelected].color = new Color(1f, 1f, 1f, 1f);
		if (PlayerGlobals.BoughtLockpick)
		{
			ItemLabel[1].alpha = 0.5f;
			ItemBG[1].alpha = 0.5f;
			PriceLabel[1].alpha = 0.5f;
			PriceBG[1].alpha = 0.5f;
		}
		if (PlayerGlobals.FakeID)
		{
			ItemLabel[2].alpha = 0.5f;
			ItemBG[2].alpha = 0.5f;
			PriceLabel[2].alpha = 0.5f;
			PriceBG[2].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtNarcotics)
		{
			ItemLabel[3].alpha = 0.5f;
			ItemBG[3].alpha = 0.5f;
			PriceLabel[3].alpha = 0.5f;
			PriceBG[3].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtPoison)
		{
			ItemLabel[4].alpha = 0.5f;
			ItemBG[4].alpha = 0.5f;
			PriceLabel[4].alpha = 0.5f;
			PriceBG[4].alpha = 0.5f;
		}
		if (PlayerGlobals.BoughtExplosive)
		{
			ItemLabel[5].alpha = 0.5f;
			ItemBG[5].alpha = 0.5f;
			PriceLabel[5].alpha = 0.5f;
			PriceBG[5].alpha = 0.5f;
		}
		for (int i = 1; i < ItemBG.Length; i++)
		{
			if (GameGlobals.YakuzaPhase < 4)
			{
				ItemPrice[i] = 0;
				PriceLabel[i].text = "FREE";
			}
			else
			{
				ItemPrice[i] = OriginalItemPrice[i];
				PriceLabel[i].text = "$" + ItemPrice[i];
			}
			if (PlayerGlobals.Money < (float)ItemPrice[i])
			{
				ItemLabel[i].alpha = 0.5f;
				ItemBG[i].alpha = 0.5f;
				PriceLabel[i].alpha = 0.5f;
				PriceBG[i].alpha = 0.5f;
			}
		}
	}

	private void UpdateRansomPortraits()
	{
		for (int i = 1; i < RansomIDs.Length; i++)
		{
			if (StudentGlobals.GetStudentRansomed(RansomIDs[i]))
			{
				RansomPortrait[RansomIDs[i]].color = new Color(0.5f, 0.5f, 0.5f, 1f);
			}
		}
	}

	private void Quit()
	{
		Yandere.RPGCamera.enabled = true;
		Yandere.CanMove = true;
		TimeDayPanel.alpha = 1f;
		Subtitle.text = "";
		Cutscene = false;
		Show = false;
		Menu = 1;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		HomeClock.UpdateMoneyLabel();
	}

	private void StartCutscene()
	{
		Yandere.MyAnimation.CrossFade(Yandere.IdleAnim);
		Yandere.RPGCamera.enabled = false;
		Yandere.CanMove = false;
		Yandere.MainCamera.transform.position = new Vector3(-2.25f, 0.1f, -5.5f);
		Yandere.MainCamera.transform.eulerAngles = new Vector3(0f, 30f, 0f);
		Yandere.transform.position = new Vector3(-2f, 0f, -4f);
		Yandere.transform.eulerAngles = new Vector3(0f, 150f, 0f);
		ButtonPrompt.alpha = 0f;
		TimeDayPanel.alpha = 0f;
		Dialogue.clip = DialogueClip[CutscenePhase];
		Dialogue.Play();
		Subtitle.text = DialogueText[CutscenePhase];
		Cutscene = true;
		Speed = 0f;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		if (!GameGlobals.Debug)
		{
			PlayerPrefs.SetInt("Yakuza", 1);
			PlayerPrefs.SetInt("a", 1);
		}
	}

	private void SummonContrabandMenu()
	{
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Purchase";
		PromptBar.Label[1].text = "Back";
		PromptBar.Label[5].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		MoneyLabel.transform.parent.gameObject.SetActive(value: false);
		ContrabandMenu.alpha = 1f;
		ServicesMenu.alpha = 0f;
		Jukebox.volume = 1f;
		Jukebox.Play();
		Subtitle.text = "";
		Cutscene = false;
		Show = true;
		Menu = 3;
	}

	private void SummonAssassinationMenu()
	{
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Abduct";
		PromptBar.Label[1].text = "Back";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.Label[5].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		MoneyLabel.transform.parent.gameObject.SetActive(value: true);
		AssassinationMenu.alpha = 1f;
		ServicesMenu.alpha = 0f;
		Jukebox.volume = 1f;
		Jukebox.Play();
		Subtitle.text = "";
		Cutscene = false;
		Show = true;
		Menu = 2;
	}

	private void SummonServicesMenu()
	{
		PromptBar.ClearButtons();
		PromptBar.Label[0].text = "Confirm";
		PromptBar.Label[1].text = "Exit";
		PromptBar.Label[4].text = "Change Selection";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		MoneyLabel.transform.parent.gameObject.SetActive(value: true);
		AssassinationMenu.alpha = 0f;
		ServicesMenu.alpha = 1f;
		Jukebox.volume = 1f;
		Jukebox.Play();
		Subtitle.text = "";
		Cutscene = false;
		Show = true;
		Menu = 1;
	}

	private void SummonKidnappingMenu()
	{
		PromptBar.ClearButtons();
		if (Prisoners > 0)
		{
			PromptBar.Label[0].text = "Sell";
		}
		PromptBar.Label[1].text = "Back";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
		MoneyLabel.transform.parent.gameObject.SetActive(value: true);
		AssassinationMenu.alpha = 0f;
		ServicesMenu.alpha = 1f;
		Jukebox.volume = 1f;
		Jukebox.Play();
		Subtitle.text = "";
		Cutscene = false;
		Show = true;
		Menu = 4;
	}

	private void UpdateMoneyLabel()
	{
		MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2");
	}

	private void CountPrisoners()
	{
		if (StudentGlobals.Prisoners == 0)
		{
			Prisoners = 0;
			return;
		}
		for (int i = 1; i < 11; i++)
		{
			if (StudentGlobals.Prisoner1 == KidnapTargets[i] || StudentGlobals.Prisoner2 == KidnapTargets[i] || StudentGlobals.Prisoner3 == KidnapTargets[i] || StudentGlobals.Prisoner4 == KidnapTargets[i] || StudentGlobals.Prisoner5 == KidnapTargets[i] || StudentGlobals.Prisoner6 == KidnapTargets[i] || StudentGlobals.Prisoner7 == KidnapTargets[i] || StudentGlobals.Prisoner8 == KidnapTargets[i] || StudentGlobals.Prisoner9 == KidnapTargets[i] || StudentGlobals.Prisoner10 == KidnapTargets[i])
			{
				if (StudentGlobals.GetStudentHealth(KidnapTargets[i]) > 0)
				{
					Payout += Ransom[KidnapTargets[i]];
					Prisoners++;
					Debug.Log("We have counted " + Prisoners + " prisoners.");
					PrisonerList[Prisoners] = KidnapTargets[i];
				}
				else
				{
					Debug.Log("One of the Yakuza's desired girls is a prisoner in our basement, but she's dead.");
				}
			}
		}
	}

	private void DeprisonStudents()
	{
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner1))
		{
			StudentGlobals.Prisoner1 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner2))
		{
			StudentGlobals.Prisoner2 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner3))
		{
			StudentGlobals.Prisoner3 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner4))
		{
			StudentGlobals.Prisoner4 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner5))
		{
			StudentGlobals.Prisoner5 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner6))
		{
			StudentGlobals.Prisoner6 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner7))
		{
			StudentGlobals.Prisoner7 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner8))
		{
			StudentGlobals.Prisoner8 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner9))
		{
			StudentGlobals.Prisoner9 = 0;
			StudentGlobals.Prisoners--;
		}
		if (StudentGlobals.GetStudentRansomed(StudentGlobals.Prisoner10))
		{
			StudentGlobals.Prisoner10 = 0;
			StudentGlobals.Prisoners--;
		}
	}
}
