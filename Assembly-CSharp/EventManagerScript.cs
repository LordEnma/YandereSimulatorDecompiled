using System;
using UnityEngine;

public class EventManagerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public NoteLockerScript NoteLocker;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public ClockScript Clock;

	public StudentScript[] EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public int[] EventSpeaker;

	public GameObject VoiceClip;

	public AudioSource VoiceClipSource;

	public bool StopWalking;

	public bool EventCheck;

	public bool CanHappen;

	public bool HintGiven;

	public bool EventOn;

	public bool Suitor;

	public bool Spoken;

	public bool Osana;

	public bool AboutStalker;

	public float StartTimer;

	public float Timer;

	public float Scale;

	public float StartTime = 13.01f;

	public float EndTime = 13.5f;

	public int EventStudent1;

	public int EventStudent2;

	public int EventPhase;

	public int OsanaID = 1;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == DayOfWeek.Monday && DateGlobals.Week == 1)
		{
			EventCheck = true;
		}
		if (OsanaID == 3)
		{
			if (GameGlobals.Eighties || DateGlobals.Weekday != DayOfWeek.Thursday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1)
			{
				base.enabled = false;
			}
			else
			{
				EventCheck = true;
			}
		}
		NoteLocker.Prompt.enabled = true;
		NoteLocker.CanLeaveNote = true;
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
		if (!Clock.StopTime && EventCheck && CanHappen)
		{
			if (Clock.HourTime > StartTime + 1f || (AboutStalker && StudentManager.RaibaruKnowsAboutStalker))
			{
				base.enabled = false;
			}
			else if (Clock.HourTime > StartTime)
			{
				if (EventStudent[1] == null)
				{
					EventStudent[1] = StudentManager.Students[EventStudent1];
				}
				else if (!EventStudent[1].Alive)
				{
					EventCheck = false;
					base.enabled = false;
				}
				if (EventStudent[2] == null)
				{
					EventStudent[2] = StudentManager.Students[EventStudent2];
				}
				else if (!EventStudent[2].Alive)
				{
					EventCheck = false;
					base.enabled = false;
				}
				if (EventStudent[1] != null && EventStudent[2] != null && EventStudent[1].enabled && !EventStudent[1].Slave && !EventStudent[2].Slave && EventStudent[1].Indoors && !EventStudent[1].Wet && !EventStudent[1].Meeting && !EventStudent[1].Talking && (OsanaID < 2 || (OsanaID > 1 && Vector3.Distance(EventStudent[1].transform.position, EventLocation[1].position) < 1f)))
				{
					StartTimer += Time.deltaTime;
					if (StartTimer > 1f && EventStudent[1].Routine && EventStudent[2].Routine && !EventStudent[1].InEvent && !EventStudent[2].InEvent)
					{
						EventStudent[1].CurrentDestination = EventLocation[1];
						EventStudent[1].Pathfinding.target = EventLocation[1];
						EventStudent[1].EventManager = this;
						EventStudent[1].InEvent = true;
						EventStudent[1].EmptyHands();
						EventStudent[2].InEvent = true;
						if (!Osana)
						{
							EventStudent[2].CurrentDestination = EventLocation[2];
							EventStudent[2].Pathfinding.target = EventLocation[2];
							EventStudent[2].EventManager = this;
							EventStudent[2].InEvent = true;
							Debug.Log("Kokona's rooftop event just began?");
						}
						else
						{
							Debug.Log("One of Osana's ''talk privately with Raibaru'' events is beginning.");
							Yandere.PauseScreen.Hint.Show = true;
							if (DateGlobals.Weekday == DayOfWeek.Monday)
							{
								if ((double)StartTime < 7.3)
								{
									Yandere.PauseScreen.Hint.QuickID = 14;
								}
								else
								{
									Yandere.PauseScreen.Hint.QuickID = 18;
								}
							}
							if (DateGlobals.Weekday == DayOfWeek.Thursday)
							{
								Yandere.PauseScreen.Hint.QuickID = 13;
							}
							_ = (double)StartTime;
							_ = 15.5;
						}
						EventStudent[2].EmptyHands();
						EventStudent[1].SpeechLines.Stop();
						EventStudent[2].SpeechLines.Stop();
						EventCheck = false;
						EventOn = true;
					}
				}
			}
		}
		if (!EventOn)
		{
			return;
		}
		float num = Vector3.Distance(Yandere.transform.position, EventStudent[EventSpeaker[EventPhase]].transform.position);
		if (Clock.HourTime > EndTime || EventStudent[1].WitnessedCorpse || EventStudent[2].WitnessedCorpse || EventStudent[1].Dying || EventStudent[2].Dying || EventStudent[1].Splashed || EventStudent[2].Splashed || EventStudent[1].Alarmed || EventStudent[2].Alarmed)
		{
			EndEvent();
			if (EventStudent[1].Alarmed && !EventStudent[2].Attacked && !EventStudent[2].Struggling)
			{
				EventStudent[2].FocusOnYandere = true;
				EventStudent[2].Alarm = 200f;
			}
			return;
		}
		if (Osana)
		{
			if (EventStudent[1].DistanceToDestination < 1f)
			{
				EventStudent[2].CurrentDestination = EventLocation[2];
				EventStudent[2].Pathfinding.target = EventLocation[2];
				EventStudent[2].EventManager = this;
			}
			else
			{
				if (EventStudent[1].Pathfinding.canMove)
				{
					if (EventStudent[1].Pathfinding.speed == 1f)
					{
						EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].WalkAnim);
					}
					else
					{
						EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].SprintAnim);
					}
				}
				EventStudent[2].CurrentDestination = EventStudent[1].FollowTargetDestination;
				EventStudent[2].Pathfinding.target = EventStudent[1].FollowTargetDestination;
			}
			if (EventStudent[2].DistanceToDestination > 1f && EventStudent[2].Pathfinding.canMove)
			{
				if (EventStudent[2].Pathfinding.speed == 1f)
				{
					EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].WalkAnim);
				}
				else
				{
					EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].SprintAnim);
				}
			}
		}
		else
		{
			if (EventStudent[1].DistanceToDestination > 1f)
			{
				EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].WalkAnim);
			}
			if (EventStudent[2].DistanceToDestination > 1f)
			{
				EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].WalkAnim);
			}
		}
		if (!EventStudent[1].Pathfinding.canMove && !EventStudent[1].Private)
		{
			EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].IdleAnim);
			EventStudent[1].Private = true;
			StudentManager.UpdateStudents();
		}
		if (Vector3.Distance(EventStudent[2].transform.position, EventLocation[2].position) < 1f && !EventStudent[2].Pathfinding.canMove && !StopWalking)
		{
			StopWalking = true;
			EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
			EventStudent[2].Private = true;
			StudentManager.UpdateStudents();
		}
		if (StopWalking && EventPhase == 1)
		{
			EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
		}
		if (!(Vector3.Distance(EventStudent[1].transform.position, EventLocation[1].position) < 1f) || EventStudent[1].Pathfinding.canMove || EventStudent[2].Pathfinding.canMove)
		{
			return;
		}
		if (EventPhase == 1)
		{
			EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].IdleAnim);
		}
		if (Osana)
		{
			SettleFriend();
		}
		if (!Spoken)
		{
			EventStudent[EventSpeaker[EventPhase]].CharacterAnimation.CrossFade(EventAnim[EventPhase]);
			if (num < 10f)
			{
				EventSubtitle.text = EventSpeech[EventPhase];
			}
			AudioClipPlayer.Play(EventClip[EventPhase], EventStudent[EventSpeaker[EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
			Spoken = true;
		}
		else
		{
			Timer += Time.deltaTime;
			if (Timer > EventClip[EventPhase].length)
			{
				EventSubtitle.text = string.Empty;
			}
			if (Yandere.transform.position.y < EventStudent[1].transform.position.y - 1f)
			{
				EventSubtitle.transform.localScale = Vector3.zero;
			}
			else if (num < 10f)
			{
				Scale = Mathf.Abs((num - 10f) * 0.2f);
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
			}
			else
			{
				EventSubtitle.transform.localScale = Vector3.zero;
			}
			Animation characterAnimation = EventStudent[EventSpeaker[EventPhase]].CharacterAnimation;
			if (characterAnimation[EventAnim[EventPhase]].time >= characterAnimation[EventAnim[EventPhase]].length - 1f)
			{
				characterAnimation.CrossFade(EventStudent[EventSpeaker[EventPhase]].IdleAnim, 1f);
			}
			if (Timer > EventClip[EventPhase].length + 1f)
			{
				Spoken = false;
				EventPhase++;
				Timer = 0f;
				if (EventPhase == EventSpeech.Length)
				{
					EndEvent();
				}
			}
			if (!Suitor && Yandere.transform.position.y > EventStudent[1].transform.position.y - 1f && EventPhase == 7 && num < 6f)
			{
				if (EventStudent1 == 25)
				{
					if (!EventGlobals.Event1)
					{
						Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
						EventGlobals.Event1 = true;
					}
				}
				else if (OsanaID < 2 && !Yandere.Police.EndOfDay.LearnedOsanaInfo2)
				{
					Debug.Log("We just eavesdropped on Osana. Her profile should update.");
					Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
					Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
					StudentManager.OsanaOfferHelp.Eavesdropped = true;
					if (SchemeGlobals.GetSchemeStage(6) == 2)
					{
						if (EventStudent[1].Friend)
						{
							SchemeGlobals.SetSchemeStage(6, 4);
						}
						else
						{
							SchemeGlobals.SetSchemeStage(6, 3);
						}
						Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
				}
			}
		}
		if (base.enabled)
		{
			if (num < 3f)
			{
				Yandere.Eavesdropping = true;
			}
			else
			{
				Yandere.Eavesdropping = false;
			}
		}
	}

	private void SettleFriend()
	{
		EventStudent[2].MoveTowardsTarget(EventLocation[2].position);
		if (Quaternion.Angle(EventStudent[2].transform.rotation, EventLocation[2].rotation) > 1f)
		{
			EventStudent[2].transform.rotation = Quaternion.Slerp(EventStudent[2].transform.rotation, EventLocation[2].rotation, 10f * Time.deltaTime);
		}
	}

	public void EndEvent()
	{
		if (Osana)
		{
			Debug.Log("One of Osana's ''talk privately with Raibaru'' events just ended.");
		}
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		EventStudent[1].CurrentDestination = EventStudent[1].Destinations[EventStudent[1].Phase];
		EventStudent[1].Pathfinding.target = EventStudent[1].Destinations[EventStudent[1].Phase];
		EventStudent[1].EventManager = null;
		EventStudent[1].InEvent = false;
		EventStudent[1].Private = false;
		if (!EventStudent[2].Attacked)
		{
			EventStudent[2].CurrentDestination = EventStudent[2].Destinations[EventStudent[2].Phase];
			EventStudent[2].Pathfinding.target = EventStudent[2].Destinations[EventStudent[2].Phase];
			EventStudent[2].EventManager = null;
			EventStudent[2].InEvent = false;
			EventStudent[2].Private = false;
		}
		_ = (double)StartTime;
		_ = 15.5;
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Jukebox.Dip = 1f;
		Yandere.Eavesdropping = false;
		EventSubtitle.text = string.Empty;
		EventCheck = false;
		EventOn = false;
		base.enabled = false;
	}
}
