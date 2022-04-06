using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class RivalAfterClassEventManagerScript : MonoBehaviour
{
	// Token: 0x06001BE4 RID: 7140 RVA: 0x00144974 File Offset: 0x00142B74
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

	// Token: 0x06001BE5 RID: 7141 RVA: 0x001449DC File Offset: 0x00142BDC
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
			if (this.Frame > 1 && this.Clock.HourTime > 17.25f && this.Senpai.gameObject.activeInHierarchy && this.Rival != null)
			{
				if ((this.Senpai.Leaving || this.Senpai.CurrentDestination == this.StudentManager.Exit) && !this.Senpai.InEvent)
				{
					this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
					this.Senpai.Pathfinding.target = this.Location[1];
					this.Senpai.CurrentDestination = this.Location[1];
					this.Senpai.Pathfinding.canSearch = true;
					this.Senpai.Pathfinding.canMove = true;
					this.Senpai.InEvent = true;
					this.Senpai.DistanceToDestination = 100f;
					this.Spy.Prompt.enabled = true;
				}
				if ((this.Rival.Leaving || this.Rival.CurrentDestination == this.StudentManager.Exit) && this.Rival.enabled && !this.Rival.InEvent)
				{
					Debug.Log("Osana's Wednesday after school event has begun.");
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location[2];
					this.Rival.CurrentDestination = this.Location[2];
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.InEvent = true;
					this.Rival.DistanceToDestination = 100f;
					this.Spy.Prompt.enabled = true;
				}
				if (this.Senpai.CurrentDestination == this.Location[1] && this.Senpai.DistanceToDestination < 0.5f)
				{
					if (!this.Impatient)
					{
						this.Senpai.CharacterAnimation.CrossFade("waiting_00");
						this.Senpai.Pathfinding.canSearch = false;
						this.Senpai.Pathfinding.canMove = false;
						if (this.Clock.HourTime > 17.916666f)
						{
							AudioClipPlayer.Play(this.ImpatientSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
							this.Senpai.CharacterAnimation.CrossFade("impatience_00");
							this.EventSubtitle.text = this.ImpatientSpeechText;
							this.Impatient = true;
						}
					}
					else if (this.Senpai.CharacterAnimation["impatience_00"].time >= this.Senpai.CharacterAnimation["impatience_00"].length)
					{
						this.StudentManager.SabotageProgress++;
						Debug.Log("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5");
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
					this.Yandere.PauseScreen.Hint.QuickID = 10;
					this.Yandere.PauseScreen.Hint.Show = true;
					this.HintGiven = true;
				}
				if (this.Rival.CurrentDestination == this.Location[2] && this.Senpai.CurrentDestination == this.Location[1] && this.Senpai.DistanceToDestination < 0.5f && this.Rival.DistanceToDestination < 0.5f && !this.Impatient)
				{
					this.Phase++;
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			if (this.StudentManager.Students[this.FriendID] != null && this.Rival.Follower != null && !PlayerGlobals.RaibaruLoner)
			{
				this.Friend = this.StudentManager.Students[this.FriendID];
				this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Friend.Pathfinding.target = this.Location[3];
				this.Friend.CurrentDestination = this.Location[3];
				this.Friend.ManualRotation = true;
				this.Friend.Cheer.enabled = true;
				this.Friend.InEvent = true;
			}
			if (this.EventDay == DayOfWeek.Tuesday)
			{
				this.Rival.EventBook.SetActive(true);
				if (!this.Sabotaged)
				{
					AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.TransferTime = 8.5f;
					this.Suffix = "A";
				}
				else
				{
					AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.TransferTime = 11f;
					this.Suffix = "B";
				}
			}
			else if (this.EventDay == DayOfWeek.Wednesday)
			{
				this.Sabotaged = this.Rival.LewdPhotos;
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
					this.TransferTime = 4.833333f;
					this.ReturnTime = 35f;
					this.TakeOutTime = 0.75f;
					this.PutAwayTime = 36.5f;
					this.Suffix = "A";
				}
				else
				{
					AudioClipPlayer.Play(this.SabotagedSpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.TransferTime = 4.833333f;
					this.ReturnTime = 26.5f;
					this.TakeOutTime = 0.75f;
					this.PutAwayTime = 50f;
					this.Suffix = "B";
				}
			}
			else if (this.EventDay == DayOfWeek.Thursday)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Epicenter.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Suffix = "A";
			}
			this.Rival.CharacterAnimation.CrossFade("f02_" + this.Weekday + "_3" + this.Suffix);
			if (this.EventDay == DayOfWeek.Thursday)
			{
				this.Senpai.CharacterAnimation.CrossFade(this.Senpai.IdleAnim);
			}
			else
			{
				this.Senpai.CharacterAnimation.CrossFade(this.Weekday + "_3" + this.Suffix);
			}
			this.Timer = 0f;
			this.Phase++;
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
					this.Rival.StopRotating = true;
					this.LookAtSenpai = true;
					this.EndSenpai();
				}
				if (this.LookAtSenpai)
				{
					this.Rival.targetRotation = Quaternion.LookRotation(this.Senpai.transform.position - this.Rival.transform.position);
					this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.targetRotation, 10f * Time.deltaTime);
				}
			}
			if (this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time >= this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].length)
			{
				this.NaturalEnd = true;
				this.EndEvent();
			}
			if (this.TakeOut && this.EventDay == DayOfWeek.Wednesday && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.TakeOutTime)
			{
				this.Rival.SmartPhone.SetActive(true);
				this.TakeOut = false;
				this.PutAway = true;
			}
			if (this.PutAway && this.EventDay == DayOfWeek.Wednesday && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.PutAwayTime)
			{
				this.Rival.SmartPhone.SetActive(false);
				this.PutAway = false;
			}
			if (this.Transfer)
			{
				if (this.EventDay == DayOfWeek.Tuesday)
				{
					if (this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.TransferTime)
					{
						this.Rival.EventBook.SetActive(false);
						this.Senpai.EventBook.SetActive(true);
						this.Transfer = false;
						this.Return = true;
					}
				}
				else if (this.EventDay == DayOfWeek.Wednesday && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.TransferTime)
				{
					this.Rival.SmartPhone.SetActive(false);
					this.Senpai.SmartPhone.SetActive(true);
					this.Transfer = false;
					this.Return = true;
				}
			}
			if (this.Return && this.EventDay == DayOfWeek.Wednesday && this.Rival.CharacterAnimation["f02_" + this.Weekday + "_3" + this.Suffix].time > this.ReturnTime)
			{
				this.Rival.SmartPhone.SetActive(true);
				this.Senpai.SmartPhone.SetActive(false);
				this.Return = false;
			}
			if (this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Splashed)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				this.EndEvent();
			}
		}
		if (this.Phase > 0 || this.Impatient)
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
				this.Yandere.Eavesdropping = (this.Distance < 5f);
			}
			else
			{
				this.EventSubtitle.transform.localScale = Vector3.zero;
				if (this.VoiceClip != null)
				{
					this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
				}
			}
		}
		if (this.Phase > 0)
		{
			if (this.Friend != null)
			{
				if (this.Friend.DistanceToDestination < 1f)
				{
					this.Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
					this.Friend.MoveTowardsTarget(this.Friend.CurrentDestination.position);
					this.Friend.targetRotation = this.Friend.CurrentDestination.rotation;
					this.Friend.transform.rotation = Quaternion.Slerp(this.Friend.transform.rotation, this.Friend.targetRotation, 10f * Time.deltaTime);
					this.Friend.MyController.radius = 0f;
					return;
				}
				this.Friend.CharacterAnimation.CrossFade(this.Friend.SprintAnim);
				this.Friend.Pathfinding.speed = 4f;
				return;
			}
			else if (this.StudentManager.Students[this.FriendID] != null && !PlayerGlobals.RaibaruLoner)
			{
				this.Friend = this.StudentManager.Students[this.FriendID];
			}
		}
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x00145B44 File Offset: 0x00143D44
	private void EndEvent()
	{
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
			this.Rival.EventBook.SetActive(false);
			this.Rival.Prompt.enabled = true;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.DistanceToDestination = 100f;
			this.Rival.Pathfinding.speed = 1f;
			this.Rival.Hurry = false;
		}
		if (this.Friend != null && this.Friend.CurrentAction == StudentActionType.Follow)
		{
			if (!this.Friend.Alarmed && !this.Friend.DramaticReaction)
			{
				this.Friend.Pathfinding.canSearch = true;
				this.Friend.Pathfinding.canMove = true;
			}
			if (this.NaturalEnd)
			{
				this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
				this.Friend.Pathfinding.target = this.Rival.transform;
				this.Friend.CurrentDestination = this.Rival.transform;
				this.Friend.Pathfinding.canSearch = true;
				this.Friend.Pathfinding.canMove = true;
				this.Friend.MyController.radius = 0.1f;
				this.Friend.ManualRotation = false;
				this.Friend.Prompt.enabled = true;
				this.Friend.InEvent = false;
				this.Friend.Private = false;
			}
			this.Friend.Cheer.enabled = false;
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
			this.StudentManager.SabotageProgress++;
			Debug.Log("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5");
		}
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
		this.Jukebox.Dip = 1f;
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x00145E98 File Offset: 0x00144098
	private void EndSenpai()
	{
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
		this.Senpai.CurrentDestination = this.Senpai.Destinations[this.Senpai.Phase];
		this.Senpai.Pathfinding.target = this.Senpai.Destinations[this.Senpai.Phase];
		this.Senpai.DistanceToDestination = 100f;
		this.OsanaThursdayRooftopEvent.enabled = false;
	}

	// Token: 0x040030D0 RID: 12496
	public OsanaThursdayAfterClassEventScript OsanaThursdayRooftopEvent;

	// Token: 0x040030D1 RID: 12497
	public StudentManagerScript StudentManager;

	// Token: 0x040030D2 RID: 12498
	public JukeboxScript Jukebox;

	// Token: 0x040030D3 RID: 12499
	public UILabel EventSubtitle;

	// Token: 0x040030D4 RID: 12500
	public YandereScript Yandere;

	// Token: 0x040030D5 RID: 12501
	public ClockScript Clock;

	// Token: 0x040030D6 RID: 12502
	public SpyScript Spy;

	// Token: 0x040030D7 RID: 12503
	public StudentScript Friend;

	// Token: 0x040030D8 RID: 12504
	public StudentScript Senpai;

	// Token: 0x040030D9 RID: 12505
	public StudentScript Rival;

	// Token: 0x040030DA RID: 12506
	public Transform[] Location;

	// Token: 0x040030DB RID: 12507
	public Transform Epicenter;

	// Token: 0x040030DC RID: 12508
	public AudioClip CancelledSpeechClip;

	// Token: 0x040030DD RID: 12509
	public string[] CancelledSpeechText;

	// Token: 0x040030DE RID: 12510
	public float[] CancelledSpeechTime;

	// Token: 0x040030DF RID: 12511
	public AudioClip SabotagedSpeechClip;

	// Token: 0x040030E0 RID: 12512
	public string[] SabotagedSpeechText;

	// Token: 0x040030E1 RID: 12513
	public float[] SabotagedSpeechTime;

	// Token: 0x040030E2 RID: 12514
	public AudioClip SpeechClip;

	// Token: 0x040030E3 RID: 12515
	public string[] SpeechText;

	// Token: 0x040030E4 RID: 12516
	public float[] SpeechTime;

	// Token: 0x040030E5 RID: 12517
	public AudioClip ImpatientSpeechClip;

	// Token: 0x040030E6 RID: 12518
	public string ImpatientSpeechText;

	// Token: 0x040030E7 RID: 12519
	public GameObject AlarmDisc;

	// Token: 0x040030E8 RID: 12520
	public GameObject VoiceClip;

	// Token: 0x040030E9 RID: 12521
	public bool LookAtSenpai;

	// Token: 0x040030EA RID: 12522
	public bool EventActive;

	// Token: 0x040030EB RID: 12523
	public bool NaturalEnd;

	// Token: 0x040030EC RID: 12524
	public bool Cancelled;

	// Token: 0x040030ED RID: 12525
	public bool HintGiven;

	// Token: 0x040030EE RID: 12526
	public bool Impatient;

	// Token: 0x040030EF RID: 12527
	public bool Sabotaged;

	// Token: 0x040030F0 RID: 12528
	public bool Transfer;

	// Token: 0x040030F1 RID: 12529
	public bool TakeOut;

	// Token: 0x040030F2 RID: 12530
	public bool PutAway;

	// Token: 0x040030F3 RID: 12531
	public bool Return;

	// Token: 0x040030F4 RID: 12532
	public float TransferTime;

	// Token: 0x040030F5 RID: 12533
	public float ReturnTime;

	// Token: 0x040030F6 RID: 12534
	public float TakeOutTime;

	// Token: 0x040030F7 RID: 12535
	public float PutAwayTime;

	// Token: 0x040030F8 RID: 12536
	public float Distance;

	// Token: 0x040030F9 RID: 12537
	public float Scale;

	// Token: 0x040030FA RID: 12538
	public float Timer;

	// Token: 0x040030FB RID: 12539
	public DayOfWeek EventDay;

	// Token: 0x040030FC RID: 12540
	public int SpeechPhase = 1;

	// Token: 0x040030FD RID: 12541
	public int FriendID = 10;

	// Token: 0x040030FE RID: 12542
	public int RivalID = 11;

	// Token: 0x040030FF RID: 12543
	public int Phase;

	// Token: 0x04003100 RID: 12544
	public int Frame;

	// Token: 0x04003101 RID: 12545
	public string Weekday = string.Empty;

	// Token: 0x04003102 RID: 12546
	public string Suffix = string.Empty;
}
