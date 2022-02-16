using System;
using UnityEngine;

// Token: 0x020003E1 RID: 993
public class OsanaThursdayAfterClassEventScript : MonoBehaviour
{
	// Token: 0x06001BAA RID: 7082 RVA: 0x0013E530 File Offset: 0x0013C730
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BAB RID: 7083 RVA: 0x0013E564 File Offset: 0x0013C764
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null)
			{
				if (this.Rival == null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				if (this.StudentManager.Students[this.FriendID] != null && !PlayerGlobals.RaibaruLoner)
				{
					this.Friend = this.StudentManager.Students[this.FriendID];
				}
				if (this.Clock.HourTime > 16.01f && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless && !this.Rival.EndSearch)
				{
					this.BeginEvent();
				}
			}
			this.Frame++;
		}
		else
		{
			if (this.Phase == 1)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.Yandere.transform.position = this.Location.position + new Vector3(2f, 0f, 2f);
					this.Rival.transform.position = this.Location.position + new Vector3(1f, 0f, 1f);
				}
				if (this.Rival.DistanceToDestination < 0.5f)
				{
					AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Rival.CharacterAnimation.CrossFade(this.EventAnim[1]);
					this.Rival.Pathfinding.canSearch = false;
					this.Rival.Pathfinding.canMove = false;
					this.Rival.Obstacle.enabled = true;
					this.Phase++;
					if (this.Friend != null)
					{
						ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[7];
						scheduleBlock.destination = "Sketch";
						scheduleBlock.action = "Sketch";
						this.Friend.GetDestinations();
						this.Friend.SketchPosition = this.FriendLocation;
						this.Friend.CurrentDestination = this.Friend.SketchPosition;
						this.Friend.Pathfinding.target = this.Friend.SketchPosition;
						this.Friend.Restless = true;
					}
				}
			}
			else if (this.Phase == 2)
			{
				this.Rival.transform.position = Vector3.Lerp(this.Rival.transform.position, this.Rival.CurrentDestination.position, 10f * Time.deltaTime);
				this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
				if ((double)this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 3.2)
				{
					this.EventSubtitle.text = this.SpeechText[1];
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				if (this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 6f)
				{
					this.Rival.SmartPhoneScreen.enabled = true;
					this.Rival.SmartPhone.SetActive(true);
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if ((double)this.Rival.CharacterAnimation[this.EventAnim[1]].time >= 13.33333)
				{
					this.OriginalPosition = this.Rival.SmartPhone.transform.localPosition;
					this.OriginalRotation = this.Rival.SmartPhone.transform.localEulerAngles;
					this.Rival.SmartPhone.transform.parent = null;
					this.Rival.SmartPhone.transform.position = new Vector3(0.5f, 12.5042f, -29.365f);
					this.Rival.SmartPhone.transform.eulerAngles = new Vector3(0f, 180f, 180f);
					this.Phase++;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Rival.CharacterAnimation[this.EventAnim[1]].time >= this.Rival.CharacterAnimation[this.EventAnim[1]].length)
				{
					this.Rival.CharacterAnimation.Play(this.EventAnim[2]);
					this.PhoneMinigame.Prompt.enabled = true;
					this.Rival.Ragdoll.Zs.SetActive(true);
					this.EventSubtitle.text = "";
					this.Rival.Distracted = true;
					this.Phase++;
					this.StudentManager.UpdateMe(this.RivalID);
				}
			}
			else if (this.Phase == 6)
			{
				if (!this.Sabotaged && !this.PhoneMinigame.Tampering)
				{
					if (this.Friend != null && !this.FriendWarned)
					{
						if (this.FriendWarningTimer == 0f)
						{
							if (Vector3.Distance(this.Yandere.transform.position, this.Friend.transform.position) < 5f)
							{
								AudioClipPlayer.Play(this.SpeechClip[3], this.Friend.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
								this.EventSubtitle.text = this.SpeechText[3];
								this.FriendWarningTimer += Time.deltaTime;
							}
						}
						else
						{
							this.FriendWarningTimer += Time.deltaTime;
							if (this.FriendWarningTimer > 5f)
							{
								this.FriendWarned = true;
							}
						}
					}
					if ((double)this.Clock.HourTime > 17.2)
					{
						AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
						this.Rival.CharacterAnimation.CrossFade(this.EventAnim[3]);
						this.Rival.Ragdoll.Zs.SetActive(false);
						this.Rival.Hurry = true;
						this.Phase++;
						this.PhoneMinigame.Prompt.enabled = false;
						this.PhoneMinigame.Prompt.Hide();
					}
				}
			}
			else if (this.Phase == 7)
			{
				if ((double)this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 2.5)
				{
					this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
					this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
					this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
					this.Phase++;
				}
			}
			else if (this.Phase == 8)
			{
				if ((double)this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 3.5)
				{
					this.Rival.SmartPhone.SetActive(false);
					this.Phase++;
				}
			}
			else if (this.Phase == 9)
			{
				if ((double)this.Rival.CharacterAnimation[this.EventAnim[3]].time >= 4.65)
				{
					this.EventSubtitle.text = this.SpeechText[2];
					this.Phase++;
				}
			}
			else if (this.Phase == 10 && this.Rival.CharacterAnimation[this.EventAnim[3]].time >= this.Rival.CharacterAnimation[this.EventAnim[3]].length)
			{
				this.EndEvent();
			}
			if (this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging || this.Rival.DiscCheck)
			{
				this.EndEvent();
			}
			if (!this.Sabotaged)
			{
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
		}
		if (this.ReturningFromSave)
		{
			this.ReturnTimer += Time.deltaTime;
			if (this.ReturnTimer > 1f)
			{
				this.ReturnFromSave();
			}
		}
	}

	// Token: 0x06001BAC RID: 7084 RVA: 0x0013F09C File Offset: 0x0013D29C
	public void EndEvent()
	{
		Debug.Log("Osana's Thursday after class event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
			this.Rival.DistanceToDestination = 100f;
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.SmartPhoneScreen.enabled = false;
		this.Rival.Ragdoll.Zs.SetActive(false);
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.Distracted = false;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
		this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
		this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
		if (this.Friend != null)
		{
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[7];
			scheduleBlock.destination = "Follow";
			scheduleBlock.action = "Follow";
			this.Friend.GetDestinations();
			this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
			this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
			this.Friend.Restless = false;
			this.Friend.EmptyHands();
		}
		this.PhoneMinigame.Prompt.enabled = false;
		this.PhoneMinigame.Prompt.Hide();
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x06001BAD RID: 7085 RVA: 0x0013F2F4 File Offset: 0x0013D4F4
	public void ReturnFromSave()
	{
		this.ReturningFromSave = false;
		this.BeginEvent();
	}

	// Token: 0x06001BAE RID: 7086 RVA: 0x0013F304 File Offset: 0x0013D504
	public void BeginEvent()
	{
		Debug.Log("Osana's Thursday after class event has begun.");
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
		this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
		this.Rival.Pathfinding.target = this.Location;
		this.Rival.CurrentDestination = this.Location;
		this.Rival.Pathfinding.canSearch = true;
		this.Rival.Pathfinding.canMove = true;
		this.Rival.Routine = false;
		this.Rival.InEvent = true;
		this.Rival.Drownable = false;
		this.Rival.StudentManager.UpdateMe(this.Rival.StudentID);
		this.Rival.Scrubber.SetActive(false);
		this.Rival.Eraser.SetActive(false);
		this.Yandere.PauseScreen.Hint.Show = true;
		this.Yandere.PauseScreen.Hint.QuickID = 19;
		this.Phase = 1;
	}

	// Token: 0x04002FF3 RID: 12275
	public StudentManagerScript StudentManager;

	// Token: 0x04002FF4 RID: 12276
	public PhoneMinigameScript PhoneMinigame;

	// Token: 0x04002FF5 RID: 12277
	public JukeboxScript Jukebox;

	// Token: 0x04002FF6 RID: 12278
	public UILabel EventSubtitle;

	// Token: 0x04002FF7 RID: 12279
	public YandereScript Yandere;

	// Token: 0x04002FF8 RID: 12280
	public ClockScript Clock;

	// Token: 0x04002FF9 RID: 12281
	public StudentScript Friend;

	// Token: 0x04002FFA RID: 12282
	public StudentScript Rival;

	// Token: 0x04002FFB RID: 12283
	public Transform FriendLocation;

	// Token: 0x04002FFC RID: 12284
	public Transform Location;

	// Token: 0x04002FFD RID: 12285
	public AudioClip[] SpeechClip;

	// Token: 0x04002FFE RID: 12286
	public string[] SpeechText;

	// Token: 0x04002FFF RID: 12287
	public string[] EventAnim;

	// Token: 0x04003000 RID: 12288
	public GameObject AlarmDisc;

	// Token: 0x04003001 RID: 12289
	public GameObject VoiceClip;

	// Token: 0x04003002 RID: 12290
	public float FriendWarningTimer;

	// Token: 0x04003003 RID: 12291
	public float ReturnTimer;

	// Token: 0x04003004 RID: 12292
	public float Distance;

	// Token: 0x04003005 RID: 12293
	public float Scale;

	// Token: 0x04003006 RID: 12294
	public float Timer;

	// Token: 0x04003007 RID: 12295
	public DayOfWeek EventDay;

	// Token: 0x04003008 RID: 12296
	public int FriendID = 10;

	// Token: 0x04003009 RID: 12297
	public int RivalID = 11;

	// Token: 0x0400300A RID: 12298
	public int Phase;

	// Token: 0x0400300B RID: 12299
	public int Frame;

	// Token: 0x0400300C RID: 12300
	public bool ReturningFromSave;

	// Token: 0x0400300D RID: 12301
	public bool FriendWarned;

	// Token: 0x0400300E RID: 12302
	public bool Sabotaged;

	// Token: 0x0400300F RID: 12303
	public Vector3 OriginalPosition;

	// Token: 0x04003010 RID: 12304
	public Vector3 OriginalRotation;
}
