using System;
using UnityEngine;

public class ToiletEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public LightSwitchScript LightSwitch;

	public BucketPourScript BucketPour;

	public ParticleSystem Splashes;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public DoorScript StallDoor;

	public PromptScript Prompt;

	public ClockScript Clock;

	public Collider Toilet;

	public StudentScript EventStudent;

	public Transform[] EventLocation;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventCheck;

	public bool EventOver;

	public float EventTime = 7f;

	public int EventPhase = 1;

	public DayOfWeek EventDay = DayOfWeek.Thursday;

	public float ToiletCountdown;

	public float Distance;

	public float Timer;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == EventDay)
		{
			EventCheck = true;
		}
	}

	private void Update()
	{
		if (!Clock.StopTime && EventCheck && Clock.HourTime > EventTime)
		{
			EventStudent = StudentManager.Students[30];
			if (EventStudent != null && EventStudent.Routine && !EventStudent.Distracted && !EventStudent.Talking && !EventStudent.Alarmed && !EventStudent.Meeting)
			{
				if (!EventStudent.WitnessedMurder)
				{
					EventStudent.CharacterAnimation.CrossFade(EventStudent.WalkAnim);
					EventStudent.CurrentDestination = EventLocation[1];
					EventStudent.Pathfinding.target = EventLocation[1];
					EventStudent.Pathfinding.canSearch = true;
					EventStudent.Pathfinding.canMove = true;
					EventStudent.LightSwitch = LightSwitch;
					EventStudent.Obstacle.checkTime = 99f;
					EventStudent.SpeechLines.Stop();
					EventStudent.ToiletEvent = this;
					EventStudent.InEvent = true;
					EventStudent.Prompt.Hide();
					Prompt.enabled = true;
					EventCheck = false;
					EventActive = true;
					if (EventStudent.Following)
					{
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
		if (EventActive)
		{
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Yandere.EmptyHands();
				Prompt.Hide();
				Prompt.enabled = false;
				EventPhase = 5;
				Timer = 0f;
				AudioClipPlayer.Play(EventClip[1], EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip);
				EventSubtitle.text = EventSpeech[1];
				EventStudent.MyController.enabled = false;
				EventStudent.Distracted = true;
				EventStudent.Routine = false;
				EventStudent.Drowned = true;
				Yandere.TargetStudent = EventStudent;
				Yandere.Attacking = true;
				Yandere.CanMove = false;
				Yandere.Drown = true;
				Yandere.DrownAnim = "f02_toiletDrownA_00";
				EventStudent.DrownAnim = "f02_toiletDrownB_00";
				EventStudent.CharacterAnimation.CrossFade(EventStudent.DrownAnim);
			}
			if (Clock.HourTime > EventTime + 0.5f || EventStudent.WitnessedMurder || EventStudent.Splashed || EventStudent.Dying || EventStudent.Alarmed)
			{
				EndEvent();
			}
			else if (!EventStudent.Pathfinding.canMove)
			{
				if (EventPhase == 1)
				{
					if (Timer == 0f)
					{
						EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.IdleAnim);
						Prompt.HideButton[0] = false;
						EventStudent.Prompt.Hide();
						EventStudent.Prompt.enabled = false;
						StallDoor.Prompt.enabled = false;
						StallDoor.Prompt.Hide();
					}
					Timer += Time.deltaTime;
					if (Timer > 3f)
					{
						StallDoor.Locked = true;
						StallDoor.CloseDoor();
						Toilet.enabled = false;
						Prompt.Hide();
						Prompt.enabled = false;
						EventStudent.CurrentDestination = EventLocation[2];
						EventStudent.Pathfinding.target = EventLocation[2];
						EventStudent.TargetDistance = 2f;
						EventPhase++;
						Timer = 0f;
					}
				}
				else if (EventPhase == 2)
				{
					if (Timer == 0f)
					{
						EventStudent.Character.GetComponent<Animation>().CrossFade(EventAnim[1]);
						BucketPour.enabled = true;
					}
					Timer += Time.deltaTime;
					if (Timer > 10f)
					{
						AudioClipPlayer.Play(EventClip[2], Toilet.transform.position, 5f, 10f, out VoiceClip);
						EventPhase++;
						Timer = 0f;
					}
				}
				else if (EventPhase == 3)
				{
					Timer += Time.deltaTime;
					if (Timer > 4f)
					{
						EventStudent.CurrentDestination = EventLocation[3];
						EventStudent.Pathfinding.target = EventLocation[3];
						EventStudent.TargetDistance = 2f;
						StallDoor.gameObject.SetActive(true);
						StallDoor.Prompt.enabled = true;
						StallDoor.Locked = false;
						EventPhase++;
						Timer = 0f;
					}
				}
				else if (EventPhase == 4)
				{
					EventStudent.Character.GetComponent<Animation>().CrossFade("f02_washHands_00");
					Timer += Time.deltaTime;
					if (Timer > 5f)
					{
						EndEvent();
					}
				}
				else if (EventPhase == 5)
				{
					Timer += Time.deltaTime;
					if (Timer > 9f)
					{
						Splashes.Stop();
						EventOver = true;
						EndEvent();
					}
					else if (Timer > 3f)
					{
						EventSubtitle.text = string.Empty;
						Splashes.Play();
					}
				}
				Distance = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
				if (Distance < 10f)
				{
					float num = Mathf.Abs((Distance - 10f) * 0.2f);
					if (num < 0f)
					{
						num = 0f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					EventSubtitle.transform.localScale = new Vector3(num, num, num);
				}
				else
				{
					EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		if (ToiletCountdown > 0f)
		{
			ToiletCountdown -= Time.deltaTime;
			if (ToiletCountdown < 0f)
			{
				Toilet.enabled = true;
			}
		}
	}

	public void EndEvent()
	{
		if (!EventOver)
		{
			if (VoiceClip != null)
			{
				UnityEngine.Object.Destroy(VoiceClip);
			}
			EventStudent.CurrentDestination = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Pathfinding.target = EventStudent.Destinations[EventStudent.Phase];
			EventStudent.Obstacle.checkTime = 1f;
			if (!EventStudent.Dying)
			{
				EventStudent.Prompt.enabled = true;
			}
			EventStudent.TargetDistance = 1f;
			EventStudent.ToiletEvent = null;
			EventStudent.InEvent = false;
			EventStudent.Private = false;
			EventSubtitle.text = string.Empty;
			StudentManager.UpdateStudents();
		}
		StallDoor.gameObject.SetActive(true);
		StallDoor.Prompt.enabled = true;
		StallDoor.Locked = false;
		BucketPour.enabled = false;
		BucketPour.Prompt.Hide();
		BucketPour.Prompt.enabled = false;
		EventActive = false;
		EventCheck = false;
		Prompt.Hide();
		Prompt.enabled = false;
		ToiletCountdown = 1f;
	}
}
