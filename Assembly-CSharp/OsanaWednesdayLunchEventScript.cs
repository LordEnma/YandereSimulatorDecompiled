using System;
using UnityEngine;

public class OsanaWednesdayLunchEventScript : MonoBehaviour
{
	public RivalAfterClassEventManagerScript AfterClassEvent;

	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Rival;

	public Transform Location;

	public AudioClip SpeechClip;

	public string SpeechText;

	public string EventAnim;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public float Distance;

	public float Scale;

	public DayOfWeek EventDay;

	public int StartPeriod;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

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
				if (Rival.Bullied)
				{
					base.enabled = false;
				}
				else if ((Clock.Period == 3 || Clock.Period == 6) && Rival.enabled && !Rival.InEvent && !Rival.Phoneless && !Rival.EndSearch)
				{
					Debug.Log("Osana's Wednesday lunchtime event has begun.");
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.Play(Rival.WalkAnim);
					Rival.Pathfinding.target = Location;
					Rival.CurrentDestination = Location;
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.Routine = false;
					Rival.InEvent = true;
					Rival.EmptyHands();
					StartPeriod = Clock.Period;
					Yandere.PauseScreen.Hint.Show = true;
					Yandere.PauseScreen.Hint.QuickID = 17;
					Phase++;
				}
			}
			Frame++;
			return;
		}
		if (Phase == 1)
		{
			if (Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(SpeechClip, Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText;
				Rival.CharacterAnimation.CrossFade("f02_" + EventAnim);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if ((double)Rival.CharacterAnimation["f02_" + EventAnim].time >= 1.33333)
			{
				Rival.SmartPhone.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if ((double)Rival.CharacterAnimation["f02_" + EventAnim].time >= 6.833333)
			{
				Rival.SmartPhone.SetActive(value: false);
				Phase++;
			}
		}
		else if (Phase == 4 && Rival.CharacterAnimation["f02_" + EventAnim].time >= Rival.CharacterAnimation["f02_" + EventAnim].length)
		{
			EndEvent();
		}
		if (Clock.Period > StartPeriod || Rival.Alarmed || Rival.Splashed)
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

	private void EndEvent()
	{
		Debug.Log("Osana's Wednesday lunchtime event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Rival.Alarmed && !Rival.Splashed)
		{
			Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
			Rival.DistanceToDestination = 100f;
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
			Rival.Routine = true;
		}
		if (Rival.Splashed)
		{
			AfterClassEvent.Cancelled = true;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
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
	}
}
