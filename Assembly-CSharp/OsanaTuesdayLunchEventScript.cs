using System;
using UnityEngine;

public class OsanaTuesdayLunchEventScript : MonoBehaviour
{
	public RivalAfterClassEventManagerScript AfterClassEvent;

	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public PromptScript PushPrompt;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform[] Location;

	public AudioSource VoiceClipSource;

	public AudioSource MyAudio;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public string[] EventAnim;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public bool DoneStretching;

	public bool Sabotaging;

	public bool Sabotaged;

	public float StinkTimer;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int StretchPhase;

	public int FriendID = 10;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		PushPrompt.gameObject.SetActive(false);
		if (DateGlobals.Weekday != EventDay || GameGlobals.RivalEliminationID > 0 || GameGlobals.Eighties)
		{
			base.enabled = false;
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
			if (Frame > 0 && StudentManager.Students[RivalID] != null && StudentManager.Students[RivalID].enabled)
			{
				if (StudentManager.Students[RivalID].Bullied)
				{
					base.enabled = false;
				}
				else if (Clock.Period == 3)
				{
					Debug.Log("Osana's Tuesday lunchtime event has begun.");
					Rival = StudentManager.Students[RivalID];
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.Play(Rival.WalkAnim);
					Rival.Pathfinding.target = Location[1];
					Rival.CurrentDestination = Location[1];
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.Routine = false;
					Rival.InEvent = true;
					Rival.EmptyHands();
					bool flag = true;
					if (PlayerGlobals.RaibaruLoner || StudentManager.Police.EndOfDay.RaibaruLoner)
					{
						flag = false;
					}
					if (StudentManager.Students[FriendID] != null && flag)
					{
						Friend = StudentManager.Students[FriendID];
						StudentManager.Patrols.List[10].GetChild(0).localEulerAngles = new Vector3(0f, 180f, 0f);
						StudentManager.Patrols.List[10].GetChild(1).localEulerAngles = new Vector3(0f, -135f, 0f);
						StudentManager.Patrols.List[10].GetChild(2).localEulerAngles = new Vector3(0f, 180f, 0f);
						StudentManager.Patrols.List[10].GetChild(3).localEulerAngles = new Vector3(0f, 135f, 0f);
						ScheduleBlock obj = Friend.ScheduleBlocks[4];
						obj.destination = "Patrol";
						obj.action = "Patrol";
						Friend.GetDestinations();
						Friend.CanTalk = false;
					}
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
				if (Phase < 4)
				{
					Phase = 1;
				}
				else if (Phase > 6)
				{
					Phase = 7;
				}
				else
				{
					DoneStretching = true;
				}
			}
		}
		else
		{
			if (Rival.DistanceToDestination < 0.5f)
			{
				if (!Rival.GoAway)
				{
					Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
				}
				Rival.targetRotation = Rival.CurrentDestination.rotation;
				Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.targetRotation, 10f * Time.deltaTime);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
			}
			if (Phase == 1)
			{
				if (Rival.DistanceToDestination < 0.5f)
				{
					AudioClipPlayer.Play(SpeechClip[1], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[1]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[1]);
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
					Rival.Obstacle.enabled = true;
					Phase++;
				}
			}
			else if (Phase == 2)
			{
				if (Rival.CharacterAnimation["f02_" + EventAnim[1]].time >= 0.833333f)
				{
					Rival.AnimatedBook.SetActive(true);
				}
				if (Rival.CharacterAnimation["f02_" + EventAnim[1]].time >= 5f)
				{
					EventSubtitle.text = SpeechText[1];
				}
				if (Rival.CharacterAnimation["f02_" + EventAnim[1]].time >= Rival.CharacterAnimation["f02_" + EventAnim[1]].length)
				{
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[2]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[2]);
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				Timer += Time.deltaTime;
				if (Timer > 60f)
				{
					AudioClipPlayer.Play(SpeechClip[2], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[3]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[3]);
					EventSubtitle.text = SpeechText[2];
					StretchPhase = 2;
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				if (Rival.CharacterAnimation["f02_" + EventAnim[3]].time >= Rival.CharacterAnimation["f02_" + EventAnim[3]].length)
				{
					Rival.AnimatedBook.transform.parent = null;
					PushPrompt.gameObject.SetActive(true);
					PushPrompt.enabled = true;
					Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
					Rival.Pathfinding.target = Location[StretchPhase];
					Rival.CurrentDestination = Location[StretchPhase];
					Rival.DistanceToDestination = 100f;
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.StinkBombSpecialCase = 1;
					Phase++;
				}
			}
			else if (Phase == 5)
			{
				if (Rival.DistanceToDestination < 0.5f || DoneStretching)
				{
					if (StretchPhase == 2)
					{
						AudioClipPlayer.Play(SpeechClip[3], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
						EventSubtitle.text = SpeechText[3];
					}
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[4]);
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
					DoneStretching = false;
					Phase++;
				}
			}
			else if (Phase == 6)
			{
				if (Rival.CharacterAnimation["f02_" + EventAnim[4]].time >= Rival.CharacterAnimation["f02_" + EventAnim[4]].length || DoneStretching)
				{
					Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
					StretchPhase++;
					DoneStretching = false;
					if (StretchPhase < 6)
					{
						Rival.Pathfinding.target = Location[StretchPhase];
						Rival.CurrentDestination = Location[StretchPhase];
						Rival.DistanceToDestination = 100f;
						Rival.Pathfinding.canSearch = true;
						Rival.Pathfinding.canMove = true;
						Phase--;
					}
					else
					{
						PushPrompt.gameObject.SetActive(false);
						Rival.StinkBombSpecialCase = 0;
						if (!Sabotaged)
						{
							Rival.Pathfinding.target = Location[1];
							Rival.CurrentDestination = Location[1];
							Rival.DistanceToDestination = 100f;
							Rival.Pathfinding.canSearch = true;
							Rival.Pathfinding.canMove = true;
						}
						else
						{
							Rival.Pathfinding.target = Location[7];
							Rival.CurrentDestination = Location[7];
							Rival.DistanceToDestination = 100f;
							Rival.Pathfinding.canSearch = true;
							Rival.Pathfinding.canMove = true;
							if (Friend != null)
							{
								ScheduleBlock obj2 = Friend.ScheduleBlocks[4];
								obj2.destination = "Follow";
								obj2.action = "Follow";
								ScheduleBlock obj3 = Friend.ScheduleBlocks[6];
								obj3.destination = "Follow";
								obj3.action = "Follow";
								Friend.GetDestinations();
							}
						}
						Phase++;
					}
				}
			}
			else if (Phase == 7)
			{
				if (!Sabotaged)
				{
					if (Rival.DistanceToDestination < 0.5f)
					{
						AudioClipPlayer.Play(SpeechClip[4], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
						Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[5]);
						Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[5]);
						EventSubtitle.text = SpeechText[4];
						Phase++;
					}
				}
				else if (Rival.DistanceToDestination < 0.5f)
				{
					Rival.EventSpecialCase = true;
					Rival.WalkAnim = "f02_sadWalk_00";
					Rival.SitAnim = "f02_sadDeskSit_00";
					AudioClipPlayer.Play(SpeechClip[6], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[8]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[8]);
					EventSubtitle.text = SpeechText[6];
					Rival.Depressed = true;
					Phase = 11;
				}
			}
			else if (Phase == 8)
			{
				if (Rival.CharacterAnimation["f02_" + EventAnim[5]].time >= Rival.CharacterAnimation["f02_" + EventAnim[5]].length)
				{
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[2]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[2]);
					Phase++;
				}
			}
			else if (Phase == 9)
			{
				if (Clock.HourTime > 13.375f)
				{
					AudioClipPlayer.Play(SpeechClip[5], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Rival.CharacterAnimation.CrossFade("f02_" + EventAnim[6]);
					Rival.AnimatedBook.GetComponent<Animation>().CrossFade(EventAnim[6]);
					EventSubtitle.text = SpeechText[5];
					Phase++;
				}
			}
			else if (Phase == 10)
			{
				if (Rival.AnimatedBook.activeInHierarchy && Rival.CharacterAnimation["f02_" + EventAnim[6]].time > 2f)
				{
					Rival.AnimatedBook.SetActive(false);
				}
				if (Rival.CharacterAnimation["f02_" + EventAnim[6]].time >= Rival.CharacterAnimation["f02_" + EventAnim[6]].length)
				{
					EndEvent();
				}
			}
			else if (Phase == 11)
			{
				if (Rival.AnimatedBook.activeInHierarchy && Rival.CharacterAnimation["f02_" + EventAnim[8]].time > 7f)
				{
					Rival.AnimatedBook.SetActive(false);
				}
				if (Rival.CharacterAnimation["f02_" + EventAnim[8]].time >= Rival.CharacterAnimation["f02_" + EventAnim[8]].length)
				{
					Rival.Destinations[4] = Location[8];
					if (Friend != null)
					{
						Friend.Destinations[4] = Location[9];
						StudentManager.LunchSpots.List[FriendID] = Location[9];
					}
					EndEvent();
				}
			}
		}
		if (PushPrompt.Circle[0].fillAmount == 0f)
		{
			PushPrompt.Circle[0].fillAmount = 1f;
			PushPrompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!PushPrompt.Yandere.StudentManager.YandereVisible)
			{
				PushPrompt.Hide();
				PushPrompt.gameObject.SetActive(false);
				Sabotaging = true;
				Yandere.CanMove = false;
				Yandere.CharacterAnimation.CrossFade("f02_" + EventAnim[7]);
				Rival.AnimatedBook.GetComponent<Animation>().Play(EventAnim[7]);
				Rival.AnimatedBook.transform.eulerAngles = new Vector3(Rival.AnimatedBook.transform.eulerAngles.x, 0f, Rival.AnimatedBook.transform.eulerAngles.z);
				Rival.AnimatedBook.transform.position = new Vector3(Rival.AnimatedBook.transform.position.x, Rival.AnimatedBook.transform.position.y, -2.8f);
				AfterClassEvent.Sabotaged = true;
			}
			else
			{
				PushPrompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				PushPrompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (Sabotaging)
		{
			Yandere.MoveTowardsTarget(Location[6].position);
			Yandere.transform.rotation = Quaternion.Slerp(Yandere.transform.rotation, Location[6].rotation, Time.deltaTime * 10f);
			if (Yandere.CharacterAnimation["f02_" + EventAnim[7]].time > 1.5f && Yandere.CharacterAnimation["f02_" + EventAnim[7]].time < 2f && !MyAudio.isPlaying)
			{
				MyAudio.Play();
			}
			if (Yandere.CharacterAnimation["f02_" + EventAnim[7]].time > Yandere.CharacterAnimation["f02_" + EventAnim[7]].length)
			{
				Yandere.CanMove = true;
				Sabotaging = false;
				Sabotaged = true;
			}
		}
		if (Clock.Period > 3 || Rival.Wet || Rival.Alarmed || Rival.Attacked || !Rival.Alive || Rival.GoAway)
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
			if (VoiceClipSource != null)
			{
				VoiceClipSource.volume = Scale;
			}
		}
		else
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			if (VoiceClipSource != null)
			{
				VoiceClipSource.volume = 0f;
			}
		}
		if (VoiceClip == null)
		{
			EventSubtitle.text = string.Empty;
		}
	}

	private void EndEvent()
	{
		Debug.Log("Osana's Tuesday lunchtime event ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Rival.Splashed && !Rival.Dodging)
		{
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
		}
		else
		{
			Debug.Log("Osana was told to stop moving.");
			Rival.Pathfinding.canSearch = false;
			Rival.Pathfinding.canMove = false;
		}
		if (!Rival.Alarmed)
		{
			Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
			Rival.DistanceToDestination = 100f;
		}
		Rival.Routine = !Rival.Splashed;
		if (Friend != null)
		{
			if (!Friend.ReturningMisplacedWeapon)
			{
				Friend.ResumeFollowing();
				Debug.Log("Raibaru was told to resume ''Follow'' protocol.");
			}
			else
			{
				Friend.ResumeFollowingAfter = true;
			}
		}
		if (Rival.AnimatedBook.transform.parent != null)
		{
			Rival.AnimatedBook.SetActive(false);
		}
		PushPrompt.enabled = false;
		PushPrompt.Hide();
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.StinkBombSpecialCase = 0;
		Rival.EventSpecialCase = false;
		Rival.Obstacle.enabled = false;
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Jukebox.Dip = 1f;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Whatever, I'll read it later...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}
}
