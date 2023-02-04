using System;
using UnityEngine;

public class OsanaVendingMachineEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public StudentScript Rival;

	public Transform Location;

	public AudioSource VoiceSource;

	public AudioSource MyAudio;

	public AudioClip[] SpeechClip;

	public AudioClip Bang;

	public string[] SpeechText;

	public string[] EventAnim;

	public GameObject OsanaVandalismCollider;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public float MinimumDistance = 0.5f;

	public float Distance;

	public float Scale;

	public float Timer;

	public DayOfWeek EventDay;

	public int StartPeriod;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	public bool PlaySound;

	private void Start()
	{
		EventSubtitle.transform.localScale = Vector3.zero;
		if (GameGlobals.Eighties)
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
				if (Rival.enabled && Rival.SnackPhase == 1)
				{
					Debug.Log("Osana's vending machine event has begun.");
					AudioClipPlayer.Play(SpeechClip[0], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					EventSubtitle.text = SpeechText[0];
					Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					Rival.CharacterAnimation.Play(Rival.WalkAnim);
					Rival.Pathfinding.target = Location;
					Rival.CurrentDestination = Location;
					Rival.Pathfinding.canSearch = true;
					Rival.Pathfinding.canMove = true;
					Rival.EatingSnack = false;
					Rival.Routine = false;
					Rival.InEvent = true;
					Rival.EmptyHands();
					Phase++;
				}
			}
			Frame++;
			return;
		}
		if (VoiceClip != null)
		{
			if (VoiceSource == null)
			{
				VoiceSource = VoiceClip.GetComponent<AudioSource>();
			}
			else
			{
				VoiceSource.pitch = Time.timeScale;
			}
		}
		if (Rival.DistanceToDestination < MinimumDistance)
		{
			if (!Rival.GoAway)
			{
				Rival.MoveTowardsTarget(Location.position);
			}
			if (Quaternion.Angle(Rival.transform.rotation, Location.rotation) > 1f)
			{
				Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Location.rotation, 10f * Time.deltaTime);
			}
		}
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
				EventSubtitle.text = SpeechText[1];
				Rival.CharacterAnimation.CrossFade(EventAnim[1]);
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Rival.Obstacle.enabled = true;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (Rival.CharacterAnimation[EventAnim[1]].time >= Rival.CharacterAnimation[EventAnim[1]].length)
			{
				Rival.CharacterAnimation[EventAnim[2]].time = 7f;
				Rival.CharacterAnimation.CrossFade(EventAnim[2]);
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				AudioClipPlayer.Play(SpeechClip[3], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[3];
				Rival.CharacterAnimation[EventAnim[3]].time = 7f;
				Rival.CharacterAnimation.CrossFade(EventAnim[3]);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				AudioClipPlayer.Play(SpeechClip[4], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Rival.CharacterAnimation[EventAnim[4]].speed = 0f;
				Rival.CharacterAnimation.CrossFade(EventAnim[4]);
				MinimumDistance = 1f;
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			if (Timer > 0.5f)
			{
				Rival.CharacterAnimation[EventAnim[4]].speed = 1f;
				OsanaVandalismCollider.SetActive(value: true);
			}
			else
			{
				Location.position = Vector3.MoveTowards(Location.position, new Vector3(-2f, 4f, -31.7f), Time.deltaTime * 5f);
			}
			if (Rival.CharacterAnimation[EventAnim[4]].time > Rival.CharacterAnimation[EventAnim[4]].length)
			{
				Rival.CharacterAnimation[EventAnim[4]].time = 0f;
			}
			if (Timer > 5.5f)
			{
				Rival.CharacterAnimation[EventAnim[4]].speed = 0f;
				OsanaVandalismCollider.SetActive(value: false);
			}
			if (Timer > 6f)
			{
				AudioClipPlayer.Play(SpeechClip[5], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				EventSubtitle.text = SpeechText[5];
				Rival.CharacterAnimation[EventAnim[5]].time = 0f;
				Rival.CharacterAnimation.CrossFade(EventAnim[5]);
				Timer = 0f;
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			Timer += Time.deltaTime;
			if (Timer > 5f)
			{
				EndEvent();
			}
		}
		if (Clock.Period > StartPeriod || Rival.Alarmed || Rival.Splashed || Rival.Dodging || Rival.GoAway)
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
			if (VoiceSource != null)
			{
				VoiceSource.volume = Scale;
			}
		}
		else
		{
			EventSubtitle.transform.localScale = Vector3.zero;
			if (VoiceSource != null)
			{
				VoiceSource.volume = 0f;
			}
		}
		if (VoiceClip == null)
		{
			EventSubtitle.text = string.Empty;
		}
	}

	private void EndEvent()
	{
		Debug.Log("Osana's vending machine event has ended.");
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (!Rival.Alarmed)
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
		Rival.Obstacle.enabled = false;
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (!StudentManager.Stop)
		{
			StudentManager.UpdateStudents();
		}
		OsanaVandalismCollider.SetActive(value: false);
		Jukebox.Dip = 1f;
		EventSubtitle.text = string.Empty;
		base.enabled = false;
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! It's not important anymore...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
	}
}
