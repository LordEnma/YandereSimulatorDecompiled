using System.IO;
using Newtonsoft.Json;
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

	public UILabel DiaryLabelBottom;

	public UILabel DiaryLabelRight;

	public UILabel DiaryLabelLeft;

	public UITexture DiaryBG;

	public UISprite BG;

	public Texture[] ModernDiaryTextures;

	public Texture[] DiaryTextures;

	public UILabel[] Label;

	public bool BorrowedBook;

	public bool Alcohol;

	public bool Condoms;

	public bool Cigarettes;

	public bool StolenRing;

	public bool AnswerSheet;

	public bool Narcotics;

	public bool StolenProperty;

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

	public bool Eighties;

	public int Page = 1;

	public Vector3 CorrectPosition;

	public Vector3 CorrectRotation;

	public bool EmeticStatus;

	public bool TranquilStatus;

	public bool HeadacheStatus;

	public bool LethalStatus;

	public bool TamperedStatus;

	public Font ModernFont;

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

	public TopicJson[] TopicData;

	protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

	public void Start()
	{
		if (!Initialized)
		{
			BG.color = new Color(1f, 0.75f, 1f, 1f);
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
			Eighties = GameGlobals.Eighties;
		}
	}

	private void Update()
	{
		if (!Window.activeInHierarchy)
		{
			if (Prompt.Circle[0].fillAmount != 0f)
			{
				return;
			}
			Prompt.Circle[0].fillAmount = 1f;
			if (!Prompt.Yandere.Chased && Prompt.Yandere.Chasers == 0)
			{
				if (Prompt.Yandere.YandereVision)
				{
					Prompt.Yandere.YandereVision = false;
					Prompt.Yandere.ResetYandereEffects();
				}
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
				if (!Eighties)
				{
					ChangeFont();
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
						bool flag = false;
						for (int i = 1; i < 26; i++)
						{
							if (!Prompt.Yandere.StudentManager.GetTopicLearnedByStudent(i, Prompt.Yandere.StudentManager.RivalID))
							{
								flag = true;
							}
						}
						if (flag)
						{
							Prompt.Yandere.NotificationManager.CustomText = "Learned the rival's likes & dislikes";
							Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
						}
						for (int j = 1; j < 26; j++)
						{
							Prompt.Yandere.StudentManager.SetTopicLearnedByStudent(j, Prompt.Yandere.StudentManager.RivalID, boolean: true);
						}
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
						Menu = 1;
						UpdateMenuLabels();
					}
					else if (Selected == 2)
					{
						Prompt.Yandere.Inventory.Condoms = false;
						Condoms = true;
						Menu = 1;
						UpdateMenuLabels();
					}
					else if (Selected == 3)
					{
						Prompt.Yandere.Inventory.Cigs = false;
						Cigarettes = true;
						Menu = 1;
						UpdateMenuLabels();
					}
					else if (Selected == 4)
					{
						Menu = 7;
						UpdateMenuLabels();
					}
					else if (Selected == 5)
					{
						Prompt.Yandere.Inventory.AnswerSheet = false;
						AnswerSheet = true;
						Menu = 1;
						UpdateMenuLabels();
					}
					else if (Selected == 6)
					{
						Prompt.Yandere.Inventory.Narcotics = false;
						Narcotics = true;
						Menu = 1;
						UpdateMenuLabels();
					}
					else
					{
						Menu = 1;
						UpdateMenuLabels();
					}
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
			else if (Menu == 7 && Label[Selected].color.a == 1f)
			{
				if (Selected == 1)
				{
					Prompt.Yandere.Inventory.Ring = false;
					StolenRing = true;
				}
				else if (Selected == 2)
				{
					Prompt.Yandere.Inventory.CaseKey = false;
					StolenProperty = true;
				}
				else if (Selected == 3)
				{
					Debug.Log("Just put the safe key into the rival's bag.");
					Prompt.Yandere.Inventory.SafeKey = false;
					StolenProperty = true;
				}
				else if (Selected == 4)
				{
					Prompt.Yandere.Inventory.ShedKey = false;
					StolenProperty = true;
				}
				else if (Selected == 5)
				{
					Prompt.Yandere.Inventory.IDCard = false;
					StolenProperty = true;
				}
				Menu = 4;
				UpdateMenuLabels();
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
			Label[4].text = "PUT STOLEN PROPERTY INTO BAG";
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
			if (!Prompt.Yandere.Inventory.Ring && !Prompt.Yandere.Inventory.CabinetKey && !Prompt.Yandere.Inventory.CaseKey && !Prompt.Yandere.Inventory.SafeKey && !Prompt.Yandere.Inventory.ShedKey && !Prompt.Yandere.Inventory.IDCard)
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
		else if (Menu == 7)
		{
			Label[1].text = "PUT STOLEN RING INTO BAG";
			Label[2].text = "PUT KATANA CASE KEY INTO BAG";
			Label[3].text = "PUT HEADMASTER SAFE KEY INTO BAG";
			Label[4].text = "PUT GARDENING SHED KEY INTO BAG";
			Label[5].text = "PUT FACULTY KEY CARD INTO BAG";
			Label[6].text = "BACK";
			if (!Prompt.Yandere.Inventory.Ring)
			{
				Label[1].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.CaseKey)
			{
				Label[2].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.SafeKey)
			{
				Label[3].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.ShedKey)
			{
				Label[4].color = new Color(1f, 1f, 1f, 0.5f);
			}
			if (!Prompt.Yandere.Inventory.IDCard)
			{
				Label[5].color = new Color(1f, 1f, 1f, 0.5f);
			}
			Limit = 6;
		}
	}

	public void GrabRivalInfo()
	{
		Rival = Prompt.Yandere.StudentManager.Students[Prompt.Yandere.StudentManager.RivalID];
		int week = DateGlobals.Week;
		if (week < 11)
		{
			if (week == 4)
			{
				NoBento = true;
			}
			int num = 10 + week;
			if (GameGlobals.CustomMode)
			{
				string value = File.ReadAllText(Path.Combine(FolderPath, "CustomTopics.json"));
				TopicData = JsonConvert.DeserializeObject<TopicJson[]>(value);
				JSON.Topics = TopicJson.LoadFromJson(Path.Combine(FolderPath, "CustomTopics.json"));
			}
			if (JSON.Topics[1].Topics == null)
			{
				Debug.Log("Something went catastrophically wrong, and JSON.Topics is empty. Filling it up with default likes and dislikes.");
				string contents = JsonConvert.SerializeObject(JsonScript.TopicAdapter(JSON.Topics));
				File.WriteAllText(Path.Combine(FolderPath, "EightiesTopics.json"), contents);
			}
			else
			{
				RivalOpinions = JSON.Topics[num].Topics;
			}
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
			DiaryLabelBottom.text = DiaryEntryLeft[num];
			if (GameGlobals.CustomMode)
			{
				DiaryLabelLeft.text = "My best friend asked me to name the 5 things I love the most. It was difficult, but I narrowed it down to:\n\n" + RivalLikes[1] + ", " + RivalLikes[2] + ", " + RivalLikes[3] + ", " + RivalLikes[4] + ", and " + RivalLikes[5] + ".\n\nNext, she wanted me to name my 5 least favorite things. I decided on:\n\n" + RivalDislikes[1] + ", " + RivalDislikes[2] + ", " + RivalDislikes[3] + ", " + RivalDislikes[4] + ", and " + RivalDislikes[5] + ".\n\nLast night, I had a nightmare that everyone at Akademi learned my most embarassing secret:";
			}
			else
			{
				switch (num)
				{
				case 1:
					DiaryLabelLeft.text = "[c][008000]I love cooking[-][/c] for the special people in my life, so I made a bento for the boy I have a crush on!\n \nApparently, the upcoming school play is all about combat. Well, [c][800000]I hate drama[-][/c] and [c][800000]I hate violence,[-][/c] so I'll pass.\n \nSo many people have invited me to join their clubs! So far, [c][008000]I love music[-][/c] and [c][008000]I love gardening,[-][/c] but [c][800000]I hate the occult![-][/c]\n \nWhile I was walking around the school, I saw the most adorable kitty! (^•w•^) Oh, [c][008000]I love cats[-][/c] so much!\n \nThere's a group of girls I've been trying to make friends with. I hope they accept me! [c][800000]I hate being alone![-][/c]\n \nI just hope that they don't enjoy spreading rumors. [c][008000]I love socializing,[-][/c] but [c][800000]I hate gossip![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 2:
					DiaryLabelLeft.text = "I might audition for the school play. [c][008000]I love drama![-][/c] It has combat, which rocks, cuz [c][008000]I love violence![-][/c]\n \nMan, my parents just don't get me. I'm grateful to them for a lot of reasons, but sometimes, [c][800000]I just hate my family.[-][/c]\n \nI can't decide which club to join. [c][008000]I love martial arts[-][/c] and [c][008000]I love sports![-][/c] How can I choose just one?!\n \nMan, [c][800000]I hate school![-][/c] The teachers get mad when I crack jokes during class. I can't help it; [c][008000]I love jokes![-][/c]\n \nNormally [c][800000]I hate gossip[-][/c], but if anyone is talking smack about the gardening club or cooking club, I let it slide.\n \n[c][800000]I hate gardening[-][/c] and [c][800000]I hate cooking![-][/c] I hate all that girly stuff! It makes me wanna barf!\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 3:
					DiaryLabelLeft.text = "[c][008000]I love reading[-][/c] about things I knew nothing about. Thanks to a fascinating book, [c][008000]I love the occult[-][/c] now!\n \nI recently learned that reading a book outdoors feels way better than reading it indoors. I guess this means that [c][008000]I love nature[-][/c]!\n \nHonestly, I'm glad the library doesn't get many visitors. [c][800000]I don't like socializing,[-][/c] anyway. [c][008000]I prefer solitude.[-][/c]\n \nI can't stand the class clowns who goof off during class instead of paying attention to the lessons. [c][800000]I hate jokes.[-][/c]\n \n[c][008000]I love school,[-][/c] but I wish the people here would stop discussing rumors. [c][800000]I hate gossip.[-][/c]\n \nI won't attend the upcoming school play. [c][800000]I don't like drama,[-][/c] and [c][800000]I don't like violence,[-][/c] either.\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 4:
					DiaryLabelLeft.text = "[c][008000]I love sports,[-][/c] but I was really tempted to join the martial arts club, since [c][008000]I love martial arts[-][/c] a lot, too!\n \nWhat you eat is much more important than what exercises you do. That's why [c][008000]I love cooking[-][/c] healthy meals so much!\n \nWhy are people always so surprised to hear that [c][008000]I love nature[-][/c]? Do I give off completely different vibes, or something?\n \nI'm disappointed that so many people at this school play video games. [c][800000]I hate video games![-][/c] Too much TV is bad for you!\n \nThe upcoming school play is based on a super-violent anime? I'll pass. [c][800000]I hate violence[-][/c], [c][800000]I hate anime.[-][/c], and [c][800000]I hate cosplay.[-][/c]\n \n[c][008000]I love cats,[-][/c] but people keep talking trash about me because there's a cat I can't catch. Argh, [c][800000]I hate gossip![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 5:
					DiaryLabelLeft.text = "[c][800000]I hate school![-][/c] What's the point? I'll never use the knowledge! I'm so rich that I'll never need to work a day in my life!\n \n[c][008000]I love my family![-][/c] Well, I don't love any of them individually, but I'm glad I was born into wealth! [c][008000]I LOVE MONEY![-][/c]\n \nArgh! [c][008000]I want to socialize[-][/c] in peace, but I am constantly being approached by peasants who want me to join their stupid clubs!\n \nI won't join the art club just because [c][008000]I love art![-][/c] And, no, I won't join the Cooking Club, either! [c][800000]I hate cooking![-][/c]\n \nWhy does this school have an occult club? Creepy! Do they worship death? [c][800000]I hate the occult[-][/c] and [c][800000]I hate violence![-][/c]\n \n[c][008000]I love gossip,[-][/c] so I tried to start some juicy rumors, but some goody-two shoes foiled my plans! Argh! [c][800000]I hate justice![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 6:
					DiaryLabelLeft.text = "I've heard that the Occult Club uses blood in their rituals! Eek! Scary! [c][800000]I hate the occult![-][/c] and [c][800000]I hate violence![-][/c]\n \n Why don't they join a normal club? [c][008000]I love art[-][/c] and [c][008000]I love martial arts[-][/c] - they should try out those things instead!\n \n There are certain clubs I could never see myself joining, though. Like, for example, [c][800000]I hate sports[-][/c] and [c][800000]I hate gardening[-][/c].\n \n Why? Because, whenever I try to do outdoor activities, my allergies act up! Nature hates me, so [c][800000]I hate nature[-][/c] back!\n \n I predict that big idol trend will be performing while wearing elaborate costumes. Sounds fun! [c][008000]I love cosplay![-][/c]\n \n [c][008000]I love music[-][/c] more than anything else in the world! Well, except hanging out with my friends. [c][008000]I love socializing[-][/c], too!\n \n Last night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 7:
					DiaryLabelLeft.text = "Why does the headmaster permit an Occult Club at this school? [c][800000]I hate the occult[-][/c] for the negative influence it has.\n \nThe upcoming school play sounds far too violent. [c][800000]I hate violence[-][/c] almost as much as [c][800000]I hate drama.[-][/c] I'll pass.\n \n[c][008000]I love school,[-][/c], but my classmates discuss rumors too much. [c][800000]I hate gossip[-][/c] and how much of a distraction it can be.\n \nI read a book outdoors and the most wonderful experience. [c][008000]I love reading [-][/c] and [c][008000]I love nature![-][/c] - they go well together!\n \nThere's a class clown in my science class. [c][800000]I hate jokes[-][/c] when they interrupt my favorite subject. [c][008000]I love science![-][/c]\n \nI haven't had any chances to practice photography recently. I hope I'll find an opportunity soon. [c][008000]I love photography![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 8:
					DiaryLabelLeft.text = "I have feelings for someone. I prepared a bento to demonstrate that [c][008000]I love cooking,[-][/c] as a proper lady should.\n \n[c][008000]I love my family[-][/c]. My parents are very spiritual. Would it disappoint them to learn that [c][008000]I love science?[-][/c]\n \n[c][008000]I love socializing,[-][/c] but my friends only seem interested in discussing rumors. [c][800000]I hate gossip...[-][/c]\n \nI've been invited to join clubs I have no interest in. [c][800000]I hate martial arts[-][/c] and [c][800000]I hate sports.[-][/c] They're not ladylike!\n \nI'm quite frightened of the Occult Club! [c][800000]I hate the occult![-][/c] I hope they don't hurt me. [c][800000]I hate violence![-][/c]\n \nThe only club I might join is the Gardening Club. [c][008000]I love gardening![-][/c] Now, there's an good activity for a proper lady!\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 9:
					DiaryLabelLeft.text = "For a recent photoshoot, I dressed up as a character from an anime! It was so fun! I think [c][008000]I love cosplay![-][/c]\n \nI was asked to join the school play. It was weirdly violent, so I declined. [c][800000]I hate violence[-][/c] and [c][800000]I hate drama.[-][/c]\n \nModeling bikinis pays really well, and [c][008000]I love money![-][/c] But, it makes girls talk trash about me. [c][800000]I hate gossip![-][/c]\n \nNot sure what club I'll join. [c][800000]I hate the occult,[-][/c] so that's out. However, [c][008000]I love art,[-][/c] so maybe the Art Club?\n \nI didn't expect a bunch of the boys at this school to follow me around everywhere I go. How annoying! [c][008000]I prefer solitude![-][/c]\n \n[c][800000]I hate this school,[-][/c] but there is one good thing here: an adorable stray kitten! Oh, [c][008000]I love cats![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				case 10:
					DiaryLabelLeft.text = "Returning to Akademi has made me remember everything I disliked about it. [c][800000]I really hate this school.[-][/c] It's full of morons!\n \nThe students are joking around and talking about anime and video games while a killer might be lurking nearby!\n \nWell, you know what? [c][800000]I hate jokes![-][/c] [c][800000]I hate anime![-][/c] And [c][800000]I hate video games![-][/c] Why? [c][008000]Justice is more important![-][/c]\n \nAnd then there's the Drama Club. Hosting a violent play at a time like this? How tasteless! [c][800000]I hate violence![-][/c] \n \nIn terms of clubs, [c][008000]I love photography[-][/c] and [c][008000]I love martial arts[-][/c] - they've agreed to keep an eye out for the killer. \n \nPursuing justice can be tiresome, though. I would rather be alone with a good book. [c][008000]I love solitude[-][/c] and [c][008000]I love reading![-][/c]\n \nLast night, I had a nightmare that everyone at school learned my most embarrassing secret: ";
					break;
				}
			}
			DiaryLabelBottom.text = DiaryEntryLeft[num];
			DiaryLabelRight.text = DiaryEntryRight[num];
			if (GameGlobals.Eighties)
			{
				DiaryBG.mainTexture = DiaryTextures[num];
			}
			else
			{
				DiaryBG.mainTexture = ModernDiaryTextures[num];
			}
		}
		if (!Eighties)
		{
			ChangeFont();
		}
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

	private void ChangeFont()
	{
		int num = 0;
		Transform[] componentsInChildren = Window.GetComponentsInChildren<Transform>();
		foreach (Transform obj in componentsInChildren)
		{
			num++;
			UILabel component = obj.GetComponent<UILabel>();
			if (component != null && component.trueTypeFont == StudentManager.VCR)
			{
				component.trueTypeFont = ModernFont;
				component.fontSize = 75;
			}
		}
	}
}
