using System;
using UnityEngine;

// Token: 0x020003DD RID: 989
public class OsanaFridayBeforeClassEvent2Script : MonoBehaviour
{
	// Token: 0x06001B98 RID: 7064 RVA: 0x00139AD4 File Offset: 0x00137CD4
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || StudentGlobals.GetStudentKidnapped(this.RivalID) || StudentGlobals.StudentSlave == this.RivalID || StudentGlobals.StudentSlave == 81 || StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || (float)StudentGlobals.GetStudentReputation(81) < -33.33333f || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B99 RID: 7065 RVA: 0x00139B68 File Offset: 0x00137D68
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[this.GanguroID] != null)
			{
				if (this.Ganguro == null)
				{
					this.Ganguro = this.StudentManager.Students[this.GanguroID];
				}
				if (this.Rival == null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				if (this.Friend == null && this.StudentManager.Students[this.FriendID] != null && !PlayerGlobals.RaibaruLoner)
				{
					this.Friend = this.StudentManager.Students[this.FriendID];
				}
				if ((double)this.Clock.HourTime > 7.25 && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Meeting && this.Rival.Indoors && !this.Rival.Wet && !this.Rival.Following && this.Rival.DistanceToDestination < 1f)
				{
					Debug.Log("Osana's ''Talk with Musume'' event has begun.");
					this.Ganguro.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
					this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.SprintAnim);
					this.Ganguro.Pathfinding.target = this.Rival.transform;
					this.Ganguro.CurrentDestination = this.Rival.transform;
					this.Ganguro.Pathfinding.canSearch = true;
					this.Ganguro.Pathfinding.canMove = true;
					this.Ganguro.Pathfinding.speed = 4f;
					this.Ganguro.SpeechLines.Stop();
					this.Ganguro.Routine = false;
					this.Ganguro.InEvent = true;
					this.Rival.InEvent = true;
					if (this.Friend != null && this.Friend.CurrentAction != StudentActionType.Follow)
					{
						this.IgnoreFriend = true;
						this.Friend = null;
					}
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 24;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			Input.GetKeyDown(KeyCode.Space);
			if (this.Ganguro.DistanceToDestination < 1f)
			{
				AudioClipPlayer.Play(this.SpeechClip[1], this.Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Rival.SpeechLines.Stop();
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Ganguro.CharacterAnimation.CrossFade(this.EventAnim[2]);
				this.Ganguro.Pathfinding.canSearch = false;
				this.Ganguro.Pathfinding.canMove = false;
				this.Ganguro.Obstacle.enabled = true;
				this.EventSubtitle.text = this.SpeechText[1];
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.targetRotation = Quaternion.LookRotation(this.Ganguro.transform.position - this.Rival.transform.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			this.targetRotation = Quaternion.LookRotation(this.Rival.transform.position - this.Ganguro.transform.position);
			this.Ganguro.transform.rotation = Quaternion.Slerp(this.Ganguro.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
			if (this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 4f)
			{
				this.EventSubtitle.text = this.SpeechText[2];
				this.Ganguro.Pathfinding.speed = 1f;
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Rival.CharacterAnimation[this.EventAnim[1]].time >= this.Rival.CharacterAnimation[this.EventAnim[1]].length)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[1];
				this.Rival.CurrentDestination = this.Location[1];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.WalkAnim);
				this.Ganguro.Pathfinding.target = this.Location[2];
				this.Ganguro.CurrentDestination = this.Location[2];
				this.Ganguro.Pathfinding.canSearch = true;
				this.Ganguro.Pathfinding.canMove = true;
				this.Spy.Prompt.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			if (this.Friend != null && this.Rival.DistanceToDestination < 5f)
			{
				this.Friend.CurrentDestination = this.Location[3];
				this.Friend.Pathfinding.target = this.Location[3];
				this.Friend.DistanceToDestination = 0.5f;
				this.Friend.IdleAnim = "f02_spying_00";
				this.Friend.SlideIn = true;
			}
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
				this.SettleRival();
			}
			if (this.Ganguro.DistanceToDestination < 0.5f)
			{
				this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.IdleAnim);
				this.SettleGanguro();
			}
			if (this.Rival.DistanceToDestination < 0.5f && this.Ganguro.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[2], this.Ganguro.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Ganguro.CharacterAnimation.CrossFade(this.EventAnim[4]);
				this.Ganguro.Pathfinding.canSearch = false;
				this.Ganguro.Pathfinding.canMove = false;
				this.Ganguro.Obstacle.enabled = true;
				this.Jukebox.Volume = this.Jukebox.Volume * 0.1f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (this.SpeechPhase < this.SpeechTime.Length && this.Timer > this.SpeechTime[this.SpeechPhase])
			{
				this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
				this.SpeechPhase++;
			}
			if ((double)this.Timer > 3.9 && this.Spy.CanRecord)
			{
				this.Spy.PromptBar.Label[0].text = "";
				this.Spy.PromptBar.UpdateButtons();
				this.Spy.CanRecord = false;
			}
			this.SettleRival();
			this.SettleGanguro();
			if (this.Rival.CharacterAnimation[this.EventAnim[3]].time >= this.Rival.CharacterAnimation[this.EventAnim[3]].length)
			{
				this.EndEvent();
			}
		}
		if (this.Rival.Alarmed || this.Clock.HourTime > 8f || this.Rival.Splashed)
		{
			this.EndEvent();
		}
		this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
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
		}
		else
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
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

	// Token: 0x06001B9A RID: 7066 RVA: 0x0013A71C File Offset: 0x0013891C
	public void EndEvent()
	{
		Debug.Log("Osana's second Friday before class event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Rival != null)
		{
			if (this.Rival.enabled && !this.Rival.Alarmed)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.DistanceToDestination = 100f;
				this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.Obstacle.enabled = false;
			this.Rival.Prompt.enabled = true;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			if (!this.Ganguro.Alarmed)
			{
				this.Ganguro.CharacterAnimation.CrossFade(this.Ganguro.WalkAnim);
				this.Ganguro.DistanceToDestination = 100f;
				this.Ganguro.CurrentDestination = this.Ganguro.Destinations[this.Ganguro.Phase];
				this.Ganguro.Pathfinding.target = this.Ganguro.Destinations[this.Ganguro.Phase];
				this.Ganguro.Pathfinding.canSearch = true;
				this.Ganguro.Pathfinding.canMove = true;
				this.Ganguro.Routine = true;
			}
			this.Ganguro.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Ganguro.Obstacle.enabled = false;
			this.Ganguro.Prompt.enabled = true;
			this.Ganguro.InEvent = false;
			this.Ganguro.Private = false;
			if (this.Friend != null)
			{
				this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
				this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
				this.Friend.IdleAnim = this.Friend.OriginalIdleAnim;
				this.Friend.DistanceToDestination = 1f;
				this.Friend.SlideIn = false;
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
		if (this.Spy.Recording)
		{
			this.AudioSoftware.ConversationRecorded = true;
		}
		this.EventSubtitle.text = string.Empty;
		this.Jukebox.Dip = 1f;
		base.enabled = false;
	}

	// Token: 0x06001B9B RID: 7067 RVA: 0x0013AA78 File Offset: 0x00138C78
	private void SettleRival()
	{
		this.Rival.MoveTowardsTarget(this.Location[1].position);
		if (Quaternion.Angle(this.Rival.transform.rotation, this.Location[1].rotation) > 1f)
		{
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[1].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x0013AB04 File Offset: 0x00138D04
	private void SettleGanguro()
	{
		this.Ganguro.MoveTowardsTarget(this.Location[2].position);
		if (Quaternion.Angle(this.Ganguro.transform.rotation, this.Location[2].rotation) > 1f)
		{
			this.Ganguro.transform.rotation = Quaternion.Slerp(this.Ganguro.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x04002F63 RID: 12131
	public OsanaFridayBeforeClassEvent1Script OtherEvent;

	// Token: 0x04002F64 RID: 12132
	public StudentManagerScript StudentManager;

	// Token: 0x04002F65 RID: 12133
	public AudioSoftwareScript AudioSoftware;

	// Token: 0x04002F66 RID: 12134
	public JukeboxScript Jukebox;

	// Token: 0x04002F67 RID: 12135
	public UILabel EventSubtitle;

	// Token: 0x04002F68 RID: 12136
	public YandereScript Yandere;

	// Token: 0x04002F69 RID: 12137
	public ClockScript Clock;

	// Token: 0x04002F6A RID: 12138
	public SpyScript Spy;

	// Token: 0x04002F6B RID: 12139
	public StudentScript Ganguro;

	// Token: 0x04002F6C RID: 12140
	public StudentScript Friend;

	// Token: 0x04002F6D RID: 12141
	public StudentScript Rival;

	// Token: 0x04002F6E RID: 12142
	public Transform[] Location;

	// Token: 0x04002F6F RID: 12143
	public AudioClip[] SpeechClip;

	// Token: 0x04002F70 RID: 12144
	public string[] SpeechText;

	// Token: 0x04002F71 RID: 12145
	public float[] SpeechTime;

	// Token: 0x04002F72 RID: 12146
	public string[] EventAnim;

	// Token: 0x04002F73 RID: 12147
	public GameObject AlarmDisc;

	// Token: 0x04002F74 RID: 12148
	public GameObject VoiceClip;

	// Token: 0x04002F75 RID: 12149
	public Quaternion targetRotation;

	// Token: 0x04002F76 RID: 12150
	public float Distance;

	// Token: 0x04002F77 RID: 12151
	public float Scale;

	// Token: 0x04002F78 RID: 12152
	public float Timer;

	// Token: 0x04002F79 RID: 12153
	public DayOfWeek EventDay;

	// Token: 0x04002F7A RID: 12154
	public int SpeechPhase = 1;

	// Token: 0x04002F7B RID: 12155
	public int GanguroID = 81;

	// Token: 0x04002F7C RID: 12156
	public int FriendID = 10;

	// Token: 0x04002F7D RID: 12157
	public int RivalID = 11;

	// Token: 0x04002F7E RID: 12158
	public int Phase;

	// Token: 0x04002F7F RID: 12159
	public int Frame;

	// Token: 0x04002F80 RID: 12160
	public bool IgnoreFriend;

	// Token: 0x04002F81 RID: 12161
	public Vector3 OriginalPosition;

	// Token: 0x04002F82 RID: 12162
	public Vector3 OriginalRotation;
}
