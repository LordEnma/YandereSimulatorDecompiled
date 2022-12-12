using System;
using UnityEngine;

public class OsanaClubEventScript : MonoBehaviour
{
	public EventManagerScript RooftopConversation;

	public StudentManagerScript StudentManager;

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

	public int[] ClubIDs;

	public GameObject VoiceClip;

	public AudioSource VoiceClipSource;

	public bool ReachedTheEnd;

	public bool EventOn;

	public bool Spoken;

	public int EventPhase;

	public float Timer;

	public float Scale;

	public int[] StudentID;

	public DayOfWeek EventDay;

	private void Start()
	{
		if (DateGlobals.Weekday != EventDay || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || GameGlobals.Eighties)
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
		if (!EventOn)
		{
			for (int i = 1; i < 3; i++)
			{
				if (EventStudent[i] == null)
				{
					EventStudent[i] = StudentManager.Students[StudentID[i]];
				}
				else if (!EventStudent[i].Alive || EventStudent[i].Slave)
				{
					base.enabled = false;
				}
			}
			if (EventStudent[1] != null && EventStudent[2] != null && EventStudent[1].enabled && EventStudent[1].Pathfinding.canMove && EventStudent[2].Pathfinding.canMove && EventStudent[1].Routine && !EventStudent[1].Wet)
			{
				Debug.Log("Osana's club event has begun.");
				EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].WalkAnim);
				EventStudent[1].CurrentDestination = EventLocation[1];
				EventStudent[1].Pathfinding.target = EventLocation[1];
				EventStudent[1].TargetDistance = 0.5f;
				EventStudent[1].Private = false;
				EventStudent[1].InEvent = true;
				EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].WalkAnim);
				EventStudent[2].CurrentDestination = EventLocation[2];
				EventStudent[2].Pathfinding.target = EventLocation[2];
				EventStudent[2].TargetDistance = 1f;
				EventStudent[2].Private = false;
				EventStudent[2].InEvent = true;
				Yandere.PauseScreen.Hint.Show = true;
				Yandere.PauseScreen.Hint.QuickID = 16;
				EventOn = true;
			}
			return;
		}
		Vector3 b = (EventStudent[1].transform.position - EventStudent[2].transform.position) * 0.5f + EventStudent[2].transform.position;
		float num = Vector3.Distance(Yandere.transform.position, b);
		if (EventPhase > 1 && EventPhase < 7)
		{
			Yandere.Eavesdropping = num < 3f;
		}
		else
		{
			Yandere.Eavesdropping = false;
		}
		if (Clock.HourTime > 13.5f || EventStudent[1].WitnessedCorpse || EventStudent[2].WitnessedCorpse || EventStudent[1].Alarmed || EventStudent[2].Alarmed || EventStudent[1].Dying || EventStudent[2].Dying || EventStudent[1].Splashed || EventStudent[1].Dodging || EventStudent[1].GoAway || Clock.Police.EndOfDay.gameObject.activeInHierarchy)
		{
			EndEvent();
			return;
		}
		for (int j = 1; j < 3; j++)
		{
			if (!EventStudent[j].Pathfinding.canMove && !EventStudent[j].Private)
			{
				EventStudent[j].CharacterAnimation.CrossFade(EventStudent[j].IdleAnim);
				EventStudent[j].Private = true;
				StudentManager.UpdateStudents();
			}
		}
		if (!EventStudent[1].Pathfinding.canMove && !EventStudent[2].Pathfinding.canMove)
		{
			if (!Spoken)
			{
				EventStudent[EventSpeaker[1]].CharacterAnimation.CrossFade(EventStudent[1].IdleAnim);
				EventStudent[EventSpeaker[2]].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
				EventStudent[EventSpeaker[EventPhase]].PickRandomAnim();
				EventStudent[EventSpeaker[EventPhase]].CharacterAnimation.CrossFade(EventStudent[EventSpeaker[EventPhase]].RandomAnim);
				AudioClipPlayer.Play(EventClip[EventPhase], EventStudent[EventSpeaker[EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Spoken = true;
				if (EventSpeaker[EventPhase] == 1 && EventPhase > 7 && EventPhase < 33 && EventPhase != 24 && num < 10f)
				{
					if (EventPhase == 30)
					{
						Debug.Log("Current EventPhase is: 30 and Osana is talking about the delinquents.");
						Yandere.NotificationManager.TopicName = "Violence";
						Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						StudentManager.SetTopicLearnedByStudent(ClubIDs[EventPhase], 11, true);
					}
					else
					{
						Debug.Log("Current EventPhase is: " + EventPhase + " and ClubID is: " + ClubIDs[EventPhase]);
						Yandere.NotificationManager.TopicName = Yandere.NotificationManager.ClubNames[ClubIDs[EventPhase]];
						Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						StudentManager.SetTopicLearnedByStudent(ClubIDs[EventPhase], 11, true);
					}
				}
				return;
			}
			int num2 = EventSpeaker[EventPhase];
			if (num2 == 1)
			{
				EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
			}
			else
			{
				EventStudent[1].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
			}
			if (EventStudent[num2].CharacterAnimation[EventStudent[num2].RandomAnim].time >= EventStudent[num2].CharacterAnimation[EventStudent[num2].RandomAnim].length)
			{
				EventStudent[num2].PickRandomAnim();
				EventStudent[num2].CharacterAnimation.CrossFade(EventStudent[num2].RandomAnim);
			}
			Timer += Time.deltaTime;
			if (Yandere.transform.position.y > EventStudent[1].transform.position.y - 1f && Yandere.transform.position.y < EventStudent[1].transform.position.y + 1f)
			{
				if (VoiceClipSource != null)
				{
					VoiceClipSource.volume = 1f;
				}
				if (num < 11f)
				{
					if (num < 10f)
					{
						if (Timer > EventClip[EventPhase].length)
						{
							EventSubtitle.text = string.Empty;
						}
						else
						{
							EventSubtitle.text = EventSpeech[EventPhase];
						}
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
						EventSubtitle.text = string.Empty;
					}
				}
			}
			else if (VoiceClipSource != null)
			{
				VoiceClipSource.volume = 0f;
			}
			if (Timer > EventClip[EventPhase].length + 0.5f)
			{
				Spoken = false;
				EventPhase++;
				Timer = 0f;
				if (EventPhase == 4)
				{
					RooftopConversation.CanHappen = true;
				}
				if (EventPhase == EventSpeech.Length)
				{
					EndEvent();
				}
				else if (EventPhase > 6)
				{
					EventStudent[1].CurrentDestination = EventLocation[EventPhase];
					EventStudent[1].Pathfinding.target = EventLocation[EventPhase];
					EventStudent[2].CurrentDestination = EventStudent[1].FollowTargetDestination;
					EventStudent[2].Pathfinding.target = EventStudent[1].FollowTargetDestination;
				}
			}
			return;
		}
		if (!EventStudent[1].Pathfinding.canMove)
		{
			EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].IdleAnim);
		}
		else
		{
			EventStudent[1].CharacterAnimation.CrossFade(EventStudent[1].WalkAnim);
		}
		if (!EventStudent[2].Pathfinding.canMove)
		{
			EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].IdleAnim);
			if (EventPhase == 1)
			{
				SettleFriend();
			}
		}
		else if (EventStudent[2].Pathfinding.speed == 1f)
		{
			EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].WalkAnim);
		}
		else
		{
			EventStudent[2].CharacterAnimation.CrossFade(EventStudent[2].RunAnim);
		}
	}

	private void SettleFriend()
	{
		EventStudent[2].MoveTowardsTarget(EventStudent[2].Pathfinding.target.position);
	}

	public void EndEvent()
	{
		Debug.Log("Ending Osana's club event.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		for (int i = 1; i < 3; i++)
		{
			if (EventStudent[i] != null)
			{
				EventStudent[i].CurrentDestination = EventStudent[i].Destinations[EventStudent[i].Phase];
				EventStudent[i].Pathfinding.target = EventStudent[i].Destinations[EventStudent[i].Phase];
				EventStudent[i].InEvent = false;
				EventStudent[i].Private = false;
			}
		}
		CheckForRooftopConvo();
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Yandere.Eavesdropping = false;
		Jukebox.Dip = 1f;
		EventSubtitle.text = string.Empty;
		ReachedTheEnd = true;
		if (EventStudent[1].GoAway)
		{
			EventStudent[1].Subtitle.CustomText = "Ugh, seriously?! Guess we'll just talk about it later...";
			EventStudent[1].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
		base.enabled = false;
	}

	public void CheckForRooftopConvo()
	{
		if (StudentManager.Students[10] != null && StudentManager.Students[11] != null && StudentManager.Students[11].Alive && StudentManager.Students[10].CurrentAction == StudentActionType.Follow)
		{
			RooftopConversation.CanHappen = true;
		}
	}
}
