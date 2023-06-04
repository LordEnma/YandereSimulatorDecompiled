using System;
using UnityEngine;

public class OsanaFridayLunchEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public AudioSoftwareScript AudioSoftware;

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

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public bool LookAtSenpai;

	public bool EventActive;

	public bool Cancelled;

	public bool HintGiven;

	public bool Impatient;

	public bool Sabotaged;

	public bool Transfer;

	public bool TakeOut;

	public bool PutAway;

	public bool Return;

	public Vector3 OriginalRotation;

	public Vector3 OriginalPosition;

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
			if (Frame > 1 && Clock.HourTime > 13f && Senpai.gameObject.activeInHierarchy && Rival != null)
			{
				if (Rival.Bullied)
				{
					base.enabled = false;
				}
				else
				{
					if (!Senpai.InEvent)
					{
						Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						Senpai.CharacterAnimation.CrossFade(Senpai.WalkAnim);
						Senpai.Pathfinding.target = Location[1];
						Senpai.CurrentDestination = Location[1];
						Senpai.Pathfinding.canSearch = true;
						Senpai.Pathfinding.canMove = true;
						Senpai.SmartPhone.SetActive(value: false);
						Senpai.InEvent = true;
						Senpai.DistanceToDestination = 100f;
						Spy.Prompt.enabled = true;
					}
					if (Rival.enabled && !Rival.InEvent && !Rival.Phoneless && !Rival.EndSearch)
					{
						Debug.Log("Osana's Friday lunch event has begun.");
						Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
						Rival.Pathfinding.target = Location[2];
						Rival.CurrentDestination = Location[2];
						Rival.Pathfinding.canSearch = true;
						Rival.Pathfinding.canMove = true;
						Rival.SmartPhone.SetActive(value: false);
						Rival.Routine = false;
						Rival.InEvent = true;
						Rival.DistanceToDestination = 100f;
						Spy.Prompt.enabled = true;
					}
					if (StudentManager.Students[FriendID] != null && !PlayerGlobals.RaibaruLoner)
					{
						Friend = StudentManager.Students[FriendID];
					}
					if (Senpai.CurrentDestination == Location[1] && Senpai.DistanceToDestination < 0.5f)
					{
						if (!Impatient)
						{
							Senpai.CharacterAnimation.CrossFade("impatientWait_00");
							Senpai.Pathfinding.canSearch = false;
							Senpai.Pathfinding.canMove = false;
						}
						else if (Senpai.CharacterAnimation["impatience_00"].time >= Senpai.CharacterAnimation["impatience_00"].length)
						{
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
						Yandere.PauseScreen.Hint.Show = true;
						Yandere.PauseScreen.Hint.QuickID = 7;
						HintGiven = true;
					}
					if (Rival.CurrentDestination == Location[2] && Senpai.CurrentDestination == Location[1] && Senpai.DistanceToDestination < 0.5f && Rival.DistanceToDestination < 0.5f && !Impatient)
					{
						Phase++;
					}
				}
			}
			Frame++;
		}
		else if (Phase == 1)
		{
			Sabotaged = AudioSoftware.AudioDoctored;
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
				TakeOutTime = 2.5f;
				TransferTime = 7f;
				ReturnTime = 19.33333f;
				PutAwayTime = 24.33333f;
				Suffix = "A";
			}
			else
			{
				AudioClipPlayer.Play(SabotagedSpeechClip, Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				TakeOutTime = 2.5f;
				TransferTime = 7f;
				ReturnTime = 16.66666f;
				PutAwayTime = 21.5f;
				Suffix = "B";
			}
			Rival.CharacterAnimation.CrossFade("f02_" + Weekday + "_3" + Suffix);
			Senpai.CharacterAnimation.CrossFade(Weekday + "_3" + Suffix);
			Timer = 0f;
			Phase++;
			if (Friend != null)
			{
				Friend.CurrentDestination = Location[3];
				Friend.Pathfinding.target = Location[3];
				Friend.IdleAnim = "f02_cornerPeek_00";
				Friend.SlideIn = true;
			}
		}
		else
		{
			if (!LookAtSenpai)
			{
				Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
				Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			}
			if (Friend != null && Friend.DistanceToDestination < 0.5f)
			{
				Friend.MoveTowardsTarget(Friend.CurrentDestination.position);
				Friend.transform.rotation = Quaternion.Slerp(Friend.transform.rotation, Friend.CurrentDestination.rotation, 10f * Time.deltaTime);
				Friend.CharacterAnimation.CrossFade(Friend.IdleAnim);
				Friend.Routine = false;
			}
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
					ScheduleBlock obj = Senpai.ScheduleBlocks[4];
					obj.destination = "Hangout";
					obj.action = "Eat";
					Senpai.GetDestinations();
					if (Senpai.InEvent)
					{
						Rival.StopRotating = true;
						LookAtSenpai = true;
						EndSenpai();
					}
				}
				if (LookAtSenpai)
				{
					Rival.targetRotation = Quaternion.LookRotation(Senpai.transform.position - Rival.transform.position);
					Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.targetRotation, 10f * Time.deltaTime);
				}
			}
			if (Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time >= Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].length)
			{
				EndEvent();
			}
			if (TakeOut && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > TakeOutTime)
			{
				Rival.SmartPhone.SetActive(value: true);
				TakeOut = false;
				PutAway = true;
			}
			if (PutAway && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > PutAwayTime)
			{
				Rival.SmartPhone.SetActive(value: false);
				PutAway = false;
			}
			if (Transfer && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > TransferTime)
			{
				OriginalRotation = Rival.SmartPhone.transform.localEulerAngles;
				OriginalPosition = Rival.SmartPhone.transform.localPosition;
				Rival.SmartPhone.transform.parent = Senpai.SmartPhone.transform.parent;
				Rival.SmartPhone.transform.localEulerAngles = Senpai.SmartPhone.transform.localEulerAngles;
				Rival.SmartPhone.transform.localPosition = Senpai.SmartPhone.transform.localPosition;
				Transfer = false;
				Return = true;
			}
			if (Return && Rival.CharacterAnimation["f02_" + Weekday + "_3" + Suffix].time > ReturnTime)
			{
				Rival.SmartPhone.transform.parent = Rival.ItemParent;
				Rival.SmartPhone.transform.localEulerAngles = OriginalRotation;
				Rival.SmartPhone.transform.localPosition = OriginalPosition;
				Return = false;
			}
			if (Senpai.Alarmed || Rival.Alarmed || Rival.Splashed || Rival.Dodging || Clock.Period == 4 || Rival.GoAway)
			{
				if (!Rival.Splashed)
				{
					UnityEngine.Object.Instantiate(AlarmDisc, Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				}
				EndEvent();
			}
		}
		if (!base.enabled || (Phase <= 0 && !Impatient))
		{
			return;
		}
		Distance = Vector3.Distance(Yandere.transform.position, Epicenter.position);
		if (Yandere.transform.position.y > Rival.transform.position.y - 0.1f && Yandere.transform.position.y < Rival.transform.position.y + 0.1f && Distance - 4f < 15f)
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
			Yandere.Eavesdropping = Distance < 2.5f;
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

	public void EndEvent()
	{
		Debug.Log("Osana's Friday lunchtime event has ended.");
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
			Rival.SmartPhone.SetActive(value: false);
			Rival.Prompt.enabled = true;
			Rival.InEvent = false;
			Rival.Private = false;
			Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
			Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
			Rival.DistanceToDestination = 100f;
			Rival.Pathfinding.speed = 1f;
			Rival.StopRotating = false;
			Rival.Hurry = false;
		}
		if (Friend != null)
		{
			ScheduleBlock obj = Friend.ScheduleBlocks[4];
			obj.destination = "LunchSpot";
			obj.action = "Eat";
			Friend.GetDestinations();
			Friend.CurrentDestination = Friend.Destinations[Friend.Phase];
			Friend.Pathfinding.target = Friend.Destinations[Friend.Phase];
			Friend.DistanceToDestination = 100f;
			Friend.IdleAnim = Friend.OriginalIdleAnim;
			Friend.SlideIn = false;
			Friend.Routine = true;
			Debug.Log("''Friend'' is being told to set her destination to her current phase's destination.");
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
		}
		if (Rival.SmartPhone.transform.parent != Rival.ItemParent)
		{
			Rival.SmartPhone.transform.parent = Rival.ItemParent;
			Rival.SmartPhone.transform.localEulerAngles = OriginalRotation;
			Rival.SmartPhone.transform.localPosition = OriginalPosition;
		}
		Jukebox.Dip = 1f;
		Yandere.Eavesdropping = false;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Maybe some other time, Senpai...";
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
		Senpai.SmartPhone.SetActive(value: false);
		Senpai.InEvent = false;
		Senpai.Private = false;
		Senpai.CurrentDestination = Senpai.Destinations[Senpai.Phase];
		Senpai.Pathfinding.target = Senpai.Destinations[Senpai.Phase];
		Senpai.DistanceToDestination = 100f;
		if (Sabotaged)
		{
			StudentManager.SabotageProgress++;
			Debug.Log("Sabotage Progress: " + StudentManager.SabotageProgress + "/5");
		}
	}
}
