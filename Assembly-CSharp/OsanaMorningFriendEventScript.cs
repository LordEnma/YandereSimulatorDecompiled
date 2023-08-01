using System;
using UnityEngine;

public class OsanaMorningFriendEventScript : MonoBehaviour
{
	public RivalMorningEventManagerScript OtherEvent;

	public StudentManagerScript StudentManager;

	public EndOfDayScript EndOfDay;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public MusicTest AudioData;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript CurrentSpeaker;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform Epicenter;

	public Transform[] Location;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public string[] EventAnim;

	public int[] Speaker;

	public AudioClip InterruptedClip;

	public string[] InterruptedSpeech;

	public float[] InterruptedTime;

	public string[] InterruptedAnim;

	public int[] InterruptedSpeaker;

	public AudioClip AltSpeechClip;

	public string[] AltSpeechText;

	public float[] AltSpeechTime;

	public string[] AltEventAnim;

	public int[] AltSpeaker;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public Quaternion targetRotation;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int SpeechPhase = 1;

	public int FriendID = 6;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	public bool LosingFriend;

	public bool Listening;

	public string LongAnimA;

	public string LongAnimB;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (LosingFriend)
		{
			if ((float)StudentGlobals.GetStudentReputation(10) > -33.33333f || StudentGlobals.StudentSlave == FriendID || StudentGlobals.StudentSlave == RivalID || PlayerGlobals.RaibaruLoner)
			{
				base.enabled = false;
			}
		}
		else if ((float)StudentGlobals.GetStudentReputation(10) <= -33.33333f || DateGlobals.Weekday != EventDay || HomeGlobals.LateForSchool || StudentManager.YandereLate || DatingGlobals.SuitorProgress == 2 || StudentGlobals.MemorialStudents > 0 || StudentGlobals.StudentSlave == FriendID || StudentGlobals.StudentSlave == RivalID || GameGlobals.RivalEliminationID > 0 || PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0 && StudentManager.Students[RivalID] != null && StudentManager.Students[FriendID] != null)
			{
				if (Friend == null)
				{
					Friend = StudentManager.Students[FriendID];
				}
				if (Rival == null)
				{
					Rival = StudentManager.Students[RivalID];
				}
				if (Clock.Period == 1 && !StudentManager.Students[1].Alarmed && !Friend.DramaticReaction && !Friend.Alarmed && !Rival.Alarmed && Rival.enabled && !Rival.Talking && Rival.Alive && !Friend.Hunted && !OtherEvent.enabled)
				{
					Debug.Log("Osana's ''talk with friend before going to the lockers'' event has begun.");
					Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Friend.CharacterAnimation.CrossFade(Friend.WalkAnim);
					Friend.Pathfinding.target = Location[1];
					Friend.CurrentDestination = Location[1];
					Friend.Pathfinding.canSearch = true;
					Friend.Pathfinding.canMove = true;
					Friend.Pathfinding.maxSpeed = 1f;
					Friend.Routine = false;
					Friend.InEvent = true;
					Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
					Rival.Pathfinding.target = Location[2];
					Rival.CurrentDestination = Location[2];
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.Routine = false;
					Rival.InEvent = true;
					Spy.Prompt.enabled = true;
					if (!LosingFriend)
					{
						Friend.Private = true;
						Rival.Private = true;
						if (!OtherEvent.NaturalEnd)
						{
							SpeechClip = InterruptedClip;
							SpeechText = InterruptedSpeech;
							SpeechTime = InterruptedTime;
							EventAnim = InterruptedAnim;
							Speaker = InterruptedSpeaker;
							LongAnimA = InterruptedAnim[0];
							LongAnimB = InterruptedAnim[1];
						}
						bool flag = false;
						if (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || StudentGlobals.GetStudentBroken(81) || StudentGlobals.StudentSlave == 81 || (float)StudentGlobals.GetStudentReputation(81) < -33.33333f)
						{
							Debug.Log("Musume's unavailable.");
							flag = true;
						}
						if (DateGlobals.Weekday == DayOfWeek.Friday && flag && OtherEvent.NaturalEnd)
						{
							SpeechClip = AltSpeechClip;
							SpeechText = AltSpeechText;
							SpeechTime = AltSpeechTime;
							EventAnim = AltEventAnim;
							Speaker = AltSpeaker;
						}
					}
					Yandere.PauseScreen.Hint.Show = true;
					Yandere.PauseScreen.Hint.QuickID = 12;
					Phase++;
				}
			}
			Frame++;
			return;
		}
		if (Phase == 1)
		{
			Friend.Pathfinding.canSearch = true;
			Friend.Pathfinding.canMove = true;
			if (Rival.DistanceToDestination < 0.5f)
			{
				Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				SettleRival();
			}
			if (Friend.DistanceToDestination < 0.5f)
			{
				Friend.CharacterAnimation.CrossFade(Friend.IdleAnim);
				Friend.Pathfinding.canSearch = false;
				Friend.Pathfinding.canMove = false;
				SettleFriend();
			}
			if (Rival.DistanceToDestination < 0.5f && Friend.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(SpeechClip, Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[SpeechPhase];
				if (LongAnimA == "")
				{
					PlayRelevantAnim();
				}
				else
				{
					Debug.Log("Should be playing unique animations for this event.");
					Rival.CharacterAnimation.CrossFade(LongAnimA);
					Friend.CharacterAnimation.CrossFade(LongAnimB);
				}
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Friend.Pathfinding.canSearch = false;
				Friend.Pathfinding.canMove = false;
				Friend.Obstacle.enabled = true;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (CurrentSpeaker != null && SpeechPhase > 0 && CurrentSpeaker.CharacterAnimation[EventAnim[SpeechPhase - 1]].time >= CurrentSpeaker.CharacterAnimation[EventAnim[SpeechPhase - 1]].length - 1f)
			{
				CurrentSpeaker.CharacterAnimation.CrossFade(CurrentSpeaker.IdleAnim, 1f);
			}
			Timer += Time.deltaTime;
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (SpeechPhase < SpeechTime.Length && Timer > SpeechTime[SpeechPhase])
			{
				if (Yandere.transform.position.z < -50f)
				{
					EventSubtitle.text = SpeechText[SpeechPhase];
				}
				PlayRelevantAnim();
				SpeechPhase++;
			}
			SettleRival();
			SettleFriend();
			if (LongAnimA == "")
			{
				if (Timer > SpeechClip.length)
				{
					EndEvent();
				}
			}
			else if (Timer > Rival.CharacterAnimation[LongAnimA].length)
			{
				EndEvent();
			}
		}
		if (Rival.Alarmed || Friend.Alarmed || Friend.DramaticReaction)
		{
			Debug.Log("The event ended naturally because a character was alarmed.");
			GameObject obj = UnityEngine.Object.Instantiate(AlarmDisc, Yandere.transform.position + Vector3.up, Quaternion.identity);
			obj.GetComponent<AlarmDiscScript>().NoScream = true;
			obj.transform.localScale = new Vector3(200f, 1f, 200f);
			EndEvent();
		}
		if (!Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
		{
			EndEvent();
			if (Rival.ShoeRemoval.Locker == null)
			{
				Rival.ShoeRemoval.Start();
			}
			Rival.ShoeRemoval.PutOnShoes();
		}
		if (Yandere.transform.position.z < -50f)
		{
			Listening = true;
			Distance = Vector3.Distance(Yandere.transform.position, Epicenter.position);
			if (!base.enabled)
			{
				return;
			}
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
				if (base.enabled)
				{
					Jukebox.Dip = 1f - 0.5f * Scale;
				}
				EventSubtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
				if (VoiceClip != null)
				{
					VoiceClip.GetComponent<AudioSource>().volume = Scale;
				}
				if (Phase > 1)
				{
					Yandere.Eavesdropping = Distance < 3f;
				}
			}
			else
			{
				if (Distance - 4f < 16f)
				{
					EventSubtitle.transform.localScale = Vector3.zero;
				}
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
		else if (Listening)
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			Listening = false;
		}
	}

	public void LateUpdate()
	{
		if (VoiceClip != null)
		{
			if (AudioData.MyAudioSource == null)
			{
				AudioData.MyAudioSource = VoiceClip.GetComponent<AudioSource>();
			}
		}
		else
		{
			AudioData.MyAudioSource = null;
		}
		if (AudioData != null && AudioData.MyAudioSource != null && CurrentSpeaker != null)
		{
			CurrentSpeaker.Jaw.transform.localEulerAngles += new Vector3(0f, 0f, AudioData.g[1].transform.position.y);
		}
	}

	public void EndEvent()
	{
		Debug.Log("Osana's ''talk with friend before going to the lockers'' event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (Rival != null)
		{
			if (!Rival.Alarmed)
			{
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.DistanceToDestination = 100f;
				if (Rival.Phase == 0)
				{
					Rival.Phase++;
				}
				Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Routine = true;
			}
			if (Rival.Alarmed)
			{
				Rival.ReturnToRoutineAfter = true;
			}
			Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Rival.Obstacle.enabled = false;
			Rival.Prompt.enabled = true;
			Rival.InEvent = false;
			Rival.Private = false;
		}
		if (Friend != null)
		{
			if (!LosingFriend)
			{
				Friend.CurrentDestination = Rival.FollowTargetDestination;
				Friend.Pathfinding.target = Rival.FollowTargetDestination;
			}
			else
			{
				Friend.CurrentDestination = Friend.Destinations[Friend.Phase];
				Friend.Pathfinding.target = Friend.Destinations[Friend.Phase];
			}
			if (!Friend.Alarmed && !Friend.DramaticReaction)
			{
				Friend.CharacterAnimation.CrossFade(Friend.WalkAnim);
				Friend.DistanceToDestination = 100f;
				Friend.Pathfinding.canSearch = true;
				Friend.Pathfinding.canMove = true;
				Friend.Routine = true;
			}
			Friend.VisionDistance = ((PlayerGlobals.PantiesEquipped == 4) ? 5f : 10f) * Friend.Paranoia;
			Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Friend.Obstacle.enabled = false;
			Friend.Prompt.enabled = true;
			Friend.InEvent = false;
			Friend.Private = false;
			if (Rival.Alarmed)
			{
				Friend.FocusOnYandere = true;
			}
		}
		Spy.Prompt.enabled = false;
		Spy.Prompt.Hide();
		if (Spy.Phase > 0)
		{
			Spy.End();
		}
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Yandere.Eavesdropping = false;
		EventSubtitle.text = string.Empty;
		Jukebox.Dip = 1f;
		base.enabled = false;
		if (LosingFriend)
		{
			Debug.Log("Raibaru will no longer hang out with Osana.");
			EndOfDay.RaibaruLoner = true;
			Debug.Log("Raibaru has become a loner, so Osana's schedule has changed.");
			if (Rival != null)
			{
				ScheduleBlock obj = Rival.ScheduleBlocks[2];
				obj.destination = "Patrol";
				obj.action = "Patrol";
				ScheduleBlock obj2 = Rival.ScheduleBlocks[7];
				obj2.destination = "Patrol";
				obj2.action = "Patrol";
				Rival.GetDestinations();
			}
		}
		AudioData.MyAudioSource = null;
	}

	private void SettleRival()
	{
		Rival.MoveTowardsTarget(Location[2].position);
		if (Quaternion.Angle(Rival.transform.rotation, Location[2].rotation) > 1f)
		{
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	private void SettleFriend()
	{
		Friend.MoveTowardsTarget(Location[1].position);
		Friend.transform.LookAt(Rival.transform.position);
	}

	private void PlayRelevantAnim()
	{
		if (LongAnimA == "")
		{
			if (Speaker[SpeechPhase] == 1)
			{
				Rival.CharacterAnimation.CrossFade(EventAnim[SpeechPhase]);
				Friend.CharacterAnimation.CrossFade(Friend.IdleAnim);
				CurrentSpeaker = Rival;
			}
			else
			{
				Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				Friend.CharacterAnimation.CrossFade(EventAnim[SpeechPhase]);
				CurrentSpeaker = Friend;
			}
		}
	}
}
