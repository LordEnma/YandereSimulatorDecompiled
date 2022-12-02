using System;
using UnityEngine;

public class RivalAfterClassEventManagerScript : MonoBehaviour
{
	public OsanaThursdayAfterClassEventScript OsanaThursdayRooftopEvent;

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

	public AudioClip CancelledSpeechClip;

	public string[] CancelledSpeechText;

	public float[] CancelledSpeechTime;

	public AudioClip SabotagedSpeechClip;

	public string[] SabotagedSpeechText;

	public float[] SabotagedSpeechTime;

	public AudioClip SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public AudioClip ImpatientSpeechClip;

	public string ImpatientSpeechText;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public bool LookAtSenpai;

	public bool EventActive;

	public bool NaturalEnd;

	public bool Cancelled;

	public bool HintGiven;

	public bool Impatient;

	public bool Sabotaged;

	public bool Transfer;

	public bool TakeOut;

	public bool PutAway;

	public bool Return;

	public float TransferTime;

	public float ReturnTime;

	public float TakeOutTime;

	public float PutAwayTime;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int SpeechPhase = 1;

	public int FriendID = 10;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public string Weekday = string.Empty;

	public string Suffix = string.Empty;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		Spy.Prompt.enabled = false;
		Spy.Prompt.Hide();
		if (DateGlobals.Weekday != EventDay || GameGlobals.RivalEliminationID > 0 || GameGlobals.Eighties)
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
				Senpai = StudentManager.Students[1];
				if (StudentManager.Students[RivalID] != null)
				{
					Rival = StudentManager.Students[RivalID];
				}
				else
				{
					base.enabled = false;
				}
			}
			if (Frame > 1 && Clock.HourTime > 17.25f && Senpai.gameObject.activeInHierarchy && Rival != null)
			{
				if ((Senpai.Leaving || Senpai.CurrentDestination == StudentManager.Exit) && !Senpai.InEvent)
				{
					Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Senpai.CharacterAnimation.CrossFade(Senpai.WalkAnim);
					Senpai.Pathfinding.target = Location[1];
					Senpai.CurrentDestination = Location[1];
					Senpai.Pathfinding.canSearch = true;
					Senpai.Pathfinding.canMove = true;
					Senpai.InEvent = true;
					Senpai.DistanceToDestination = 100f;
					Spy.Prompt.enabled = true;
				}
				if ((Rival.Leaving || Rival.CurrentDestination == StudentManager.Exit) && Rival.enabled && !Rival.InEvent)
				{
					Debug.Log("Osana's Wednesday after school event has begun.");
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
					Rival.Pathfinding.target = Location[2];
					Rival.CurrentDestination = Location[2];
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.InEvent = true;
					Rival.DistanceToDestination = 100f;
					Spy.Prompt.enabled = true;
				}
				if (Senpai.CurrentDestination == Location[1] && Senpai.DistanceToDestination < 0.5f)
				{
					if (!Impatient)
					{
						Senpai.CharacterAnimation.CrossFade("waiting_00");
						Senpai.Pathfinding.canSearch = false;
						Senpai.Pathfinding.canMove = false;
						if (Clock.HourTime > 17.916666f)
						{
							AudioClipPlayer.Play(ImpatientSpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
							Senpai.CharacterAnimation.CrossFade("impatience_00");
							EventSubtitle.text = ImpatientSpeechText;
							Impatient = true;
						}
					}
					else if (Senpai.CharacterAnimation["impatience_00"].time >= Senpai.CharacterAnimation["impatience_00"].length)
					{
						StudentManager.SabotageProgress++;
						Debug.Log("Sabotage Progress: " + StudentManager.SabotageProgress + "/5");
						EndEvent();
					}
				}
				if (Rival.CurrentDestination == Location[2] && Rival.DistanceToDestination < 0.5f)
				{
					Rival.CharacterAnimation.CrossFade(Rival.IdleAnim);
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
				}
				if (!HintGiven)
				{
					Yandere.PauseScreen.Hint.QuickID = 10;
					Yandere.PauseScreen.Hint.Show = true;
					HintGiven = true;
				}
				if (Rival.CurrentDestination == Location[2] && Senpai.CurrentDestination == Location[1] && Senpai.DistanceToDestination < 0.5f && Rival.DistanceToDestination < 0.5f && !Impatient)
				{
					Phase++;
				}
			}
			Frame++;
		}
		else if (Phase == 1)
		{
			if (StudentManager.Students[FriendID] != null && Rival.Follower != null && !PlayerGlobals.RaibaruLoner)
			{
				Friend = StudentManager.Students[FriendID];
				Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Friend.Pathfinding.target = Location[3];
				Friend.CurrentDestination = Location[3];
				Friend.ManualRotation = true;
				Friend.Cheer.enabled = true;
				Friend.InEvent = true;
			}
			if (EventDay == DayOfWeek.Tuesday)
			{
				Rival.EventBook.SetActive(true);
				if (!Sabotaged)
				{
					AudioClipPlayer.Play(SpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					TransferTime = 8.5f;
					Suffix = "A";
				}
				else
				{
					AudioClipPlayer.Play(SabotagedSpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					TransferTime = 11f;
					Suffix = "B";
				}
			}
			else if (EventDay == DayOfWeek.Wednesday)
			{
				Sabotaged = Rival.LewdPhotos;
				if (Rival.Phoneless)
				{
					Cancelled = true;
				}
				if (Cancelled)
				{
					AudioClipPlayer.Play(CancelledSpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Transfer = false;
					TakeOut = false;
					Suffix = "C";
				}
				else if (!Sabotaged)
				{
					AudioClipPlayer.Play(SpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					TransferTime = 4.833333f;
					ReturnTime = 35f;
					TakeOutTime = 0.75f;
					PutAwayTime = 36.5f;
					Suffix = "A";
				}
				else
				{
					AudioClipPlayer.Play(SabotagedSpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					TransferTime = 4.833333f;
					ReturnTime = 26.5f;
					TakeOutTime = 0.75f;
					PutAwayTime = 50f;
					Suffix = "B";
				}
			}
			else if (EventDay == DayOfWeek.Thursday)
			{
				AudioClipPlayer.Play(SpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Suffix = "A";
			}
			Rival.CharacterAnimation.CrossFade("f02_" + Weekday + "_3" + Suffix);
			if (EventDay == DayOfWeek.Thursday)
			{
				Senpai.CharacterAnimation.CrossFade(Senpai.IdleAnim);
			}
			else
			{
				Senpai.CharacterAnimation.CrossFade(Weekday + "_3" + Suffix);
			}
			Timer = 0f;
			Phase++;
		}
		else
		{
			Timer += Time.deltaTime;
			if (VoiceClip != null)
			{
				VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (Cancelled)
			{
				if (SpeechPhase < CancelledSpeechTime.Length && Timer > CancelledSpeechTime[SpeechPhase])
				{
					EventSubtitle.text = CancelledSpeechText[SpeechPhase];
					SpeechPhase++;
				}
			}
			else if (!Sabotaged)
			{
				if (SpeechPhase < SpeechTime.Length && Timer > SpeechTime[SpeechPhase])
				{
					EventSubtitle.text = SpeechText[SpeechPhase];
					SpeechPhase++;
				}
			}
			else
			{
				if (SpeechPhase < SabotagedSpeechTime.Length && Timer > SabotagedSpeechTime[SpeechPhase])
				{
					EventSubtitle.text = SabotagedSpeechText[SpeechPhase];
					SpeechPhase++;
				}
				if (Senpai.CharacterAnimation[Weekday + "_3" + Suffix].time >= Senpai.CharacterAnimation[Weekday + "_3" + Suffix].length)
				{
					Rival.StopRotating = true;
					LookAtSenpai = true;
					EndSenpai();
				}
				if (LookAtSenpai)
				{
					Rival.targetRotation = Quaternion.LookRotation(Senpai.transform.position - Rival.transform.position);
					Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.targetRotation, 10f * Time.deltaTime);
				}
			}
			if (Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time >= Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].length)
			{
				NaturalEnd = true;
				EndEvent();
			}
			if (TakeOut && EventDay == DayOfWeek.Wednesday && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > TakeOutTime)
			{
				Rival.SmartPhone.SetActive(true);
				TakeOut = false;
				PutAway = true;
			}
			if (PutAway && EventDay == DayOfWeek.Wednesday && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > PutAwayTime)
			{
				Rival.SmartPhone.SetActive(false);
				PutAway = false;
			}
			if (Transfer)
			{
				if (EventDay == DayOfWeek.Tuesday)
				{
					if (Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > TransferTime)
					{
						Rival.EventBook.SetActive(false);
						Senpai.EventBook.SetActive(true);
						Transfer = false;
						Return = true;
					}
				}
				else if (EventDay == DayOfWeek.Wednesday && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > TransferTime)
				{
					Rival.SmartPhone.SetActive(false);
					Senpai.SmartPhone.SetActive(true);
					Transfer = false;
					Return = true;
				}
			}
			if (Return && EventDay == DayOfWeek.Wednesday && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > ReturnTime)
			{
				Rival.SmartPhone.SetActive(true);
				Senpai.SmartPhone.SetActive(false);
				Return = false;
			}
			if (Senpai.Alarmed || Rival.Alarmed || Rival.Splashed || Rival.GoAway)
			{
				UnityEngine.Object.Instantiate(AlarmDisc, Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				EndEvent();
			}
		}
		if (Phase > 0 || Impatient)
		{
			Distance = Vector3.Distance(Yandere.transform.position, Epicenter.position);
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
				Yandere.Eavesdropping = Distance < 5f;
			}
			else
			{
				EventSubtitle.transform.localScale = Vector3.zero;
				if (VoiceClip != null)
				{
					VoiceClip.GetComponent<AudioSource>().volume = 0f;
				}
			}
		}
		if (Phase <= 0)
		{
			return;
		}
		if (Friend != null)
		{
			if (Friend.DistanceToDestination < 1f)
			{
				Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
				Friend.MoveTowardsTarget(Friend.CurrentDestination.position);
				Friend.targetRotation = Friend.CurrentDestination.rotation;
				Friend.transform.rotation = Quaternion.Slerp(Friend.transform.rotation, Friend.targetRotation, 10f * Time.deltaTime);
				Friend.MyController.radius = 0f;
			}
			else
			{
				Friend.CharacterAnimation.CrossFade(Friend.SprintAnim);
				Friend.Pathfinding.speed = 4f;
			}
		}
		else if (StudentManager.Students[FriendID] != null && !PlayerGlobals.RaibaruLoner)
		{
			Friend = StudentManager.Students[FriendID];
		}
	}

	private void EndEvent()
	{
		Debug.Log("Osana's talking-with-Senpai-before-going-home event ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (Senpai.InEvent)
		{
			EndSenpai();
		}
		if (!Rival.Ragdoll.Zs.activeInHierarchy)
		{
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
			Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
			Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
			Rival.DistanceToDestination = 100f;
			Rival.Pathfinding.speed = 1f;
			Rival.Hurry = false;
		}
		if (Friend != null && Friend.CurrentAction == StudentActionType.Follow)
		{
			if (!Friend.Alarmed && !Friend.DramaticReaction)
			{
				Friend.Pathfinding.canSearch = true;
				Friend.Pathfinding.canMove = true;
			}
			if (NaturalEnd || Rival.GoAway)
			{
				Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				Friend.Pathfinding.target = Rival.transform;
				Friend.CurrentDestination = Rival.transform;
				Friend.Pathfinding.canSearch = true;
				Friend.Pathfinding.canMove = true;
				Friend.MyController.radius = 0.1f;
				Friend.ManualRotation = false;
				Friend.Prompt.enabled = true;
				Friend.InEvent = false;
				Friend.Private = false;
			}
			Friend.Cheer.enabled = false;
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
		if (Sabotaged)
		{
			Rival.WalkAnim = "f02_sadWalk_00";
			StudentManager.SabotageProgress++;
			Debug.Log("Sabotage Progress: " + StudentManager.SabotageProgress + "/5");
		}
		Yandere.Eavesdropping = false;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		Jukebox.Dip = 1f;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Forget it, let's just go home...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}

	private void EndSenpai()
	{
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
		Senpai.CurrentDestination = Senpai.Destinations[Senpai.Phase];
		Senpai.Pathfinding.target = Senpai.Destinations[Senpai.Phase];
		Senpai.DistanceToDestination = 100f;
		if (EventDay == DayOfWeek.Thursday)
		{
			OsanaThursdayRooftopEvent.enabled = false;
		}
	}
}
