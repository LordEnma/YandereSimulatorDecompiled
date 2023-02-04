using System;
using UnityEngine;

public class PhoneEventScript : MonoBehaviour
{
	public OsanaClubEventScript OsanaClubEvent;

	public StudentManagerScript StudentManager;

	public OsanaClubEventScript ClubEvent;

	public BucketPourScript DumpPoint;

	public YandereScript Yandere;

	public JukeboxScript Jukebox;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public StudentScript EventFriend;

	public UILabel EventSubtitle;

	public Transform EventLocation;

	public Transform SpyLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public float[] SpeechTimes;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EndedPrematurely;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public bool HintGiven;

	public int EventStudentID = 7;

	public int EventFriendID = 34;

	public float EventTime = 7.5f;

	public int EventPhase = 1;

	public DayOfWeek EventDay = DayOfWeek.Monday;

	public float CurrentClipLength;

	public float FailSafe;

	public float Timer;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == EventDay)
		{
			EventCheck = true;
		}
		if (HomeGlobals.LateForSchool || StudentManager.YandereLate || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode)
		{
			base.enabled = false;
		}
	}

	private void OnAwake()
	{
	}

	private void Update()
	{
		if (!Clock.StopTime && EventCheck)
		{
			if (Clock.HourTime > EventTime + 0.5f)
			{
				base.enabled = false;
			}
			else if (Clock.HourTime > EventTime)
			{
				if (EventStudent == null)
				{
					EventStudent = StudentManager.Students[EventStudentID];
				}
				if (EventStudent != null && !EventStudent.InEvent && !EventStudent.Meeting && EventStudent.Alive && EventStudent.DistanceToDestination < 1f && !EventStudent.Phoneless && !EventStudent.EndSearch && EventStudent.Routine)
				{
					Timer += Time.deltaTime;
					if (Timer > 1f)
					{
						if (OsanaClubEvent != null && EventStudent.Alive)
						{
							Debug.Log("Osana's Monday morning phone event has begun.");
						}
						EventStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						if (EventStudentID == 11)
						{
							EventFriend = StudentManager.Students[EventFriendID];
							if (EventFriend != null && EventFriend.CurrentAction == StudentActionType.Follow && !EventFriend.InvestigatingBloodPool && !EventFriend.ReturningMisplacedWeapon && !EventFriend.Electrified)
							{
								Debug.Log("Raibaru is available, so she's getting involved in the event.");
								EventFriend.CharacterAnimation.CrossFade(EventFriend.IdleAnim);
								EventFriend.Pathfinding.canSearch = false;
								EventFriend.Pathfinding.canMove = false;
								EventFriend.TargetDistance = 0.5f;
								EventFriend.SpeechLines.Stop();
								EventFriend.PhoneEvent = this;
								EventFriend.CanTalk = false;
								EventFriend.Routine = false;
								EventFriend.InEvent = true;
								EventFriend.Prompt.Hide();
							}
						}
						if (EventStudent.enabled && EventStudent.Routine && !EventStudent.Distracted && !EventStudent.Talking && !EventStudent.Meeting && !EventStudent.Investigating && EventStudent.Indoors)
						{
							if (!EventStudent.WitnessedMurder)
							{
								EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
								EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
								EventStudent.Obstacle.checkTime = 99f;
								EventStudent.SpeechLines.Stop();
								EventStudent.PhoneEvent = this;
								EventStudent.CanTalk = false;
								EventStudent.InEvent = true;
								EventStudent.Prompt.Hide();
								EventCheck = false;
								EventActive = true;
								Timer = 0f;
								Yandere.PauseScreen.Hint.Show = true;
								Yandere.PauseScreen.Hint.QuickID = 15;
								if (EventStudent.Following)
								{
									EventStudent.Pathfinding.canMove = true;
									EventStudent.Pathfinding.speed = 1f;
									EventStudent.Following = false;
									EventStudent.Routine = true;
									Yandere.Follower = null;
									Yandere.Followers--;
									EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
									EventStudent.Prompt.Label[0].text = "     Talk";
								}
							}
							else
							{
								base.enabled = false;
							}
						}
					}
				}
			}
		}
		if (!EventActive)
		{
			return;
		}
		if (EventStudent.DistanceToDestination < 0.5f)
		{
			EventStudent.Pathfinding.canSearch = false;
			EventStudent.Pathfinding.canMove = false;
		}
		if (Clock.HourTime > EventTime + 0.5f || EventStudent.WitnessedMurder || EventStudent.Splashed || EventStudent.Alarmed || EventStudent.Dodging || EventStudent.Dying || EventStudent.GoAway || !EventStudent.Alive)
		{
			EndedPrematurely = true;
			EndEvent();
			return;
		}
		if (!EventStudent.Pathfinding.canMove)
		{
			if (EventPhase == 1)
			{
				Timer += Time.deltaTime;
				EventStudent.CharacterAnimation.CrossFade(EventAnim[0]);
				AudioClipPlayer.Play(EventClip[0], EventStudent.transform.position, 5f, 10f, out VoiceClip, out CurrentClipLength);
				EventPhase++;
			}
			else if (EventPhase == 2)
			{
				Timer += Time.deltaTime;
				if (Timer > 1.5f)
				{
					EventStudent.SmartPhone.SetActive(value: true);
					EventStudent.SmartPhone.transform.localPosition = new Vector3(0.01f, -0.005f, -0.025f);
					EventStudent.SmartPhone.transform.localEulerAngles = new Vector3(0f, -150f, 165f);
				}
				if (Timer > 2f)
				{
					AudioClipPlayer.Play(EventClip[1], EventStudent.transform.position, 5f, 10f, out VoiceClip, out CurrentClipLength);
					EventSubtitle.text = EventSpeech[1];
					Timer = 0f;
					EventPhase++;
				}
			}
			else if (EventPhase == 3)
			{
				Timer += Time.deltaTime;
				if (Timer > CurrentClipLength)
				{
					EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.RunAnim);
					EventStudent.CurrentDestination = EventLocation;
					EventStudent.Pathfinding.target = EventLocation;
					EventStudent.Pathfinding.canSearch = true;
					EventStudent.Pathfinding.canMove = true;
					EventStudent.Pathfinding.speed = 4f;
					EventSubtitle.text = string.Empty;
					EventStudent.Hurry = true;
					Timer = 0f;
					EventPhase++;
				}
			}
			else if (EventPhase == 4)
			{
				if (EventStudentID != 11)
				{
					DumpPoint.enabled = true;
				}
				EventStudent.Private = true;
				EventStudent.Character.GetComponent<Animation>().CrossFade(EventAnim[2]);
				AudioClipPlayer.Play(EventClip[2], EventStudent.transform.position, 5f, 10f, out VoiceClip, out CurrentClipLength);
				EventPhase++;
			}
			else if (EventPhase < 13)
			{
				if (VoiceClip != null)
				{
					VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
					EventStudent.Character.GetComponent<Animation>()[EventAnim[2]].time = VoiceClip.GetComponent<AudioSource>().time;
					if (VoiceClip.GetComponent<AudioSource>().time > SpeechTimes[EventPhase - 3])
					{
						EventSubtitle.text = EventSpeech[EventPhase - 3];
						EventPhase++;
					}
				}
			}
			else
			{
				if (EventStudent.Character.GetComponent<Animation>()[EventAnim[2]].time >= EventStudent.Character.GetComponent<Animation>()[EventAnim[2]].length * 90.33333f)
				{
					EventStudent.SmartPhone.SetActive(value: true);
				}
				if (EventStudent.Character.GetComponent<Animation>()[EventAnim[2]].time >= EventStudent.Character.GetComponent<Animation>()[EventAnim[2]].length)
				{
					EndEvent();
				}
			}
			if (Yandere.transform.position.z < -38f || Yandere.transform.position.x > -18f)
			{
				if (EventSubtitle.transform.localScale.x > 0f)
				{
					EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
			else
			{
				float num = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					Jukebox.Dip = 1f - 0.5f * num2;
					EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					EventSubtitle.transform.localScale = Vector3.zero;
				}
				if (base.enabled && EventPhase > 4)
				{
					if (num < 5f)
					{
						Yandere.Eavesdropping = true;
					}
					else
					{
						Yandere.Eavesdropping = false;
					}
				}
				if (EventPhase == 11 && num < 5f)
				{
					if (EventStudentID == 30)
					{
						if (!EventGlobals.Event2)
						{
							EventGlobals.Event2 = true;
							Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
							ConversationGlobals.SetTopicDiscovered(25, value: true);
							Yandere.NotificationManager.TopicName = "Money";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
							Yandere.NotificationManager.TopicName = "Money";
							Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							StudentManager.SetTopicLearnedByStudent(25, EventStudentID, boolean: true);
						}
					}
					else if (!Yandere.Police.EndOfDay.LearnedOsanaInfo1)
					{
						Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
						Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
						if (SchemeGlobals.GetSchemeStage(6) == 1)
						{
							SchemeGlobals.SetSchemeStage(6, 2);
							Yandere.PauseScreen.Schemes.UpdateInstructions();
						}
					}
				}
			}
		}
		else
		{
			EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.RunAnim);
			EventStudent.Pathfinding.speed = 4f;
		}
		if ((!EventStudent.Pathfinding.canMove && EventPhase <= 3) || !(EventFriend != null) || EventFriend.CurrentAction != StudentActionType.Follow || !EventFriend.InEvent || EventPhase <= 3)
		{
			return;
		}
		if (EventFriend.CurrentDestination != SpyLocation)
		{
			Timer += Time.deltaTime;
			if (Timer > 3f)
			{
				EventFriend.CharacterAnimation.CrossFade(EventStudent.RunAnim);
				EventFriend.CurrentDestination = SpyLocation;
				EventFriend.Pathfinding.target = SpyLocation;
				EventFriend.Pathfinding.canSearch = true;
				EventFriend.Pathfinding.canMove = true;
				EventFriend.Pathfinding.speed = 4f;
				EventFriend.Routine = true;
				Timer = 0f;
			}
			else
			{
				EventFriend.targetRotation = Quaternion.LookRotation(StudentManager.Students[EventStudentID].transform.position - EventFriend.transform.position);
				EventFriend.transform.rotation = Quaternion.Slerp(EventFriend.transform.rotation, EventFriend.targetRotation, 10f * Time.deltaTime);
			}
		}
		else if (EventFriend.DistanceToDestination < 1f)
		{
			EventFriend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
			EventFriend.Pathfinding.canSearch = false;
			EventFriend.Pathfinding.canMove = false;
			SettleFriend();
		}
	}

	private void SettleFriend()
	{
		EventFriend.MoveTowardsTarget(SpyLocation.position);
		if (Quaternion.Angle(EventFriend.transform.rotation, SpyLocation.rotation) > 1f)
		{
			EventFriend.transform.rotation = Quaternion.Slerp(EventFriend.transform.rotation, SpyLocation.rotation, 10f * Time.deltaTime);
		}
	}

	private void EndEvent()
	{
		Debug.Log("A phone event ended.");
		if (!EventOver)
		{
			EventStudent.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			if (VoiceClip != null)
			{
				UnityEngine.Object.Destroy(VoiceClip);
			}
			if (EventFriend != null && EventFriend.Alive && !EventFriend.Electrified && !EventFriend.Electrocuted && EventFriend.CurrentAction == StudentActionType.Follow && EventFriend.InEvent)
			{
				Debug.Log("Raibaru is exiting the phone event.");
				EventFriend.CurrentDestination = EventFriend.Destinations[EventFriend.Phase];
				EventFriend.Pathfinding.target = EventFriend.Destinations[EventFriend.Phase];
				EventFriend.Obstacle.checkTime = 1f;
				EventFriend.Pathfinding.speed = 1f;
				EventFriend.TargetDistance = 1f;
				EventFriend.IgnoringThingsOnGround = true;
				EventFriend.InEvent = false;
				EventFriend.Private = false;
				EventFriend.Routine = true;
				EventFriend.CanTalk = true;
				if (!EndedPrematurely)
				{
					OsanaClubEvent.enabled = true;
				}
				if (EventFriend.Alarmed)
				{
					EventFriend.Pathfinding.canSearch = false;
					EventFriend.Pathfinding.canMove = false;
				}
			}
			EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Obstacle.checkTime = 1f;
			if (!EventStudent.Dying)
			{
				EventStudent.Prompt.enabled = true;
			}
			if (!EventStudent.WitnessedMurder)
			{
				EventStudent.SmartPhone.SetActive(value: false);
			}
			EventStudent.Pathfinding.speed = 1f;
			EventStudent.TargetDistance = 1f;
			EventStudent.PhoneEvent = null;
			EventStudent.InEvent = false;
			EventStudent.Private = false;
			EventStudent.CanTalk = true;
			EventSubtitle.text = string.Empty;
			StudentManager.UpdateStudents();
			if (EventStudent.GoAway)
			{
				ClubEvent.enabled = false;
			}
		}
		EventStudent.Hurry = false;
		Yandere.Eavesdropping = false;
		Jukebox.Dip = 1f;
		EventActive = false;
		EventCheck = false;
		base.enabled = false;
	}
}
