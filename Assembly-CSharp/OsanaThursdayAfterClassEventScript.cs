using System;
using UnityEngine;

// Token: 0x020003E7 RID: 999
public class OsanaThursdayAfterClassEventScript : MonoBehaviour
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x001410F8 File Offset: 0x0013F2F8
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x0014112C File Offset: 0x0013F32C
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

	// Token: 0x06001BD4 RID: 7124 RVA: 0x00141C64 File Offset: 0x0013FE64
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

	// Token: 0x06001BD5 RID: 7125 RVA: 0x00141EBC File Offset: 0x001400BC
	public void ReturnFromSave()
	{
		this.ReturningFromSave = false;
		this.BeginEvent();
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x00141ECC File Offset: 0x001400CC
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

	// Token: 0x04003069 RID: 12393
	public StudentManagerScript StudentManager;

	// Token: 0x0400306A RID: 12394
	public PhoneMinigameScript PhoneMinigame;

	// Token: 0x0400306B RID: 12395
	public JukeboxScript Jukebox;

	// Token: 0x0400306C RID: 12396
	public UILabel EventSubtitle;

	// Token: 0x0400306D RID: 12397
	public YandereScript Yandere;

	// Token: 0x0400306E RID: 12398
	public ClockScript Clock;

	// Token: 0x0400306F RID: 12399
	public StudentScript Friend;

	// Token: 0x04003070 RID: 12400
	public StudentScript Rival;

	// Token: 0x04003071 RID: 12401
	public Transform FriendLocation;

	// Token: 0x04003072 RID: 12402
	public Transform Location;

	// Token: 0x04003073 RID: 12403
	public AudioClip[] SpeechClip;

	// Token: 0x04003074 RID: 12404
	public string[] SpeechText;

	// Token: 0x04003075 RID: 12405
	public string[] EventAnim;

	// Token: 0x04003076 RID: 12406
	public GameObject AlarmDisc;

	// Token: 0x04003077 RID: 12407
	public GameObject VoiceClip;

	// Token: 0x04003078 RID: 12408
	public float FriendWarningTimer;

	// Token: 0x04003079 RID: 12409
	public float ReturnTimer;

	// Token: 0x0400307A RID: 12410
	public float Distance;

	// Token: 0x0400307B RID: 12411
	public float Scale;

	// Token: 0x0400307C RID: 12412
	public float Timer;

	// Token: 0x0400307D RID: 12413
	public DayOfWeek EventDay;

	// Token: 0x0400307E RID: 12414
	public int FriendID = 10;

	// Token: 0x0400307F RID: 12415
	public int RivalID = 11;

	// Token: 0x04003080 RID: 12416
	public int Phase;

	// Token: 0x04003081 RID: 12417
	public int Frame;

	// Token: 0x04003082 RID: 12418
	public bool ReturningFromSave;

	// Token: 0x04003083 RID: 12419
	public bool FriendWarned;

	// Token: 0x04003084 RID: 12420
	public bool Sabotaged;

	// Token: 0x04003085 RID: 12421
	public Vector3 OriginalPosition;

	// Token: 0x04003086 RID: 12422
	public Vector3 OriginalRotation;
}
