using System;
using UnityEngine;

public class ModernRivalEventScript : MonoBehaviour
{
	public EventInstructions[] Instructions;

	public bool Depressing;

	public StudentManagerScript StudentManager;

	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public AudioSource MyAudio;

	public ClockScript Clock;

	public GameObject[] EventObject;

	public StudentScript[] Char;

	public int[] CharIDs;

	public StartCriteriaType StartCriteria;

	public NextCriteriaType NextCriteria;

	public DayOfWeek Day;

	public RivalEventType EventID;

	public ClubType Club;

	public float SpecialCaseTimer;

	public float StartTimer;

	public float TimeLimit;

	public float StartTime;

	public float Timer;

	public bool AlreadyPopulated;

	public bool ClubCheck;

	public bool Private;

	public bool Done;

	public int SpecialCase;

	public int Characters;

	public int Loops;

	public int Phase;

	public int Week;

	public string[] AlternateDialogue;

	private void Start()
	{
		if (GameGlobals.Eighties || DateGlobals.Week != Week || DateGlobals.Weekday != Day)
		{
			base.gameObject.SetActive(value: false);
		}
		if (ClubCheck && ClubGlobals.GetClubClosed(Club))
		{
			Instructions[0].Destination[0].eulerAngles = Vector3.zero;
			for (int i = 1; i < Instructions.Length; i++)
			{
				Instructions[i].Dialogue = AlternateDialogue[i];
				Instructions[i].Anim[0] = "f02_bulliedIdle_00";
			}
		}
	}

	private void Update()
	{
		StartTimer += Time.deltaTime;
		if (!(StartTimer > 1f))
		{
			return;
		}
		if (Phase == -1)
		{
			if (StartCriteria == StartCriteriaType.PositionZ)
			{
				if (Clock.HourTime > 8f)
				{
					Debug.Log("It's too late in the day for one of a rival's events to happen. It won't be happening.");
					base.gameObject.SetActive(value: false);
					base.enabled = false;
				}
				else if (Char[0] == null)
				{
					Char[0] = StudentManager.Students[CharIDs[0]];
					if (Char[0] != null)
					{
						PopulateCharacterList();
					}
				}
				else if (!Char[0].InEvent && Char[0].transform.position.z > -48f && Clock.HourTime > 7.02f)
				{
					Debug.Log("A character's event has begun because they have walked past the school gate.");
					if (Char[0].Slave || Char[0].Hunted)
					{
						Debug.Log("Never mind. Cancel event. Character is a mind-broken slave or is being targeted by one.");
						base.gameObject.SetActive(value: false);
						base.enabled = false;
					}
					else
					{
						Char[0].InEvent = true;
						Char[0].Private = Private;
						Char[0].IgnoringPettyActions = true;
						Phase++;
						TakeInstructions();
					}
				}
			}
			else if (StartCriteria == StartCriteriaType.BagSet)
			{
				if (Char[0] == null)
				{
					PopulateCharacterList();
				}
				else
				{
					if (Char[0].BookBag.activeInHierarchy)
					{
						return;
					}
					Debug.Log("The rival has set down her bookbag, so an event is ready to begin, but are all characters ready?");
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < Char.Length; i++)
					{
						if (Char[i] != null && !Char[i].InEvent && Char[i].Routine && !Char[i].Following)
						{
							num++;
						}
						if (Char[i] != null && !Char[i].Alive)
						{
							num2++;
						}
					}
					if (num != Characters - num2)
					{
						return;
					}
					Debug.Log("A character's event has begun because they have set down their bookbag, and all characters involved are ready.");
					if (Char[0].Slave || Char[0].Hunted)
					{
						Debug.Log("Never mind. Cancel event. Character is a mind-broken slave or is being targeted by one.");
						base.gameObject.SetActive(value: false);
						base.enabled = false;
						return;
					}
					Char[0].InEvent = true;
					Char[0].Private = Private;
					Char[0].IgnoringPettyActions = true;
					StudentScript[] array = Char;
					foreach (StudentScript studentScript in array)
					{
						if (studentScript != null)
						{
							studentScript.InEvent = true;
						}
					}
					Phase++;
					TakeInstructions();
				}
			}
			else if (StartCriteria == StartCriteriaType.Time && Clock.HourTime > StartTime)
			{
				if (Char[0] == null)
				{
					PopulateCharacterList();
				}
				else if (!Char[0].InEvent && Char[0].Routine)
				{
					Debug.Log("A ModernRivalEvent has begun because the clock has advanced to a specific time of day.");
					for (int k = 0; k < Char.Length; k++)
					{
						Char[k].EmptyHands();
						Char[k].InEvent = true;
						Char[k].Private = Private;
						Char[k].IgnoringPettyActions = true;
					}
					Phase++;
					TakeInstructions();
				}
			}
			else if (StartCriteria == StartCriteriaType.Indoors)
			{
				if (Char[0] == null)
				{
					PopulateCharacterList();
				}
				else if (Char[0].Indoors)
				{
					Debug.Log("A character's event has begun because they've changed into their indoor shoes.");
					Char[0].InEvent = true;
					Char[0].Private = Private;
					Char[0].IgnoringPettyActions = true;
					Phase++;
					TakeInstructions();
				}
			}
			return;
		}
		if (NextCriteria == NextCriteriaType.TimeLimit)
		{
			Timer += Time.deltaTime;
			if (Timer > TimeLimit)
			{
				Phase++;
				TakeInstructions();
			}
		}
		else if (NextCriteria == NextCriteriaType.DestinationReached)
		{
			int num3 = 0;
			for (int l = 0; l < Char.Length; l++)
			{
				if (Char[l] != null)
				{
					if (Char[l].DistanceToDestination < 0.5f)
					{
						PlayDesignatedAnimation(l);
						num3++;
					}
					else if (Instructions[Phase].Rush)
					{
						Char[l].CharacterAnimation.CrossFade(Char[l].SprintAnim);
					}
					else
					{
						Char[l].CharacterAnimation.CrossFade(Char[l].WalkAnim);
					}
				}
			}
			if (num3 == Characters)
			{
				Phase++;
				TakeInstructions();
			}
		}
		UpdateSubtitle();
		for (int m = 0; m < Char.Length; m++)
		{
			if (Char[m] != null && (Char[m].Alarmed || Char[m].Splashed || Char[m].Dying || Char[m].GoAway))
			{
				Debug.Log("The event ended because a character was alarmed or splashed or stink bombed or killed.");
				if (Char[m].GoAway)
				{
					Char[m].Subtitle.CustomText = "What's that smell?! I can't take it! I'm getting out of here!";
					Char[m].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				}
				EndEvent();
			}
		}
		if (base.enabled && Phase < Instructions.Length)
		{
			SpecialCaseCheck();
		}
	}

	private void TakeInstructions()
	{
		float num = Vector3.Distance(Yandere.transform.position, Char[0].transform.position);
		if (num < 10f)
		{
			EventSubtitle.text = string.Empty;
		}
		Timer = 0f;
		if (Phase == Instructions.Length)
		{
			if (Depressing)
			{
				StudentManager.SabotageProgress++;
				Debug.Log("SabtoageProgress is now " + StudentManager.SabotageProgress + "/5");
			}
			EndEvent();
			return;
		}
		for (int i = 0; i < Char.Length; i++)
		{
			if (Char[i] != null)
			{
				if (Instructions[Phase].Type == InstructionType.Stay)
				{
					Char[i].Pathfinding.canSearch = false;
					Char[i].Pathfinding.canMove = false;
					Char[i].Pathfinding.speed = 0f;
				}
				else
				{
					Char[i].Pathfinding.target = Instructions[Phase].Destination[i];
					Char[i].CurrentDestination = Instructions[Phase].Destination[i];
					Char[i].Pathfinding.canSearch = true;
					Char[i].Pathfinding.canMove = true;
					Char[i].DistanceToDestination = 100f;
					if (Instructions[Phase].Rush)
					{
						Char[i].Pathfinding.speed = 4f;
					}
					else
					{
						Char[i].Pathfinding.speed = 1f;
					}
				}
				PlayDesignatedAnimation(i);
			}
			if (Instructions[Phase].Audio != null)
			{
				MyAudio.clip = Instructions[Phase].Audio;
				AudioSource.PlayClipAtPoint(MyAudio.clip, Char[0].transform.position);
			}
			if (num < 10f)
			{
				EventSubtitle.text = Instructions[Phase].Dialogue;
			}
			NextCriteria = Instructions[Phase].NextCritera;
			SpecialCase = Instructions[Phase].SpecialCase;
			TimeLimit = Instructions[Phase].TimeLimit;
			SpecialCaseTimer = 0f;
		}
	}

	public void UpdateSubtitle()
	{
		if (Yandere.transform.position.y > Char[0].transform.position.y - 1f && Yandere.transform.position.y < Char[0].transform.position.y + 1f)
		{
			float num = Vector3.Distance(Yandere.transform.position, Char[0].transform.position);
			float num2 = Mathf.Abs((num - 10f) * 0.2f);
			if (num < 10f)
			{
				if (Phase < Instructions.Length)
				{
					EventSubtitle.text = Instructions[Phase].Dialogue;
				}
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
				Jukebox.Dip = 1f - 0.5f * num2;
				if (Private && num < 5f)
				{
					Yandere.Eavesdropping = true;
				}
				else
				{
					Yandere.Eavesdropping = false;
				}
			}
			else if (num < 11f)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
				EventSubtitle.text = string.Empty;
				Yandere.Eavesdropping = false;
				Jukebox.Dip = 1f;
				num2 = 0f;
			}
		}
		else
		{
			MyAudio.volume = 0f;
			Jukebox.Dip = 1f;
		}
	}

	public void SpecialCaseCheck()
	{
		switch (Instructions[Phase].SpecialCase)
		{
		case 1:
			SpecialCaseTimer += Time.deltaTime;
			if (SpecialCaseTimer > 1.5f && !Char[0].SmartPhone.activeInHierarchy)
			{
				Char[0].CharacterAnimation["f02_AmaiPhoneLoop_00"].speed = 0.4f;
				Char[0].SmartPhone.transform.localPosition = new Vector3(0.025f, 0.0075f, 0.05f);
				Char[0].SmartPhone.transform.localEulerAngles = new Vector3(15f, -150f, 180f);
				Char[0].SmartPhone.SetActive(value: true);
			}
			break;
		case 2:
			if (!Private)
			{
				Char[0].SmartPhone.transform.localPosition = new Vector3(-0.005f, -0.0075f, 0f);
				Char[0].SmartPhone.transform.localEulerAngles = new Vector3(15f, -150f, 180f);
				Char[0].CharacterAnimation["f02_OsanaPhoneCall_00"].speed = 0.6f;
				Char[0].IgnoringPettyActions = false;
				Char[0].Private = true;
				Private = true;
			}
			break;
		case 3:
			if (Vector3.Distance(Yandere.transform.position, Char[0].transform.position) < 5f && !StudentManager.Police.EndOfDay.LearnedRival2Info[1])
			{
				Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
				StudentManager.Police.EndOfDay.StudentManager.Police.EndOfDay.LearnedRival2Info[1] = true;
			}
			break;
		case 4:
			if (Char[0].CharacterAnimation["f02_OsanaPhoneCall_00"].time > 42.66666f)
			{
				Char[0].SmartPhone.SetActive(value: false);
			}
			break;
		case 5:
		{
			for (int i = 1; i < Char.Length; i++)
			{
				if (Char[i] != null)
				{
					Char[i].InEvent = true;
					Char[i].Routine = false;
					Char[i].SpeechLines.Stop();
					Char[i].FocusOnStudent = true;
					Char[i].WeirdStudent = Char[0].transform;
					Char[i].CharacterAnimation.CrossFade(Char[i].IdleAnim);
				}
			}
			break;
		}
		case 6:
			SendClubToBakeSale();
			break;
		case 7:
			if (Char[0].GiftBag != null)
			{
				Char[0].GiftBag.SetActive(value: false);
			}
			EventObject[0].SetActive(value: true);
			break;
		case 8:
			Loops++;
			if (Loops < 5)
			{
				Phase = 0;
			}
			break;
		case 9:
			EventObject[0].SetActive(value: false);
			break;
		case 10:
			EventObject[1].SetActive(value: true);
			break;
		case 11:
		{
			ScheduleBlock obj = Char[0].ScheduleBlocks[4];
			obj.destination = "Picnic";
			obj.action = "Picnic";
			Char[0].GetDestinations();
			Char[0].Pathfinding.target = Char[0].Destinations[4];
			Char[0].CurrentDestination = Char[0].Destinations[4];
			ScheduleBlock obj2 = Char[1].ScheduleBlocks[4];
			obj2.destination = "Picnic";
			obj2.action = "Picnic";
			Char[1].GetDestinations();
			Char[1].Pathfinding.target = Char[1].Destinations[4];
			Char[1].CurrentDestination = Char[1].Destinations[4];
			break;
		}
		case 12:
			SpecialCaseTimer += Time.deltaTime;
			if (SpecialCaseTimer > 6.66666f)
			{
				Char[0].CameraFlash.SetActive(value: false);
				Char[0].SmartPhone.SetActive(value: false);
			}
			else if (SpecialCaseTimer > 5.33333f)
			{
				Char[0].CameraFlash.SetActive(value: true);
			}
			else if (SpecialCaseTimer > 1.25f)
			{
				Char[0].SmartPhone.transform.localPosition = new Vector3(-0.02f, -0.0025f, 0.025f);
				Char[0].SmartPhone.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
				Char[0].SmartPhone.transform.localPosition = new Vector3(0f, 0.005f, -0.01f);
				Char[0].SmartPhone.transform.localEulerAngles = new Vector3(7.33333f, -154f, 173.66666f);
				Char[0].SmartPhone.SetActive(value: true);
			}
			break;
		case 13:
			Char[0].SmartPhone.SetActive(value: true);
			break;
		case 14:
			EventObject[0].SetActive(value: true);
			EventObject[1].SetActive(value: false);
			break;
		case 15:
			SpecialCaseTimer += Time.deltaTime;
			if (SpecialCaseTimer > 7f)
			{
				Char[0].SodaCan.SetActive(value: true);
			}
			break;
		case 16:
			SpecialCaseTimer += Time.deltaTime;
			if (SpecialCaseTimer > 3.5f)
			{
				if (Char[0].CrushedCan.activeInHierarchy)
				{
					Char[0].CrushedCan.SetActive(value: false);
					EventObject[0].SetActive(value: true);
					EventObject[0].transform.position = Char[0].LeftHand.position;
					Rigidbody component = EventObject[0].GetComponent<Rigidbody>();
					component.AddRelativeForce(Char[0].transform.forward * -100f);
					component.AddRelativeForce(Vector3.up * 100f);
				}
			}
			else if (SpecialCaseTimer > 2.33333f)
			{
				Char[0].CrushedCan.SetActive(value: true);
				Char[0].SodaCan.SetActive(value: false);
			}
			break;
		case 17:
			Char[0].TaroApron.enabled = true;
			break;
		case 18:
			Char[0].TaroApron.newRenderer.enabled = false;
			break;
		case 19:
			Char[0].WalkAnim = "f02_walkHoldingBag_00";
			Char[0].GiftBag.SetActive(value: true);
			break;
		case 20:
			Char[0].WalkAnim = "f02_picnicWalk_00";
			Char[0].IdleAnim = "f02_picnicIdle_00";
			Char[0].PicnicProps[0].SetActive(value: true);
			Char[0].PicnicProps[1].SetActive(value: true);
			Char[0].PicnicProps[2].SetActive(value: true);
			EventObject[2].SetActive(value: false);
			break;
		case 21:
			Char[0].WalkAnim = Char[0].OriginalWalkAnim;
			Char[0].IdleAnim = Char[0].OriginalIdleAnim;
			Char[0].PicnicProps[0].SetActive(value: false);
			Char[0].PicnicProps[1].SetActive(value: false);
			Char[0].PicnicProps[2].SetActive(value: false);
			EventObject[1].SetActive(value: true);
			break;
		}
	}

	public void EndEvent()
	{
		Debug.Log("A Modern Rival Event named " + base.gameObject.name + " has ended.");
		if (EventID == RivalEventType.AmaiClubEvent)
		{
			SendClubToBakeSale();
		}
		else
		{
			_ = EventID;
			_ = 2;
		}
		if (Char[0] != null)
		{
			Char[0].WalkAnim = Char[0].OriginalWalkAnim;
		}
		for (int i = 0; i < Char.Length; i++)
		{
			if (Char[i] != null && Char[i].Alive && !Char[i].Dying)
			{
				Char[i].EmptyHands();
				if (!Char[i].Alarmed && !Char[i].Splashed && !Char[i].GoAway)
				{
					Char[i].Pathfinding.canSearch = true;
					Char[i].Pathfinding.canMove = true;
					Char[i].Pathfinding.speed = 1f;
					Char[i].Routine = true;
				}
				else
				{
					Debug.Log("Character # " + i + " was alarmed when event ended.");
				}
				Char[i].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				Char[i].CurrentDestination = Char[i].Destinations[Char[i].Phase];
				Char[i].Pathfinding.target = Char[i].Destinations[Char[i].Phase];
				Char[i].IgnoringPettyActions = false;
				Char[i].SmartPhone.SetActive(value: false);
				Char[i].DistanceToDestination = 100f;
				Char[i].Prompt.enabled = true;
				Char[i].InEvent = false;
				Char[i].Private = false;
				if (Depressing && Char[i].Rival)
				{
					Char[i].IdleAnim = "f02_bulliedIdle_00";
					Char[i].WalkAnim = "f02_bulliedWalk_00";
				}
				if (!StudentManager.Stop)
				{
					StudentManager.UpdateStudents();
				}
			}
		}
		EventSubtitle.text = string.Empty;
		Yandere.Eavesdropping = false;
		Jukebox.Dip = 1f;
		MyAudio.Stop();
		Done = true;
		if (Week == 2 && Day == DayOfWeek.Thursday && StartTime == 16f)
		{
			StudentManager.RestoreScorchMarks = true;
		}
		base.enabled = false;
	}

	public void PlayDesignatedAnimation(int ID)
	{
		if (Instructions[Phase].Anim[ID] == "Idle")
		{
			Char[ID].CharacterAnimation.CrossFade(Char[ID].IdleAnim);
		}
		else if (Instructions[Phase].Anim[ID] == "Talk")
		{
			Char[ID].CharacterAnimation.CrossFade(Char[ID].TalkAnim);
		}
		else if (Instructions[Phase].Anim[ID] == "Walk")
		{
			Char[ID].CharacterAnimation.CrossFade(Char[ID].WalkAnim);
		}
		else if (Instructions[Phase].Anim[ID] != "")
		{
			Char[ID].CharacterAnimation.CrossFade(Instructions[Phase].Anim[ID]);
		}
	}

	public void PopulateCharacterList()
	{
		if (EventID == RivalEventType.AmaiPhoneEvent)
		{
			Debug.Log("PopulateCharactersList is now being called.");
			Debug.Log("AlreadyPopulated is: " + AlreadyPopulated);
		}
		if (AlreadyPopulated)
		{
			return;
		}
		for (int i = 0; i < Char.Length; i++)
		{
			Char[i] = StudentManager.Students[CharIDs[i]];
			if (Char[i] != null)
			{
				Characters++;
			}
		}
		AlreadyPopulated = true;
	}

	public void SendClubToBakeSale()
	{
		for (int i = 0; i < Char.Length; i++)
		{
			if (Char[i] != null)
			{
				Char[i].WeirdStudent = null;
				Char[i].FocusOnStudent = false;
				ScheduleBlock obj = Char[i].ScheduleBlocks[2];
				obj.destination = "BakeSale";
				obj.action = "BakeSale";
				ScheduleBlock obj2 = Char[i].ScheduleBlocks[4];
				obj2.destination = "BakeSale";
				obj2.action = "BakeSale";
				ScheduleBlock obj3 = Char[i].ScheduleBlocks[7];
				obj3.destination = "BakeSale";
				obj3.action = "BakeSale";
				Char[i].GetDestinations();
				Char[i].CurrentAction = StudentActionType.BakeSale;
				Char[i].Pathfinding.speed = 1f;
			}
		}
	}
}
