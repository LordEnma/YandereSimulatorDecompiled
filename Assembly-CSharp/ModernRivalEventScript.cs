using System;
using UnityEngine;

public class ModernRivalEventScript : MonoBehaviour
{
	public EventInstructions[] Instructions;

	public ModernRivalEventScript AlternateEvent;

	public StudentManagerScript StudentManager;

	public ModernRivalEventScript OtherEvent;

	public UILabel EventSubtitle;

	public JukeboxScript Jukebox;

	public YandereScript Yandere;

	public AudioSource MyAudio;

	public SpyScript SpyPrompt;

	public ClockScript Clock;

	public AudioClip Silence;

	public GameObject[] EventObject;

	public Texture[] OverlayTexture;

	public StudentScript[] Char;

	public int[] CharIDs;

	public StartCriteriaType StartCriteria;

	public NextCriteriaType NextCriteria;

	public DayOfWeek Day;

	public RivalEventType EventID;

	public ClubType Club;

	public float SpecialCaseTimer;

	public float AudioTimer;

	public float StartTimer;

	public float TimeLimit;

	public float StartTime;

	public float WaitTimer;

	public float EndTime;

	public float Timer;

	public bool DisableBlendshapes;

	public bool DynamicPopulation;

	public bool AlreadyPopulated;

	public bool SyncAnimToAudio;

	public bool CancelOnDeath;

	public bool ClubClosed;

	public bool Depressing;

	public bool ClubCheck;

	public bool Private;

	public bool Done;

	public int SpecialCase;

	public int Characters;

	public int Offset;

	public int Frame;

	public int Loops;

	public int Phase;

	public int Week;

	public string[] AlternateAnim;

	public string[] AlternateDialogue;

	public AudioClip[] AlternateAudio;

	public AudioSourceScript TimeRespectingAudioSource;

	public GameObject AudioSourceObject;

	private void Start()
	{
		if (GameGlobals.Eighties || DateGlobals.Week != Week || DateGlobals.Weekday != Day)
		{
			base.gameObject.SetActive(value: false);
		}
		if (ClubCheck && ClubGlobals.GetClubClosed(Club))
		{
			AlternateEvent.gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: false);
			AlternateEvent.Instructions[0].Destination[0].eulerAngles = Vector3.zero;
			for (int i = 1; i < AlternateEvent.Instructions.Length; i++)
			{
				AlternateEvent.Instructions[i].Dialogue = AlternateEvent.AlternateDialogue[i];
				AlternateEvent.Instructions[i].Audio = AlternateEvent.AlternateAudio[i];
				AlternateEvent.Instructions[i].Anim[0] = "f02_bulliedIdle_00";
			}
		}
	}

	private void Update()
	{
		StartTimer += Time.deltaTime;
		if (!(StartTimer > 1f) || !(Clock.HourTime < 18f))
		{
			return;
		}
		if (Phase == -1)
		{
			if (Clock.HourTime > EndTime)
			{
				base.enabled = false;
			}
			else if (StartCriteria == StartCriteriaType.PositionZ)
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
						return;
					}
					Instructions[0].Destination[0].position = Char[0].transform.position;
					Char[0].InEvent = true;
					Char[0].Private = Private;
					Char[0].IgnoringPettyActions = true;
					Phase++;
					TakeInstructions();
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
					if (CancelOnDeath && Char[1] == null)
					{
						EndEvent();
						return;
					}
					int num = 0;
					int num2 = 0;
					for (int i = 0; i < Char.Length; i++)
					{
						Char[i] = StudentManager.Students[CharIDs[i]];
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
					if (!ClubClosed)
					{
						CheckForDeaths();
					}
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
					Debug.Log("A ModernRivalEvent named " + base.gameObject.name + " has begun because the clock has advanced to a specific time of day.");
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
				else
				{
					if (!Char[0].Indoors)
					{
						return;
					}
					Debug.Log("A character's event has begun because they've changed into their indoor shoes.");
					if (CancelOnDeath && Char[1] == null)
					{
						EndEvent();
						return;
					}
					for (int l = 0; l < Char.Length; l++)
					{
						Char[l].EmptyHands();
						Char[l].InEvent = true;
						Char[l].Private = Private;
						Char[l].IgnoringPettyActions = true;
					}
					Phase++;
					TakeInstructions();
				}
			}
			else
			{
				if (StartCriteria != StartCriteriaType.OtherEventFinished)
				{
					return;
				}
				if (Char[0] == null)
				{
					PopulateCharacterList();
				}
				else if (OtherEvent.Done)
				{
					Debug.Log("A character's event has begun because another event finished.");
					for (int m = 0; m < Char.Length; m++)
					{
						Char[m].EmptyHands();
						Char[m].InEvent = true;
						Char[m].Private = Private;
						Char[m].IgnoringPettyActions = true;
					}
					Phase++;
					TakeInstructions();
				}
			}
			return;
		}
		if (SyncAnimToAudio && TimeRespectingAudioSource != null)
		{
			Char[0].CharacterAnimation[Instructions[1].Anim[0]].time = TimeRespectingAudioSource.MyAudioSource.time;
			Char[1].CharacterAnimation[Instructions[1].Anim[1]].time = TimeRespectingAudioSource.MyAudioSource.time;
		}
		if (NextCriteria == NextCriteriaType.TimeLimit)
		{
			Timer += Time.deltaTime;
			if (Timer > TimeLimit)
			{
				Phase++;
				TakeInstructions();
			}
			if (Frame > 0)
			{
				for (int n = 0; n < Char.Length; n++)
				{
					if (Char[n] != null)
					{
						if (!Char[n].FocusOnStudent)
						{
							Char[n].transform.rotation = Quaternion.Slerp(Char[n].transform.rotation, Char[n].CurrentDestination.rotation, 10f * Time.deltaTime);
						}
						if (Instructions[Phase].Type != InstructionType.Stay && Instructions[Phase].Destination[n] != null)
						{
							Char[n].MoveTowardsTarget(Char[n].CurrentDestination.position);
						}
					}
				}
			}
		}
		else if (NextCriteria == NextCriteriaType.DestinationReached)
		{
			int num3 = 0;
			for (int num4 = 0; num4 < Char.Length; num4++)
			{
				if (!(Char[num4] != null))
				{
					continue;
				}
				if (Char[num4].DistanceToDestination < 0.5f)
				{
					PlayDesignatedAnimation(num4);
					num3++;
					Char[num4].Pathfinding.canSearch = false;
					Char[num4].Pathfinding.canMove = false;
					if (Frame > 0)
					{
						if (!Char[num4].FocusOnStudent)
						{
							Char[num4].transform.rotation = Quaternion.Slerp(Char[num4].transform.rotation, Char[num4].CurrentDestination.rotation, 10f * Time.deltaTime);
						}
						Char[num4].MoveTowardsTarget(Char[num4].CurrentDestination.position);
					}
				}
				else if (Instructions[Phase].Rush)
				{
					Char[num4].CharacterAnimation.CrossFade(Char[num4].SprintAnim);
				}
				else
				{
					Char[num4].CharacterAnimation.CrossFade(Char[num4].WalkAnim);
				}
			}
			if (num3 == Characters)
			{
				Phase++;
				TakeInstructions();
			}
		}
		else if (NextCriteria == NextCriteriaType.AudioFinished)
		{
			AudioTimer += Time.deltaTime;
			if (AudioTimer > Instructions[Phase].Audio.length)
			{
				WaitTimer += Time.deltaTime;
				if (WaitTimer > 0.5f)
				{
					AudioTimer = 0f;
					WaitTimer = 0f;
					Phase++;
					TakeInstructions();
				}
			}
		}
		UpdateSubtitle();
		for (int num5 = 0; num5 < Char.Length; num5++)
		{
			if (Char[num5] != null && (Char[num5].Alarmed || Char[num5].Splashed || Char[num5].Dying || Char[num5].GoAway))
			{
				Debug.Log("The event ended because a character was alarmed or splashed or stink bombed or killed.");
				if (Char[num5].GoAway)
				{
					Char[num5].Subtitle.CustomText = "What's that smell?! I can't take it! I'm getting out of here!";
					Char[num5].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				}
				EndEvent();
			}
		}
		if (base.enabled && Phase < Instructions.Length)
		{
			SpecialCaseCheck();
		}
		Frame++;
	}

	private void TakeInstructions()
	{
		if (SpyPrompt != null)
		{
			SpyPrompt.gameObject.SetActive(value: true);
		}
		float num = Vector3.Distance(Yandere.transform.position, Char[0].transform.position);
		if (num < 10f)
		{
			EventSubtitle.text = string.Empty;
		}
		if (Phase == 0 && DisableBlendshapes)
		{
			Char[0].Cosmetic.ResetBlendshapes();
		}
		if (Phase == 1 && Char.Length > 1 && Char[1] != null && Char[1].Club == ClubType.Council)
		{
			Char[1].CharacterAnimation.Stop("f02_faceCouncil" + Char[1].Suffix + "_00");
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
		}
		else
		{
			for (int i = 0; i < Char.Length; i++)
			{
				if (!(Char[i] != null))
				{
					continue;
				}
				if (Instructions[Phase].Destination[i] != null)
				{
					Char[i].Pathfinding.target = Instructions[Phase].Destination[i];
					Char[i].CurrentDestination = Instructions[Phase].Destination[i];
				}
				if (Instructions[Phase].Type == InstructionType.Stay)
				{
					Char[i].Pathfinding.canSearch = false;
					Char[i].Pathfinding.canMove = false;
					Char[i].Pathfinding.speed = 0f;
				}
				else
				{
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
				SpawnTimeRespectingAudioSource(Instructions[Phase].Audio);
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
		Frame = 0;
	}

	public void UpdateSubtitle()
	{
		if (Yandere.transform.position.y > Char[0].transform.position.y - 1f && Yandere.transform.position.y < Char[0].transform.position.y + 1f)
		{
			float num = Vector3.Distance(Yandere.transform.position, Char[0].transform.position);
			float value = Mathf.Abs((num - 11f) * 0.2f);
			if (num < 11f)
			{
				if (Phase < Instructions.Length)
				{
					EventSubtitle.text = Instructions[Phase].Dialogue;
				}
				value = Mathf.Clamp(value, 0f, 1f);
				EventSubtitle.transform.localScale = new Vector3(value, value, value);
				Jukebox.Dip = 1f - 0.5f * value;
				if (Private && num < 5f)
				{
					Yandere.Eavesdropping = true;
				}
				else
				{
					Yandere.Eavesdropping = false;
				}
			}
			else if (num < 12f)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
				EventSubtitle.text = string.Empty;
				Yandere.Eavesdropping = false;
				Jukebox.Dip = 1f;
				value = 0f;
			}
			if (SpyPrompt != null && SpyPrompt.SpyCamera.gameObject.activeInHierarchy)
			{
				EventSubtitle.transform.localScale = Vector3.one;
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
			Char[0].PhoneCallScreen.SetActive(value: true);
			break;
		case 2:
			if (!Private)
			{
				Char[0].SmartPhone.transform.localPosition = new Vector3(0.01f, 0.005f, 0f);
				Char[0].SmartPhone.transform.localEulerAngles = new Vector3(0f, -155f, 165f);
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
			for (int k = 1; k < Char.Length; k++)
			{
				if (Char[k] != null)
				{
					Char[k].InEvent = true;
					Char[k].Routine = false;
					Char[k].SpeechLines.Stop();
					Char[k].FocusOnStudent = true;
					Char[k].WeirdStudent = Char[0].transform;
					Char[k].CharacterAnimation.CrossFade(Char[k].IdleAnim);
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
			Debug.Log("Now updating characters' routines to have a picnic.");
			ScheduleBlock obj2 = Char[0].ScheduleBlocks[4];
			obj2.destination = "Picnic";
			obj2.action = "Picnic";
			Char[0].GetDestinations();
			Char[0].Pathfinding.target = Char[0].Destinations[4];
			Char[0].CurrentDestination = Char[0].Destinations[4];
			Char[0].MyRenderer.updateWhenOffscreen = true;
			ScheduleBlock obj3 = Char[1].ScheduleBlocks[4];
			obj3.destination = "Picnic";
			obj3.action = "Picnic";
			Char[1].GetDestinations();
			Char[1].Pathfinding.target = Char[1].Destinations[4];
			Char[1].CurrentDestination = Char[1].Destinations[4];
			Char[1].MyRenderer.updateWhenOffscreen = true;
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
			if (SpecialCaseTimer > 3.75f)
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
			if (StudentManager.BakeSaleFoodTrays[1].activeInHierarchy)
			{
				for (int j = 1; j < 8; j++)
				{
					StudentManager.BakeSaleFoodTrays[j].SetActive(value: false);
				}
				StudentManager.Students[1].TaroApron.enabled = true;
				EventObject[1].SetActive(value: true);
			}
			break;
		case 18:
		{
			StudentManager.Students[1].TaroApron.newRenderer.enabled = false;
			ScheduleBlock obj = StudentManager.Students[1].ScheduleBlocks[4];
			obj.destination = "LunchSpot";
			obj.action = "Eat";
			StudentManager.Students[1].GetDestinations();
			break;
		}
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
			Char[1].WalkAnim = Char[1].PlateWalkAnim;
			Char[1].IdleAnim = Char[1].PlateIdleAnim;
			Char[1].PicnicProps[0].SetActive(value: true);
			EventObject[2].SetActive(value: false);
			break;
		case 21:
			Char[0].MyRenderer.updateWhenOffscreen = true;
			Char[1].MyRenderer.updateWhenOffscreen = true;
			Char[0].WalkAnim = Char[0].OriginalWalkAnim;
			Char[0].IdleAnim = Char[0].OriginalIdleAnim;
			Char[1].WalkAnim = Char[1].OriginalWalkAnim;
			Char[1].IdleAnim = Char[1].OriginalIdleAnim;
			Char[0].PicnicProps[0].SetActive(value: false);
			Char[0].PicnicProps[1].SetActive(value: false);
			Char[0].PicnicProps[2].SetActive(value: false);
			Char[1].PicnicProps[0].SetActive(value: false);
			EventObject[0].SetActive(value: false);
			EventObject[1].SetActive(value: true);
			break;
		case 22:
			EventObject[0].SetActive(value: true);
			break;
		case 23:
			Char[0].PhoneCallScreen.SetActive(value: false);
			break;
		case 24:
		{
			for (int i = 0; i < Char.Length; i++)
			{
				if (Char[i] != null)
				{
					Char[i].WeirdStudent = null;
					Char[i].FocusOnStudent = false;
				}
			}
			break;
		}
		case 25:
			Char[1].MyRenderer.materials[2].SetTexture("_OverlayTex", OverlayTexture[0]);
			Char[1].MyRenderer.materials[0].SetTexture("_OverlayTex", OverlayTexture[1]);
			Char[1].MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
			Char[1].MyRenderer.materials[0].SetFloat("_BlendAmount", 1f);
			break;
		case 26:
			Char[1].MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
			break;
		case 27:
			EventObject[0].SetActive(value: false);
			EventObject[1].SetActive(value: true);
			break;
		case 28:
			EventObject[1].SetActive(value: false);
			break;
		case 29:
			Debug.Log("Attempting to jump ahead to Phase 21.");
			Phase = 21;
			TakeInstructions();
			break;
		case 30:
			Loops++;
			Debug.Log("So far, we have looped " + Loops + " times.");
			if (Loops >= 10)
			{
				Phase++;
				TakeInstructions();
			}
			else if (EventObject[2].activeInHierarchy)
			{
				Phase = 19;
				TakeInstructions();
			}
			else
			{
				Phase = 12;
				TakeInstructions();
			}
			break;
		case 31:
			Phase = 22;
			TakeInstructions();
			break;
		case 32:
			Char[0].PicnicBlanket.SetActive(value: true);
			break;
		case 33:
			Char[0].PicnicBlanket.transform.parent = null;
			EventObject[0].SetActive(value: true);
			break;
		case 34:
			Debug.Log("The event calling this case is " + base.gameObject.name);
			EventObject[0].SetActive(value: false);
			EventObject[3].SetActive(value: true);
			break;
		case 35:
			if (Timer > 1f)
			{
				Char[0].SmartPhone.SetActive(value: true);
			}
			break;
		case 36:
			if (Char[0].CharacterAnimation["amaiFridayLunch_00"].time > 24f || Char[0].CharacterAnimation["amaiFridayLunchSabo_00"].time > 28f)
			{
				Char[0].SmartPhone.SetActive(value: false);
			}
			break;
		}
	}

	public void EndEvent()
	{
		Debug.Log("A Modern Rival Event named " + base.gameObject.name + " has ended.");
		if (EventID == RivalEventType.AmaiPhoneEvent)
		{
			Char[0].PhoneCallScreen.SetActive(value: false);
		}
		else if (EventID == RivalEventType.AmaiAkaneEvent)
		{
			ScheduleBlock obj = Char[1].ScheduleBlocks[1];
			obj.destination = "Patrol";
			obj.action = "Patrol";
			Char[1].GetDestinations();
			Char[1].Pathfinding.target = Char[1].Destinations[1];
			Char[1].CurrentDestination = Char[1].Destinations[1];
		}
		else if (EventID == RivalEventType.AmaiUekiyaEvent)
		{
			Debug.Log("Now attempting to adjust Uekiya's routine.");
			for (int i = 0; i < 3; i++)
			{
				ScheduleBlock obj2 = Char[1].ScheduleBlocks[i];
				obj2.destination = "Patrol";
				obj2.action = "Club";
			}
			Char[1].GetDestinations();
			Char[1].Pathfinding.target = Char[1].Destinations[1];
			Char[1].CurrentDestination = Char[1].Destinations[1];
		}
		else if (EventID == RivalEventType.AmaiClubEvent)
		{
			SendClubToBakeSale();
		}
		else if (EventID == RivalEventType.AmaiMondayLunchEvent)
		{
			if (Char[0] != null)
			{
				ScheduleBlock scheduleBlock = null;
				scheduleBlock = Char[0].ScheduleBlocks[4];
				if (StudentManager.RivalBookBag.BentoStolen)
				{
					scheduleBlock.destination = "BakeSale";
					scheduleBlock.action = "BakeSale";
				}
				else
				{
					scheduleBlock.destination = "LunchSpot";
					scheduleBlock.action = "Eat";
				}
				Char[0].GetDestinations();
			}
		}
		else if (EventID == RivalEventType.AmaiTuesdayLunchEvent)
		{
			EventObject[0].SetActive(value: false);
		}
		else if (EventID == RivalEventType.AmaiCookingEvent)
		{
			MakeStudentsPrepareFoodForever();
		}
		else if (EventID == RivalEventType.AmaiPicnicEvent && Depressing)
		{
			Char[1].WalkAnim = Char[1].OriginalWalkAnim;
		}
		if (Char[0] != null)
		{
			Char[0].WalkAnim = Char[0].OriginalWalkAnim;
			Char[0].Cosmetic.EyeTypeCheck();
		}
		if (Char.Length > 1 && Char[1] != null && Char[1].Club == ClubType.Council)
		{
			Char[1].CharacterAnimation.Play("f02_faceCouncil" + Char[1].Suffix + "_00");
		}
		for (int j = 0; j < Char.Length; j++)
		{
			if (!(Char[j] != null) || !Char[j].Alive || Char[j].Dying)
			{
				continue;
			}
			Char[j].EmptyHands();
			if (!Char[j].Alarmed && !Char[j].Splashed && !Char[j].GoAway)
			{
				Char[j].Pathfinding.canSearch = true;
				Char[j].Pathfinding.canMove = true;
				Char[j].Pathfinding.speed = 1f;
				Char[j].Routine = true;
			}
			else
			{
				Debug.Log("Character # " + j + " was alarmed when event ended.");
			}
			if (Char[j].TimeRespectingAudioSource != null)
			{
				UnityEngine.Object.Destroy(Char[j].TimeRespectingAudioSource);
			}
			Char[j].CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Char[j].CurrentDestination = Char[j].Destinations[Char[j].Phase];
			Char[j].Pathfinding.target = Char[j].Destinations[Char[j].Phase];
			Char[j].IgnoringPettyActions = false;
			Char[j].SmartPhone.SetActive(value: false);
			Char[j].DistanceToDestination = 100f;
			Char[j].Prompt.enabled = true;
			Char[j].InEvent = false;
			Char[j].Private = false;
			if (Char[j].Rival)
			{
				if (Depressing)
				{
					Char[j].IdleAnim = "f02_bulliedIdle_00";
					Char[j].WalkAnim = "f02_bulliedWalk_00";
				}
				else
				{
					Char[j].IdleAnim = Char[j].OriginalIdleAnim;
					Char[j].WalkAnim = Char[j].OriginalWalkAnim;
				}
			}
			if (!StudentManager.Stop)
			{
				StudentManager.UpdateStudents();
			}
			if (Char[j].Rival)
			{
				Debug.Log(Char[j]?.ToString() + " is a rival, so, as she is exiting this event, we're going to check to see if she needs to add ''Place Bag'' to her routine.");
				Char[j].CheckIfWeNeedToPlaceBag();
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
		if (TimeRespectingAudioSource != null)
		{
			UnityEngine.Object.Destroy(TimeRespectingAudioSource.gameObject);
		}
		if (SpyPrompt != null)
		{
			if (SpyPrompt.SpyCamera.activeInHierarchy)
			{
				SpyPrompt.End();
			}
			SpyPrompt.Prompt.Hide();
			SpyPrompt.gameObject.SetActive(value: false);
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
		else if (Instructions[Phase].Anim[ID] == "Wait")
		{
			Char[ID].CharacterAnimation.CrossFade(Char[ID].WaitAnim);
		}
		else if (Instructions[Phase].Anim[ID] == "PrepareFood")
		{
			Char[ID].CharacterAnimation.CrossFade(Char[ID].PrepareFoodAnim);
		}
		else if (Instructions[Phase].Anim[ID] != "")
		{
			Char[ID].CharacterAnimation.CrossFade(Instructions[Phase].Anim[ID]);
		}
	}

	public void PopulateCharacterList()
	{
		if (Char[0] == null)
		{
			AlreadyPopulated = false;
			Characters = 0;
			if (DynamicPopulation)
			{
				GrabAvailableStudents();
				DynamicPopulation = false;
			}
		}
		_ = EventID;
		_ = 1;
		if (EventID == RivalEventType.AmaiCakeEvent)
		{
			Debug.Log("AmaiCakeEvent's PopulateCharactersList is now being called.");
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
		StudentManager.BakeSaleHasBegun = true;
	}

	public void MakeStudentsPrepareFoodForever()
	{
		Debug.Log("Now attempting to adjust student routines so that several students prepare food in the Home Ec room.");
		if (Char[0] != null)
		{
			ScheduleBlock obj = Char[0].ScheduleBlocks[4];
			obj.destination = "Patrol";
			obj.action = "Patrol";
			Char[0].GetDestinations();
			Char[0].CurrentAction = StudentActionType.Patrol;
			Char[0].Pathfinding.speed = 1f;
		}
		for (int i = 1 + Offset; i < Char.Length; i++)
		{
			if (Char[i] != null)
			{
				StudentManager.BakeSalePrepSpots[Char[i].StudentID] = Instructions[0].Destination[i];
				Debug.Log("StudentManager.BakeSalePrepSpots[" + Char[i].StudentID + "] was just changed to " + StudentManager.BakeSalePrepSpots[Char[i].StudentID]);
				ScheduleBlock obj2 = Char[i].ScheduleBlocks[4];
				obj2.destination = "BakeSalePrepSpot";
				obj2.action = "PrepareFoodForever";
				Char[i].GetDestinations();
				Char[i].CurrentAction = StudentActionType.PrepareFoodForever;
				Char[i].Pathfinding.target = Char[i].Destinations[Char[i].Phase];
				Char[i].CurrentDestination = Char[i].Destinations[Char[i].Phase];
				Char[i].Pathfinding.speed = 1f;
			}
		}
	}

	public void CheckForDeaths()
	{
		Debug.Log("The script named " + base.gameObject.name + " is now checking to see if any of the characters involved in this event are dead.");
		for (int i = 2; i < CharIDs.Length; i++)
		{
			int num = CharIDs[i];
			if (StudentManager.Students[num] == null)
			{
				Debug.Log("Student #" + num + " is not at school?");
				int num2 = i * 2;
				Instructions[num2].Dialogue = "";
				Instructions[num2].TimeLimit = 0f;
				Instructions[num2].Audio = Silence;
				Instructions[num2].NextCritera = NextCriteriaType.TimeLimit;
				if (num2 + 1 < Instructions.Length)
				{
					Instructions[num2 + 1].Dialogue = "";
					Instructions[num2 + 1].TimeLimit = 0f;
					Instructions[num2 + 1].Audio = Silence;
					Instructions[num2 + 1].NextCritera = NextCriteriaType.TimeLimit;
				}
			}
		}
	}

	public void GrabAvailableStudents()
	{
		Debug.Log("Grabbing available students!");
		int num = 2;
		int num2 = 2;
		while (num < CharIDs.Length && num2 < StudentManager.Students.Length)
		{
			if (StudentManager.Students[num2] != null && StudentManager.Students[num2].Class < 30 && !StudentManager.Students[num2].BakeSale)
			{
				Debug.Log("Student #" + num + " appears to be available. Not part of the Bake Sale or anything. Adding this student to an event.");
				CharIDs[num] = num2;
				num++;
			}
			num2++;
		}
	}

	public void SpawnTimeRespectingAudioSource(AudioClip Clip, float AudioOffset = 0f, bool Follow = false)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(AudioSourceObject, Char[0].transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
		TimeRespectingAudioSource = gameObject.GetComponent<AudioSourceScript>();
		TimeRespectingAudioSource.MyClip = Clip;
		TimeRespectingAudioSource.Offset = AudioOffset;
		if (Follow)
		{
			gameObject.transform.parent = base.transform;
		}
	}
}
