using System;
using UnityEngine;

// Token: 0x020003DB RID: 987
public class OsanaMorningFriendEventScript : MonoBehaviour
{
	// Token: 0x06001B86 RID: 7046 RVA: 0x0013A478 File Offset: 0x00138678
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

	// Token: 0x06001B87 RID: 7047 RVA: 0x0013A56C File Offset: 0x0013876C
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

	// Token: 0x06001B88 RID: 7048 RVA: 0x0013AEEC File Offset: 0x001390EC
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

	// Token: 0x06001B89 RID: 7049 RVA: 0x0013B28C File Offset: 0x0013948C
	private void SettleRival()
	{
		this.Rival.MoveTowardsTarget(this.Location[2].position);
		if (Quaternion.Angle(this.Rival.transform.rotation, this.Location[2].rotation) > 1f)
		{
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x0013B317 File Offset: 0x00139517
	private void SettleFriend()
	{
		this.Friend.MoveTowardsTarget(this.Location[1].position);
		this.Friend.transform.LookAt(this.Rival.transform.position);
	}

	// Token: 0x06001B8B RID: 7051 RVA: 0x0013B354 File Offset: 0x00139554
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

	// Token: 0x04002F7C RID: 12156
	public RivalMorningEventManagerScript OtherEvent;

	// Token: 0x04002F7D RID: 12157
	public StudentManagerScript StudentManager;

	// Token: 0x04002F7E RID: 12158
	public EndOfDayScript EndOfDay;

	// Token: 0x04002F7F RID: 12159
	public JukeboxScript Jukebox;

	// Token: 0x04002F80 RID: 12160
	public UILabel EventSubtitle;

	// Token: 0x04002F81 RID: 12161
	public YandereScript Yandere;

	// Token: 0x04002F82 RID: 12162
	public ClockScript Clock;

	// Token: 0x04002F83 RID: 12163
	public SpyScript Spy;

	// Token: 0x04002F84 RID: 12164
	public StudentScript CurrentSpeaker;

	// Token: 0x04002F85 RID: 12165
	public StudentScript Friend;

	// Token: 0x04002F86 RID: 12166
	public StudentScript Rival;

	// Token: 0x04002F87 RID: 12167
	public Transform Epicenter;

	// Token: 0x04002F88 RID: 12168
	public Transform[] Location;

	// Token: 0x04002F89 RID: 12169
	public AudioClip SpeechClip;

	// Token: 0x04002F8A RID: 12170
	public string[] SpeechText;

	// Token: 0x04002F8B RID: 12171
	public float[] SpeechTime;

	// Token: 0x04002F8C RID: 12172
	public string[] EventAnim;

	// Token: 0x04002F8D RID: 12173
	public int[] Speaker;

	// Token: 0x04002F8E RID: 12174
	public AudioClip InterruptedClip;

	// Token: 0x04002F8F RID: 12175
	public string[] InterruptedSpeech;

	// Token: 0x04002F90 RID: 12176
	public float[] InterruptedTime;

	// Token: 0x04002F91 RID: 12177
	public string[] InterruptedAnim;

	// Token: 0x04002F92 RID: 12178
	public int[] InterruptedSpeaker;

	// Token: 0x04002F93 RID: 12179
	public AudioClip AltSpeechClip;

	// Token: 0x04002F94 RID: 12180
	public string[] AltSpeechText;

	// Token: 0x04002F95 RID: 12181
	public float[] AltSpeechTime;

	// Token: 0x04002F96 RID: 12182
	public string[] AltEventAnim;

	// Token: 0x04002F97 RID: 12183
	public int[] AltSpeaker;

	// Token: 0x04002F98 RID: 12184
	public GameObject AlarmDisc;

	// Token: 0x04002F99 RID: 12185
	public GameObject VoiceClip;

	// Token: 0x04002F9A RID: 12186
	public Quaternion targetRotation;

	// Token: 0x04002F9B RID: 12187
	public float Distance;

	// Token: 0x04002F9C RID: 12188
	public float Scale;

	// Token: 0x04002F9D RID: 12189
	public float Timer;

	// Token: 0x04002F9E RID: 12190
	public DayOfWeek EventDay;

	// Token: 0x04002F9F RID: 12191
	public int SpeechPhase = 1;

	// Token: 0x04002FA0 RID: 12192
	public int FriendID = 6;

	// Token: 0x04002FA1 RID: 12193
	public int RivalID = 11;

	// Token: 0x04002FA2 RID: 12194
	public int Phase;

	// Token: 0x04002FA3 RID: 12195
	public int Frame;

	// Token: 0x04002FA4 RID: 12196
	public Vector3 OriginalPosition;

	// Token: 0x04002FA5 RID: 12197
	public Vector3 OriginalRotation;

	// Token: 0x04002FA6 RID: 12198
	public bool LosingFriend;
}
