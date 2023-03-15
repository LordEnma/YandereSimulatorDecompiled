using System;
using UnityEngine;

public class OsanaFridayBeforeClassEvent2Script : MonoBehaviour
{
	public OsanaFridayBeforeClassEvent1Script OtherEvent;

	public StudentManagerScript StudentManager;

	public AudioSoftwareScript AudioSoftware;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript Ganguro;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform[] Location;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public string[] EventAnim;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public Quaternion targetRotation;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int SpeechPhase = 1;

	public int GanguroID = 81;

	public int FriendID = 10;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public bool IgnoreFriend;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != EventDay || StudentGlobals.GetStudentKidnapped(RivalID) || StudentGlobals.StudentSlave == RivalID || StudentGlobals.StudentSlave == 81 || StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || (float)StudentGlobals.GetStudentReputation(81) < -33.33333f || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0 && StudentManager.Students[RivalID] != null && StudentManager.Students[GanguroID] != null)
			{
				if (Ganguro == null)
				{
					Ganguro = StudentManager.Students[GanguroID];
				}
				if (Rival == null)
				{
					Rival = StudentManager.Students[RivalID];
				}
				if (Friend == null && StudentManager.Students[FriendID] != null && !PlayerGlobals.RaibaruLoner)
				{
					Friend = StudentManager.Students[FriendID];
				}
				if (!Ganguro.Alive)
				{
					base.enabled = false;
				}
				else if ((double)Clock.HourTime > 7.25 && Rival.enabled && !Rival.InEvent && !Rival.Meeting && Rival.Indoors && !Rival.Wet && !Rival.Following && !Rival.Meeting && !Rival.Hunted && Rival.Pathfinding.target == Rival.Destinations[2] && Rival.DistanceToDestination < 1f && !Rival.Phoneless && !Rival.EndSearch)
				{
					Debug.Log("Osana's ''Talk with Musume'' event has begun.");
					Ganguro.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
					Ganguro.CharacterAnimation.CrossFade(Ganguro.SprintAnim);
					Ganguro.Pathfinding.target = Rival.transform;
					Ganguro.CurrentDestination = Rival.transform;
					Ganguro.Pathfinding.canSearch = true;
					Ganguro.Pathfinding.canMove = true;
					Ganguro.Pathfinding.speed = 4f;
					Ganguro.SpeechLines.Stop();
					Ganguro.Routine = false;
					Ganguro.InEvent = true;
					Rival.InEvent = true;
					if (Friend != null && (Friend.InvestigatingBloodPool || Friend.ReturningMisplacedWeapon || Friend.CurrentAction != StudentActionType.Follow))
					{
						IgnoreFriend = true;
						Friend = null;
					}
					Yandere.PauseScreen.Hint.Show = true;
					Yandere.PauseScreen.Hint.QuickID = 24;
					Phase++;
				}
			}
			Frame++;
			return;
		}
		if (Phase == 1)
		{
			Input.GetKeyDown(KeyCode.Space);
			if (Ganguro.DistanceToDestination < 1f)
			{
				AudioClipPlayer.Play(SpeechClip[1], Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Rival.CharacterAnimation.CrossFade(EventAnim[1]);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Rival.SpeechLines.Stop();
				Rival.Routine = false;
				Rival.InEvent = true;
				Ganguro.CharacterAnimation.CrossFade(EventAnim[2]);
				Ganguro.Pathfinding.canSearch = false;
				Ganguro.Pathfinding.canMove = false;
				Ganguro.Obstacle.enabled = true;
				EventSubtitle.text = SpeechText[1];
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			targetRotation = Quaternion.LookRotation(Ganguro.transform.position - Rival.transform.position);
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, targetRotation, 10f * Time.deltaTime);
			targetRotation = Quaternion.LookRotation(Rival.transform.position - Ganguro.transform.position);
			Ganguro.transform.rotation = Quaternion.Slerp(Ganguro.transform.rotation, targetRotation, 10f * Time.deltaTime);
			if (Rival.CharacterAnimation[EventAnim[1]].time >= 4f)
			{
				EventSubtitle.text = SpeechText[2];
				Ganguro.Pathfinding.speed = 1f;
				Phase++;
			}
			CheckForFriendDistraction();
			if (Friend != null)
			{
				Friend.Distracted = true;
			}
		}
		else if (Phase == 3)
		{
			if (Rival.CharacterAnimation[EventAnim[1]].time >= Rival.CharacterAnimation[EventAnim[1]].length)
			{
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.Pathfinding.target = Location[1];
				Rival.CurrentDestination = Location[1];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Ganguro.CharacterAnimation.CrossFade(Ganguro.WalkAnim);
				Ganguro.Pathfinding.target = Location[2];
				Ganguro.CurrentDestination = Location[2];
				Ganguro.Pathfinding.canSearch = true;
				Ganguro.Pathfinding.canMove = true;
				Spy.Prompt.enabled = true;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			CheckForFriendDistraction();
			if (Friend != null && Rival.DistanceToDestination < 5f)
			{
				Friend.CurrentDestination = Location[3];
				Friend.Pathfinding.target = Location[3];
				Friend.DistanceToDestination = 0.5f;
				Friend.IdleAnim = "f02_spying_00";
				Friend.SlideIn = true;
			}
			if (Rival.DistanceToDestination < 0.5f)
			{
				Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
				SettleRival();
			}
			if (Ganguro.DistanceToDestination < 0.5f)
			{
				Ganguro.CharacterAnimation.CrossFade(Ganguro.IdleAnim);
				SettleGanguro();
			}
			if (Rival.DistanceToDestination < 0.5f && Ganguro.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(SpeechClip[2], Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Rival.CharacterAnimation.CrossFade(EventAnim[3]);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Ganguro.CharacterAnimation.CrossFade(EventAnim[4]);
				Ganguro.Pathfinding.canSearch = false;
				Ganguro.Pathfinding.canMove = false;
				Ganguro.Obstacle.enabled = true;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (SpeechPhase < SpeechTime.Length && Timer > SpeechTime[SpeechPhase])
			{
				EventSubtitle.text = SpeechText[SpeechPhase];
				SpeechPhase++;
			}
			if ((double)Timer > 3.9 && Spy.CanRecord)
			{
				Spy.PromptBar.Label[0].text = "";
				Spy.PromptBar.UpdateButtons();
				Spy.CanRecord = false;
			}
			SettleRival();
			SettleGanguro();
			if (Rival.CharacterAnimation[EventAnim[3]].time >= Rival.CharacterAnimation[EventAnim[3]].length)
			{
				EndEvent();
			}
		}
		if (Rival.Alarmed || Clock.HourTime > 8f || Rival.Splashed || Rival.GoAway)
		{
			EndEvent();
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
		Debug.Log("Osana's second Friday before class event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (Rival != null)
		{
			if (Rival.enabled && !Rival.Alarmed)
			{
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.DistanceToDestination = 100f;
				Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Routine = true;
			}
			Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Rival.Obstacle.enabled = false;
			Rival.Prompt.enabled = true;
			Rival.InEvent = false;
			Rival.Private = false;
			if (!Ganguro.Alarmed)
			{
				Ganguro.CharacterAnimation.CrossFade(Ganguro.WalkAnim);
				Ganguro.DistanceToDestination = 100f;
				Ganguro.CurrentDestination = Ganguro.Destinations[Ganguro.Phase];
				Ganguro.Pathfinding.target = Ganguro.Destinations[Ganguro.Phase];
				Ganguro.Pathfinding.canSearch = true;
				Ganguro.Pathfinding.canMove = true;
				Ganguro.Routine = true;
			}
			Ganguro.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Ganguro.Obstacle.enabled = false;
			Ganguro.Prompt.enabled = true;
			Ganguro.InEvent = false;
			Ganguro.Private = false;
			if (Friend != null)
			{
				if (Friend.FollowTarget != null)
				{
					Friend.CurrentDestination = Friend.FollowTarget.transform;
					Friend.Pathfinding.target = Friend.FollowTarget.transform;
				}
				Friend.IdleAnim = Friend.OriginalIdleAnim;
				Friend.DistanceToDestination = 1f;
				Friend.SlideIn = false;
				Friend.Distracted = false;
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
		if (Spy.Recording)
		{
			AudioSoftware.ConversationRecorded = true;
		}
		EventSubtitle.text = string.Empty;
		Jukebox.Dip = 1f;
		base.enabled = false;
		if (Rival != null && Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! I'm not in the mood for this...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}

	private void SettleRival()
	{
		if (!Rival.GoAway)
		{
			Rival.MoveTowardsTarget(Location[1].position);
		}
		if (Quaternion.Angle(Rival.transform.rotation, Location[1].rotation) > 1f)
		{
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Location[1].rotation, 10f * Time.deltaTime);
		}
	}

	private void SettleGanguro()
	{
		if (!Ganguro.GoAway)
		{
			Ganguro.MoveTowardsTarget(Location[2].position);
		}
		if (Quaternion.Angle(Ganguro.transform.rotation, Location[2].rotation) > 1f)
		{
			Ganguro.transform.rotation = Quaternion.Slerp(Ganguro.transform.rotation, Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	private void CheckForFriendDistraction()
	{
		if (Friend != null && (Friend.InvestigatingBloodPool || Friend.ReturningMisplacedWeapon || Friend.CurrentAction != StudentActionType.Follow))
		{
			IgnoreFriend = true;
			Friend = null;
		}
	}
}
