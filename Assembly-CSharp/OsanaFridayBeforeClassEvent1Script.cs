using System;
using UnityEngine;

public class OsanaFridayBeforeClassEvent1Script : MonoBehaviour
{
	public OsanaFridayBeforeClassEvent2Script OtherEvent;

	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Rival;

	public Transform Location;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public string EventAnim;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public GameObject Yoogle;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public Vector3 OriginalPosition;

	public Vector3 OriginalRotation;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != EventDay || StudentGlobals.StudentSlave == RivalID || GameGlobals.RivalEliminationID > 0 || StudentManager.RivalEliminated || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		Yoogle.SetActive(value: false);
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
				if (Rival.enabled && !Rival.InEvent && !Rival.Phoneless && Rival.Indoors && !OtherEvent.enabled && !Rival.GoAway && !Rival.Meeting && !Rival.Alarmed)
				{
					Debug.Log("Osana's ''make playlist'' event has begun.");
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.Play(Rival.WalkAnim);
					Rival.Pathfinding.target = Location;
					Rival.CurrentDestination = Location;
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.Routine = false;
					Rival.InEvent = true;
					Yandere.PauseScreen.Hint.Show = true;
					Yandere.PauseScreen.Hint.QuickID = 15;
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
				AudioClipPlayer.Play(SpeechClip[1], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[1];
				Rival.CharacterAnimation.CrossFade(EventAnim);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Rival.Distracted = true;
				Yoogle.SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (!Rival.GoAway)
			{
				Rival.MoveTowardsTarget(Location.position);
			}
			if (Quaternion.Angle(Rival.transform.rotation, Location.rotation) > 1f)
			{
				Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Location.rotation, 10f * Time.deltaTime);
			}
			Timer += Time.deltaTime;
			if (Input.GetKeyDown("space"))
			{
				Timer += 60f;
			}
			if (Timer > 60f)
			{
				EndEvent();
			}
		}
		if (Rival.Alarmed || Clock.HourTime > 8f || Rival.Splashed || Rival.Dodging || Rival.GoAway || Rival.LovestruckWaiting || Rival.Dying)
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
			if (base.enabled)
			{
				Jukebox.Dip = 1f - 0.5f * Scale;
			}
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

	public void EndEvent()
	{
		Debug.Log("Osana's Friday ''create a mixtape in the Computer Lab'' event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (Rival != null)
		{
			if (Rival.enabled && !Rival.Alarmed && !Rival.Splashed && !Rival.Dying)
			{
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.DistanceToDestination = 100f;
				Rival.CurrentDestination = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.target = Rival.Destinations[Rival.Phase];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Routine = true;
			}
			Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Rival.SmartPhoneScreen.enabled = false;
			Rival.Ragdoll.Zs.SetActive(value: false);
			Rival.Obstacle.enabled = false;
			Rival.Prompt.enabled = true;
			Rival.Distracted = false;
			Rival.InEvent = false;
			Rival.Private = false;
			Yoogle.SetActive(value: false);
			Rival.SmartPhone.transform.parent = Rival.ItemParent;
			Rival.SmartPhone.transform.localPosition = OriginalPosition;
			Rival.SmartPhone.transform.localEulerAngles = OriginalRotation;
		}
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		Jukebox.Dip = 1f;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		if (Rival != null && Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Guess I'll just do it later...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}
}
