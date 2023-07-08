using System;
using UnityEngine;

public class OsanaMondayLunchEventScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public OsanaClubEventScript ClubEvent;

	public JukeboxScript Jukebox;

	public UILabel EventSubtitle;

	public YandereScript Yandere;

	public ClockScript Clock;

	public SpyScript Spy;

	public StudentScript Senpai;

	public StudentScript Friend;

	public StudentScript Rival;

	public BentoScript[] Bento;

	public string[] SabotagedSpeechText;

	public string[] SpeechText;

	public float[] SabotagedSpeechTime;

	public float[] SpeechTime;

	public AudioClip[] SpeechClip;

	public Transform[] Location;

	public Transform Epicenter;

	public GameObject AlarmDisc;

	public GameObject VoiceClip;

	public Vector3 OriginalPosition;

	public bool Sabotaged;

	public bool Finished;

	public float Distance;

	public float Scale;

	public float Timer;

	public float RotationX;

	public float RotationY;

	public float RotationZ;

	public int SpeechPhase = 1;

	public int DebugPoison;

	public int FriendID = 6;

	public int RivalID = 11;

	public int Phase;

	public int Frame;

	private void Start()
	{
		OriginalPosition = Epicenter.position;
		EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Week > 1 || DateGlobals.Weekday != DayOfWeek.Monday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || GameGlobals.Eighties || Finished)
		{
			base.gameObject.SetActive(value: false);
			base.enabled = false;
		}
		if (Finished && StudentManager.Students[FriendID] != null)
		{
			MakeRaibaruEatLunch();
		}
	}

	private void Update()
	{
		if (Phase == 0)
		{
			if (Frame > 0 && StudentManager.Students[RivalID] != null && StudentManager.Students[RivalID].enabled && StudentManager.Students[1].gameObject.activeInHierarchy && Clock.Period == 3 && !StudentManager.Students[RivalID].Meeting)
			{
				Debug.Log("Osana's lunchtime event has begun.");
				if (ClubEvent.enabled)
				{
					ClubEvent.EndEvent();
				}
				DisableBentos();
				Bento[1].gameObject.SetActive(value: true);
				Bento[2].gameObject.SetActive(value: true);
				Senpai = StudentManager.Students[1];
				Rival = StudentManager.Students[RivalID];
				Friend = StudentManager.Students[FriendID];
				Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Senpai.CharacterAnimation.Play(Senpai.WalkAnim);
				Senpai.Pathfinding.target = Location[1];
				Senpai.CurrentDestination = Location[1];
				Senpai.SmartPhone.SetActive(value: false);
				Senpai.Pathfinding.canSearch = true;
				Senpai.Pathfinding.canMove = true;
				Senpai.Routine = false;
				Senpai.InEvent = true;
				Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				Rival.CharacterAnimation.Play(Rival.WalkAnim);
				Rival.Pathfinding.target = Location[0];
				Rival.CurrentDestination = Location[0];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Rival.Routine = false;
				Rival.InEvent = true;
				Rival.EmptyHands();
				Spy.gameObject.SetActive(value: true);
				if (Friend != null)
				{
					Friend.FocusOnYandere = false;
					Friend.IgnoringThingsOnGround = true;
					Friend.CanTalk = false;
					Friend.EmptyHands();
					Friend.SpeechLines.Stop();
				}
				Yandere.PauseScreen.Hint.Show = true;
				Yandere.PauseScreen.Hint.QuickID = 7;
				Phase++;
			}
			Frame++;
		}
		else if (Phase == 1)
		{
			if (Rival.DistanceToDestination < 0.5f)
			{
				EventSubtitle.text = SpeechText[SpeechPhase];
				SpeechPhase++;
				AudioClipPlayer.Play(SpeechClip[0], Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Rival.CharacterAnimation["f02_pondering_00"].speed = 2f;
				Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				Epicenter.position = Rival.transform.position;
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (!Rival.GoAway)
			{
				Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
			}
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (Friend != null)
			{
				Friend.Pathfinding.target = Rival.transform;
				Friend.CurrentDestination = Rival.transform;
			}
			if (Rival.CharacterAnimation["f02_pondering_00"].time >= Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				Epicenter.position = OriginalPosition;
				EventSubtitle.text = string.Empty;
				Rival.CharacterAnimation.Play(Rival.WalkAnim);
				Rival.Pathfinding.target = Location[2];
				Rival.CurrentDestination = Location[2];
				Rival.Pathfinding.canSearch = true;
				Rival.Pathfinding.canMove = true;
				Bento[1].gameObject.SetActive(value: false);
				Bento[2].gameObject.SetActive(value: false);
				if (Friend != null)
				{
					Rival.FollowTargetDestination.localPosition = new Vector3(0f, 0f, -0.5f);
					Friend.Pathfinding.target = Rival.FollowTargetDestination;
					Friend.CurrentDestination = Rival.FollowTargetDestination;
				}
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			if (Rival.DistanceToDestination > 0.5f && !Rival.Dodging)
			{
				Rival.CharacterAnimation.CrossFade(Rival.WalkAnim);
				Rival.Pathfinding.target = Location[2];
				Rival.CurrentDestination = Location[2];
			}
			if (Senpai.DistanceToDestination < 0.5f && Rival.DistanceToDestination < 0.5f)
			{
				MakeRaibaruGoHide();
				AudioClipPlayer.Play(SpeechClip[1], Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Senpai.CharacterAnimation.CrossFade("Monday_2A");
				Rival.CharacterAnimation.CrossFade("f02_Monday_2A");
				Rival.Bento.transform.localEulerAngles = new Vector3(15f, Rival.Bento.transform.localEulerAngles.y, Rival.Bento.transform.localEulerAngles.z);
				Rival.Bento.transform.localPosition = new Vector3(-0.02f, Rival.Bento.transform.localPosition.y, Rival.Bento.transform.localPosition.z);
				Rival.Bento.SetActive(value: true);
				Senpai.Pathfinding.canSearch = false;
				Senpai.Pathfinding.canMove = false;
				Rival.Pathfinding.canSearch = false;
				Rival.Pathfinding.canMove = false;
				Phase++;
			}
			else
			{
				if (Senpai.DistanceToDestination < 0.5f)
				{
					Senpai.CharacterAnimation.CrossFade("thinking_00");
					if (!Senpai.GoAway)
					{
						Senpai.MoveTowardsTarget(Senpai.CurrentDestination.position);
					}
					Senpai.transform.rotation = Quaternion.Slerp(Senpai.transform.rotation, Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
					Senpai.Pathfinding.canSearch = false;
					Senpai.Pathfinding.canMove = false;
				}
				if (Rival.DistanceToDestination < 0.5f)
				{
					Rival.CharacterAnimation.CrossFade("f02_pondering_00");
					if (!Rival.GoAway)
					{
						Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
					}
					Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
					Rival.Pathfinding.canSearch = false;
					Rival.Pathfinding.canMove = false;
				}
			}
		}
		else if (Phase == 4)
		{
			Timer += Time.deltaTime;
			MakeRaibaruGoHide();
			if (!Senpai.GoAway)
			{
				Senpai.MoveTowardsTarget(Senpai.CurrentDestination.position);
			}
			Senpai.transform.rotation = Quaternion.Slerp(Senpai.transform.rotation, Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (!Rival.GoAway)
			{
				Rival.MoveTowardsTarget(Rival.CurrentDestination.position);
			}
			Rival.transform.rotation = Quaternion.Slerp(Rival.transform.rotation, Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (Timer > 21.5f)
			{
				Senpai.Bento.transform.localPosition = new Vector3(-0.01652f, -0.02516f, -0.08239f);
				Senpai.Bento.transform.localEulerAngles = new Vector3(-35f, 116f, 165f);
				RotationX = -35f;
				RotationY = 115f;
				RotationZ = 165f;
				Senpai.Bento.SetActive(value: true);
				Rival.Bento.SetActive(value: false);
				Phase++;
			}
		}
		else if (Phase == 5)
		{
			Timer += Time.deltaTime;
			RotationX = Mathf.Lerp(RotationX, 6f, Time.deltaTime);
			RotationY = Mathf.Lerp(RotationY, 153f, Time.deltaTime);
			RotationZ = Mathf.Lerp(RotationZ, 102.5f, Time.deltaTime);
			Senpai.Bento.transform.localPosition = Vector3.Lerp(Senpai.Bento.transform.localPosition, new Vector3(-0.045f, -0.08f, -0.025f), Time.deltaTime);
			Senpai.Bento.transform.localEulerAngles = new Vector3(RotationX, RotationY, RotationZ);
			if (Timer > 29.833334f)
			{
				Senpai.Lid.transform.parent = Senpai.RightHand;
				Senpai.Lid.transform.localPosition = new Vector3(-0.025f, -0.025f, -0.015f);
				Senpai.Lid.transform.localEulerAngles = new Vector3(41.5f, -60f, -180f);
			}
			if (Timer > 30f && (float)Bento[1].Poison > 0f)
			{
				Senpai.CharacterAnimation.CrossFade("Monday_2B");
				Rival.CharacterAnimation.CrossFade("f02_Monday_2B");
				Sabotaged = true;
				SpeechPhase = 0;
			}
			if (Timer > 30.433332f)
			{
				Senpai.Lid.transform.parent = null;
				Senpai.Lid.transform.position = new Vector3(-0.31f, 12.501f, -29.335f);
				Senpai.Lid.transform.eulerAngles = new Vector3(0f, 0f, 180f);
			}
			if (Timer > 31f)
			{
				Senpai.Chopsticks[0].SetActive(value: true);
				Senpai.Chopsticks[1].SetActive(value: true);
				Phase++;
			}
		}
		else if (Phase == 6)
		{
			Timer += Time.deltaTime;
			if (!Sabotaged)
			{
				if (Timer > 37.15f)
				{
					AudioClipPlayer.Play(SpeechClip[2], Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
					Phase++;
				}
			}
			else if (Timer > 41f)
			{
				AudioClipPlayer.Play(SpeechClip[3], Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out VoiceClip, Yandere.transform.position.y);
				Phase++;
			}
		}
		else if (Phase == 7)
		{
			Timer += Time.deltaTime;
			if (!Sabotaged)
			{
				if (Senpai.CharacterAnimation["Monday_2A"].time > Senpai.CharacterAnimation["Monday_2A"].length)
				{
					EndEvent();
				}
			}
			else
			{
				if (Timer > 44.5f && Senpai.Bento.transform.parent != null)
				{
					Senpai.Bento.transform.parent = null;
					Senpai.Bento.transform.position = new Vector3(-0.853f, 12.501f, -29.33333f);
					Senpai.Bento.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					Senpai.Chopsticks[0].SetActive(value: false);
					Senpai.Chopsticks[1].SetActive(value: false);
				}
				if (Senpai.InEvent && Senpai.CharacterAnimation["Monday_2B"].time > Senpai.CharacterAnimation["Monday_2B"].length)
				{
					Senpai.WalkAnim = "stomachPainWalk_00";
					Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					Senpai.Pathfinding.target = StudentManager.MaleVomitSpots[3];
					Senpai.CurrentDestination = StudentManager.MaleVomitSpots[3];
					Senpai.CharacterAnimation.CrossFade(Senpai.WalkAnim);
					Senpai.Pathfinding.canSearch = true;
					Senpai.Pathfinding.canMove = true;
					Senpai.Pathfinding.speed = 2f;
					Senpai.Distracted = true;
					Senpai.Vomiting = true;
					Senpai.InEvent = false;
					Senpai.Routine = false;
					Senpai.Private = true;
					StudentManager.SabotageProgress++;
					Debug.Log("Sabotage Progress: " + StudentManager.SabotageProgress + "/5");
				}
				if (Rival.CharacterAnimation["f02_Monday_2B"].time > Rival.CharacterAnimation["f02_Monday_2B"].length)
				{
					EndEvent();
				}
			}
		}
		if (Phase > 3)
		{
			if (!Sabotaged)
			{
				if (SpeechPhase < SpeechTime.Length && Timer > SpeechTime[SpeechPhase])
				{
					EventSubtitle.text = SpeechText[SpeechPhase];
					SpeechPhase++;
				}
			}
			else if (SpeechPhase < SabotagedSpeechTime.Length && Timer > 41f + SabotagedSpeechTime[SpeechPhase])
			{
				EventSubtitle.text = SabotagedSpeechText[SpeechPhase];
				SpeechPhase++;
			}
			if (Friend.DistanceToDestination < 0.5f)
			{
				Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
				Friend.Pathfinding.canSearch = false;
				Friend.Pathfinding.canMove = false;
				if (!Friend.MyBento.gameObject.activeInHierarchy && !Friend.MyBento.Tampered)
				{
					Friend.MyBento.gameObject.SetActive(value: true);
					Friend.MyBento.transform.parent = null;
					Friend.MyBento.transform.position = Bento[3].transform.position;
					Friend.MyBento.transform.eulerAngles = Bento[3].transform.eulerAngles;
					Friend.MyBento.Prompt.enabled = true;
				}
				SettleFriend();
			}
		}
		if (Phase <= 0)
		{
			return;
		}
		if (Clock.Period > 3 || Senpai.Alarmed || Rival.Alarmed || Rival.Wet || Rival.GoAway || Senpai.GoAway)
		{
			if (Senpai.Alarmed || (Rival.Alarmed && !Rival.Wet))
			{
				UnityEngine.Object.Instantiate(AlarmDisc, Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
			}
			EndEvent();
		}
		if (VoiceClip != null)
		{
			VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
		}
		Distance = Vector3.Distance(Yandere.transform.position, Epicenter.position);
		if (!base.enabled)
		{
			return;
		}
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
			if (Phase > 3)
			{
				Yandere.Eavesdropping = Distance < 2.5f;
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
	}

	private void SettleFriend()
	{
		Friend.MoveTowardsTarget(Location[3].position);
		if (Quaternion.Angle(Friend.transform.rotation, Location[3].rotation) > 1f)
		{
			Friend.transform.rotation = Quaternion.Slerp(Friend.transform.rotation, Location[3].rotation, 10f * Time.deltaTime);
		}
	}

	private void EndEvent()
	{
		if (VoiceClip != null)
		{
			UnityEngine.Object.Destroy(VoiceClip);
		}
		if (Senpai.InEvent)
		{
			Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Senpai.InEvent = false;
			Senpai.Private = false;
			Senpai.Pathfinding.canSearch = true;
			Senpai.Pathfinding.canMove = true;
			Senpai.TargetDistance = 1f;
			Senpai.Routine = true;
		}
		Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		Rival.DistanceToDestination = 100f;
		Rival.Prompt.enabled = true;
		Rival.InEvent = false;
		Rival.Private = false;
		if (!Rival.Splashed)
		{
			Rival.Pathfinding.canSearch = true;
			Rival.Pathfinding.canMove = true;
		}
		else
		{
			Rival.Pathfinding.canSearch = false;
			Rival.Pathfinding.canMove = false;
		}
		Rival.TargetDistance = 1f;
		Rival.Routine = !Rival.Splashed;
		if (Rival.Alarmed || Senpai.Alarmed)
		{
			Senpai.Pathfinding.canSearch = false;
			Senpai.Pathfinding.canMove = false;
			Senpai.TargetDistance = 0.5f;
			Senpai.Routine = !Senpai.Alarmed;
			Rival.Pathfinding.canSearch = false;
			Rival.Pathfinding.canMove = false;
			Rival.TargetDistance = 0.5f;
			Rival.Routine = !Rival.Alarmed;
		}
		if (Friend != null)
		{
			MakeRaibaruEatLunch();
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
		EventSubtitle.text = string.Empty;
		Yandere.Eavesdropping = false;
		base.enabled = false;
		Jukebox.Dip = 1f;
		Debug.Log("Ending Osana's Monday Lunch Event.");
		if (Rival.GoAway)
		{
			Rival.Subtitle.CustomText = "Ugh, seriously?! Nevermind, Senpai...just forget it...";
			Rival.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
		}
		DisableBentos();
		Finished = true;
	}

	private void DisableBentos()
	{
		Bento[1].Prompt.Hide();
		Bento[1].Prompt.enabled = false;
		Bento[2].Prompt.Hide();
		Bento[2].Prompt.enabled = false;
		Bento[1].gameObject.SetActive(value: false);
		Bento[2].gameObject.SetActive(value: false);
		Bento[1].enabled = false;
		Bento[2].enabled = false;
	}

	private void MakeRaibaruGoHide()
	{
		if (Friend != null && Friend.DistanceToDestination > 1f)
		{
			Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			Friend.CharacterAnimation.Play(Friend.WalkAnim);
			Friend.Pathfinding.target = Location[3];
			Friend.CurrentDestination = Location[3];
			Friend.Pathfinding.canSearch = true;
			Friend.Pathfinding.canMove = true;
			Friend.Distracted = false;
			Friend.Routine = false;
			Friend.InEvent = true;
		}
	}

	private void MakeRaibaruEatLunch()
	{
		if (!Friend.Electrified)
		{
			if (!Friend.Alarmed)
			{
				Friend.Pathfinding.canSearch = true;
				Friend.Pathfinding.canMove = true;
				Friend.CanTalk = true;
				Friend.Routine = true;
			}
			Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			Friend.Prompt.enabled = true;
			Friend.InEvent = false;
			Friend.Private = false;
			ScheduleBlock obj = Friend.ScheduleBlocks[4];
			obj.destination = "LunchSpot";
			obj.action = "Eat";
			Friend.GetDestinations();
			Friend.CurrentDestination = Friend.Destinations[Friend.Phase];
			Friend.Pathfinding.target = Friend.Destinations[Friend.Phase];
			Friend.DistanceToDestination = 100f;
			Friend.MyBento.gameObject.SetActive(value: false);
			Friend.MyBento.transform.parent = Friend.LeftHand;
			Friend.MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
			Friend.MyBento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
			Friend.IgnoringThingsOnGround = false;
			Debug.Log("Osana's Monday lunch event ended, so Raibaru is being told to set her destination to her current phase's destination.");
		}
	}
}
