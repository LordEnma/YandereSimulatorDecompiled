using UnityEngine;

public class SocialScript : MonoBehaviour
{
	public DialogueWheelScript DialogueWheel;

	public InputManagerScript InputManager;

	public UILabel PsychologyBonusLabel;

	public UILabel AcquaintenceLabel;

	public UILabel DialogueLabel;

	public UILabel FriendLabel;

	public UISprite[] ComplimentButton;

	public UISprite[] ShowOffButton;

	public UISprite[] Checkmark;

	public UISprite[] Button;

	public GameObject ComplimentSet;

	public GameObject ShowOffSet;

	public StudentScript Student;

	public YandereScript Yandere;

	public UISprite Divider;

	public Transform Arrow;

	public Transform Bar;

	public UIPanel Panel;

	public float[] StudentThresholds;

	public string[] ShowOffDialogue;

	public string[] Dialogue;

	public int[] StudentFriendships;

	public bool[] SpokeNegative;

	public bool[] SpokePositive;

	public bool[] Complimented;

	public bool[] ShowedOff;

	public bool[] Gifted;

	public int Multiplier;

	public int StudentID;

	public int Selected;

	public int Column;

	public int Row;

	public bool Complimenting;

	public bool ShowingOff;

	public bool Tutorial;

	public bool Show;

	private void Start()
	{
		ComplimentSet.SetActive(value: false);
		ShowOffSet.SetActive(value: false);
		for (int i = 1; i < 101; i++)
		{
			StudentFriendships[i] = StudentGlobals.GetStudentFriendship(i);
		}
		if (!GameGlobals.Eighties)
		{
			StudentThresholds[4] = 0.25f;
			StudentThresholds[39] = 0.25f;
		}
		Tutorial = GameGlobals.KokonaTutorial;
	}

	private void Update()
	{
		if (Show)
		{
			Yandere.MainCamera.transform.position = Vector3.Lerp(Yandere.MainCamera.transform.position, Yandere.transform.position + new Vector3(0f, 1.4f, 0f) + Yandere.transform.forward * 0.1f, Time.unscaledDeltaTime * 10f);
			Yandere.MainCamera.transform.eulerAngles = Vector3.Lerp(Yandere.MainCamera.transform.eulerAngles, Yandere.transform.eulerAngles, Time.unscaledDeltaTime * 10f);
			Student.CharacterAnimation.Play(Student.IdleAnim);
			Student.CharacterAnimation[Student.IdleAnim].time += Time.unscaledDeltaTime;
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 1f, Time.unscaledDeltaTime * 10f);
			if (Complimenting)
			{
				if (InputManager.TappedDown)
				{
					Row++;
					if (Row > 6)
					{
						Row = 1;
					}
					UpdateHighlight();
				}
				if (InputManager.TappedUp)
				{
					Row--;
					if (Row < 1)
					{
						Row = 6;
					}
					UpdateHighlight();
				}
				if (InputManager.TappedRight)
				{
					Column++;
					if (Column > 3)
					{
						Column = 1;
					}
					UpdateHighlight();
				}
				if (InputManager.TappedLeft)
				{
					Column--;
					if (Column < 1)
					{
						Column = 3;
					}
					UpdateHighlight();
				}
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (Selected == (int)Student.Persona)
					{
						Student.Talk.CalculateRepBonus();
						Student.Reputation.PendingRep += 1f + (float)Student.RepBonus;
						Student.PendingRep += 1f + (float)Student.RepBonus;
						DialogueLabel.text = "Thanks, I appreciate that!";
					}
					else
					{
						DialogueLabel.text = "Uh...okay.";
					}
					Complimented[StudentID] = true;
					ReturnToMainMenu();
					UpdateButtons();
					Selected = 3;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ReturnToMainMenu();
					Selected = 3;
				}
				return;
			}
			if (ShowingOff)
			{
				if (InputManager.TappedDown)
				{
					Selected++;
					if (Selected > 5)
					{
						Selected = 1;
					}
					UpdateShowOffHighlight();
				}
				if (InputManager.TappedUp)
				{
					Selected--;
					if (Selected < 1)
					{
						Selected = 5;
					}
					UpdateShowOffHighlight();
				}
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					int num = 0;
					if (Selected == 1)
					{
						num = Yandere.Class.BiologyGrade + Yandere.Class.BiologyBonus;
					}
					else if (Selected == 2)
					{
						num = Yandere.Class.ChemistryGrade + Yandere.Class.ChemistryBonus;
					}
					else if (Selected == 3)
					{
						num = Yandere.Class.LanguageGrade + Yandere.Class.LanguageBonus;
					}
					else if (Selected == 4)
					{
						num = Yandere.Class.PhysicalGrade + Yandere.Class.PhysicalBonus;
					}
					else if (Selected == 5)
					{
						num = Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus;
					}
					DialogueLabel.text = ShowOffDialogue[num];
					if (num > 0)
					{
						StudentFriendships[StudentID] += num - 1;
						Student.Talk.CalculateRepBonus();
						Student.Reputation.PendingRep += 1f + (float)Student.RepBonus;
						Student.PendingRep += 1f + (float)Student.RepBonus;
					}
					ShowedOff[StudentID] = true;
					ReturnToMainMenu();
					UpdateButtons();
					Selected = 4;
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					ReturnToMainMenu();
					Selected = 4;
				}
				return;
			}
			Time.timeScale = 0.0001f;
			if (InputManager.TappedDown)
			{
				Selected++;
				if (Selected > 6)
				{
					Selected = 1;
				}
				Arrow.localPosition = new Vector3(570f, 450 - Selected * 100, 0f);
			}
			if (InputManager.TappedUp)
			{
				Selected--;
				if (Selected < 1)
				{
					Selected = 6;
				}
				Arrow.localPosition = new Vector3(570f, 450 - Selected * 100, 0f);
			}
			Yandere.CameraEffects.UpdateDOF(Vector3.Distance(Yandere.MainCamera.transform.position, Student.Head.position));
			if (!Input.GetButtonDown(InputNames.Xbox_A))
			{
				return;
			}
			if (Selected == 6)
			{
				Yandere.ShoulderCamera.enabled = true;
				Yandere.CameraEffects.UpdateDOF(2f);
				Yandere.HUD.alpha = 1f;
				DialogueWheel.Panel.enabled = true;
				DialogueWheel.Panel.alpha = 1f;
				DialogueWheel.Show = true;
				Time.timeScale = 1f;
				Show = false;
			}
			else
			{
				if (Button[Selected].alpha != 1f)
				{
					return;
				}
				if (Selected == 1 || Selected == 2)
				{
					DialogueWheel.PromptBar.ClearButtons();
					DialogueWheel.PromptBar.Label[0].text = "Speak";
					DialogueWheel.PromptBar.Label[1].text = "Back";
					DialogueWheel.PromptBar.UpdateButtons();
					DialogueWheel.PromptBar.Show = true;
					DialogueWheel.TopicInterface.UpdateOpinions();
					DialogueWheel.TopicInterface.gameObject.SetActive(value: true);
					DialogueWheel.TopicInterface.Positive = false;
					if (Selected == 2)
					{
						DialogueWheel.TopicInterface.Positive = true;
					}
					DialogueWheel.TopicInterface.UpdateTopicHighlight();
					base.gameObject.SetActive(value: false);
					Yandere.HUD.alpha = 1f;
				}
				else if (Selected == 3)
				{
					DialogueWheel.PromptBar.ClearButtons();
					DialogueWheel.PromptBar.Label[0].text = "Confirm";
					DialogueWheel.PromptBar.Label[1].text = "Back";
					DialogueWheel.PromptBar.Label[4].text = "Change Selection";
					DialogueWheel.PromptBar.Label[5].text = "Change Selection";
					DialogueWheel.PromptBar.UpdateButtons();
					DialogueWheel.PromptBar.Show = true;
					ComplimentSet.SetActive(value: true);
					Complimenting = true;
					UpdateHighlight();
				}
				else if (Selected == 4)
				{
					DialogueWheel.PromptBar.ClearButtons();
					DialogueWheel.PromptBar.Label[0].text = "Confirm";
					DialogueWheel.PromptBar.Label[1].text = "Back";
					DialogueWheel.PromptBar.Label[4].text = "Change Selection";
					DialogueWheel.PromptBar.UpdateButtons();
					DialogueWheel.PromptBar.Show = true;
					ShowOffSet.SetActive(value: true);
					ShowingOff = true;
					Selected = 1;
					UpdateShowOffHighlight();
				}
				else if (Selected == 5)
				{
					DialogueLabel.text = "Oh, wow! Thanks! That's really generous of you!";
					Yandere.Inventory.Money -= 5f;
					Yandere.Inventory.UpdateMoney();
					Student.Talk.CalculateRepBonus();
					Student.Reputation.PendingRep += 1f + (float)Student.RepBonus;
					Student.PendingRep += 1f + (float)Student.RepBonus;
					Gifted[StudentID] = true;
					UpdateButtons();
				}
			}
		}
		else
		{
			Panel.alpha = Mathf.MoveTowards(Panel.alpha, 0f, Time.deltaTime * 10f);
			if (Panel.alpha < 0.0001f)
			{
				Panel.alpha = 0f;
				base.enabled = false;
			}
		}
	}

	public void UpdateButtons()
	{
		Bar.localScale = new Vector3((float)StudentFriendships[StudentID] * 0.01f, 1f, 1f);
		Divider.transform.localPosition = new Vector3(-850f + 1700f * StudentThresholds[StudentID], 530f, 0f);
		AcquaintenceLabel.transform.localPosition = new Vector3(-850f + 1700f * StudentThresholds[StudentID] * 0.5f, 530f, 0f);
		FriendLabel.transform.localPosition = new Vector3((Divider.transform.localPosition.x + 850f) * 0.5f + 2f, 530f, 0f);
		for (int i = 1; i < Checkmark.Length; i++)
		{
			Checkmark[i].spriteName = "No";
			Checkmark[i].color = Color.red;
		}
		if (Tutorial)
		{
			SpokeNegative[StudentID] = true;
			Complimented[StudentID] = true;
			ShowedOff[StudentID] = true;
			Gifted[StudentID] = true;
		}
		if (SpokeNegative[StudentID])
		{
			Button[1].alpha = 0.5f;
		}
		else
		{
			Button[1].alpha = 1f;
		}
		if (SpokePositive[StudentID])
		{
			Button[2].alpha = 0.5f;
		}
		else
		{
			Button[2].alpha = 1f;
		}
		if (Complimented[StudentID])
		{
			Button[3].alpha = 0.5f;
		}
		else
		{
			Button[3].alpha = 1f;
		}
		if (ShowedOff[StudentID])
		{
			Button[4].alpha = 0.5f;
		}
		else
		{
			Button[4].alpha = 1f;
		}
		if (Gifted[StudentID])
		{
			Button[5].alpha = 0.5f;
		}
		else
		{
			Button[5].alpha = 1f;
		}
		if (Yandere.Inventory.Money < 5f)
		{
			Button[5].alpha = 0.5f;
		}
		Multiplier = 1;
		if (PlayerGlobals.PantiesEquipped == 3)
		{
			Checkmark[1].spriteName = "Yes";
			Checkmark[1].color = Color.green;
			Multiplier++;
		}
		if (Yandere.Class.SocialBonus > 0)
		{
			Checkmark[2].spriteName = "Yes";
			Checkmark[2].color = Color.green;
			Multiplier++;
		}
		Student.ChameleonCheck();
		if (Student.Chameleon)
		{
			Checkmark[3].spriteName = "Yes";
			Checkmark[3].color = Color.green;
			Multiplier++;
		}
		if ((Student.Male && Yandere.Class.Seduction + Yandere.Class.SeductionBonus > 0) || Yandere.Class.Seduction == 5)
		{
			Checkmark[4].spriteName = "Yes";
			Checkmark[4].color = Color.green;
			Multiplier++;
		}
		PsychologyBonusLabel.text = (Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus).ToString() ?? "";
		Multiplier += Yandere.Class.PsychologyGrade + Yandere.Class.PsychologyBonus;
	}

	public void UpdateHighlight()
	{
		for (int i = 1; i < ComplimentButton.Length; i++)
		{
			ComplimentButton[i].color = new Color(1f, 0.75f, 1f, 1f);
		}
		Selected = Column + (Row - 1) * 3;
		ComplimentButton[Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	public void UpdateShowOffHighlight()
	{
		for (int i = 1; i < ShowOffButton.Length; i++)
		{
			ShowOffButton[i].color = new Color(1f, 0.75f, 1f, 1f);
		}
		ShowOffButton[Selected].color = new Color(1f, 1f, 1f, 1f);
	}

	public void ReturnToMainMenu()
	{
		DialogueWheel.PromptBar.ClearButtons();
		DialogueWheel.PromptBar.Label[0].text = "Confirm";
		DialogueWheel.PromptBar.Label[4].text = "Change Selection";
		DialogueWheel.PromptBar.UpdateButtons();
		DialogueWheel.PromptBar.Show = true;
		ShowOffSet.SetActive(value: false);
		ShowingOff = false;
		ComplimentSet.SetActive(value: false);
		Complimenting = false;
	}

	public void SaveFriendships()
	{
		for (int i = 1; i < 101; i++)
		{
			StudentGlobals.SetStudentFriendship(i, StudentFriendships[i]);
		}
	}

	public void CheckFriendStatus()
	{
		if (Student == null)
		{
			Debug.Log("Warning! Student was null!");
			Student = Yandere.TargetStudent;
		}
		Debug.Log("Current Student is: " + Student.Name);
		Debug.Log("Current StudentID is: " + StudentID);
		if (StudentFriendships[StudentID] > 100)
		{
			StudentFriendships[StudentID] = 100;
		}
		if (!Student.Friend && (float)StudentFriendships[StudentID] >= 100f * StudentThresholds[StudentID])
		{
			Debug.Log("Befriending student now.");
			Yandere.NotificationManager.CustomText = "Student Befriended!";
			Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			Yandere.StudentManager.StudentBefriended[StudentID] = true;
			Yandere.Police.EndOfDay.NewFriends++;
			Yandere.Friends++;
			Student.Friend = true;
			Student.TurnOutlinesGreen();
			DialogueWheel.HideShadows();
		}
	}
}
