using System.Globalization;
using UnityEngine;

public class HomeInternetScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public InputManagerScript InputManager;

	public PauseScreenScript PauseScreen;

	public PromptBarScript PromptBar;

	public HomeClockScript Clock;

	public HomeYandereScript HomeYandere;

	public HomeCameraScript HomeCamera;

	public HomeWindowScript HomeWindow;

	public UILabel NewPostTextLabel;

	public UILabel YanderePostLabel;

	public UILabel YancordLabel;

	public UILabel AcceptLabel;

	public UITexture YancordLogo;

	public GameObject InternetPrompts;

	public GameObject NavigationMenu;

	public GameObject OnlineShopping;

	public GameObject SocialMedia;

	public GameObject NewPostText;

	public GameObject ChangeLabel;

	public GameObject ChangeIcon;

	public GameObject WriteLabel;

	public GameObject WriteIcon;

	public GameObject PostLabel;

	public GameObject PostIcon;

	public GameObject BG;

	public Transform MenuHighlight;

	public Transform StudentPost1;

	public Transform StudentPost2;

	public Transform YandereReply;

	public Transform YanderePost;

	public Transform LameReply;

	public Transform NewPost;

	public Transform Menu;

	public Transform[] StudentReplies;

	public UISprite[] Highlights;

	public UILabel[] PostLabels;

	public UILabel[] NameLabels;

	public UILabel[] ReplyLabels;

	public UILabel[] MenuLabels;

	public string[] Locations;

	public string[] Actions;

	public bool PostSequence;

	public bool WritingPost;

	public bool ShowMenu;

	public bool FadeOut;

	public bool Success;

	public bool Posted;

	public int MenuSelected = 1;

	public int Selected = 1;

	public int Week = 1;

	public int ID = 1;

	public int Location;

	public int Student;

	public int Action;

	public float Timer;

	public UITexture StudentPost1Portrait;

	public UITexture StudentPost2Portrait;

	public UITexture LamePostPortrait;

	public Texture AnonymousPortrait;

	public Texture CurrentPortrait;

	public UITexture[] Portraits;

	public int Height;

	public Transform Highlight;

	public Transform ItemList;

	public GameObject AreYouSure;

	public AudioSource MyAudio;

	public UILabel MoneyLabel;

	public float Shake;

	private void Awake()
	{
		Week = DateGlobals.Week;
		if (Week == 2)
		{
			NewPostTextLabel.text = "Did you know that _______________ used to ____________________ into    ______________________________?";
		}
		StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, -180f, StudentPost1.localPosition.z);
		StudentPost2.localPosition = new Vector3(StudentPost2.localPosition.x, -365f, StudentPost2.localPosition.z);
		YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, -88f, YandereReply.localPosition.z);
		YanderePost.localPosition = new Vector3(YanderePost.localPosition.x, -2f, YanderePost.localPosition.z);
		for (int i = 1; i < 6; i++)
		{
			Transform transform = StudentReplies[i];
			transform.localPosition = new Vector3(transform.localPosition.x, -40f, transform.localPosition.z);
		}
		LameReply.localPosition = new Vector3(LameReply.localPosition.x, -40f, LameReply.localPosition.z);
		PostLabels[1].text = "";
		PostLabels[2].text = "";
		PostLabels[3].text = "";
		Highlights[1].enabled = false;
		Highlights[2].enabled = false;
		Highlights[3].enabled = false;
		YanderePost.gameObject.SetActive(value: false);
		NavigationMenu.SetActive(value: true);
		ChangeLabel.SetActive(value: false);
		ChangeIcon.SetActive(value: false);
		PostLabel.SetActive(value: false);
		PostIcon.SetActive(value: false);
		OnlineShopping.SetActive(value: false);
		NewPostText.SetActive(value: false);
		BG.SetActive(value: false);
		if (!SchemeGlobals.EmbarassingSecret || StudentGlobals.GetStudentExposed(11))
		{
			WriteLabel.SetActive(value: false);
			WriteIcon.SetActive(value: false);
		}
		GetPortrait(2);
		StudentPost1Portrait.mainTexture = CurrentPortrait;
		GetPortrait(39);
		StudentPost2Portrait.mainTexture = CurrentPortrait;
		GetPortrait(25);
		LamePostPortrait.mainTexture = CurrentPortrait;
		for (ID = 1; ID < 6; ID++)
		{
			GetPortrait(86 - ID);
			Portraits[ID].mainTexture = CurrentPortrait;
		}
		if (!DateGlobals.DayPassed || YancordGlobals.CurrentConversation == 6)
		{
			YancordLabel.color = new Color(1f, 1f, 1f, 0.2f);
			YancordLogo.color = new Color(1f, 1f, 1f, 0.2f);
		}
	}

	private void Update()
	{
		if (HomeYandere.CanMove || HomeCamera.HomeDarkness.FadeOut || PauseScreen.Show)
		{
			return;
		}
		if (NavigationMenu.activeInHierarchy && !HomeCamera.CyberstalkWindow.activeInHierarchy)
		{
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				NavigationMenu.SetActive(value: false);
				SocialMedia.SetActive(value: true);
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				if (DateGlobals.DayPassed)
				{
					HomeCamera.HomeDarkness.FadeOut = true;
				}
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				PauseScreen.MainMenu.SetActive(value: false);
				PauseScreen.Panel.enabled = true;
				PauseScreen.Sideways = true;
				PauseScreen.Show = true;
				StudentInfoMenu.gameObject.SetActive(value: true);
				StudentInfoMenu.CyberStalking = true;
				StartCoroutine(StudentInfoMenu.UpdatePortraits());
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "View Info";
				PromptBar.Label[1].text = "Back";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
			}
			else if (Input.GetButtonDown(InputNames.Xbox_LB))
			{
				NavigationMenu.SetActive(value: false);
				OnlineShopping.SetActive(value: true);
				MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
			}
			else if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				HomeCamera.Destination = HomeCamera.Destinations[0];
				HomeCamera.Target = HomeCamera.Targets[0];
				HomeYandere.CanMove = true;
				HomeWindow.Show = false;
				base.enabled = false;
			}
		}
		else if (SocialMedia.activeInHierarchy)
		{
			Menu.localScale = Vector3.Lerp(Menu.localScale, ShowMenu ? new Vector3(2f, 2f, 2f) : Vector3.zero, Time.deltaTime * 10f);
			if (WritingPost)
			{
				NewPost.transform.localPosition = Vector3.Lerp(NewPost.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
				NewPost.transform.localScale = Vector3.Lerp(NewPost.transform.localScale, new Vector3(2.43f, 2.43f, 2.43f), Time.deltaTime * 10f);
				for (int i = 1; i < Highlights.Length; i++)
				{
					UISprite uISprite = Highlights[i];
					uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, Mathf.MoveTowards(uISprite.color.a, FadeOut ? 0f : 1f, Time.deltaTime));
				}
				if (Highlights[Selected].color.a == 1f)
				{
					FadeOut = true;
				}
				else if (Highlights[Selected].color.a == 0f)
				{
					FadeOut = false;
				}
				if (!ShowMenu)
				{
					if (InputManager.TappedRight)
					{
						Selected++;
						UpdateHighlight();
					}
					if (InputManager.TappedLeft)
					{
						Selected--;
						UpdateHighlight();
					}
				}
				else
				{
					if (InputManager.TappedDown)
					{
						MenuSelected++;
						UpdateMenuHighlight();
					}
					if (InputManager.TappedUp)
					{
						MenuSelected--;
						UpdateMenuHighlight();
					}
				}
			}
			else
			{
				NewPost.transform.localPosition = Vector3.Lerp(NewPost.transform.localPosition, new Vector3(175f, -10f, 0f), Time.deltaTime * 10f);
				NewPost.transform.localScale = Vector3.Lerp(NewPost.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			}
			if (!PostSequence)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A) && WriteIcon.activeInHierarchy && !Posted)
				{
					if (!ShowMenu)
					{
						if (!WritingPost)
						{
							AcceptLabel.text = "Select";
							ChangeLabel.SetActive(value: true);
							ChangeIcon.SetActive(value: true);
							NewPostText.SetActive(value: true);
							BG.SetActive(value: true);
							WritingPost = true;
							Selected = 1;
							UpdateHighlight();
						}
						else if (Selected == 1)
						{
							PauseScreen.MainMenu.SetActive(value: false);
							PauseScreen.Panel.enabled = true;
							PauseScreen.Sideways = true;
							PauseScreen.Show = true;
							StudentInfoMenu.gameObject.SetActive(value: true);
							StudentInfoMenu.CyberBullying = true;
							StartCoroutine(StudentInfoMenu.UpdatePortraits());
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "View Info";
							PromptBar.Label[1].text = "Back";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 2)
						{
							MenuSelected = 1;
							UpdateMenuHighlight();
							ShowMenu = true;
							for (int j = 1; j < MenuLabels.Length; j++)
							{
								MenuLabels[j].text = Locations[j];
							}
						}
						else if (Selected == 3)
						{
							MenuSelected = 1;
							UpdateMenuHighlight();
							ShowMenu = true;
							for (int k = 1; k < MenuLabels.Length; k++)
							{
								MenuLabels[k].text = Actions[k];
							}
						}
					}
					else
					{
						if (Selected == 2)
						{
							Location = MenuSelected;
							PostLabels[2].text = Locations[MenuSelected];
							ShowMenu = false;
						}
						else if (Selected == 3)
						{
							Action = MenuSelected;
							PostLabels[3].text = Actions[MenuSelected];
							ShowMenu = false;
						}
						CheckForCompletion();
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					if (!ShowMenu)
					{
						if (!WritingPost)
						{
							NavigationMenu.SetActive(value: true);
							SocialMedia.SetActive(value: false);
						}
						else
						{
							AcceptLabel.text = "Write";
							ChangeLabel.SetActive(value: false);
							ChangeIcon.SetActive(value: false);
							PostLabel.SetActive(value: false);
							PostIcon.SetActive(value: false);
							ExitPost();
						}
					}
					else
					{
						ShowMenu = false;
					}
				}
				if (Input.GetButtonDown(InputNames.Xbox_X) && PostIcon.activeInHierarchy)
				{
					if (Week == 1)
					{
						Debug.Log("Week is 1.");
						YanderePostLabel.text = "Did you know that " + PostLabels[1].text + " used to " + PostLabels[2].text + " about " + PostLabels[3].text + "?";
					}
					else
					{
						Debug.Log("Week is 2.");
						YanderePostLabel.text = "Did you know that " + PostLabels[1].text + " used to " + PostLabels[2].text + " into " + PostLabels[3].text + "?";
					}
					ExitPost();
					InternetPrompts.SetActive(value: false);
					ChangeLabel.SetActive(value: false);
					ChangeIcon.SetActive(value: false);
					WriteLabel.SetActive(value: false);
					WriteIcon.SetActive(value: false);
					PostLabel.SetActive(value: false);
					PostIcon.SetActive(value: false);
					PostSequence = true;
					Posted = true;
					if (Student == 11 && Location == 10 && Action == 10)
					{
						Success = true;
					}
					else if (Student == 12 && Location == 9 && Action == 9)
					{
						Success = true;
						ChangeReplies(2);
					}
				}
			}
			if (!PostSequence)
			{
				return;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Timer += 2f;
			}
			Timer += Time.deltaTime;
			if (Timer > 1f && Timer < 3f)
			{
				YanderePost.gameObject.SetActive(value: true);
				YanderePost.transform.localPosition = new Vector3(YanderePost.transform.localPosition.x, Mathf.Lerp(YanderePost.transform.localPosition.y, -155f, Time.deltaTime * 10f), YanderePost.transform.localPosition.z);
				StudentPost1.transform.localPosition = new Vector3(StudentPost1.transform.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -365f, Time.deltaTime * 10f), StudentPost1.transform.localPosition.z);
				StudentPost2.transform.localPosition = new Vector3(StudentPost2.transform.localPosition.x, Mathf.Lerp(StudentPost2.transform.localPosition.y, -550f, Time.deltaTime * 10f), StudentPost2.transform.localPosition.z);
			}
			if (!Success)
			{
				if (Timer > 3f && Timer < 5f)
				{
					LameReply.localPosition = new Vector3(LameReply.localPosition.x, Mathf.Lerp(LameReply.transform.localPosition.y, -88f, Time.deltaTime * 10f), LameReply.localPosition.z);
					YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), YandereReply.localPosition.z);
					StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), StudentPost1.localPosition.z);
				}
				if (Timer > 5f)
				{
					PlayerGlobals.Reputation -= 20f;
					InternetPrompts.SetActive(value: true);
					PostSequence = false;
				}
				return;
			}
			if (Timer > 3f && Timer < 5f)
			{
				Transform transform = StudentReplies[1];
				transform.localPosition = new Vector3(transform.localPosition.x, Mathf.Lerp(transform.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform.localPosition.z);
				YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -137f, Time.deltaTime * 10f), YandereReply.localPosition.z);
				StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -415f, Time.deltaTime * 10f), StudentPost1.localPosition.z);
			}
			if (Timer > 5f && Timer < 7f)
			{
				Transform transform2 = StudentReplies[2];
				transform2.localPosition = new Vector3(transform2.localPosition.x, Mathf.Lerp(transform2.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform2.localPosition.z);
				Transform transform3 = StudentReplies[1];
				transform3.localPosition = new Vector3(transform3.localPosition.x, Mathf.Lerp(transform3.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform3.localPosition.z);
				YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -185f, Time.deltaTime * 10f), YandereReply.localPosition.z);
				StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -465f, Time.deltaTime * 10f), StudentPost1.localPosition.z);
			}
			if (Timer > 7f && Timer < 9f)
			{
				Transform transform4 = StudentReplies[3];
				transform4.localPosition = new Vector3(transform4.localPosition.x, Mathf.Lerp(transform4.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform4.localPosition.z);
				Transform transform5 = StudentReplies[2];
				transform5.localPosition = new Vector3(transform5.localPosition.x, Mathf.Lerp(transform5.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform5.localPosition.z);
				Transform transform6 = StudentReplies[1];
				transform6.localPosition = new Vector3(transform6.localPosition.x, Mathf.Lerp(transform6.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform6.localPosition.z);
				YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -233f, Time.deltaTime * 10f), YandereReply.localPosition.z);
				StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -510f, Time.deltaTime * 10f), StudentPost1.localPosition.z);
			}
			if (Timer > 9f && Timer < 11f)
			{
				Transform transform7 = StudentReplies[4];
				transform7.localPosition = new Vector3(transform7.localPosition.x, Mathf.Lerp(transform7.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform7.localPosition.z);
				Transform transform8 = StudentReplies[3];
				transform8.localPosition = new Vector3(transform8.localPosition.x, Mathf.Lerp(transform8.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform8.localPosition.z);
				Transform transform9 = StudentReplies[2];
				transform9.localPosition = new Vector3(transform9.localPosition.x, Mathf.Lerp(transform9.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform9.localPosition.z);
				Transform transform10 = StudentReplies[1];
				transform10.localPosition = new Vector3(transform10.localPosition.x, Mathf.Lerp(transform10.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform10.localPosition.z);
				YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -281f, Time.deltaTime * 10f), YandereReply.localPosition.z);
				StudentPost1.localPosition = new Vector3(StudentPost1.localPosition.x, Mathf.Lerp(StudentPost1.transform.localPosition.y, -560f, Time.deltaTime * 10f), StudentPost1.localPosition.z);
			}
			if (Timer > 11f && Timer < 13f)
			{
				Transform transform11 = StudentReplies[5];
				transform11.localPosition = new Vector3(transform11.localPosition.x, Mathf.Lerp(transform11.transform.localPosition.y, -88f, Time.deltaTime * 10f), transform11.localPosition.z);
				Transform transform12 = StudentReplies[4];
				transform12.localPosition = new Vector3(transform12.localPosition.x, Mathf.Lerp(transform12.transform.localPosition.y, -136f, Time.deltaTime * 10f), transform12.localPosition.z);
				Transform transform13 = StudentReplies[3];
				transform13.localPosition = new Vector3(transform13.localPosition.x, Mathf.Lerp(transform13.transform.localPosition.y, -184f, Time.deltaTime * 10f), transform13.localPosition.z);
				Transform transform14 = StudentReplies[2];
				transform14.localPosition = new Vector3(transform14.localPosition.x, Mathf.Lerp(transform14.transform.localPosition.y, -232f, Time.deltaTime * 10f), transform14.localPosition.z);
				Transform transform15 = StudentReplies[1];
				transform15.localPosition = new Vector3(transform15.localPosition.x, Mathf.Lerp(transform15.transform.localPosition.y, -280f, Time.deltaTime * 10f), transform15.localPosition.z);
				YandereReply.localPosition = new Vector3(YandereReply.localPosition.x, Mathf.Lerp(YandereReply.transform.localPosition.y, -329f, Time.deltaTime * 10f), YandereReply.localPosition.z);
			}
			if (Timer > 13f)
			{
				PlayerGlobals.Reputation -= 10f;
				StudentGlobals.SetStudentExposed(11, value: true);
				StudentGlobals.UpdateRivalReputation = true;
				Debug.Log("''StudentGlobals.UpdateRivalReputation''' has been set to ''true''.");
				InternetPrompts.SetActive(value: true);
				PostSequence = false;
			}
		}
		else
		{
			if (!OnlineShopping.activeInHierarchy)
			{
				return;
			}
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				if (Height == 0 || Height > 1)
				{
					if (PlayerGlobals.Money > 33.33f)
					{
						if (!AreYouSure.activeInHierarchy)
						{
							AreYouSure.SetActive(value: true);
						}
						else
						{
							AreYouSure.SetActive(value: false);
							GameGlobals.SpareUniform = true;
							PlayerGlobals.Money -= 33.33f;
							MyAudio.Play();
							MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
							Clock.UpdateMoneyLabel();
						}
					}
					else
					{
						Shake = 10f;
					}
				}
				else if (Height == 1)
				{
					if (PlayerGlobals.Money > 8.49f)
					{
						if (!AreYouSure.activeInHierarchy)
						{
							AreYouSure.SetActive(value: true);
						}
						else
						{
							AreYouSure.SetActive(value: false);
							GameGlobals.BlondeHair = true;
							PlayerGlobals.Money -= 8.49f;
							MyAudio.Play();
							MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
							Clock.UpdateMoneyLabel();
						}
					}
					else
					{
						Shake = 10f;
					}
				}
			}
			Shake = Mathf.MoveTowards(Shake, 0f, Time.deltaTime * 10f);
			MoneyLabel.transform.localPosition = new Vector3(570f + Random.Range(Shake * -1f, Shake * 1f), 420f + Random.Range(Shake * -1f, Shake * 1f), 0f);
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				if (!AreYouSure.activeInHierarchy)
				{
					NavigationMenu.SetActive(value: true);
					OnlineShopping.SetActive(value: false);
				}
				else
				{
					AreYouSure.SetActive(value: false);
				}
			}
			if (!AreYouSure.activeInHierarchy)
			{
				if (InputManager.TappedDown)
				{
					Height++;
				}
				if (InputManager.TappedUp)
				{
					Height--;
				}
			}
			if (Height < 0)
			{
				Height = 0;
			}
			if (Height > 4)
			{
				Height = 4;
			}
			if (Height == 0)
			{
				Highlight.localPosition = Vector3.Lerp(Highlight.localPosition, new Vector3(Highlight.localPosition.x, 130f, Highlight.localPosition.z), Time.deltaTime * 10f);
			}
			else if (Height > 0)
			{
				Highlight.localPosition = Vector3.Lerp(Highlight.localPosition, new Vector3(Highlight.localPosition.x, -85f, Highlight.localPosition.z), Time.deltaTime * 10f);
			}
			if (Height < 2)
			{
				ItemList.localPosition = Vector3.Lerp(ItemList.localPosition, new Vector3(ItemList.localPosition.x, 130f, ItemList.localPosition.z), Time.deltaTime * 10f);
			}
			else
			{
				ItemList.localPosition = Vector3.Lerp(ItemList.localPosition, new Vector3(ItemList.localPosition.x, 130 + 215 * (Height - 1), ItemList.localPosition.z), Time.deltaTime * 10f);
			}
		}
	}

	private void ExitPost()
	{
		Highlights[1].enabled = false;
		Highlights[2].enabled = false;
		Highlights[3].enabled = false;
		NewPostText.SetActive(value: false);
		BG.SetActive(value: false);
		PostLabels[1].text = string.Empty;
		PostLabels[2].text = string.Empty;
		PostLabels[3].text = string.Empty;
		WritingPost = false;
	}

	private void UpdateHighlight()
	{
		if (Selected > 3)
		{
			Selected = 1;
		}
		if (Selected < 1)
		{
			Selected = 3;
		}
		Highlights[1].enabled = false;
		Highlights[2].enabled = false;
		Highlights[3].enabled = false;
		Highlights[Selected].enabled = true;
	}

	private void UpdateMenuHighlight()
	{
		if (MenuSelected > 10)
		{
			MenuSelected = 1;
		}
		if (MenuSelected < 1)
		{
			MenuSelected = 10;
		}
		MenuHighlight.transform.localPosition = new Vector3(MenuHighlight.transform.localPosition.x, 220f - 40f * (float)MenuSelected, MenuHighlight.transform.localPosition.z);
	}

	private void CheckForCompletion()
	{
		if (PostLabels[1].text != string.Empty && PostLabels[2].text != string.Empty && PostLabels[3].text != string.Empty)
		{
			PostLabel.SetActive(value: true);
			PostIcon.SetActive(value: true);
		}
	}

	private void GetPortrait(int ID)
	{
		if (StudentGlobals.GetStudentDead(ID) || StudentGlobals.GetStudentKidnapped(ID) || StudentGlobals.GetStudentArrested(ID) || StudentGlobals.GetStudentExpelled(ID))
		{
			Debug.Log("Student #" + ID + " cannot post on the Internet because they are Dead/Kidnapped/Arrested/Expelled.");
			NameLabels[ID].text = "Anonymous";
			CurrentPortrait = AnonymousPortrait;
			return;
		}
		WWW wWW = new WWW("file:///" + Application.streamingAssetsPath + "/Portraits/Student_" + ID + ".png");
		CurrentPortrait = wWW.texture;
	}

	private void ChangeReplies(int Rival)
	{
		if (Rival == 2)
		{
			NewPostTextLabel.text = "Did you know that _______________ used to ____________________  in       ______________________________?";
			ReplyLabels[1].text = "omg really??? i thought i just imagined it";
			ReplyLabels[2].text = "YOU LITERALLY SAW IT WITH YOUR OWN EYES???";
			ReplyLabels[3].text = "lol dis is gettin gud";
			ReplyLabels[4].text = "who is ever going 2 eat at her bakery after this???";
			ReplyLabels[5].text = "time to review bomb her fam's nasty-ass bakery";
		}
	}
}
