using System;
using UnityEngine;

// Token: 0x020003D7 RID: 983
public class OsanaFridayBeforeClassEvent2Script : MonoBehaviour
{
	// Token: 0x06001B70 RID: 7024 RVA: 0x001359F8 File Offset: 0x00133BF8
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || StudentGlobals.GetStudentKidnapped(this.RivalID) || StudentGlobals.StudentSlave == this.RivalID || StudentGlobals.StudentSlave == 81 || StudentGlobals.GetStudentDead(81) || StudentGlobals.GetStudentKidnapped(81) || StudentGlobals.GetStudentArrested(81) || StudentGlobals.GetStudentExpelled(81) || (float)StudentGlobals.GetStudentReputation(81) < -33.33333f || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B71 RID: 7025 RVA: 0x00135A8C File Offset: 0x00133C8C
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

	// Token: 0x06001B72 RID: 7026 RVA: 0x00136640 File Offset: 0x00134840
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

	// Token: 0x06001B73 RID: 7027 RVA: 0x0013699C File Offset: 0x00134B9C
	private void SettleRival()
	{
		this.Rival.MoveTowardsTarget(this.Location[1].position);
		if (Quaternion.Angle(this.Rival.transform.rotation, this.Location[1].rotation) > 1f)
		{
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location[1].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001B74 RID: 7028 RVA: 0x00136A28 File Offset: 0x00134C28
	private void SettleGanguro()
	{
		this.Ganguro.MoveTowardsTarget(this.Location[2].position);
		if (Quaternion.Angle(this.Ganguro.transform.rotation, this.Location[2].rotation) > 1f)
		{
			this.Ganguro.transform.rotation = Quaternion.Slerp(this.Ganguro.transform.rotation, this.Location[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x04002EF1 RID: 12017
	public OsanaFridayBeforeClassEvent1Script OtherEvent;

	// Token: 0x04002EF2 RID: 12018
	public StudentManagerScript StudentManager;

	// Token: 0x04002EF3 RID: 12019
	public AudioSoftwareScript AudioSoftware;

	// Token: 0x04002EF4 RID: 12020
	public JukeboxScript Jukebox;

	// Token: 0x04002EF5 RID: 12021
	public UILabel EventSubtitle;

	// Token: 0x04002EF6 RID: 12022
	public YandereScript Yandere;

	// Token: 0x04002EF7 RID: 12023
	public ClockScript Clock;

	// Token: 0x04002EF8 RID: 12024
	public SpyScript Spy;

	// Token: 0x04002EF9 RID: 12025
	public StudentScript Ganguro;

	// Token: 0x04002EFA RID: 12026
	public StudentScript Friend;

	// Token: 0x04002EFB RID: 12027
	public StudentScript Rival;

	// Token: 0x04002EFC RID: 12028
	public Transform[] Location;

	// Token: 0x04002EFD RID: 12029
	public AudioClip[] SpeechClip;

	// Token: 0x04002EFE RID: 12030
	public string[] SpeechText;

	// Token: 0x04002EFF RID: 12031
	public float[] SpeechTime;

	// Token: 0x04002F00 RID: 12032
	public string[] EventAnim;

	// Token: 0x04002F01 RID: 12033
	public GameObject AlarmDisc;

	// Token: 0x04002F02 RID: 12034
	public GameObject VoiceClip;

	// Token: 0x04002F03 RID: 12035
	public Quaternion targetRotation;

	// Token: 0x04002F04 RID: 12036
	public float Distance;

	// Token: 0x04002F05 RID: 12037
	public float Scale;

	// Token: 0x04002F06 RID: 12038
	public float Timer;

	// Token: 0x04002F07 RID: 12039
	public DayOfWeek EventDay;

	// Token: 0x04002F08 RID: 12040
	public int SpeechPhase = 1;

	// Token: 0x04002F09 RID: 12041
	public int GanguroID = 81;

	// Token: 0x04002F0A RID: 12042
	public int FriendID = 10;

	// Token: 0x04002F0B RID: 12043
	public int RivalID = 11;

	// Token: 0x04002F0C RID: 12044
	public int Phase;

	// Token: 0x04002F0D RID: 12045
	public int Frame;

	// Token: 0x04002F0E RID: 12046
	public bool IgnoreFriend;

	// Token: 0x04002F0F RID: 12047
	public Vector3 OriginalPosition;

	// Token: 0x04002F10 RID: 12048
	public Vector3 OriginalRotation;
}
