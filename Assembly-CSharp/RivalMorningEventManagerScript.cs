using System;
using UnityEngine;

public class RivalMorningEventManagerScript : MonoBehaviour
{
	public OsanaMorningFriendEventScript OsanaLoseFriendEvent;

	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript Friend;

	public StudentScript Senpai;

	public StudentScript Rival;

	public Transform[] Location;

	public Transform Epicenter;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public AudioSource VoiceClipSource;

	public bool NaturalEnd;

	public bool Listening;

	public bool HintGiven;

	public bool Transfer;

	public bool End;

	public float TransferTime;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int SpeechPhase = 1;

	public int FriendID = 6;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public string Weekday = string.Empty;

	public float AnimationTime;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		Spy.Prompt.enabled = true;
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
		}
		if (DateGlobals.Weekday != EventDay || HomeGlobals.LateForSchool || StudentManager.YandereLate || DatingGlobals.SuitorProgress == 2 || StudentGlobals.MemorialStudents > 0 || GameGlobals.RivalEliminationID > 0 || StudentGlobals.StudentSlave == RivalID || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties || StudentManager.RecordingVideo)
		{
			Spy.Prompt.enabled = false;
			base.enabled = false;
		}
		if (base.enabled && (float)StudentGlobals.GetStudentReputation(10) <= -33.33333f)
		{
			OsanaLoseFriendEvent.OtherEvent = this;
		}
	}

	private void Update()
	{
		if (VoiceClip != null)
		{
			if (VoiceClipSource == null)
			{
				VoiceClipSource = VoiceClip.GetComponent<AudioSource>();
			}
			else
			{
				VoiceClipSource.pitch = Time.timeScale;
			}
		}
		if (Phase == 0)
		{
			if (Frame > 5 && StudentManager.Students[RivalID] != null && StudentManager.Students[1].gameObject.activeInHierarchy && StudentManager.Students[RivalID] != null)
			{
				Debug.Log("Osana's morning Senpai interaction event is now taking place.");
				if (StudentManager.Students[FriendID] != null && !PlayerGlobals.RaibaruLoner && StudentGlobals.StudentSlave != FriendID)
				{
					Friend = StudentManager.Students[FriendID];
					if (Friend.Investigating)
					{
						Friend.StopInvestigating();
					}
					if ((float)StudentGlobals.GetStudentReputation(10) > -33.33333f)
					{
						Friend.CharacterAnimation.Play("f02_cornerPeek_00");
						Friend.Cheer.enabled = true;
					}
					else
					{
						Friend.CharacterAnimation.Play(Friend.BulliedIdleAnim);
					}
					Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Friend.transform.position = Location[3].position;
					Friend.transform.eulerAngles = Location[3].eulerAngles;
					Friend.Pathfinding.canSearch = false;
					Friend.Pathfinding.canMove = false;
					Friend.IgnoringPettyActions = true;
					Friend.ImmuneToLaughter = true;
					Friend.VisionDistance = 20f;
					Friend.Routine = false;
					Friend.InEvent = true;
					Friend.Spawned = true;
				}
				Senpai = StudentManager.Students[1];
				Rival = StudentManager.Students[RivalID];
				Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Senpai.CharacterAnimation.Play(Senpai.IdleAnim);
				Senpai.transform.position = Location[1].position;
				Senpai.transform.eulerAngles = Location[1].eulerAngles;
				Senpai.Pathfinding.canSearch = false;
				Senpai.Pathfinding.canMove = false;
				Senpai.Routine = false;
				Senpai.InEvent = true;
				Senpai.Spawned = true;
				Senpai.Prompt.Hide();
				Senpai.Prompt.enabled = false;
				if (Rival.Investigating)
				{
					Rival.StopInvestigating();
				}
				Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Rival.CharacterAnimation.Play(Rival.IdleAnim);
				Rival.transform.position = Location[2].position;
				Rival.transform.eulerAngles = Location[2].eulerAngles;
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Routine = false;
				Rival.InEvent = true;
				Rival.Spawned = true;
				Rival.Private = true;
				Rival.Prompt.Hide();
				Rival.Prompt.enabled = false;
				Spy.Prompt.enabled = true;
				Phase++;
				if (EventDay == DayOfWeek.Tuesday)
				{
					StudentManager.Students[1].EventBook.SetActive(true);
				}
			}
			Frame++;
		}
		else if (Phase == 1)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f)
			{
				AudioClipPlayer.Play(SpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Rival.CharacterAnimation.CrossFade("f02_" + Weekday + "_1");
				Senpai.CharacterAnimation.CrossFade(Weekday + "_1");
				Timer = 0f;
				Phase++;
			}
		}
		else
		{
			if (AnimationTime > 0f)
			{
				Debug.Log("Attempting to restore animation.");
				Rival.CharacterAnimation.Play("f02_" + Weekday + "_1");
				Senpai.CharacterAnimation.Play(Weekday + "_1");
				Rival.CharacterAnimation["f02_" + Weekday + "_1"].time = AnimationTime;
				Senpai.CharacterAnimation[Weekday + "_1"].time = AnimationTime;
				if (VoiceClipSource != null)
				{
					VoiceClipSource.time = AnimationTime;
					AnimationTime = 0f;
				}
				else
				{
					AudioClipPlayer.Play(SpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				}
			}
			Timer += Time.deltaTime;
			if (Timer > 1f && !HintGiven)
			{
				Yandere.PauseScreen.Hint.Show = true;
				Yandere.PauseScreen.Hint.QuickID = 1;
				HintGiven = true;
			}
			if (VoiceClipSource != null)
			{
				VoiceClipSource.pitch = Time.timeScale;
			}
			if (SpeechPhase < SpeechTime.Length)
			{
				if (Timer > SpeechTime[SpeechPhase])
				{
					if (Vector3.Distance(Yandere.transform.position, Epicenter.position) < 11f)
					{
						EventSubtitle.text = SpeechText[SpeechPhase];
					}
					SpeechPhase++;
				}
			}
			else
			{
				if (Senpai == null)
				{
					Senpai = StudentManager.Students[1];
				}
				if (Senpai.CharacterAnimation[Weekday + "_1"].time >= Senpai.CharacterAnimation[Weekday + "_1"].length)
				{
					Debug.Log("This rival morning event ended naturally because the animation finished playing.");
					NaturalEnd = true;
					EndEvent();
				}
			}
			if (Transfer && Rival.CharacterAnimation["f02_" + Weekday + "_1"].time > TransferTime)
			{
				Senpai.EventBook.SetActive(false);
				Rival.EventBook.SetActive(true);
				Transfer = false;
			}
			if (Clock.Period > 1)
			{
				Debug.Log("The event ended because the school period has advanced.");
				EndEvent();
			}
			if (Rival != null && (Senpai.Alarmed || Rival.Alarmed || (Friend != null && Friend.DramaticReaction)))
			{
				Debug.Log("The event ended naturally because a character was alarmed.");
				GameObject obj = UnityEngine.Object.Instantiate(AlarmDisc, Rival.transform.position + Vector3.up, Quaternion.identity);
				obj.GetComponent<AlarmDiscScript>().NoScream = true;
				obj.transform.localScale = new Vector3(150f, 1f, 150f);
				obj.GetComponent<AlarmDiscScript>().FocusOnYandere = true;
				EndEvent();
			}
			if (!Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
			{
				EndEvent();
			}
			if (Yandere.transform.position.z < -50f)
			{
				Listening = true;
				Distance = Vector3.Distance(Yandere.transform.position, Epicenter.position);
				if (base.enabled)
				{
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
						if (VoiceClipSource != null)
						{
							VoiceClipSource.volume = Scale;
						}
						Yandere.Eavesdropping = Distance < 3f;
					}
					else
					{
						if (Distance - 4f < 16f)
						{
							EventSubtitle.transform.localScale = Vector3.zero;
						}
						if (VoiceClipSource != null)
						{
							VoiceClipSource.volume = 0f;
						}
					}
				}
			}
			else if (Listening)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
				Listening = false;
			}
		}
		if (End)
		{
			Debug.Log("The event ended naturally because the ''End'' variable was set to ''true''.");
			EndEvent();
		}
	}

	public void EndEvent()
	{
		Debug.Log("Osana's morning ''Talk with Senpai'' event has ended.");
		if (Phase <= 0 || !Rival.Alive)
		{
			return;
		}
		if (EventDay == DayOfWeek.Tuesday)
		{
			ScheduleBlock obj = Senpai.ScheduleBlocks[2];
			obj.destination = "Patrol";
			obj.action = "Patrol";
			ScheduleBlock obj2 = Senpai.ScheduleBlocks[7];
			obj2.destination = "Patrol";
			obj2.action = "Patrol";
			Senpai.GetDestinations();
		}
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Senpai.Alarmed)
		{
			Senpai.Pathfinding.canSearch = true;
			Senpai.Pathfinding.canMove = true;
			Senpai.Routine = true;
		}
		Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Senpai.EventBook.SetActive(false);
		Senpai.InEvent = false;
		Senpai.Private = false;
		if (!Rival.Alarmed)
		{
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			Rival.Routine = true;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.EventBook.SetActive(false);
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (Friend != null)
		{
			if (!Friend.Alarmed && !Friend.DramaticReaction)
			{
				Friend.Pathfinding.canSearch = true;
				Friend.Pathfinding.canMove = true;
				Friend.Routine = true;
			}
			if (NaturalEnd)
			{
				Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				Friend.Prompt.enabled = true;
				Friend.InEvent = false;
				Friend.Private = false;
			}
			else
			{
				Friend.Pathfinding.target = Location[3];
				Friend.CurrentDestination = Location[3];
			}
			Friend.Cheer.enabled = false;
			Friend.ImmuneToLaughter = false;
			Friend.IgnoringPettyActions = false;
		}
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Spy.Prompt.Hide();
		Spy.Prompt.enabled = false;
		if (Spy.Phase > 0)
		{
			Spy.End();
		}
		Yandere.Eavesdropping = false;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		Jukebox.Dip = 1f;
	}

	public void SaveAnimationTime()
	{
		if (Phase > 1 && base.enabled)
		{
			if (Rival != null)
			{
				AnimationTime = Rival.CharacterAnimation["f02_" + Weekday + "_1"].time;
			}
			Debug.Log("AnimationTime was: " + AnimationTime);
		}
	}
}
