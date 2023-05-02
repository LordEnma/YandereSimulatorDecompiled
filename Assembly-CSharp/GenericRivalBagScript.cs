using UnityEngine;

public class GenericRivalBagScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public GenericRivalEventScript Event;

	public PromptBarScript PromptBar;

	public StudentScript Rival;

	public PromptScript Prompt;

	public JsonScript JSON;

	public GameObject MagazineButton;

	public GameObject DiaryButton;

	public GameObject Window;

	public Transform Highlight;

	public Transform Magazine;

	public Transform Diary;

	public UILabel DiaryLabelRight;

	public UILabel DiaryLabelLeft;

	public UILabel[] Label;

	public UITexture DiaryBG;

	public Texture[] DiaryTextures;

	public bool BorrowedBook;

	public bool Alcohol;

	public bool Condoms;

	public bool Cigarettes;

	public bool StolenRing;

	public bool AnswerSheet;

	public bool Narcotics;

	public bool ShowMagazine;

	public bool BentoStolen;

	public bool ShowDiary;

	public bool NoBento;

	public int Selected;

	public int Limit;

	public int Menu;

	public int[] RivalOpinions;

	public string[] Subjects;

	public string[] RivalDislikes;

	public string[] RivalLikes;

	public int Dislikes = 1;

	public int Likes = 1;

	public int[] DesiredHairstyles;

	public int[] DesiredAccessories;

	public int[] DesiredEyewears;

	public int[] DesiredSkins;

	public string[] DesiredHairColors;

	public bool[] DesiredJewelries;

	public int[] DesiredTraits;

	public string[] DiaryEntryLeft;

	public string[] DiaryEntryRight;

	public int DesiredHairstyle;

	public int DesiredAccessory;

	public int DesiredEyewear;

	public int DesiredSkin;

	public string DesiredHairColor;

	public bool DesiredJewelry;

	public int DesiredTrait;

	public string DesiredHairstyleText;

	public string DesiredAccessoryText;

	public string DesiredEyewearText;

	public string DesiredSkinText;

	public string DesiredHairColorText;

	public string DesiredJewelryText;

	public string DesiredTraitText;

	public bool Initialized;

	public int Page = 1;

	public Vector3 CorrectPosition;

	public Vector3 CorrectRotation;

	public bool EmeticStatus;

	public bool TranquilStatus;

	public bool HeadacheStatus;

	public bool LethalStatus;

	public bool TamperedStatus;

	public GameObject TanHearts;

	public GameObject PiercingHearts;

	public GameObject DarkHairHearts;

	public GameObject GlassesHearts;

	public GameObject BandanaHearts;

	public GameObject JewleryHearts;

	public GameObject SunglassesHearts;

	public GameObject PonytailHearts;

	public GameObject SlickHearts;

	public GameObject CourageHearts;

	public GameObject SmartHearts;

	public GameObject StrongHearts;

	public GameObject QuoteBoxes;

	public Transform Pivot;

	public UITexture[] Pages;

	public void Start()
	{
		if (!Initialized)
		{
			GrabRivalInfo();
			Magazine.gameObject.SetActive(value: false);
			MagazineButton.SetActive(value: false);
			Magazine.localPosition = new Vector3(-700f, -1470f, 0f);
			Magazine.localEulerAngles = new Vector3(0f, 0f, 45f);
			Diary.gameObject.SetActive(value: false);
			DiaryButton.SetActive(value: false);
			Diary.localPosition = new Vector3(-700f, -1470f, 0f);
			Diary.localEulerAngles = new Vector3(0f, 0f, 45f);
			base.gameObject.SetActive(value: false);
			Window.SetActive(value: false);
			Prompt.enabled = false;
			Prompt.Hide();
			Initialized = true;
		}
	}

	private void Update()
	{
		if (!Window.activeInHierarchy)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					Prompt.Yandere.RPGCamera.enabled = false;
					Prompt.Yandere.CanMove = false;
					Time.timeScale = 0.0001f;
					Window.SetActive(value: true);
					Menu = 1;
					UpdateMenuLabels();
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Confirm";
					PromptBar.Label[4].text = "Change Selection";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "Can't do that! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			return;
		}
		if (InputManager.TappedDown)
		{
			Selected++;
			UpdateHighlight();
		}
		else if (InputManager.TappedUp)
		{
			Selected--;
			UpdateHighlight();
		}
		if (Input.GetButtonDown(InputNames.Xbox_A))
		{
			if (Menu == 1)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						Menu = 2;
						UpdateMenuLabels();
					}
					else if (Selected == 2)
					{
						Menu = 3;
						UpdateMenuLabels();
					}
					else if (Selected == 3)
					{
						Menu = 4;
						UpdateMenuLabels();
					}
					else if (Selected == 4)
					{
						CloseWindow();
					}
				}
			}
			else if (Menu == 2)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						Debug.Log("The player has stolen the book that the rival borrowed from Senpai.");
						BorrowedBook = false;
						Event.Sabotage();
						ScheduleBlock obj = Rival.ScheduleBlocks[4];
						obj.destination = "Search Patrol";
						obj.action = "Search Patrol";
						Rival.GetDestinations();
						Debug.Log("The rival's routine should now be adjusted to ''Search'' at lunchtime.");
						UpdateMenuLabels();
					}
					else if (Selected == 2)
					{
						MagazineButton.SetActive(value: true);
						Highlight.gameObject.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						Menu = 5;
						UpdateMenuLabels();
					}
					else if (Selected == 3)
					{
						DiaryButton.SetActive(value: true);
						GrabRivalInfo();
						Highlight.gameObject.SetActive(value: false);
						PromptBar.ClearButtons();
						PromptBar.Label[1].text = "Back";
						PromptBar.UpdateButtons();
						Menu = 6;
						UpdateMenuLabels();
						for (int i = 1; i < 26; i++)
						{
							Prompt.Yandere.StudentManager.SetTopicLearnedByStudent(i, Prompt.Yandere.StudentManager.RivalID, boolean: true);
						}
						Prompt.Yandere.NotificationManager.CustomText = "Learned the rival's likes & dislikes";
						Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else if (Selected == 4)
					{
						Menu = 1;
						UpdateMenuLabels();
					}
				}
			}
			else if (Menu == 3)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						Prompt.Yandere.Inventory.EmeticPoisons--;
						Rival.MyBento.Tampered = true;
						Rival.MyBento.Emetic = true;
					}
					else if (Selected == 2)
					{
						Prompt.Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Prompt.Yandere.Numbness;
						Prompt.Yandere.Inventory.LethalPoisons--;
						Rival.MyBento.Tampered = true;
						Rival.MyBento.Lethal = true;
					}
					else if (Selected == 3)
					{
						Prompt.Yandere.Inventory.HeadachePoisons--;
						Rival.MyBento.Tampered = true;
						Rival.MyBento.Headache = true;
					}
					else if (Selected == 4)
					{
						Prompt.Yandere.Inventory.SedativePoisons--;
						Rival.MyBento.Tampered = true;
						Rival.MyBento.Tranquil = true;
					}
					else if (Selected == 5)
					{
						if (Rival.ScheduleBlocks[4].action != "Search Patrol")
						{
							Debug.Log("The current rival should spend her lunchtime looking sad.");
							Rival.ScheduleBlocks[4].action = "Shamed";
							Rival.GetDestinations();
						}
						BentoStolen = true;
					}
					Menu = 1;
					UpdateMenuLabels();
				}
			}
			else if (Menu == 4)
			{
				if (Label[Selected].color.a == 1f)
				{
					if (Selected == 1)
					{
						Prompt.Yandere.Inventory.Sake = false;
						Alcohol = true;
					}
					else if (Selected == 2)
					{
						Prompt.Yandere.Inventory.Condoms = false;
						Condoms = true;
					}
					else if (Selected == 3)
					{
						Prompt.Yandere.Inventory.Cigs = false;
						Cigarettes = true;
					}
					else if (Selected == 4)
					{
						Prompt.Yandere.Inventory.Ring = false;
						StolenRing = true;
					}
					else if (Selected == 5)
					{
						Prompt.Yandere.Inventory.AnswerSheet = false;
						AnswerSheet = true;
					}
					else if (Selected == 6)
					{
						Prompt.Yandere.Inventory.Narcotics = false;
						Narcotics = true;
					}
					Menu = 1;
					UpdateMenuLabels();
				}
			}
			else if (Menu == 5)
			{
				PromptBar.Label[5].text = "Change Selection";
				PromptBar.UpdateButtons();
				Magazine.gameObject.SetActive(value: true);
				MagazineButton.SetActive(value: false);
				ShowMagazine = true;
				HideAllHearts();
				Page = 1;
				UpdateHearts();
			}
			else if (Menu == 6)
			{
				Diary.gameObject.SetActive(value: true);
				DiaryButton.SetActive(value: false);
				ShowDiary = true;
			}
		}
		else if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			if (ShowMagazine)
			{
				PromptBar.Label[5].text = "";
				PromptBar.UpdateButtons();
				MagazineButton.SetActive(value: true);
				ShowMagazine = false;
			}
			else if (ShowDiary)
			{
				PromptBar.Label[5].text = "";
				PromptBar.UpdateButtons();
				DiaryButton.SetActive(value: true);
				ShowDiary = false;
			}
			else
			{
				MagazineButton.SetActive(value: false);
				DiaryButton.SetActive(value: false);
				Highlight.gameObject.SetActive(value: true);
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Confirm";
				PromptBar.Label[4].text = "Change Selection";
				PromptBar.UpdateButtons();
				if (Menu == 5)
				{
					Menu = 2;
					UpdateMenuLabels();
				}
				else if (Menu == 6)
				{
					Menu = 2;
					UpdateMenuLabels();
				}
			}
		}
		else if (Page == 1 && Prompt.Yandere.PauseScreen.InputManager.TappedRight)
		{
			Page++;
			HideAllHearts();
			UpdateHearts();
		}
		else if (Page == 2 && Prompt.Yandere.PauseScreen.InputManager.TappedLeft)
		{
			Page--;
			HideAllHearts();
			UpdateHearts();
		}
		if (ShowMagazine)
		{
			Magazine.localPosition = Vector3.Lerp(Magazine.localPosition, new Vector3(0f, 50f, 0f), Time.unscaledDeltaTime * 10f);
			Magazine.localEulerAngles = Vector3.Lerp(Magazine.localEulerAngles, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			if (Page == 1)
			{
				Pivot.localEulerAngles = Vector3.Lerp(Pivot.localEulerAngles, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 36f);
				if (Pivot.localEulerAngles.y < 90f)
				{
					Pages[2].enabled = true;
				}
				if (!(Pivot.localEulerAngles.y < 1f))
				{
				}
			}
			else
			{
				Pivot.localEulerAngles = Vector3.Lerp(Pivot.localEulerAngles, new Vector3(0f, 180f, 0f), Time.unscaledDeltaTime * 36f);
				if (Pivot.localEulerAngles.y > 90f)
				{
					Pages[2].enabled = false;
				}
				if (!(Pivot.localEulerAngles.y > 179f))
				{
				}
			}
		}
		else
		{
			Magazine.localPosition = Vector3.Lerp(Magazine.localPosition, new Vector3(-735f, -1470f, 0f), Time.unscaledDeltaTime * 10f);
			Magazine.localEulerAngles = Vector3.Lerp(Magazine.localEulerAngles, new Vector3(0f, 0f, 45f), Time.unscaledDeltaTime * 10f);
		}
		if (ShowDiary)
		{
			Diary.localPosition = Vector3.Lerp(Diary.localPosition, new Vector3(0f, 50f, 0f), Time.unscaledDeltaTime * 10f);
			Diary.localEulerAngles = Vector3.Lerp(Diary.localEulerAngles, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
		}
		else
		{
			Diary.localPosition = Vector3.Lerp(Diary.localPosition, new Vector3(-765f, -1530f, 0f), Time.unscaledDeltaTime * 10f);
			Diary.localEulerAngles = Vector3.Lerp(Diary.localEulerAngles, new Vector3(0f, 0f, 45f), Time.unscaledDeltaTime * 10f);
		}
	}

	private void CloseWindow()
	{
		Selected = 1;
		UpdateHighlight();
		Prompt.Yandere.RPGCamera.enabled = true;
		Prompt.Yandere.CanMove = true;
		Window.SetActive(value: false);
		Time.timeScale = 1f;
		PromptBar.ClearButtons();
		PromptBar.Show = false;
	}

	private void UpdateHighlight()
	{
		if (Selected > Limit)
		{
			Selected = 1;
		}
		else if (Selected < 1)
		{
			Selected = Limit;
		}
		Highlight.localPosition = new Vector3(0f, 400 - Selected * 100, 0f);
	}

	private void UpdateMenuLabels()
	{
		Selected = 1;
		UpdateHighlight();
		for (int i = 1; i < Label.Length; i++)
		{
			Label[i].color = new Color(1f, 1f, 1f, 1f);
			Label[i].text = "";
		}
		Label[8].text = "";
		if (Menu == 1)
		{
			Label[1].text = "BOOKS";
			Label[2].text = "BENTO";
			Label[3].text = "CONTRABAND";
			Label[4].text = "EXIT";
			if (Rival == null)
			{
				Debug.Log("Rival was null, grabbing her info now.");
				GrabRivalInfo();
			}
			if (Rival.MyBento.Tampered || BentoStolen || NoBento)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
				if (BentoStolen)
				{
					Label[2].text = "BENTO (STOLEN)";
				}
				else if (NoBento)
				{
					Label[2].text = "NO BENTO";
				}
				else
				{
					Label[2].text = "BENTO (POISONED)";
				}
			}
			if (Prompt.Yandere.StudentManager.Clock.Period > 3)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 4;
		}
		else if (Menu == 2)
		{
			Label[1].text = "STEAL BORROWED BOOK";
			Label[2].text = "READ MAGAZINE";
			Label[3].text = "READ DIARY";
			Label[4].text = "BACK";
			if (!BorrowedBook || Prompt.Yandere.StudentManager.Clock.Period == 3)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 4;
		}
		else if (Menu == 3)
		{
			Label[1].text = "PUT EMETIC POISON IN BENTO";
			Label[2].text = "PUT LETHAL POISON IN BENTO";
			Label[3].text = "PUT HEADACHE POISON IN BENTO";
			Label[4].text = "PUT SEDATIVE POISON IN BENTO";
			Label[5].text = "STEAL BENTO";
			Label[6].text = "BACK";
			if (Prompt.Yandere.Inventory.EmeticPoisons == 0)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (Prompt.Yandere.Inventory.LethalPoisons == 0)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (Prompt.Yandere.Inventory.HeadachePoisons == 0)
			{
				Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (Prompt.Yandere.Inventory.SedativePoisons == 0)
			{
				Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 6;
		}
		else if (Menu == 4)
		{
			Label[1].text = "PUT ALCOHOL INTO BAG";
			Label[2].text = "PUT CONDOMS INTO BAG";
			Label[3].text = "PUT CIGARETTES INTO BAG";
			Label[4].text = "PUT STOLEN RING INTO BAG";
			Label[5].text = "PUT ANSWER SHEET INTO BAG";
			Label[6].text = "PUT NARCOTICS INTO BAG";
			Label[7].text = "BACK";
			if (!Prompt.Yandere.Inventory.Sake)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Condoms)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Cigs)
			{
				Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Ring)
			{
				Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.AnswerSheet)
			{
				Label[5].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.Narcotics)
			{
				Label[6].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 7;
		}
		else if (Menu == 5)
		{
			Label[8].text = "You find a magazine in your rival's bookbag.\n\nIt's a fashion magazine with lots of cute boys in it.\n\nYour rival has drawn hearts next to certain boys.\n\nYou could use this information to determine what traits she's attracted to.\n\nTo look inside the magazine, press:\n\n";
		}
		else if (Menu == 6)
		{
			Label[8].text = "You find a diary in your rival's bookbag.\n\nBy reading your rival's diary, you will be able to learn her likes and dislikes,\n\nembarassing secrets that will allow you to spread gossip about her,\n\nand personal problems that you can discuss with her by leaving a note in her locker.\n\nTo look inside the diary, press:\n\n";
			Prompt.Yandere.Police.EndOfDay.LearnedAboutPhotographer = true;
			Prompt.Yandere.StudentManager.EmbarassingSecret = true;
		}
	}

	public void GrabRivalInfo()
	{
		Rival = Prompt.Yandere.StudentManager.Students[Prompt.Yandere.StudentManager.RivalID];
		int week = DateGlobals.Week;
		if (week >= 11)
		{
			return;
		}
		if (week == 4)
		{
			NoBento = true;
		}
		int num = 10 + week;
		RivalOpinions = JSON.Topics[num].Topics;
		int i = 1;
		Likes = 1;
		Dislikes = 1;
		for (; i < 26; i++)
		{
			if (RivalOpinions[i] == 2)
			{
				RivalLikes[Likes] = Subjects[i];
				Likes++;
			}
			else if (RivalOpinions[i] == 1)
			{
				RivalDislikes[Dislikes] = Subjects[i];
				Dislikes++;
			}
		}
		num -= 10;
		DesiredHairstyle = DesiredHairstyles[num];
		DesiredAccessory = DesiredAccessories[num];
		DesiredEyewear = DesiredEyewears[num];
		DesiredSkin = DesiredSkins[num];
		DesiredHairColor = DesiredHairColors[num];
		DesiredJewelry = DesiredJewelries[num];
		DesiredTrait = DesiredTraits[num];
		DiaryLabelLeft.text = "My best friend asked me to name the 5 things I love the most. It was difficult, but I narrowed it down to:\n\n" + RivalLikes[1] + ", " + RivalLikes[2] + ", " + RivalLikes[3] + ", " + RivalLikes[4] + ", and " + RivalLikes[5] + ".\n\nNext, she wanted me to name my 5 least favorite things. I decided on:\n\n" + RivalDislikes[1] + ", " + RivalDislikes[2] + ", " + RivalDislikes[3] + ", " + RivalDislikes[4] + ", and " + RivalDislikes[5] + ".\n\nLast night, I had a nightmare that everyone at Akademi learned my most embarassing secret:\n\n" + DiaryEntryLeft[num];
		DiaryLabelRight.text = DiaryEntryRight[num];
		DiaryBG.mainTexture = DiaryTextures[num];
	}

	private void HideAllHearts()
	{
		PonytailHearts.SetActive(value: false);
		SlickHearts.SetActive(value: false);
		PiercingHearts.SetActive(value: false);
		BandanaHearts.SetActive(value: false);
		GlassesHearts.SetActive(value: false);
		SunglassesHearts.SetActive(value: false);
		TanHearts.SetActive(value: false);
		DarkHairHearts.SetActive(value: false);
		JewleryHearts.SetActive(value: false);
		CourageHearts.SetActive(value: false);
		SmartHearts.SetActive(value: false);
		StrongHearts.SetActive(value: false);
		QuoteBoxes.SetActive(value: false);
	}

	private void UpdateHearts()
	{
		if (Page == 1)
		{
			QuoteBoxes.SetActive(value: true);
			if (DesiredAccessory == 17)
			{
				PiercingHearts.SetActive(value: true);
			}
			else if (DesiredAccessory == 1)
			{
				BandanaHearts.SetActive(value: true);
			}
			if (DesiredEyewear == 6)
			{
				GlassesHearts.SetActive(value: true);
			}
			else if (DesiredEyewear == 3)
			{
				SunglassesHearts.SetActive(value: true);
			}
			if (DesiredSkin == 6)
			{
				TanHearts.SetActive(value: true);
			}
			if (DesiredHairColor == "SolidBlack")
			{
				DarkHairHearts.SetActive(value: true);
			}
			if (DesiredJewelry)
			{
				JewleryHearts.SetActive(value: true);
			}
			if (DesiredTrait == 1)
			{
				CourageHearts.SetActive(value: true);
			}
			else if (DesiredTrait == 2)
			{
				SmartHearts.SetActive(value: true);
			}
			else if (DesiredTrait == 3)
			{
				StrongHearts.SetActive(value: true);
			}
		}
		else if (DesiredHairstyle == 55)
		{
			PonytailHearts.SetActive(value: true);
		}
		else if (DesiredHairstyle == 56)
		{
			SlickHearts.SetActive(value: true);
		}
	}

	public void UpdatePosition()
	{
		base.transform.position = CorrectPosition;
		base.transform.eulerAngles = CorrectRotation;
	}

	public void RememberBentoStatus()
	{
		if (Rival != null)
		{
			EmeticStatus = Rival.MyBento.Emetic;
			TranquilStatus = Rival.MyBento.Tranquil;
			HeadacheStatus = Rival.MyBento.Headache;
			LethalStatus = Rival.MyBento.Lethal;
			TamperedStatus = Rival.MyBento.Tampered;
		}
	}

	public void RestoreBentoStatus()
	{
		if (Rival != null)
		{
			Rival.MyBento.Emetic = EmeticStatus;
			Rival.MyBento.Tranquil = TranquilStatus;
			Rival.MyBento.Headache = HeadacheStatus;
			Rival.MyBento.Lethal = LethalStatus;
			Rival.MyBento.Tampered = TamperedStatus;
		}
	}
}
