using UnityEngine;
using UnityEngine.SceneManagement;

public class WeekSelectScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public InputManagerScript InputManager;

	public EightiesStatsScript Stats;

	public GameObject[] Shadow;

	public UISprite Darkness;

	public UILabel StartLabel;

	public UILabel EditLabel;

	public UILabel WeekLabel;

	public Transform Arrow;

	public bool SettingDetails;

	public bool SettingRivals;

	public bool SettingWeek;

	public bool Fading;

	public int DetailID = 1;

	public int RivalID = 1;

	public int WeekID = 1;

	public int FadeID = 1;

	public int Row = 1;

	public int Column = 1;

	public int[] Specifics;

	public int CurrentWeek;

	public Vector3[] StartingPosition;

	public Transform[] Sleeve;

	public Transform[] Tape;

	private void Start()
	{
		StudentManager.InitializeReputations();
		GameGlobals.ReputationsInitialized = true;
		base.transform.position = new Vector3(0f, 2.31f, 0f);
		EditLabel.gameObject.SetActive(value: false);
		StartLabel.text = "NEXT";
		Darkness.alpha = 1f;
		UpdateArrow();
		UpdateText();
		for (int i = 1; i < 11; i++)
		{
			StartingPosition[i] = Sleeve[i].position;
		}
		DetermineSelectedWeek();
		StudentGlobals.Prisoners = 0;
	}

	private void Update()
	{
		if (Fading)
		{
			if (FadeID == 1)
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
				if (Darkness.alpha == 0f)
				{
					Fading = false;
					FadeID++;
				}
			}
			else
			{
				Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
				if (Darkness.alpha == 1f)
				{
					for (int i = 1; i < 11; i++)
					{
						if (GameGlobals.GetSpecificEliminations(i) == 1 || GameGlobals.GetSpecificEliminations(i) == 5 || GameGlobals.GetSpecificEliminations(i) == 6 || GameGlobals.GetSpecificEliminations(i) == 7 || GameGlobals.GetSpecificEliminations(i) == 8 || GameGlobals.GetSpecificEliminations(i) == 10 || GameGlobals.GetSpecificEliminations(i) == 14 || GameGlobals.GetSpecificEliminations(i) == 15 || GameGlobals.GetSpecificEliminations(i) == 16 || GameGlobals.GetSpecificEliminations(i) == 17 || GameGlobals.GetSpecificEliminations(i) == 19 || GameGlobals.GetSpecificEliminations(i) == 20)
						{
							Debug.Log("Rival #" + i + " is dead.");
							StudentGlobals.SetStudentDead(i + 10, value: true);
							continue;
						}
						StudentGlobals.SetStudentDead(i + 10, value: false);
						if (GameGlobals.GetSpecificEliminations(i) == 2)
						{
							PlayerGlobals.SetStudentFriend(i + 10, value: true);
							PlayerGlobals.Friends++;
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 3)
						{
							Debug.Log("Rival #" + i + " was betrayed, so she will appear in the basement as a prisoner.");
							StudentGlobals.SetStudentKidnapped(i + 10, value: true);
							StudentGlobals.SetStudentMissing(i + 10, value: true);
							StudentGlobals.SetStudentHealth(i + 10, 100);
							StudentGlobals.Prisoners++;
							AssignPrisoner(i);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 4)
						{
							Debug.Log("Rival #" + i + " was bullied out of school, so she will not be appearing at Akademi.");
							StudentGlobals.SetStudentMissing(i + 10, value: true);
							StudentGlobals.SetStudentReputation(i + 10, -100);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 9)
						{
							StudentGlobals.SetStudentExpelled(i + 10, value: true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 11)
						{
							StudentGlobals.SetStudentArrested(i + 10, value: true);
						}
						else if (GameGlobals.GetSpecificEliminations(i) == 12)
						{
							Debug.Log("Rival #" + i + " was kidnapped, so she will appear in the basement as a prisoner.");
							StudentGlobals.SetStudentKidnapped(i + 10, value: true);
							StudentGlobals.SetStudentMissing(i + 10, value: true);
							StudentGlobals.SetStudentHealth(i + 10, 100);
							StudentGlobals.Prisoners++;
							AssignPrisoner(i);
						}
					}
					GameGlobals.SetSpecificEliminations(DateGlobals.Week, 0);
					GameGlobals.SetRivalEliminations(DateGlobals.Week, 0);
					ClassGlobals.BonusStudyPoints = DateGlobals.Week * 50 - 50;
					GameGlobals.EightiesCutsceneID = DateGlobals.Week;
					DateGlobals.PassDays = 0;
					SceneManager.LoadScene("EightiesCutsceneScene");
				}
			}
		}
		if (SettingWeek)
		{
			if (InputManager.TappedDown || InputManager.TappedUp)
			{
				if (Row == 1)
				{
					Row = 2;
				}
				else
				{
					Row = 1;
				}
				DetermineSelectedWeek();
			}
			else if (InputManager.TappedRight)
			{
				Column++;
				if (Column > 5)
				{
					Column = 1;
				}
				DetermineSelectedWeek();
			}
			else if (InputManager.TappedLeft)
			{
				Column--;
				if (Column < 1)
				{
					Column = 5;
				}
				DetermineSelectedWeek();
			}
		}
		else if (SettingRivals)
		{
			if (InputManager.TappedDown)
			{
				if (RivalID == 5 || RivalID == 10)
				{
					SettingRivals = false;
					SettingDetails = true;
					if (RivalID == 5)
					{
						DetailID = 1;
					}
					else
					{
						DetailID = 5;
					}
				}
				else
				{
					RivalID++;
				}
				UpdateArrow();
			}
			else if (InputManager.TappedUp)
			{
				if (RivalID != 1 && RivalID != 6)
				{
					RivalID--;
				}
				UpdateArrow();
			}
			else if (InputManager.TappedRight)
			{
				if (RivalID < 6)
				{
					RivalID += 5;
				}
				else
				{
					RivalID -= 5;
				}
				UpdateArrow();
			}
			else if (InputManager.TappedLeft)
			{
				if (RivalID > 5)
				{
					RivalID -= 5;
				}
				else
				{
					RivalID += 5;
				}
				UpdateArrow();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_Y))
			{
				GameGlobals.SetSpecificEliminations(RivalID, GameGlobals.GetSpecificEliminations(RivalID) + 1);
				if (GameGlobals.GetSpecificEliminations(RivalID) > 20)
				{
					GameGlobals.SetSpecificEliminations(RivalID, 1);
				}
				GameGlobals.SetRivalEliminations(RivalID, Specifics[GameGlobals.GetSpecificEliminations(RivalID)]);
				Debug.Log("Rival #" + RivalID + "'s SpecificElimination is now " + GameGlobals.GetSpecificEliminations(RivalID));
				Debug.Log("Rival #" + RivalID + "'s Elimination is now " + GameGlobals.GetRivalEliminations(RivalID));
				UpdateText();
			}
			else if (Input.GetButtonDown(InputNames.Xbox_X))
			{
				GameGlobals.SetSpecificEliminations(RivalID, GameGlobals.GetSpecificEliminations(RivalID) - 1);
				if (GameGlobals.GetSpecificEliminations(RivalID) < 1)
				{
					GameGlobals.SetSpecificEliminations(RivalID, 20);
				}
				GameGlobals.SetRivalEliminations(RivalID, Specifics[GameGlobals.GetSpecificEliminations(RivalID)]);
				UpdateText();
			}
		}
		else if (InputManager.TappedDown)
		{
			if (DetailID != 4 && DetailID != 8)
			{
				DetailID++;
			}
			UpdateArrow();
		}
		else if (InputManager.TappedUp)
		{
			if (DetailID == 1 || DetailID == 5)
			{
				SettingDetails = false;
				SettingRivals = true;
				if (DetailID == 1)
				{
					RivalID = 5;
				}
				else
				{
					RivalID = 10;
				}
			}
			else
			{
				DetailID--;
			}
			UpdateArrow();
		}
		else if (InputManager.TappedRight)
		{
			if (DetailID < 5)
			{
				DetailID += 4;
			}
			else
			{
				DetailID -= 4;
			}
			UpdateArrow();
		}
		else if (InputManager.TappedLeft)
		{
			if (DetailID > 4)
			{
				DetailID -= 4;
			}
			else
			{
				DetailID += 4;
			}
			UpdateArrow();
		}
		else if (Input.GetButtonDown(InputNames.Xbox_Y) || Input.GetButtonDown(InputNames.Xbox_X))
		{
			if (DetailID == 1)
			{
				if (PlayerGlobals.PoliceVisits == 0)
				{
					PlayerGlobals.PoliceVisits = 10;
				}
				else
				{
					PlayerGlobals.PoliceVisits = 0;
				}
			}
			else if (DetailID == 2)
			{
				if (PlayerGlobals.CorpsesDiscovered == 0)
				{
					PlayerGlobals.CorpsesDiscovered = 10;
				}
				else
				{
					PlayerGlobals.CorpsesDiscovered = 0;
				}
			}
			else if (DetailID == 3)
			{
				if (PlayerGlobals.Reputation == 0f)
				{
					PlayerGlobals.Reputation = 100f;
				}
				else
				{
					PlayerGlobals.Reputation = 0f;
				}
			}
			else if (DetailID == 4)
			{
				if (!StudentGlobals.GetStudentGrudge(2))
				{
					SetGrudges(Grudge: true);
				}
				else
				{
					SetGrudges(Grudge: false);
				}
			}
			else if (DetailID == 5)
			{
				if (PlayerGlobals.Friends == 0)
				{
					MakeFriends(Friend: true);
				}
				else
				{
					MakeFriends(Friend: false);
				}
			}
			else if (DetailID == 6)
			{
				if (PlayerGlobals.Alarms == 0)
				{
					PlayerGlobals.Alarms = 10;
				}
				else
				{
					PlayerGlobals.Alarms = 0;
				}
			}
			else if (DetailID == 7)
			{
				if (PlayerGlobals.WeaponWitnessed == 0)
				{
					PlayerGlobals.WeaponWitnessed = 10;
				}
				else
				{
					PlayerGlobals.WeaponWitnessed = 0;
				}
			}
			else if (DetailID == 8)
			{
				if (PlayerGlobals.BloodWitnessed == 0)
				{
					PlayerGlobals.BloodWitnessed = 10;
				}
				else
				{
					PlayerGlobals.BloodWitnessed = 0;
				}
			}
			UpdateText();
		}
		if (SettingWeek)
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 2.31f, 0f), Time.deltaTime * 10f);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				SettingWeek = false;
				SettingRivals = true;
				EditLabel.gameObject.SetActive(value: true);
				StartLabel.text = "START";
				RivalID = 1;
				UpdateArrow();
			}
		}
		else
		{
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			if (Input.GetButtonDown(InputNames.Xbox_A))
			{
				Fading = true;
			}
			if (Input.GetButtonDown(InputNames.Xbox_B))
			{
				SettingWeek = true;
				SettingRivals = false;
				SettingDetails = false;
				EditLabel.gameObject.SetActive(value: false);
				StartLabel.text = "NEXT";
				UpdateArrow();
			}
		}
		for (int j = 1; j < 11; j++)
		{
			if (j == CurrentWeek)
			{
				Sleeve[j].transform.position = Vector3.Lerp(Sleeve[j].transform.position, StartingPosition[j] + base.transform.up * 0.05f + base.transform.right * -0.05f, Time.deltaTime * 10f);
				Tape[j].transform.localPosition = Vector3.Lerp(Tape[j].transform.localPosition, new Vector3(0f, -0.0003f, 0f), Time.deltaTime * 10f);
			}
			else
			{
				Sleeve[j].transform.position = Vector3.Lerp(Sleeve[j].transform.position, StartingPosition[j], Time.deltaTime * 10f);
				Tape[j].transform.localPosition = Vector3.Lerp(Tape[j].transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
			}
		}
	}

	private void UpdateArrow()
	{
		if (SettingWeek)
		{
			Arrow.localPosition = new Vector3(0f, 610f, 0f);
		}
		else if (SettingRivals)
		{
			if (RivalID < 6)
			{
				Arrow.localPosition = new Vector3(-820f, 495 - 120 * RivalID, 0f);
			}
			else
			{
				Arrow.localPosition = new Vector3(-15f, 495 - 120 * (RivalID - 5), 0f);
			}
		}
		else if (DetailID < 5)
		{
			Arrow.localPosition = new Vector3(-800f, -257 - 33 * DetailID, 0f);
		}
		else
		{
			Arrow.localPosition = new Vector3(0f, -257 - 33 * (DetailID - 4), 0f);
		}
	}

	private void UpdateText()
	{
		WeekLabel.text = "STARTING WEEK: " + CurrentWeek;
		for (int i = 1; i < 11; i++)
		{
			if (i < DateGlobals.Week)
			{
				Shadow[i].SetActive(value: false);
				continue;
			}
			Shadow[i].SetActive(value: true);
			GameGlobals.SetRivalEliminations(i, 0);
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		Stats.Start();
	}

	private void SetGrudges(bool Grudge)
	{
		for (int i = 2; i < 12; i++)
		{
			StudentGlobals.SetStudentGrudge(i, Grudge);
		}
	}

	private void MakeFriends(bool Friend)
	{
		for (int i = 2; i < 86; i++)
		{
			if (i < 11 || i > 20)
			{
				PlayerGlobals.SetStudentFriend(i, Friend);
				PlayerGlobals.Friends++;
			}
		}
		if (Friend)
		{
			GameGlobals.YakuzaPhase = 1;
			return;
		}
		PlayerGlobals.Friends = 0;
		GameGlobals.YakuzaPhase = 0;
	}

	private void DetermineSelectedWeek()
	{
		CurrentWeek = Column + (Row - 1) * 5;
		for (int i = 1; i < 10; i++)
		{
			GameGlobals.SetRivalEliminations(i, 0);
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		for (int i = 1; i < CurrentWeek; i++)
		{
			GameGlobals.SetRivalEliminations(i, 1);
			GameGlobals.SetSpecificEliminations(i, 1);
		}
		DateGlobals.Week = CurrentWeek;
		UpdateText();
	}

	private void AssignPrisoner(int ID)
	{
		if (StudentGlobals.Prisoners == 1)
		{
			StudentGlobals.Prisoner1 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 2)
		{
			StudentGlobals.Prisoner2 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 3)
		{
			StudentGlobals.Prisoner3 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 4)
		{
			StudentGlobals.Prisoner4 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 5)
		{
			StudentGlobals.Prisoner5 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 6)
		{
			StudentGlobals.Prisoner6 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 7)
		{
			StudentGlobals.Prisoner7 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 8)
		{
			StudentGlobals.Prisoner8 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 9)
		{
			StudentGlobals.Prisoner9 = 10 + ID;
		}
		else if (StudentGlobals.Prisoners == 10)
		{
			StudentGlobals.Prisoner10 = 10 + ID;
		}
	}
}
