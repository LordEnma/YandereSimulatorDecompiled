using System;
using UnityEngine;

public class OsanaThursdayAfterClassEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public PhoneMinigameScript PhoneMinigame;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Friend;

	public StudentScript Rival;

	public Transform FriendLocation;

	public Transform Location;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public string[] EventAnim;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public float FriendWarningTimer;

	public float ReturnTimer;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int FriendID = 10;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public bool ReturningFromSave;

	public bool FriendWarned;

	public bool Sabotaged;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != EventDay || GameGlobals.RivalEliminationID > 0)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0 && StudentManager.Students[RivalID] != null)
			{
				if (Rival == null)
				{
					Rival = StudentManager.Students[RivalID];
				}
				if (StudentManager.Students[FriendID] != null && !PlayerGlobals.RaibaruLoner)
				{
					Friend = StudentManager.Students[FriendID];
				}
				if (Clock.HourTime > 16.01f && Rival.enabled && !Rival.InEvent && !Rival.Phoneless && !Rival.EndSearch && !Rival.Meeting)
				{
					BeginEvent();
				}
			}
			Frame++;
		}
		else
		{
			if (Phase == 1)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					Yandere.transform.position = Location.position + new Vector3(2f, 0f, 2f);
					Rival.transform.position = Location.position + new Vector3(1f, 0f, 1f);
				}
				if (Rival.DistanceToDestination < 0.5f)
				{
					AudioClipPlayer.Play(SpeechClip[1], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Rival.CharacterAnimation.CrossFade(EventAnim[1]);
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
					Rival.Obstacle.enabled = true;
					Phase++;
					if (Friend != null)
					{
						ScheduleBlock obj = Friend.ScheduleBlocks[7];
						obj.destination = "Sketch";
						obj.action = "Sketch";
						Friend.GetDestinations();
						Friend.SketchPosition = FriendLocation;
						Friend.CurrentDestination = Friend.SketchPosition;
						Friend.Pathfinding.target = Friend.SketchPosition;
						Friend.Restless = true;
					}
				}
			}
			else if (Phase == 2)
			{
				Rival.transform.position = Vector3.Lerp(Rival.transform.position, Rival.CurrentDestination.position, 10f * Time.deltaTime);
				Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
				if ((double)Rival.CharacterAnimation[EventAnim[1]].time >= 3.2)
				{
					EventSubtitle.text = SpeechText[1];
					Timer = 0f;
					Phase++;
				}
			}
			else if (Phase == 3)
			{
				if (Rival.CharacterAnimation[EventAnim[1]].time >= 6f)
				{
					Rival.SmartPhoneScreen.enabled = true;
					Rival.SmartPhone.SetActive(true);
					Phase++;
				}
			}
			else if (Phase == 4)
			{
				if ((double)Rival.CharacterAnimation[EventAnim[1]].time >= 13.33333)
				{
					OriginalPosition = Rival.SmartPhone.transform.localPosition;
					OriginalRotation = Rival.SmartPhone.transform.localEulerAngles;
					Rival.SmartPhone.transform.parent = null;
					Rival.SmartPhone.transform.position = new Vector3(0.5f, 12.5042f, -29.365f);
					Rival.SmartPhone.transform.eulerAngles = new Vector3(0f, 180f, 180f);
					Phase++;
				}
			}
			else if (Phase == 5)
			{
				if (Rival.CharacterAnimation[EventAnim[1]].time >= Rival.CharacterAnimation[EventAnim[1]].length)
				{
					Rival.CharacterAnimation.Play(EventAnim[2]);
					PhoneMinigame.Prompt.enabled = true;
					Rival.Ragdoll.Zs.SetActive(true);
					EventSubtitle.text = "";
					Rival.Distracted = true;
					Phase++;
					StudentManager.UpdateMe(RivalID);
				}
			}
			else if (Phase == 6)
			{
				if (!Sabotaged && !PhoneMinigame.Tampering)
				{
					if (Friend != null && !FriendWarned)
					{
						if (FriendWarningTimer == 0f)
						{
							if (Vector3.Distance(Yandere.transform.position, Friend.transform.position) < 5f)
							{
								AudioClipPlayer.Play(SpeechClip[3], Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
								EventSubtitle.text = SpeechText[3];
								FriendWarningTimer += Time.deltaTime;
							}
						}
						else
						{
							FriendWarningTimer += Time.deltaTime;
							if (FriendWarningTimer > 5f)
							{
								FriendWarned = true;
							}
						}
					}
					if ((double)Clock.HourTime > 17.2)
					{
						AudioClipPlayer.Play(SpeechClip[2], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
						Rival.CharacterAnimation.CrossFade(EventAnim[3]);
						Rival.Ragdoll.Zs.SetActive(false);
						Rival.Hurry = true;
						Phase++;
						PhoneMinigame.Prompt.enabled = false;
						PhoneMinigame.Prompt.Hide();
					}
				}
			}
			else if (Phase == 7)
			{
				if ((double)Rival.CharacterAnimation[EventAnim[3]].time >= 2.5)
				{
					Rival.SmartPhone.transform.parent = Rival.ItemParent;
					Rival.SmartPhone.transform.localPosition = OriginalPosition;
					Rival.SmartPhone.transform.localEulerAngles = OriginalRotation;
					Phase++;
				}
			}
			else if (Phase == 8)
			{
				if ((double)Rival.CharacterAnimation[EventAnim[3]].time >= 3.5)
				{
					Rival.SmartPhone.SetActive(false);
					Phase++;
				}
			}
			else if (Phase == 9)
			{
				if ((double)Rival.CharacterAnimation[EventAnim[3]].time >= 4.65)
				{
					EventSubtitle.text = SpeechText[2];
					Phase++;
				}
			}
			else if (Phase == 10 && Rival.CharacterAnimation[EventAnim[3]].time >= Rival.CharacterAnimation[EventAnim[3]].length)
			{
				EndEvent();
			}
			if (Rival.Alarmed || Rival.Splashed || Rival.Dodging || Rival.DiscCheck || Rival.Dying || Rival.GoAway)
			{
				EndEvent();
			}
			if (!Sabotaged)
			{
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
		}
		if (ReturningFromSave)
		{
			ReturnTimer += Time.deltaTime;
			if (ReturnTimer > 1f)
			{
				ReturnFromSave();
			}
		}
	}

	public void EndEvent()
	{
		Debug.Log("Osana's Thursday after class event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Rival.Alarmed && !Rival.Attacked && !Rival.Hunted)
		{
			Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
			Rival.DistanceToDestination = 100f;
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			Rival.Routine = true;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.SmartPhoneScreen.enabled = false;
		Rival.Ragdoll.Zs.SetActive(false);
		Rival.Obstacle.enabled = false;
		Rival.Prompt.enabled = true;
		Rival.Distracted = false;
		Rival.InEvent = false;
		Rival.Private = false;
		Rival.SmartPhone.transform.parent = Rival.ItemParent;
		Rival.SmartPhone.transform.localPosition = OriginalPosition;
		Rival.SmartPhone.transform.localEulerAngles = OriginalRotation;
		if (Friend != null)
		{
			ScheduleBlock obj = Friend.ScheduleBlocks[7];
			obj.destination = "Follow";
			obj.action = "Follow";
			Friend.GetDestinations();
			if (!Friend.ReturningMisplacedWeapon)
			{
				Friend.CurrentDestination = Friend.FollowTarget.transform;
				Friend.Pathfinding.target = Friend.FollowTarget.transform;
				Friend.EmptyHands();
			}
			Friend.Restless = false;
		}
		PhoneMinigame.Prompt.enabled = false;
		PhoneMinigame.Prompt.Hide();
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Jukebox.Dip = 1f;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Guess I'm not taking a nap after all...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}

	public void ReturnFromSave()
	{
		ReturningFromSave = false;
		BeginEvent();
	}

	public void BeginEvent()
	{
		Debug.Log("Osana's Thursday after class event has begun.");
		Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		Rival.CharacterAnimation.Play(Rival.WalkAnim);
		Rival.Pathfinding.target = Location;
		Rival.CurrentDestination = Location;
		Rival.Pathfinding.canSearch = true;
		Rival.Pathfinding.canMove = true;
		Rival.Routine = false;
		Rival.InEvent = true;
		Rival.Drownable = false;
		Rival.StudentManager.UpdateMe(Rival.StudentID);
		Rival.Scrubber.SetActive(false);
		Rival.Eraser.SetActive(false);
		Yandere.PauseScreen.Hint.Show = true;
		Yandere.PauseScreen.Hint.QuickID = 19;
		Phase = 1;
	}
}
