using System;
using UnityEngine;

// Token: 0x020003DF RID: 991
public class OsanaMorningFriendEventScript : MonoBehaviour
{
	// Token: 0x06001B9C RID: 7068 RVA: 0x0013D290 File Offset: 0x0013B490
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (this.LosingFriend)
		{
			if ((float)StudentGlobals.GetStudentReputation(10) > -33.33333f || StudentGlobals.StudentSlave == this.FriendID || StudentGlobals.StudentSlave == this.RivalID || PlayerGlobals.RaibaruLoner)
			{
				base.enabled = false;
				return;
			}
		}
		else if ((float)StudentGlobals.GetStudentReputation(10) <= -33.33333f || DateGlobals.Weekday != this.EventDay || HomeGlobals.LateForSchool || this.StudentManager.YandereLate || DatingGlobals.SuitorProgress == 2 || StudentGlobals.MemorialStudents > 0 || StudentGlobals.StudentSlave == this.FriendID || StudentGlobals.StudentSlave == this.RivalID || GameGlobals.RivalEliminationID > 0 || PlayerGlobals.RaibaruLoner || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B9D RID: 7069 RVA: 0x0013D384 File Offset: 0x0013B584
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[this.FriendID] != null)
			{
				if (this.Friend == null)
				{
					this.Friend = this.StudentManager.Students[this.FriendID];
				}
				if (this.Rival == null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				if (this.Clock.Period == 1 && !this.StudentManager.Students[1].Alarmed && !this.Friend.DramaticReaction && !this.Friend.Alarmed && !this.Rival.Alarmed && this.Rival.enabled && !this.Rival.Talking && this.Rival.Alive && !this.Friend.Hunted && !this.OtherEvent.enabled)
				{
					Debug.Log("Osana's ''talk with friend before going to the lockers'' event has begun.");
					this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Friend.CharacterAnimation.CrossFade(this.Friend.WalkAnim);
					this.Friend.Pathfinding.target = this.Location[1];
					this.Friend.CurrentDestination = this.Location[1];
					this.Friend.Pathfinding.canSearch = true;
					this.Friend.Pathfinding.canMove = true;
					this.Friend.Routine = false;
					this.Friend.InEvent = true;
					this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location[2];
					this.Rival.CurrentDestination = this.Location[2];
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Spy.Prompt.enabled = true;
					if (!this.LosingFriend)
					{
						this.Friend.Private = true;
						this.Rival.Private = true;
						if (!this.OtherEvent.NaturalEnd)
						{
							this.SpeechClip = this.InterruptedClip;
							this.SpeechText = this.InterruptedSpeech;
							this.SpeechTime = this.InterruptedTime;
							this.EventAnim = this.InterruptedAnim;
							this.Speaker = this.InterruptedSpeaker;
						}
						bool flag = false;
						if (StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || StudentGlobals.GetStudentBroken(81) || StudentGlobals.StudentSlave == 81 || (float)StudentGlobals.GetStudentReputation(81) < -33.33333f)
						{
							Debug.Log("Musume's unavailable.");
							flag = true;
						}
						if (DateGlobals.Weekday == DayOfWeek.Friday && flag && this.OtherEvent.NaturalEnd)
						{
							this.SpeechClip = this.AltSpeechClip;
							this.SpeechText = this.AltSpeechText;
							this.SpeechTime = this.AltSpeechTime;
							this.EventAnim = this.AltEventAnim;
							this.Speaker = this.AltSpeaker;
						}
					}
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 12;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			this.Friend.Pathfinding.canSearch = true;
			this.Friend.Pathfinding.canMove = true;
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.SettleRival();
			}
			if (this.Friend.DistanceToDestination < 0.5f)
			{
				this.Friend.CharacterAnimation.CrossFade(this.Friend.IdleAnim);
				this.Friend.Pathfinding.canSearch = false;
				this.Friend.Pathfinding.canMove = false;
				this.SettleFriend();
			}
			if (this.Rival.DistanceToDestination < 0.5f && this.Friend.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
				this.PlayRelevantAnim();
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Friend.Pathfinding.canSearch = false;
				this.Friend.Pathfinding.canMove = false;
				this.Friend.Obstacle.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.CurrentSpeaker != null && this.SpeechPhase > 0 && this.CurrentSpeaker.CharacterAnimation[this.EventAnim[this.SpeechPhase - 1]].time >= this.CurrentSpeaker.CharacterAnimation[this.EventAnim[this.SpeechPhase - 1]].length - 1f)
			{
				this.CurrentSpeaker.CharacterAnimation.CrossFade(this.CurrentSpeaker.IdleAnim, 1f);
			}
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (this.SpeechPhase < this.SpeechTime.Length && this.Timer > this.SpeechTime[this.SpeechPhase])
			{
				this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
				this.PlayRelevantAnim();
				this.SpeechPhase++;
			}
			this.SettleRival();
			this.SettleFriend();
			if (this.Timer > this.SpeechClip.length)
			{
				this.EndEvent();
			}
		}
		if (this.Rival.Alarmed || this.Friend.Alarmed || this.Friend.DramaticReaction)
		{
			Debug.Log("The event ended naturally because a character was alarmed.");
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity);
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
			gameObject.transform.localScale = new Vector3(200f, 1f, 200f);
			this.EndEvent();
		}
		if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
		{
			this.EndEvent();
			if (this.Rival.ShoeRemoval.Locker == null)
			{
				this.Rival.ShoeRemoval.Start();
			}
			this.Rival.ShoeRemoval.PutOnShoes();
		}
		this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
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
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = this.Scale;
			}
			if (this.Phase > 1)
			{
				this.Yandere.Eavesdropping = (this.Distance < 3f);
			}
		}
		else
		{
			if (this.Distance - 4f < 16f)
			{
				this.EventSubtitle.transform.localScale = Vector3.zero;
			}
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
			}
		}
		if (this.VoiceClip == null)
		{
			this.EventSubtitle.text = string.Empty;
		}
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x0013DD04 File Offset: 0x0013BF04
	public void EndEvent()
	{
		Debug.Log("Osana's ''talk with friend before going to the lockers'' event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Rival != null)
		{
			if (!this.Rival.Alarmed)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.DistanceToDestination = 100f;
				this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			if (this.Rival.Alarmed)
			{
				this.Rival.ReturnToRoutineAfter = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.Obstacle.enabled = false;
			this.Rival.Prompt.enabled = true;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
		}
		if (this.Friend != null)
		{
			if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
			{
				this.Friend.CharacterAnimation.CrossFade(this.Friend.WalkAnim);
				this.Friend.DistanceToDestination = 100f;
				this.Friend.CurrentDestination = this.Rival.FollowTargetDestination;
				this.Friend.Pathfinding.target = this.Rival.FollowTargetDestination;
				this.Friend.Pathfinding.canSearch = true;
				this.Friend.Pathfinding.canMove = true;
				this.Friend.Routine = true;
			}
			this.Friend.VisionDistance = ((PlayerGlobals.PantiesEquipped == 4) ? 5f : 10f) * this.Friend.Paranoia;
			this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Friend.Obstacle.enabled = false;
			this.Friend.Prompt.enabled = true;
			this.Friend.InEvent = false;
			this.Friend.Private = false;
			if (this.Rival.Alarmed)
			{
				this.Friend.FocusOnYandere = true;
			}
		}
		this.Spy.Prompt.enabled = false;
		this.Spy.Prompt.Hide();
		if (this.Spy.Phase > 0)
		{
			this.Spy.End();
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		this.Jukebox.Dip = 1f;
		base.enabled = false;
		if (this.LosingFriend)
		{
			Debug.Log("Raibaru will no longer hang out with Osana.");
			this.EndOfDay.RaibaruLoner = true;
			Debug.Log("Raibaru has become a loner, so Osana's schedule has changed.");
			ScheduleBlock scheduleBlock = this.Rival.ScheduleBlocks[2];
			scheduleBlock.destination = "Patrol";
			scheduleBlock.action = "Patrol";
			ScheduleBlock scheduleBlock2 = this.Rival.ScheduleBlocks[7];
			scheduleBlock2.destination = "Patrol";
			scheduleBlock2.action = "Patrol";
			this.Rival.GetDestinations();
		}
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x0013E0A4 File Offset: 0x0013C2A4
	private void SettleRival()
	{
		this.Rival.MoveTowardsTarget(this.Location[2].position);
		if (Quaternion.Angle(this.Rival.transform.rotation, this.Location[2].rotation) > 1f)
		{
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001BA0 RID: 7072 RVA: 0x0013E12F File Offset: 0x0013C32F
	private void SettleFriend()
	{
		this.Friend.MoveTowardsTarget(this.Location[1].position);
		this.Friend.transform.LookAt(this.Rival.transform.position);
	}

	// Token: 0x06001BA1 RID: 7073 RVA: 0x0013E16C File Offset: 0x0013C36C
	private void PlayRelevantAnim()
	{
		if (this.Speaker[this.SpeechPhase] == 1)
		{
			this.Rival.CharacterAnimation.CrossFade(this.EventAnim[this.SpeechPhase]);
			this.Friend.CharacterAnimation.CrossFade(this.Friend.IdleAnim);
			this.CurrentSpeaker = this.Rival;
			return;
		}
		this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
		this.Friend.CharacterAnimation.CrossFade(this.EventAnim[this.SpeechPhase]);
		this.CurrentSpeaker = this.Friend;
	}

	// Token: 0x04002FC2 RID: 12226
	public RivalMorningEventManagerScript OtherEvent;

	// Token: 0x04002FC3 RID: 12227
	public StudentManagerScript StudentManager;

	// Token: 0x04002FC4 RID: 12228
	public EndOfDayScript EndOfDay;

	// Token: 0x04002FC5 RID: 12229
	public JukeboxScript Jukebox;

	// Token: 0x04002FC6 RID: 12230
	public UILabel EventSubtitle;

	// Token: 0x04002FC7 RID: 12231
	public YandereScript Yandere;

	// Token: 0x04002FC8 RID: 12232
	public ClockScript Clock;

	// Token: 0x04002FC9 RID: 12233
	public SpyScript Spy;

	// Token: 0x04002FCA RID: 12234
	public StudentScript CurrentSpeaker;

	// Token: 0x04002FCB RID: 12235
	public StudentScript Friend;

	// Token: 0x04002FCC RID: 12236
	public StudentScript Rival;

	// Token: 0x04002FCD RID: 12237
	public Transform Epicenter;

	// Token: 0x04002FCE RID: 12238
	public Transform[] Location;

	// Token: 0x04002FCF RID: 12239
	public AudioClip SpeechClip;

	// Token: 0x04002FD0 RID: 12240
	public string[] SpeechText;

	// Token: 0x04002FD1 RID: 12241
	public float[] SpeechTime;

	// Token: 0x04002FD2 RID: 12242
	public string[] EventAnim;

	// Token: 0x04002FD3 RID: 12243
	public int[] Speaker;

	// Token: 0x04002FD4 RID: 12244
	public AudioClip InterruptedClip;

	// Token: 0x04002FD5 RID: 12245
	public string[] InterruptedSpeech;

	// Token: 0x04002FD6 RID: 12246
	public float[] InterruptedTime;

	// Token: 0x04002FD7 RID: 12247
	public string[] InterruptedAnim;

	// Token: 0x04002FD8 RID: 12248
	public int[] InterruptedSpeaker;

	// Token: 0x04002FD9 RID: 12249
	public AudioClip AltSpeechClip;

	// Token: 0x04002FDA RID: 12250
	public string[] AltSpeechText;

	// Token: 0x04002FDB RID: 12251
	public float[] AltSpeechTime;

	// Token: 0x04002FDC RID: 12252
	public string[] AltEventAnim;

	// Token: 0x04002FDD RID: 12253
	public int[] AltSpeaker;

	// Token: 0x04002FDE RID: 12254
	public GameObject AlarmDisc;

	// Token: 0x04002FDF RID: 12255
	public GameObject VoiceClip;

	// Token: 0x04002FE0 RID: 12256
	public Quaternion targetRotation;

	// Token: 0x04002FE1 RID: 12257
	public float Distance;

	// Token: 0x04002FE2 RID: 12258
	public float Scale;

	// Token: 0x04002FE3 RID: 12259
	public float Timer;

	// Token: 0x04002FE4 RID: 12260
	public DayOfWeek EventDay;

	// Token: 0x04002FE5 RID: 12261
	public int SpeechPhase = 1;

	// Token: 0x04002FE6 RID: 12262
	public int FriendID = 6;

	// Token: 0x04002FE7 RID: 12263
	public int RivalID = 11;

	// Token: 0x04002FE8 RID: 12264
	public int Phase;

	// Token: 0x04002FE9 RID: 12265
	public int Frame;

	// Token: 0x04002FEA RID: 12266
	public Vector3 OriginalPosition;

	// Token: 0x04002FEB RID: 12267
	public Vector3 OriginalRotation;

	// Token: 0x04002FEC RID: 12268
	public bool LosingFriend;
}
