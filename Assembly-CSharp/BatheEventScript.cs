using System;
using UnityEngine;

public class BatheEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript EventStudent;

	public UILabel EventSubtitle;

	public AudioClip[] EventClip;

	public string[] EventSpeech;

	public string[] EventAnim;

	public GameObject RivalPhone;

	public GameObject VoiceClip;

	public bool EventActive;

	public bool EventOver;

	public float EventTime = 15.1f;

	public int EventPhase = 1;

	public DayOfWeek EventDay = DayOfWeek.Thursday;

	public Vector3 OriginalPosition;

	public float CurrentClipLength;

	public float Timer;

	private void Start()
	{
		RivalPhone.SetActive(value: false);
		if (DateGlobals.Weekday != EventDay)
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (!Clock.StopTime && !EventActive && Clock.HourTime > EventTime)
		{
			EventStudent = StudentManager.Students[30];
			if (EventStudent != null && !EventStudent.Distracted && !EventStudent.Talking && !EventStudent.Meeting && EventStudent.Indoors)
			{
				if (!EventStudent.WitnessedMurder)
				{
					OriginalPosition = EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
					EventStudent.CurrentDestination = StudentManager.FemaleStripSpot;
					EventStudent.Pathfinding.target = StudentManager.FemaleStripSpot;
					EventStudent.Character.GetComponent<Animation>().CrossFade(EventStudent.WalkAnim);
					EventStudent.Pathfinding.canSearch = true;
					EventStudent.Pathfinding.canMove = true;
					EventStudent.Pathfinding.speed = 1f;
					EventStudent.SpeechLines.Stop();
					EventStudent.DistanceToDestination = 100f;
					EventStudent.SmartPhone.SetActive(value: false);
					EventStudent.Obstacle.checkTime = 99f;
					EventStudent.InEvent = true;
					EventStudent.Private = true;
					EventStudent.Prompt.Hide();
					EventStudent.Hearts.Stop();
					EventActive = true;
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
		if (!EventActive)
		{
			return;
		}
		if (Clock.HourTime > EventTime + 1f || EventStudent.WitnessedMurder || EventStudent.Splashed || EventStudent.Dodging || EventStudent.Alarmed || EventStudent.Dying || !EventStudent.Alive)
		{
			EndEvent();
			return;
		}
		if (EventStudent.DistanceToDestination < 0.5f)
		{
			if (EventPhase == 1)
			{
				EventStudent.Routine = false;
				EventStudent.BathePhase = 1;
				EventStudent.Wet = true;
				EventPhase++;
			}
			else if (EventPhase == 2)
			{
				if (EventStudent.BathePhase == 4)
				{
					RivalPhone.SetActive(value: true);
					EventPhase++;
				}
			}
			else if (EventPhase == 3 && !EventStudent.Wet)
			{
				EndEvent();
			}
		}
		if (EventPhase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > CurrentClipLength + 1f)
			{
				EventStudent.Routine = true;
				EndEvent();
			}
		}
		float num = Vector3.Distance(Yandere.transform.position, EventStudent.transform.position);
		if (!(num < 11f))
		{
			return;
		}
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
			EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
		}
		else
		{
			EventSubtitle.transform.localScale = Vector3.zero;
		}
	}

	private void EndEvent()
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
				EventStudent.Pathfinding.canSearch = true;
				EventStudent.Pathfinding.canMove = true;
				EventStudent.Pathfinding.speed = 1f;
				EventStudent.TargetDistance = 1f;
				EventStudent.Private = false;
			}
			EventStudent.InEvent = false;
			EventSubtitle.text = string.Empty;
			StudentManager.UpdateStudents();
		}
		EventActive = false;
		base.enabled = false;
	}
}
