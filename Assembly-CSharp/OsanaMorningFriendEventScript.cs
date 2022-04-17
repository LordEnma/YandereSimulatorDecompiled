using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class OsanaMorningFriendEventScript : MonoBehaviour
{
	// Token: 0x06001BCF RID: 7119 RVA: 0x00140568 File Offset: 0x0013E768
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

	// Token: 0x06001BD0 RID: 7120 RVA: 0x0014065C File Offset: 0x0013E85C
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

	// Token: 0x06001BD1 RID: 7121 RVA: 0x00140FDC File Offset: 0x0013F1DC
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

	// Token: 0x06001BD2 RID: 7122 RVA: 0x0014137C File Offset: 0x0013F57C
	private void SettleRival()
	{
		this.Rival.MoveTowardsTarget(this.Location[2].position);
		if (Quaternion.Angle(this.Rival.transform.rotation, this.Location[2].rotation) > 1f)
		{
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00141407 File Offset: 0x0013F607
	private void SettleFriend()
	{
		this.Friend.MoveTowardsTarget(this.Location[1].position);
		this.Friend.transform.LookAt(this.Rival.transform.position);
	}

	// Token: 0x06001BD4 RID: 7124 RVA: 0x00141444 File Offset: 0x0013F644
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

	// Token: 0x04003049 RID: 12361
	public RivalMorningEventManagerScript OtherEvent;

	// Token: 0x0400304A RID: 12362
	public StudentManagerScript StudentManager;

	// Token: 0x0400304B RID: 12363
	public EndOfDayScript EndOfDay;

	// Token: 0x0400304C RID: 12364
	public JukeboxScript Jukebox;

	// Token: 0x0400304D RID: 12365
	public UILabel EventSubtitle;

	// Token: 0x0400304E RID: 12366
	public YandereScript Yandere;

	// Token: 0x0400304F RID: 12367
	public ClockScript Clock;

	// Token: 0x04003050 RID: 12368
	public SpyScript Spy;

	// Token: 0x04003051 RID: 12369
	public StudentScript CurrentSpeaker;

	// Token: 0x04003052 RID: 12370
	public StudentScript Friend;

	// Token: 0x04003053 RID: 12371
	public StudentScript Rival;

	// Token: 0x04003054 RID: 12372
	public Transform Epicenter;

	// Token: 0x04003055 RID: 12373
	public Transform[] Location;

	// Token: 0x04003056 RID: 12374
	public AudioClip SpeechClip;

	// Token: 0x04003057 RID: 12375
	public string[] SpeechText;

	// Token: 0x04003058 RID: 12376
	public float[] SpeechTime;

	// Token: 0x04003059 RID: 12377
	public string[] EventAnim;

	// Token: 0x0400305A RID: 12378
	public int[] Speaker;

	// Token: 0x0400305B RID: 12379
	public AudioClip InterruptedClip;

	// Token: 0x0400305C RID: 12380
	public string[] InterruptedSpeech;

	// Token: 0x0400305D RID: 12381
	public float[] InterruptedTime;

	// Token: 0x0400305E RID: 12382
	public string[] InterruptedAnim;

	// Token: 0x0400305F RID: 12383
	public int[] InterruptedSpeaker;

	// Token: 0x04003060 RID: 12384
	public AudioClip AltSpeechClip;

	// Token: 0x04003061 RID: 12385
	public string[] AltSpeechText;

	// Token: 0x04003062 RID: 12386
	public float[] AltSpeechTime;

	// Token: 0x04003063 RID: 12387
	public string[] AltEventAnim;

	// Token: 0x04003064 RID: 12388
	public int[] AltSpeaker;

	// Token: 0x04003065 RID: 12389
	public GameObject AlarmDisc;

	// Token: 0x04003066 RID: 12390
	public GameObject VoiceClip;

	// Token: 0x04003067 RID: 12391
	public Quaternion targetRotation;

	// Token: 0x04003068 RID: 12392
	public float Distance;

	// Token: 0x04003069 RID: 12393
	public float Scale;

	// Token: 0x0400306A RID: 12394
	public float Timer;

	// Token: 0x0400306B RID: 12395
	public DayOfWeek EventDay;

	// Token: 0x0400306C RID: 12396
	public int SpeechPhase = 1;

	// Token: 0x0400306D RID: 12397
	public int FriendID = 6;

	// Token: 0x0400306E RID: 12398
	public int RivalID = 11;

	// Token: 0x0400306F RID: 12399
	public int Phase;

	// Token: 0x04003070 RID: 12400
	public int Frame;

	// Token: 0x04003071 RID: 12401
	public Vector3 OriginalPosition;

	// Token: 0x04003072 RID: 12402
	public Vector3 OriginalRotation;

	// Token: 0x04003073 RID: 12403
	public bool LosingFriend;
}
