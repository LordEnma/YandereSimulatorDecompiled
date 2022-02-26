using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class RivalMorningEventManagerScript : MonoBehaviour
{
	// Token: 0x06001BCA RID: 7114 RVA: 0x00143E4C File Offset: 0x0014204C
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.Spy.Prompt.enabled = true;
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
		}
		if (DateGlobals.Weekday != this.EventDay || HomeGlobals.LateForSchool || this.StudentManager.YandereLate || DatingGlobals.SuitorProgress == 2 || StudentGlobals.MemorialStudents > 0 || GameGlobals.RivalEliminationID > 0 || StudentGlobals.StudentSlave == this.RivalID || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties || this.StudentManager.RecordingVideo)
		{
			this.Spy.Prompt.enabled = false;
			base.enabled = false;
		}
		if (base.enabled && (float)StudentGlobals.GetStudentReputation(10) <= -33.33333f)
		{
			this.OsanaLoseFriendEvent.OtherEvent = this;
		}
	}

	// Token: 0x06001BCB RID: 7115 RVA: 0x00143F38 File Offset: 0x00142138
	private void Update()
	{
		if (this.VoiceClip != null)
		{
			if (this.VoiceClipSource == null)
			{
				this.VoiceClipSource = this.VoiceClip.GetComponent<AudioSource>();
			}
			else
			{
				this.VoiceClipSource.pitch = Time.timeScale;
			}
		}
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[1].gameObject.activeInHierarchy && this.StudentManager.Students[this.RivalID] != null)
			{
				Debug.Log("Osana's morning Senpai interaction event is now taking place.");
				if (this.StudentManager.Students[this.FriendID] != null && !PlayerGlobals.RaibaruLoner && StudentGlobals.StudentSlave != this.FriendID)
				{
					this.Friend = this.StudentManager.Students[this.FriendID];
					if (this.Friend.Investigating)
					{
						this.Friend.StopInvestigating();
					}
					if ((float)StudentGlobals.GetStudentReputation(10) > -33.33333f)
					{
						this.Friend.CharacterAnimation.Play("f02_cornerPeek_00");
						this.Friend.Cheer.enabled = true;
					}
					else
					{
						this.Friend.CharacterAnimation.Play(this.Friend.BulliedIdleAnim);
					}
					this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Friend.transform.position = this.Location[3].position;
					this.Friend.transform.eulerAngles = this.Location[3].eulerAngles;
					this.Friend.Pathfinding.canSearch = false;
					this.Friend.Pathfinding.canMove = false;
					this.Friend.ImmuneToLaughter = true;
					this.Friend.VisionDistance = 20f;
					this.Friend.Routine = false;
					this.Friend.InEvent = true;
					this.Friend.Spawned = true;
				}
				this.Senpai = this.StudentManager.Students[1];
				this.Rival = this.StudentManager.Students[this.RivalID];
				this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Senpai.CharacterAnimation.Play(this.Senpai.IdleAnim);
				this.Senpai.transform.position = this.Location[1].position;
				this.Senpai.transform.eulerAngles = this.Location[1].eulerAngles;
				this.Senpai.Pathfinding.canSearch = false;
				this.Senpai.Pathfinding.canMove = false;
				this.Senpai.Routine = false;
				this.Senpai.InEvent = true;
				this.Senpai.Spawned = true;
				this.Senpai.Prompt.Hide();
				this.Senpai.Prompt.enabled = false;
				if (this.Rival.Investigating)
				{
					this.Rival.StopInvestigating();
				}
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
				this.Rival.transform.position = this.Location[2].position;
				this.Rival.transform.eulerAngles = this.Location[2].eulerAngles;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.Spawned = true;
				this.Rival.Private = true;
				this.Rival.Prompt.Hide();
				this.Rival.Prompt.enabled = false;
				this.Spy.Prompt.enabled = true;
				this.Phase++;
				if (this.EventDay == DayOfWeek.Tuesday)
				{
					this.StudentManager.Students[1].EventBook.SetActive(true);
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_1");
				this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_1");
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && !this.HintGiven)
			{
				this.Yandere.PauseScreen.Hint.Show = true;
				this.Yandere.PauseScreen.Hint.QuickID = 1;
				this.HintGiven = true;
			}
			if (this.VoiceClipSource != null)
			{
				this.VoiceClipSource.pitch = Time.timeScale;
			}
			if (this.SpeechPhase < this.SpeechTime.Length)
			{
				if (this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else
			{
				if (this.Senpai == null)
				{
					this.Senpai = this.StudentManager.Students[1];
				}
				if (this.Senpai.CharacterAnimation[this.Weekday + "_1"].time >= this.Senpai.CharacterAnimation[this.Weekday + "_1"].length)
				{
					Debug.Log("This rival morning event ended naturally because the animation finished playing.");
					this.NaturalEnd = true;
					this.EndEvent();
				}
			}
			if (this.Transfer && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_1"].time > this.TransferTime)
			{
				this.Senpai.EventBook.SetActive(false);
				this.Rival.EventBook.SetActive(true);
				this.Transfer = false;
			}
			if (this.Clock.Period > 1)
			{
				Debug.Log("The event ended because the school period has advanced.");
				this.EndEvent();
			}
			if (this.Rival != null && (this.Senpai.Alarmed || this.Rival.Alarmed || (this.Friend != null && this.Friend.DramaticReaction)))
			{
				Debug.Log("The event ended naturally because a character was alarmed.");
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Rival.transform.position + Vector3.up, Quaternion.identity);
				gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
				gameObject.transform.localScale = new Vector3(150f, 1f, 150f);
				gameObject.GetComponent<AlarmDiscScript>().FocusOnYandere = true;
				this.EndEvent();
			}
			if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
			{
				this.EndEvent();
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
			if (base.enabled)
			{
				if (this.Distance - 4f < 15f)
				{
					this.Scale = Mathf.Abs(1f - (this.Distance - 4f) / 15f);
					if (this.Scale < 0f)
					{
						this.Scale = 0f;
					}
					if (this.Scale > 1f)
					{
						this.Scale = 1f;
					}
					this.Jukebox.Dip = 1f - 0.5f * this.Scale;
					this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
					if (this.VoiceClipSource != null)
					{
						this.VoiceClipSource.volume = this.Scale;
					}
					this.Yandere.Eavesdropping = (this.Distance < 3f);
				}
				else
				{
					if (this.Distance - 4f < 16f)
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
					if (this.VoiceClipSource != null)
					{
						this.VoiceClipSource.volume = 0f;
					}
				}
			}
		}
		if (this.End)
		{
			Debug.Log("The event ended naturally because the ''End'' variable was set to ''true''.");
			this.EndEvent();
		}
	}

	// Token: 0x06001BCC RID: 7116 RVA: 0x0014489C File Offset: 0x00142A9C
	public void EndEvent()
	{
		Debug.Log("Osana's morning ''Talk with Senpai'' event has ended.");
		if (this.Phase > 0 && this.Rival.Alive)
		{
			if (this.EventDay == DayOfWeek.Tuesday)
			{
				ScheduleBlock scheduleBlock = this.Senpai.ScheduleBlocks[2];
				scheduleBlock.destination = "Patrol";
				scheduleBlock.action = "Patrol";
				ScheduleBlock scheduleBlock2 = this.Senpai.ScheduleBlocks[7];
				scheduleBlock2.destination = "Patrol";
				scheduleBlock2.action = "Patrol";
				this.Senpai.GetDestinations();
			}
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			if (!this.Senpai.Alarmed)
			{
				this.Senpai.Pathfinding.canSearch = true;
				this.Senpai.Pathfinding.canMove = true;
				this.Senpai.Routine = true;
			}
			this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Senpai.EventBook.SetActive(false);
			this.Senpai.InEvent = false;
			this.Senpai.Private = false;
			if (!this.Rival.Alarmed)
			{
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.EventBook.SetActive(false);
			this.Rival.Prompt.enabled = true;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			if (this.Friend != null)
			{
				if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
				{
					this.Friend.Pathfinding.canSearch = true;
					this.Friend.Pathfinding.canMove = true;
					this.Friend.Routine = true;
				}
				if (this.NaturalEnd)
				{
					this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.Friend.Prompt.enabled = true;
					this.Friend.InEvent = false;
					this.Friend.Private = false;
				}
				else
				{
					this.Friend.Pathfinding.target = this.Location[3];
					this.Friend.CurrentDestination = this.Location[3];
				}
				this.Friend.Cheer.enabled = false;
				this.Friend.ImmuneToLaughter = false;
			}
			if (!this.StudentManager.Stop)
			{
				this.StudentManager.UpdateStudents(0);
			}
			this.Spy.Prompt.Hide();
			this.Spy.Prompt.enabled = false;
			if (this.Spy.Phase > 0)
			{
				this.Spy.End();
			}
			this.Yandere.Eavesdropping = false;
			this.EventSubtitle.text = string.Empty;
			base.enabled = false;
			this.Jukebox.Dip = 1f;
		}
	}

	// Token: 0x0400309D RID: 12445
	public OsanaMorningFriendEventScript OsanaLoseFriendEvent;

	// Token: 0x0400309E RID: 12446
	public StudentManagerScript StudentManager;

	// Token: 0x0400309F RID: 12447
	public JukeboxScript Jukebox;

	// Token: 0x040030A0 RID: 12448
	public UILabel EventSubtitle;

	// Token: 0x040030A1 RID: 12449
	public YandereScript Yandere;

	// Token: 0x040030A2 RID: 12450
	public ClockScript Clock;

	// Token: 0x040030A3 RID: 12451
	public SpyScript Spy;

	// Token: 0x040030A4 RID: 12452
	public StudentScript Friend;

	// Token: 0x040030A5 RID: 12453
	public StudentScript Senpai;

	// Token: 0x040030A6 RID: 12454
	public StudentScript Rival;

	// Token: 0x040030A7 RID: 12455
	public Transform[] Location;

	// Token: 0x040030A8 RID: 12456
	public Transform Epicenter;

	// Token: 0x040030A9 RID: 12457
	public AudioClip SpeechClip;

	// Token: 0x040030AA RID: 12458
	public string[] SpeechText;

	// Token: 0x040030AB RID: 12459
	public float[] SpeechTime;

	// Token: 0x040030AC RID: 12460
	public GameObject AlarmDisc;

	// Token: 0x040030AD RID: 12461
	public GameObject VoiceClip;

	// Token: 0x040030AE RID: 12462
	public AudioSource VoiceClipSource;

	// Token: 0x040030AF RID: 12463
	public bool NaturalEnd;

	// Token: 0x040030B0 RID: 12464
	public bool HintGiven;

	// Token: 0x040030B1 RID: 12465
	public bool Transfer;

	// Token: 0x040030B2 RID: 12466
	public bool End;

	// Token: 0x040030B3 RID: 12467
	public float TransferTime;

	// Token: 0x040030B4 RID: 12468
	public float Distance;

	// Token: 0x040030B5 RID: 12469
	public float Scale;

	// Token: 0x040030B6 RID: 12470
	public float Timer;

	// Token: 0x040030B7 RID: 12471
	public DayOfWeek EventDay;

	// Token: 0x040030B8 RID: 12472
	public int SpeechPhase = 1;

	// Token: 0x040030B9 RID: 12473
	public int FriendID = 6;

	// Token: 0x040030BA RID: 12474
	public int RivalID = 11;

	// Token: 0x040030BB RID: 12475
	public int Phase;

	// Token: 0x040030BC RID: 12476
	public int Frame;

	// Token: 0x040030BD RID: 12477
	public string Weekday = string.Empty;
}
