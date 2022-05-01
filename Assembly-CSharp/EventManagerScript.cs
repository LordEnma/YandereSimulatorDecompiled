using System;
using UnityEngine;

// Token: 0x020002B8 RID: 696
public class EventManagerScript : MonoBehaviour
{
	// Token: 0x0600146B RID: 5227 RVA: 0x000C71F8 File Offset: 0x000C53F8
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.EventCheck = true;
		}
		if (this.OsanaID == 3)
		{
			if (GameGlobals.Eighties || DateGlobals.Weekday != DayOfWeek.Thursday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode)
			{
				base.enabled = false;
			}
			else
			{
				this.EventCheck = true;
			}
		}
		this.NoteLocker.Prompt.enabled = true;
		this.NoteLocker.CanLeaveNote = true;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C727C File Offset: 0x000C547C
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
		if (!this.Clock.StopTime && this.EventCheck && this.CanHappen)
		{
			if (this.Clock.HourTime > this.StartTime + 1f)
			{
				base.enabled = false;
			}
			else if (this.Clock.HourTime > this.StartTime)
			{
				if (this.EventStudent[1] == null)
				{
					this.EventStudent[1] = this.StudentManager.Students[this.EventStudent1];
				}
				else if (!this.EventStudent[1].Alive)
				{
					this.EventCheck = false;
					base.enabled = false;
				}
				if (this.EventStudent[2] == null)
				{
					this.EventStudent[2] = this.StudentManager.Students[this.EventStudent2];
				}
				else if (!this.EventStudent[2].Alive)
				{
					this.EventCheck = false;
					base.enabled = false;
				}
				if (this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].enabled && !this.EventStudent[1].Slave && !this.EventStudent[2].Slave && this.EventStudent[1].Indoors && !this.EventStudent[1].Wet && !this.EventStudent[1].Meeting && !this.EventStudent[1].Talking && (this.OsanaID < 2 || (this.OsanaID > 1 && Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) < 1f)))
				{
					this.StartTimer += Time.deltaTime;
					if (this.StartTimer > 1f && this.EventStudent[1].Routine && this.EventStudent[2].Routine && !this.EventStudent[1].InEvent && !this.EventStudent[2].InEvent)
					{
						this.EventStudent[1].CurrentDestination = this.EventLocation[1];
						this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
						this.EventStudent[1].EventManager = this;
						this.EventStudent[1].InEvent = true;
						this.EventStudent[1].EmptyHands();
						this.EventStudent[2].InEvent = true;
						if (!this.Osana)
						{
							this.EventStudent[2].CurrentDestination = this.EventLocation[2];
							this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
							this.EventStudent[2].EventManager = this;
							this.EventStudent[2].InEvent = true;
							Debug.Log("Kokona's rooftop event just began?");
						}
						else
						{
							Debug.Log("One of Osana's ''talk privately with Raibaru'' events is beginning.");
							this.Yandere.PauseScreen.Hint.Show = true;
							if (DateGlobals.Weekday == DayOfWeek.Monday)
							{
								if ((double)this.StartTime < 7.3)
								{
									this.Yandere.PauseScreen.Hint.QuickID = 14;
								}
								else
								{
									this.Yandere.PauseScreen.Hint.QuickID = 18;
								}
							}
							if (DateGlobals.Weekday == DayOfWeek.Thursday)
							{
								this.Yandere.PauseScreen.Hint.QuickID = 13;
							}
							double num = (double)this.StartTime;
						}
						this.EventStudent[2].EmptyHands();
						this.EventStudent[1].SpeechLines.Stop();
						this.EventStudent[2].SpeechLines.Stop();
						this.EventCheck = false;
						this.EventOn = true;
					}
				}
			}
		}
		if (this.EventOn)
		{
			float num2 = Vector3.Distance(this.Yandere.transform.position, this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position);
			if (this.Clock.HourTime > this.EndTime || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].Splashed || this.EventStudent[2].Splashed || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed)
			{
				this.EndEvent();
				return;
			}
			if (this.Osana)
			{
				if (this.EventStudent[1].DistanceToDestination < 1f)
				{
					this.EventStudent[2].CurrentDestination = this.EventLocation[2];
					this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
					this.EventStudent[2].EventManager = this;
				}
				else
				{
					if (this.EventStudent[1].Pathfinding.canMove)
					{
						this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
					}
					if (this.EventStudent[2].DistanceToDestination > 1f)
					{
						this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
					}
					this.EventStudent[2].CurrentDestination = this.EventStudent[1].FollowTargetDestination;
					this.EventStudent[2].Pathfinding.target = this.EventStudent[1].FollowTargetDestination;
				}
			}
			else
			{
				if (this.EventStudent[1].DistanceToDestination > 1f)
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				}
				if (this.EventStudent[2].DistanceToDestination > 1f)
				{
					this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
				}
			}
			if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[1].Private)
			{
				this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
				this.EventStudent[1].Private = true;
				this.StudentManager.UpdateStudents(0);
			}
			if (Vector3.Distance(this.EventStudent[2].transform.position, this.EventLocation[2].position) < 1f && !this.EventStudent[2].Pathfinding.canMove && !this.StopWalking)
			{
				this.StopWalking = true;
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
				this.EventStudent[2].Private = true;
				this.StudentManager.UpdateStudents(0);
			}
			if (this.StopWalking && this.EventPhase == 1)
			{
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
			}
			if (Vector3.Distance(this.EventStudent[1].transform.position, this.EventLocation[1].position) < 1f && !this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
				}
				if (this.Osana)
				{
					this.SettleFriend();
				}
				if (!this.Spoken)
				{
					this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventAnim[this.EventPhase]);
					if (num2 < 10f)
					{
						this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
					}
					AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Spoken = true;
				}
				else
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.EventClip[this.EventPhase].length)
					{
						this.EventSubtitle.text = string.Empty;
					}
					if (this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y - 1f)
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
					else if (num2 < 10f)
					{
						this.Scale = Mathf.Abs((num2 - 10f) * 0.2f);
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
					}
					else
					{
						this.EventSubtitle.transform.localScale = Vector3.zero;
					}
					Animation characterAnimation = this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation;
					if (characterAnimation[this.EventAnim[this.EventPhase]].time >= characterAnimation[this.EventAnim[this.EventPhase]].length - 1f)
					{
						characterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].IdleAnim, 1f);
					}
					if (this.Timer > this.EventClip[this.EventPhase].length + 1f)
					{
						this.Spoken = false;
						this.EventPhase++;
						this.Timer = 0f;
						if (this.EventPhase == this.EventSpeech.Length)
						{
							this.EndEvent();
						}
					}
					if (!this.Suitor && this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - 1f && this.EventPhase == 7 && num2 < 5f)
					{
						if (this.EventStudent1 == 25)
						{
							if (!EventGlobals.Event1)
							{
								this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
								EventGlobals.Event1 = true;
							}
						}
						else if (this.OsanaID < 2 && !this.Yandere.Police.EndOfDay.LearnedOsanaInfo2)
						{
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
							this.Yandere.Police.EndOfDay.LearnedOsanaInfo2 = true;
							this.StudentManager.OsanaOfferHelp.Eavesdropped = true;
							if (SchemeGlobals.GetSchemeStage(6) == 2)
							{
								if (this.EventStudent[1].Friend)
								{
									SchemeGlobals.SetSchemeStage(6, 4);
								}
								else
								{
									SchemeGlobals.SetSchemeStage(6, 3);
								}
								this.Yandere.PauseScreen.Schemes.UpdateInstructions();
							}
						}
					}
				}
				if (base.enabled)
				{
					if (num2 < 3f)
					{
						this.Yandere.Eavesdropping = true;
						return;
					}
					this.Yandere.Eavesdropping = false;
				}
			}
		}
	}

	// Token: 0x0600146D RID: 5229 RVA: 0x000C7EA8 File Offset: 0x000C60A8
	private void SettleFriend()
	{
		this.EventStudent[2].MoveTowardsTarget(this.EventLocation[2].position);
		if (Quaternion.Angle(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation) > 1f)
		{
			this.EventStudent[2].transform.rotation = Quaternion.Slerp(this.EventStudent[2].transform.rotation, this.EventLocation[2].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x0600146E RID: 5230 RVA: 0x000C7F3C File Offset: 0x000C613C
	public void EndEvent()
	{
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		this.EventStudent[1].CurrentDestination = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].Pathfinding.target = this.EventStudent[1].Destinations[this.EventStudent[1].Phase];
		this.EventStudent[1].EventManager = null;
		this.EventStudent[1].InEvent = false;
		this.EventStudent[1].Private = false;
		this.EventStudent[2].CurrentDestination = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].Pathfinding.target = this.EventStudent[2].Destinations[this.EventStudent[2].Phase];
		this.EventStudent[2].EventManager = null;
		this.EventStudent[2].InEvent = false;
		this.EventStudent[2].Private = false;
		double num = (double)this.StartTime;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.Yandere.Eavesdropping = false;
		this.EventSubtitle.text = string.Empty;
		this.EventCheck = false;
		this.EventOn = false;
		base.enabled = false;
	}

	// Token: 0x04001F70 RID: 8048
	public StudentManagerScript StudentManager;

	// Token: 0x04001F71 RID: 8049
	public NoteLockerScript NoteLocker;

	// Token: 0x04001F72 RID: 8050
	public UILabel EventSubtitle;

	// Token: 0x04001F73 RID: 8051
	public YandereScript Yandere;

	// Token: 0x04001F74 RID: 8052
	public JukeboxScript Jukebox;

	// Token: 0x04001F75 RID: 8053
	public ClockScript Clock;

	// Token: 0x04001F76 RID: 8054
	public StudentScript[] EventStudent;

	// Token: 0x04001F77 RID: 8055
	public Transform[] EventLocation;

	// Token: 0x04001F78 RID: 8056
	public AudioClip[] EventClip;

	// Token: 0x04001F79 RID: 8057
	public string[] EventSpeech;

	// Token: 0x04001F7A RID: 8058
	public string[] EventAnim;

	// Token: 0x04001F7B RID: 8059
	public int[] EventSpeaker;

	// Token: 0x04001F7C RID: 8060
	public GameObject VoiceClip;

	// Token: 0x04001F7D RID: 8061
	public AudioSource VoiceClipSource;

	// Token: 0x04001F7E RID: 8062
	public bool StopWalking;

	// Token: 0x04001F7F RID: 8063
	public bool EventCheck;

	// Token: 0x04001F80 RID: 8064
	public bool CanHappen;

	// Token: 0x04001F81 RID: 8065
	public bool HintGiven;

	// Token: 0x04001F82 RID: 8066
	public bool EventOn;

	// Token: 0x04001F83 RID: 8067
	public bool Suitor;

	// Token: 0x04001F84 RID: 8068
	public bool Spoken;

	// Token: 0x04001F85 RID: 8069
	public bool Osana;

	// Token: 0x04001F86 RID: 8070
	public float StartTimer;

	// Token: 0x04001F87 RID: 8071
	public float Timer;

	// Token: 0x04001F88 RID: 8072
	public float Scale;

	// Token: 0x04001F89 RID: 8073
	public float StartTime = 13.01f;

	// Token: 0x04001F8A RID: 8074
	public float EndTime = 13.5f;

	// Token: 0x04001F8B RID: 8075
	public int EventStudent1;

	// Token: 0x04001F8C RID: 8076
	public int EventStudent2;

	// Token: 0x04001F8D RID: 8077
	public int EventPhase;

	// Token: 0x04001F8E RID: 8078
	public int OsanaID = 1;
}
