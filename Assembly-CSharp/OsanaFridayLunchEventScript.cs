using System;
using UnityEngine;

// Token: 0x020003E4 RID: 996
public class OsanaFridayLunchEventScript : MonoBehaviour
{
	// Token: 0x06001BC6 RID: 7110 RVA: 0x0013D3C8 File Offset: 0x0013B5C8
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.Spy.Prompt.enabled = false;
		this.Spy.Prompt.Hide();
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BC7 RID: 7111 RVA: 0x0013D430 File Offset: 0x0013B630
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0)
			{
				this.Senpai = this.StudentManager.Students[1];
				if (this.StudentManager.Students[this.RivalID] != null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				else
				{
					base.enabled = false;
				}
			}
			if (this.Frame > 1 && this.Clock.HourTime > 13f && this.Senpai.gameObject.activeInHierarchy && this.Rival != null)
			{
				if (this.Rival.Bullied)
				{
					base.enabled = false;
				}
				else
				{
					if (!this.Senpai.InEvent)
					{
						this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
						this.Senpai.Pathfinding.target = this.Location[1];
						this.Senpai.CurrentDestination = this.Location[1];
						this.Senpai.Pathfinding.canSearch = true;
						this.Senpai.Pathfinding.canMove = true;
						this.Senpai.SmartPhone.SetActive(false);
						this.Senpai.InEvent = true;
						this.Senpai.DistanceToDestination = 100f;
						this.Spy.Prompt.enabled = true;
					}
					if (this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless)
					{
						Debug.Log("Osana's Friday lunch event has begun.");
						this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
						this.Rival.Pathfinding.target = this.Location[2];
						this.Rival.CurrentDestination = this.Location[2];
						this.Rival.Pathfinding.canSearch = true;
						this.Rival.Pathfinding.canMove = true;
						this.Rival.SmartPhone.SetActive(false);
						this.Rival.InEvent = true;
						this.Rival.DistanceToDestination = 100f;
						this.Spy.Prompt.enabled = true;
					}
					if (this.StudentManager.Students[this.FriendID] != null && !PlayerGlobals.RaibaruLoner)
					{
						this.Friend = this.StudentManager.Students[this.FriendID];
					}
					if (this.Senpai.CurrentDestination == this.Location[1] && this.Senpai.DistanceToDestination < 0.5f)
					{
						if (!this.Impatient)
						{
							this.Senpai.CharacterAnimation.CrossFade("waiting_00");
							this.Senpai.Pathfinding.canSearch = false;
							this.Senpai.Pathfinding.canMove = false;
						}
						else if (this.Senpai.CharacterAnimation["impatience_00"].time >= this.Senpai.CharacterAnimation["impatience_00"].length)
						{
							this.EndEvent();
						}
					}
					if (this.Rival.CurrentDestination == this.Location[2] && this.Rival.DistanceToDestination < 0.5f)
					{
						this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
						this.Rival.Pathfinding.canSearch = false;
						this.Rival.Pathfinding.canMove = false;
					}
					if (!this.HintGiven)
					{
						this.Yandere.PauseScreen.Hint.Show = true;
						this.Yandere.PauseScreen.Hint.QuickID = 7;
						this.HintGiven = true;
					}
					if (this.Rival.CurrentDestination == this.Location[2] && this.Senpai.CurrentDestination == this.Location[1] && this.Senpai.DistanceToDestination < 0.5f && this.Rival.DistanceToDestination < 0.5f && !this.Impatient)
					{
						this.Phase++;
					}
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			this.Sabotaged = this.AudioSoftware.AudioDoctored;
			if (this.Rival.Phoneless)
			{
				this.Cancelled = true;
			}
			if (this.Cancelled)
			{
				AudioClipPlayer.Play(this.CancelledSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Transfer = false;
				this.TakeOut = false;
				this.Suffix = "C";
			}
			else if (!this.Sabotaged)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.TakeOutTime = 2.5f;
				this.TransferTime = 7f;
				this.ReturnTime = 19.33333f;
				this.PutAwayTime = 24.33333f;
				this.Suffix = "A";
			}
			else
			{
				AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.TakeOutTime = 2.5f;
				this.TransferTime = 7f;
				this.ReturnTime = 16.66666f;
				this.PutAwayTime = 21.5f;
				this.Suffix = "B";
			}
			this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_3" + this.Suffix);
			this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_3" + this.Suffix);
			this.Timer = 0f;
			this.Phase++;
			if (this.Friend != null)
			{
				this.Friend.CurrentDestination = this.Location[3];
				this.Friend.Pathfinding.target = this.Location[3];
				this.Friend.IdleAnim = "f02_cornerPeek_00";
				this.Friend.SlideIn = true;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (this.Cancelled)
			{
				if (this.SpeechPhase < this.CancelledSpeechTime.Length && this.Timer > this.CancelledSpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.CancelledSpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else if (!this.Sabotaged)
			{
				if (this.SpeechPhase < this.SpeechTime.Length && this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else
			{
				if (this.SpeechPhase < this.SabotagedSpeechTime.Length && this.Timer > this.SabotagedSpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SabotagedSpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
				if (this.Senpai.CharacterAnimation[this.Weekday + "_3" + this.Suffix].time >= this.Senpai.CharacterAnimation[this.Weekday + "_3" + this.Suffix].length)
				{
					ScheduleBlock scheduleBlock = this.Senpai.ScheduleBlocks[4];
					scheduleBlock.destination = "Hangout";
					scheduleBlock.action = "Eat";
					this.Senpai.GetDestinations();
					if (this.Senpai.InEvent)
					{
						this.Rival.StopRotating = true;
						this.LookAtSenpai = true;
						this.EndSenpai();
					}
				}
				if (this.LookAtSenpai)
				{
					this.Rival.targetRotation = Quaternion.LookRotation(this.Senpai.transform.position - this.Rival.transform.position);
					this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.targetRotation, 10f * Time.deltaTime);
				}
			}
			if (this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time >= this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].length)
			{
				this.EndEvent();
			}
			if (this.TakeOut && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.TakeOutTime)
			{
				this.Rival.SmartPhone.SetActive(true);
				this.TakeOut = false;
				this.PutAway = true;
			}
			if (this.PutAway && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.PutAwayTime)
			{
				this.Rival.SmartPhone.SetActive(false);
				this.PutAway = false;
			}
			if (this.Transfer && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.TransferTime)
			{
				this.OriginalRotation = this.Rival.SmartPhone.transform.localEulerAngles;
				this.OriginalPosition = this.Rival.SmartPhone.transform.localPosition;
				this.Rival.SmartPhone.transform.parent = this.Senpai.SmartPhone.transform.parent;
				this.Rival.SmartPhone.transform.localEulerAngles = this.Senpai.SmartPhone.transform.localEulerAngles;
				this.Rival.SmartPhone.transform.localPosition = this.Senpai.SmartPhone.transform.localPosition;
				this.Transfer = false;
				this.Return = true;
			}
			if (this.Return && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.ReturnTime)
			{
				this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
				this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
				this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
				this.Return = false;
			}
			if (this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Splashed || this.Rival.Dodging || this.Clock.Period == 4)
			{
				if (!this.Rival.Splashed)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				}
				this.EndEvent();
			}
		}
		if (base.enabled && (this.Phase > 0 || this.Impatient))
		{
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
				this.Yandere.Eavesdropping = (this.Distance < 2.5f);
				return;
			}
			this.EventSubtitle.transform.localScale = Vector3.zero;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
			}
		}
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x0013E264 File Offset: 0x0013C464
	public void EndEvent()
	{
		Debug.Log("Osana's Friday lunchtime event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Senpai.InEvent)
		{
			this.EndSenpai();
		}
		if (!this.Rival.Ragdoll.Zs.activeInHierarchy)
		{
			if (!this.Rival.Alarmed)
			{
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.SmartPhone.SetActive(false);
			this.Rival.Prompt.enabled = true;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.DistanceToDestination = 100f;
			this.Rival.Pathfinding.speed = 1f;
			this.Rival.StopRotating = false;
			this.Rival.Hurry = false;
		}
		if (this.Friend != null)
		{
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
			scheduleBlock.destination = "LunchSpot";
			scheduleBlock.action = "Eat";
			this.Friend.GetDestinations();
			this.Friend.CurrentDestination = this.Friend.Destinations[this.Friend.Phase];
			this.Friend.Pathfinding.target = this.Friend.Destinations[this.Friend.Phase];
			this.Friend.DistanceToDestination = 100f;
			this.Friend.IdleAnim = this.Friend.OriginalIdleAnim;
			this.Friend.SlideIn = false;
			Debug.Log("''Friend'' is being told to set her destination to her current phase's destination.");
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
		if (this.Sabotaged)
		{
			this.Rival.WalkAnim = "f02_sadWalk_00";
		}
		if (this.Rival.SmartPhone.transform.parent != this.Rival.ItemParent)
		{
			this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
			this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
			this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
		}
		this.Jukebox.Dip = 1f;
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x06001BC9 RID: 7113 RVA: 0x0013E5AC File Offset: 0x0013C7AC
	private void EndSenpai()
	{
		if (!this.Senpai.Alarmed)
		{
			this.Senpai.Pathfinding.canSearch = true;
			this.Senpai.Pathfinding.canMove = true;
			this.Senpai.Routine = true;
		}
		this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Senpai.SmartPhone.SetActive(false);
		this.Senpai.InEvent = false;
		this.Senpai.Private = false;
		this.Senpai.CurrentDestination = this.Senpai.Destinations[this.Senpai.Phase];
		this.Senpai.Pathfinding.target = this.Senpai.Destinations[this.Senpai.Phase];
		this.Senpai.DistanceToDestination = 100f;
		if (this.Sabotaged)
		{
			this.StudentManager.SabotageProgress++;
			Debug.Log("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5");
		}
	}

	// Token: 0x04002FED RID: 12269
	public StudentManagerScript StudentManager;

	// Token: 0x04002FEE RID: 12270
	public AudioSoftwareScript AudioSoftware;

	// Token: 0x04002FEF RID: 12271
	public JukeboxScript Jukebox;

	// Token: 0x04002FF0 RID: 12272
	public UILabel EventSubtitle;

	// Token: 0x04002FF1 RID: 12273
	public YandereScript Yandere;

	// Token: 0x04002FF2 RID: 12274
	public ClockScript Clock;

	// Token: 0x04002FF3 RID: 12275
	public SpyScript Spy;

	// Token: 0x04002FF4 RID: 12276
	public StudentScript Friend;

	// Token: 0x04002FF5 RID: 12277
	public StudentScript Senpai;

	// Token: 0x04002FF6 RID: 12278
	public StudentScript Rival;

	// Token: 0x04002FF7 RID: 12279
	public Transform[] Location;

	// Token: 0x04002FF8 RID: 12280
	public Transform Epicenter;

	// Token: 0x04002FF9 RID: 12281
	public AudioClip CancelledSpeechClip;

	// Token: 0x04002FFA RID: 12282
	public string[] CancelledSpeechText;

	// Token: 0x04002FFB RID: 12283
	public float[] CancelledSpeechTime;

	// Token: 0x04002FFC RID: 12284
	public AudioClip SabotagedSpeechClip;

	// Token: 0x04002FFD RID: 12285
	public string[] SabotagedSpeechText;

	// Token: 0x04002FFE RID: 12286
	public float[] SabotagedSpeechTime;

	// Token: 0x04002FFF RID: 12287
	public AudioClip SpeechClip;

	// Token: 0x04003000 RID: 12288
	public string[] SpeechText;

	// Token: 0x04003001 RID: 12289
	public float[] SpeechTime;

	// Token: 0x04003002 RID: 12290
	public GameObject AlarmDisc;

	// Token: 0x04003003 RID: 12291
	public GameObject VoiceClip;

	// Token: 0x04003004 RID: 12292
	public bool LookAtSenpai;

	// Token: 0x04003005 RID: 12293
	public bool EventActive;

	// Token: 0x04003006 RID: 12294
	public bool Cancelled;

	// Token: 0x04003007 RID: 12295
	public bool HintGiven;

	// Token: 0x04003008 RID: 12296
	public bool Impatient;

	// Token: 0x04003009 RID: 12297
	public bool Sabotaged;

	// Token: 0x0400300A RID: 12298
	public bool Transfer;

	// Token: 0x0400300B RID: 12299
	public bool TakeOut;

	// Token: 0x0400300C RID: 12300
	public bool PutAway;

	// Token: 0x0400300D RID: 12301
	public bool Return;

	// Token: 0x0400300E RID: 12302
	public Vector3 OriginalRotation;

	// Token: 0x0400300F RID: 12303
	public Vector3 OriginalPosition;

	// Token: 0x04003010 RID: 12304
	public float TransferTime;

	// Token: 0x04003011 RID: 12305
	public float ReturnTime;

	// Token: 0x04003012 RID: 12306
	public float TakeOutTime;

	// Token: 0x04003013 RID: 12307
	public float PutAwayTime;

	// Token: 0x04003014 RID: 12308
	public float Distance;

	// Token: 0x04003015 RID: 12309
	public float Scale;

	// Token: 0x04003016 RID: 12310
	public float Timer;

	// Token: 0x04003017 RID: 12311
	public DayOfWeek EventDay;

	// Token: 0x04003018 RID: 12312
	public int SpeechPhase = 1;

	// Token: 0x04003019 RID: 12313
	public int FriendID = 10;

	// Token: 0x0400301A RID: 12314
	public int RivalID = 11;

	// Token: 0x0400301B RID: 12315
	public int Phase;

	// Token: 0x0400301C RID: 12316
	public int Frame;

	// Token: 0x0400301D RID: 12317
	public string Weekday = string.Empty;

	// Token: 0x0400301E RID: 12318
	public string Suffix = string.Empty;
}
