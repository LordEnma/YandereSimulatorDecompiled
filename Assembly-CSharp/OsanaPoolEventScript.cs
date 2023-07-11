using System;
using UnityEngine;

public class OsanaPoolEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public PromptScript Prompt;

	public ClockScript Clock;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform[] Location;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public string[] EventAnim;

	public GameObject AlarmDisc;

	public GameObject BigSplash;

	public GameObject VoiceClip;

	public GameObject Weight;

	public bool Murdering;

	public float StinkTimer;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int MurderPhase = 1;

	public int FriendID = 10;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	private void Start()
	{
		if (GameGlobals.Eighties || DateGlobals.Weekday != EventDay)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0)
			{
				if (StudentManager.VictimID == RivalID)
				{
					base.enabled = false;
				}
				else if (StudentManager.Students[RivalID] != null && StudentManager.Students[RivalID].enabled && Clock.Period == 3)
				{
					Debug.Log("Osana's pool event has begun.");
					if (StudentManager.Students[FriendID] != null && StudentManager.Students[FriendID].FollowTarget != null)
					{
						Friend = StudentManager.Students[FriendID];
						if (Friend != null)
						{
							Friend.CanTalk = false;
						}
					}
					Rival = StudentManager.Students[RivalID];
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.MyRenderer.updateWhenOffscreen = true;
					Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
					Rival.Pathfinding.target = StudentManager.FemaleStripSpot;
					Rival.CurrentDestination = StudentManager.FemaleStripSpot;
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.Pen.SetActive(value: false);
					Rival.Routine = false;
					Rival.InEvent = true;
					Rival.StinkBombSpecialCase = 1;
					Rival.SmartPhone.SetActive(value: false);
					Yandere.PauseScreen.Hint.Show = true;
					Yandere.PauseScreen.Hint.QuickID = 17;
					Phase++;
				}
			}
			Frame++;
			return;
		}
		if (Rival.StinkBombSpecialCase == 2)
		{
			Debug.Log("Osana is holding her breath.");
			StinkTimer += Time.deltaTime;
			if (StinkTimer > 1f)
			{
				Rival.StinkBombSpecialCase = 1;
				StinkTimer = 0f;
			}
		}
		else if (Phase == 1)
		{
			if (!Rival.Wet)
			{
				Rival.Pathfinding.target = StudentManager.FemaleStripSpot;
				Rival.CurrentDestination = StudentManager.FemaleStripSpot;
			}
			if (Rival.DistanceToDestination < 0.5f)
			{
				if (StudentManager.CommunalLocker.Student == null)
				{
					Rival.StudentManager.CommunalLocker.Open = true;
					Rival.StudentManager.CommunalLocker.Student = Rival;
					Rival.StudentManager.CommunalLocker.SpawnSteam();
					Rival.Schoolwear = 2;
					Phase++;
				}
				else
				{
					Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				}
			}
		}
		else if (Phase == 2)
		{
			if (!Rival.StudentManager.CommunalLocker.SteamCountdown)
			{
				StudentManager.CommunalLocker.Student = null;
				if (Friend != null)
				{
					ScheduleBlock obj = Friend.ScheduleBlocks[Friend.Phase];
					obj.destination = "Sunbathe";
					obj.action = "Sunbathe";
					Friend.Actions[Friend.Phase] = StudentActionType.Sunbathe;
					Friend.CurrentAction = StudentActionType.Sunbathe;
					Friend.GetDestinations();
					Friend.CurrentDestination = StudentManager.FemaleStripSpot;
					Friend.Pathfinding.target = StudentManager.FemaleStripSpot;
					Friend.Pathfinding.canSearch = true;
					Friend.Pathfinding.canMove = true;
				}
				Rival.Pathfinding.target = Location[1];
				Rival.CurrentDestination = Location[1];
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(SpeechClip[1], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[1];
				Rival.CharacterAnimation["f02_" + EventAnim[1]].time = 0f;
				Rival.CharacterAnimation.Play("f02_" + EventAnim[1]);
				Rival.OsanaHair.GetComponent<Animation>().Play("Hair_" + EventAnim[1]);
				Rival.OsanaHair.transform.parent = Rival.transform;
				Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
				Rival.OsanaHair.transform.localPosition = Vector3.zero;
				Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
				Rival.OsanaHairL.enabled = false;
				Rival.OsanaHairR.enabled = false;
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Pathfinding.speed = 0f;
				Rival.transform.eulerAngles = Location[1].eulerAngles;
				Phase++;
			}
			else
			{
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Pathfinding.speed = 1f;
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			if (!Rival.GoAway)
			{
				Rival.MoveTowardsTarget(Location[1].position);
			}
			if (Timer > 5.53333f)
			{
				Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[2]);
				Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + EventAnim[2]);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			if (Timer > 10f)
			{
				AudioClipPlayer.Play(SpeechClip[2], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[2];
				Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[3]);
				Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + EventAnim[3]);
				Rival.Ragdoll.Zs.SetActive(value: true);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			if (MurderPhase < 2)
			{
				Timer += Time.deltaTime;
				if (Clock.HourTime > 13.375f)
				{
					AudioClipPlayer.Play(SpeechClip[3], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					EventSubtitle.text = SpeechText[3];
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[2]);
					Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + EventAnim[2]);
					Prompt.Hide();
					Prompt.gameObject.SetActive(value: false);
					Rival.Ragdoll.Zs.SetActive(value: false);
					Timer = 0f;
					Phase++;
				}
			}
		}
		else if (Phase == 7)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				AudioClipPlayer.Play(SpeechClip[4], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[4];
				Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[4]);
				Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + EventAnim[4]);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 8)
		{
			Timer += Time.deltaTime;
			if (Timer > 4.33333f)
			{
				Debug.Log("Now moving from Phase 8 to Phase 9.");
				AttachHair();
				Rival.Pathfinding.target = StudentManager.FemaleStripSpot;
				Rival.CurrentDestination = StudentManager.FemaleStripSpot;
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Pathfinding.speed = 1f;
				if (Friend != null)
				{
					ScheduleBlock obj2 = Friend.ScheduleBlocks[Friend.Phase];
					obj2.destination = "Follow";
					obj2.action = "Follow";
					Friend.GetDestinations();
					Friend.CurrentDestination = Friend.FollowTarget.transform;
					Friend.Pathfinding.target = Friend.FollowTarget.transform;
					Friend.Pathfinding.canSearch = true;
					Friend.Pathfinding.canMove = true;
					Friend.Pathfinding.speed = 1f;
				}
				Phase++;
			}
		}
		else if (Phase == 9)
		{
			Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			if (Rival.DistanceToDestination < 0.5f)
			{
				if (StudentManager.CommunalLocker.Student == null)
				{
					Rival.StudentManager.CommunalLocker.Open = true;
					Rival.StudentManager.CommunalLocker.Student = Rival;
					Rival.StudentManager.CommunalLocker.SpawnSteam();
					Rival.Schoolwear = 1;
					if (Friend != null)
					{
						StudentManager.CommunalLocker.SpawnSteamNoSideEffects(Friend);
					}
					Phase++;
				}
				else
				{
					Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				}
			}
		}
		else if (Phase == 10 && !Rival.StudentManager.CommunalLocker.SteamCountdown)
		{
			Rival.StudentManager.CommunalLocker.Student = null;
			EndEvent();
		}
		if (Phase == 6)
		{
			if (Yandere.PickUp != null)
			{
				Prompt.enabled = Yandere.PickUp.Weight;
			}
			else
			{
				Prompt.enabled = false;
			}
		}
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Hide();
			Prompt.gameObject.SetActive(value: false);
			Murdering = true;
			Rival.Blind = true;
			Yandere.CanMove = false;
			Rival.Distracted = true;
			Rival.Ragdoll.Zs.SetActive(value: false);
			Yandere.CharacterAnimation.CrossFade("f02_" + EventAnim[5]);
			Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[6]);
			Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + EventAnim[6]);
		}
		if (Murdering)
		{
			if (PlayerGlobals.PantiesEquipped == 10)
			{
				Yandere.Sanity -= Time.deltaTime * 2f * Yandere.Numbness;
			}
			else
			{
				Yandere.Sanity -= Time.deltaTime * 4f * Yandere.Numbness;
			}
			if (Yandere.Chased)
			{
				Murdering = false;
				Weight.GetComponent<Animation>().Stop();
				Rival.OsanaHair.GetComponent<Animation>().Stop();
				Rival.CharacterAnimation.GetComponent<Animation>().Stop();
			}
			Yandere.MoveTowardsTarget(Location[2].position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, Location[2].rotation, Time.deltaTime * 10f);
			if (Yandere.CharacterAnimation["f02_" + EventAnim[5]].time > 1f && Weight.transform.parent != Location[3])
			{
				Yandere.EmptyHands();
				Weight.transform.parent = Location[3];
				Weight.transform.localPosition = Vector3.zero;
				Weight.transform.localEulerAngles = Vector3.zero;
				Weight.GetComponent<Animation>().Play("Weight_" + EventAnim[5]);
				Weight.GetComponent<Animation>()["Weight_" + EventAnim[5]].time = Yandere.CharacterAnimation["f02_" + EventAnim[5]].time;
			}
			if (MurderPhase == 1)
			{
				if (Yandere.CharacterAnimation["f02_" + EventAnim[5]].time > 10f)
				{
					Yandere.MurderousActionTimer = 999f;
					Rival.SpawnAlarmDisc();
					AudioClipPlayer.Play(SpeechClip[5], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					EventSubtitle.text = SpeechText[5];
					MurderPhase++;
				}
			}
			else if (MurderPhase == 2)
			{
				if (Yandere.CharacterAnimation["f02_" + EventAnim[5]].time > 14.5f)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(BigSplash, Location[4].position, Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					MurderPhase++;
				}
			}
			else if (MurderPhase == 3 && Yandere.CharacterAnimation["f02_" + EventAnim[5]].time > 14.833333f)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate(BigSplash, Location[4].position, Quaternion.identity);
				gameObject2.transform.eulerAngles = new Vector3(-90f, gameObject2.transform.eulerAngles.y, gameObject2.transform.eulerAngles.z);
				MurderPhase++;
			}
			if (Yandere.CharacterAnimation["f02_" + EventAnim[5]].time > Yandere.CharacterAnimation["f02_" + EventAnim[5]].length)
			{
				Yandere.MurderousActionTimer = 0f;
				Yandere.CanMove = true;
				Murdering = false;
				Rival.NoRagdoll = true;
				Rival.BecomeRagdoll();
				Rival.DeathType = DeathType.Drowning;
				Yandere.Police.EndOfDay.PoolEvent = true;
			}
		}
		if (Clock.HourTime > 14f || Rival.Alarmed || Rival.Attacked || Rival.Stop)
		{
			EndEvent();
		}
		if (Phase > 2 && Phase < 8 && Rival.StinkBombSpecialCase == 2)
		{
			Debug.Log("Skipping directly to Phase 8 now.");
			AttachHair();
			Phase = 8;
		}
		Distance = Vector3.Distance(Yandere.transform.position, Rival.transform.position);
		if (Distance - 4f < 15f)
		{
			Scale = Mathf.Abs(1f - (Distance - 4f) / 15f);
			if (Scale < 0f)
			{
				Scale = 0f;
			}
			if (Scale > 1f)
			{
				Scale = 1f;
			}
			Jukebox.Dip = 1f - 0.5f * Scale;
			EventSubtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().volume = Scale;
			}
		}
		else
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().volume = 0f;
			}
		}
		if (VoiceClip == null)
		{
			EventSubtitle.text = string.Empty;
		}
	}

	public void EndEvent()
	{
		Debug.Log("Osana's pool event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		Rival.Pathfinding.speed = 1f;
		if (!Rival.Alarmed && !Rival.Attacked && !Rival.Stop)
		{
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			Rival.Routine = true;
			Rival.Schoolwear = 1;
			Rival.ChangeSchoolwear();
		}
		else
		{
			Rival.Pathfinding.canSearch = false;
			Rival.Pathfinding.canMove = false;
		}
		if (Rival.Schoolwear != 1)
		{
			Rival.CurrentDestination = Rival.StudentManager.StrippingPositions[Rival.GirlID];
			Rival.Pathfinding.target = Rival.StudentManager.StrippingPositions[Rival.GirlID];
			Rival.NotActuallyWet = true;
			Rival.Wet = true;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.MyRenderer.updateWhenOffscreen = false;
		Rival.Ragdoll.Zs.SetActive(value: false);
		Rival.Obstacle.enabled = false;
		Rival.StinkBombSpecialCase = 0;
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Rival.OsanaHair.GetComponent<Animation>().Stop();
		Rival.OsanaHair.transform.parent = Rival.Head;
		Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
		Rival.OsanaHair.transform.localPosition = new Vector3(0f, -1.442789f, 0.01900469f);
		Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
		Rival.OsanaHairL.enabled = true;
		Rival.OsanaHairR.enabled = true;
		if (Friend != null)
		{
			ScheduleBlock obj = Friend.ScheduleBlocks[Friend.Phase];
			obj.destination = "Follow";
			obj.action = "Follow";
			Friend.GetDestinations();
			if (Friend.FollowTarget != null)
			{
				Friend.CurrentDestination = Friend.FollowTarget.transform;
				Friend.Pathfinding.target = Friend.FollowTarget.transform;
			}
			Friend.Pathfinding.canSearch = true;
			Friend.Pathfinding.canMove = true;
			Friend.CanTalk = true;
			if (Friend.GoAway)
			{
				Friend.CurrentDestination = StudentManager.GoAwaySpots.List[Friend.StudentID];
				Friend.Pathfinding.target = StudentManager.GoAwaySpots.List[Friend.StudentID];
			}
		}
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		Jukebox.Dip = 1f;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Forget about sunbathing...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}

	public void ReturnFromSave()
	{
		Rival = StudentManager.Students[RivalID];
		Friend = StudentManager.Students[FriendID];
		if (Friend != null)
		{
			ScheduleBlock obj = Friend.ScheduleBlocks[Friend.Phase];
			obj.destination = "Sunbathe";
			obj.action = "Sunbathe";
			Friend.Actions[Friend.Phase] = StudentActionType.Sunbathe;
			Friend.CurrentAction = StudentActionType.Sunbathe;
			Friend.GetDestinations();
			Friend.CurrentDestination = StudentManager.FemaleStripSpot;
			Friend.Pathfinding.target = StudentManager.FemaleStripSpot;
			Friend.Pathfinding.canSearch = true;
			Friend.Pathfinding.canMove = true;
		}
		Rival.Pathfinding.target = Location[1];
		Rival.CurrentDestination = Location[1];
		Phase = 3;
	}

	public void AttachHair()
	{
		Rival.OsanaHair.GetComponent<Animation>().Stop();
		Rival.OsanaHair.transform.parent = Rival.Head;
		Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
		Rival.OsanaHair.transform.localPosition = new Vector3(0f, -1.442789f, 0.01900469f);
		Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
		Rival.OsanaHairL.enabled = true;
		Rival.OsanaHairR.enabled = true;
	}
}
