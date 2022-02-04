using System;
using UnityEngine;

// Token: 0x020003E1 RID: 993
public class OsanaTuesdayLunchEventScript : MonoBehaviour
{
	// Token: 0x06001BA7 RID: 7079 RVA: 0x0013EFA8 File Offset: 0x0013D1A8
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.PushPrompt.gameObject.SetActive(false);
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BA8 RID: 7080 RVA: 0x0013F000 File Offset: 0x0013D200
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
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[this.RivalID].enabled)
			{
				if (this.StudentManager.Students[this.RivalID].Bullied)
				{
					base.enabled = false;
				}
				else if (this.Clock.Period == 3)
				{
					Debug.Log("Osana's Tuesday lunchtime event has begun.");
					this.Rival = this.StudentManager.Students[this.RivalID];
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location[1];
					this.Rival.CurrentDestination = this.Location[1];
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Rival.EmptyHands();
					Debug.Log("PlayerGlobals.RaibaruLoner is: " + PlayerGlobals.RaibaruLoner.ToString());
					bool flag = true;
					if (PlayerGlobals.RaibaruLoner || this.StudentManager.Police.EndOfDay.RaibaruLoner)
					{
						flag = false;
					}
					if (this.StudentManager.Students[this.FriendID] != null && flag)
					{
						this.Friend = this.StudentManager.Students[this.FriendID];
						this.StudentManager.Patrols.List[10].GetChild(0).localEulerAngles = new Vector3(0f, 180f, 0f);
						this.StudentManager.Patrols.List[10].GetChild(1).localEulerAngles = new Vector3(0f, -135f, 0f);
						this.StudentManager.Patrols.List[10].GetChild(2).localEulerAngles = new Vector3(0f, 180f, 0f);
						this.StudentManager.Patrols.List[10].GetChild(3).localEulerAngles = new Vector3(0f, 135f, 0f);
						ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
						scheduleBlock.destination = "Patrol";
						scheduleBlock.action = "Patrol";
						this.Friend.GetDestinations();
					}
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 17;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[1]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[1]);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= 0.833333f)
			{
				this.Rival.AnimatedBook.SetActive(true);
			}
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= 5f)
			{
				this.EventSubtitle.text = this.SpeechText[1];
			}
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].length)
			{
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 60f)
			{
				AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[3]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[3]);
				this.EventSubtitle.text = this.SpeechText[2];
				this.StretchPhase = 2;
				this.Phase++;
			}
		}
		else if (this.Phase == 4)
		{
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[3]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[3]].length)
			{
				this.Rival.AnimatedBook.transform.parent = null;
				this.PushPrompt.gameObject.SetActive(true);
				this.PushPrompt.enabled = true;
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[this.StretchPhase];
				this.Rival.CurrentDestination = this.Location[this.StretchPhase];
				this.Rival.DistanceToDestination = 100f;
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				if (this.StretchPhase == 2)
				{
					AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.EventSubtitle.text = this.SpeechText[3];
				}
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[4]);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[4]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[4]].length)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.StretchPhase++;
				if (this.StretchPhase < 6)
				{
					this.Rival.Pathfinding.target = this.Location[this.StretchPhase];
					this.Rival.CurrentDestination = this.Location[this.StretchPhase];
					this.Rival.DistanceToDestination = 100f;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Phase--;
				}
				else
				{
					this.PushPrompt.gameObject.SetActive(false);
					if (!this.Sabotaged)
					{
						this.Rival.Pathfinding.target = this.Location[1];
						this.Rival.CurrentDestination = this.Location[1];
						this.Rival.DistanceToDestination = 100f;
						this.Rival.Pathfinding.canSearch = true;
						this.Rival.Pathfinding.canMove = true;
					}
					else
					{
						this.Rival.Pathfinding.target = this.Location[7];
						this.Rival.CurrentDestination = this.Location[7];
						this.Rival.DistanceToDestination = 100f;
						this.Rival.Pathfinding.canSearch = true;
						this.Rival.Pathfinding.canMove = true;
						if (this.Friend != null)
						{
							ScheduleBlock scheduleBlock2 = this.Friend.ScheduleBlocks[4];
							scheduleBlock2.destination = "Follow";
							scheduleBlock2.action = "Follow";
							ScheduleBlock scheduleBlock3 = this.Friend.ScheduleBlocks[6];
							scheduleBlock3.destination = "Follow";
							scheduleBlock3.action = "Follow";
							this.Friend.GetDestinations();
						}
					}
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 7)
		{
			if (!this.Sabotaged)
			{
				if (this.Rival.DistanceToDestination < 0.5f)
				{
					AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[5]);
					this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[5]);
					this.EventSubtitle.text = this.SpeechText[4];
					this.Phase++;
				}
			}
			else if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.Rival.WalkAnim = "f02_sadWalk_00";
				this.Rival.SitAnim = "f02_sadDeskSit_00";
				AudioClipPlayer.Play(this.SpeechClip[6], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[8]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[8]);
				this.EventSubtitle.text = this.SpeechText[6];
				this.Rival.Depressed = true;
				this.Phase = 11;
			}
		}
		else if (this.Phase == 8)
		{
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[5]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[5]].length)
			{
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			if (this.Clock.HourTime > 13.375f)
			{
				AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[6]);
				this.Rival.AnimatedBook.GetComponent<Animation>().CrossFade(this.EventAnim[6]);
				this.EventSubtitle.text = this.SpeechText[5];
				this.Phase++;
			}
		}
		else if (this.Phase == 10)
		{
			if (this.Rival.AnimatedBook.activeInHierarchy && this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].time > 2f)
			{
				this.Rival.AnimatedBook.SetActive(false);
			}
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[6]].length)
			{
				this.EndEvent();
			}
		}
		else if (this.Phase == 11)
		{
			if (this.Rival.AnimatedBook.activeInHierarchy && this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].time > 7f)
			{
				this.Rival.AnimatedBook.SetActive(false);
			}
			if (this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim[8]].length)
			{
				this.Rival.Destinations[4] = this.Location[8];
				if (this.Friend != null)
				{
					this.Friend.Destinations[4] = this.Location[9];
					this.StudentManager.LunchSpots.List[this.FriendID] = this.Location[9];
				}
				this.EndEvent();
			}
		}
		if (this.PushPrompt.Circle[0].fillAmount == 0f)
		{
			this.PushPrompt.Hide();
			this.PushPrompt.gameObject.SetActive(false);
			this.Sabotaging = true;
			this.Yandere.CanMove = false;
			this.Yandere.CharacterAnimation.CrossFade("f02_" + this.EventAnim[7]);
			this.Rival.AnimatedBook.GetComponent<Animation>().Play(this.EventAnim[7]);
			this.Rival.AnimatedBook.transform.eulerAngles = new Vector3(this.Rival.AnimatedBook.transform.eulerAngles.x, 0f, this.Rival.AnimatedBook.transform.eulerAngles.z);
			this.Rival.AnimatedBook.transform.position = new Vector3(this.Rival.AnimatedBook.transform.position.x, this.Rival.AnimatedBook.transform.position.y, -2.8f);
			this.AfterClassEvent.Sabotaged = true;
		}
		if (this.Sabotaging)
		{
			this.Yandere.MoveTowardsTarget(this.Location[6].position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Location[6].rotation, Time.deltaTime * 10f);
			if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time > 1.5f && this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time < 2f && !this.MyAudio.isPlaying)
			{
				this.MyAudio.Play();
			}
			if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].time > this.Yandere.CharacterAnimation["f02_" + this.EventAnim[7]].length)
			{
				this.Yandere.CanMove = true;
				this.Sabotaging = false;
				this.Sabotaged = true;
			}
		}
		if (this.Clock.Period > 3 || this.Rival.Wet || this.Rival.Alarmed)
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
			if (this.VoiceClipSource != null)
			{
				this.VoiceClipSource.volume = this.Scale;
			}
		}
		else
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			if (this.VoiceClipSource != null)
			{
				this.VoiceClipSource.volume = 0f;
			}
		}
		if (this.VoiceClip == null)
		{
			this.EventSubtitle.text = string.Empty;
		}
	}

	// Token: 0x06001BA9 RID: 7081 RVA: 0x001403F0 File Offset: 0x0013E5F0
	private void EndEvent()
	{
		Debug.Log("Osana's Tuesday lunchtime event ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Splashed && !this.Rival.Dodging)
		{
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
		}
		else
		{
			Debug.Log("Osana was told to stop moving.");
			this.Rival.Pathfinding.canSearch = false;
			this.Rival.Pathfinding.canMove = false;
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
			this.Rival.DistanceToDestination = 100f;
		}
		this.Rival.Routine = !this.Rival.Splashed;
		if (this.Friend != null)
		{
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
			scheduleBlock.destination = "Follow";
			scheduleBlock.action = "Follow";
			this.Friend.GetDestinations();
			this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
			this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
			Debug.Log("Raibaru was told to resume ''Follow'' protocol.");
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.AnimatedBook.SetActive(false);
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x04003008 RID: 12296
	public RivalAfterClassEventManagerScript AfterClassEvent;

	// Token: 0x04003009 RID: 12297
	public StudentManagerScript StudentManager;

	// Token: 0x0400300A RID: 12298
	public JukeboxScript Jukebox;

	// Token: 0x0400300B RID: 12299
	public PromptScript PushPrompt;

	// Token: 0x0400300C RID: 12300
	public UILabel EventSubtitle;

	// Token: 0x0400300D RID: 12301
	public YandereScript Yandere;

	// Token: 0x0400300E RID: 12302
	public ClockScript Clock;

	// Token: 0x0400300F RID: 12303
	public StudentScript Friend;

	// Token: 0x04003010 RID: 12304
	public StudentScript Rival;

	// Token: 0x04003011 RID: 12305
	public Transform[] Location;

	// Token: 0x04003012 RID: 12306
	public AudioSource VoiceClipSource;

	// Token: 0x04003013 RID: 12307
	public AudioSource MyAudio;

	// Token: 0x04003014 RID: 12308
	public AudioClip[] SpeechClip;

	// Token: 0x04003015 RID: 12309
	public string[] SpeechText;

	// Token: 0x04003016 RID: 12310
	public string[] EventAnim;

	// Token: 0x04003017 RID: 12311
	public GameObject AlarmDisc;

	// Token: 0x04003018 RID: 12312
	public GameObject VoiceClip;

	// Token: 0x04003019 RID: 12313
	public bool Sabotaging;

	// Token: 0x0400301A RID: 12314
	public bool Sabotaged;

	// Token: 0x0400301B RID: 12315
	public float Distance;

	// Token: 0x0400301C RID: 12316
	public float Scale;

	// Token: 0x0400301D RID: 12317
	public float Timer;

	// Token: 0x0400301E RID: 12318
	public DayOfWeek EventDay;

	// Token: 0x0400301F RID: 12319
	public int StretchPhase;

	// Token: 0x04003020 RID: 12320
	public int FriendID = 10;

	// Token: 0x04003021 RID: 12321
	public int RivalID = 11;

	// Token: 0x04003022 RID: 12322
	public int Phase;

	// Token: 0x04003023 RID: 12323
	public int Frame;
}
