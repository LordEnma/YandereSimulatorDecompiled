using System;
using UnityEngine;

// Token: 0x020003A3 RID: 931
public class PhoneEventScript : MonoBehaviour
{
	// Token: 0x06001AA1 RID: 6817 RVA: 0x0011E4A0 File Offset: 0x0011C6A0
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == this.EventDay)
		{
			this.EventCheck = true;
		}
		if (HomeGlobals.LateForSchool || this.StudentManager.YandereLate || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001AA2 RID: 6818 RVA: 0x0011E4FF File Offset: 0x0011C6FF
	private void OnAwake()
	{
	}

	// Token: 0x06001AA3 RID: 6819 RVA: 0x0011E504 File Offset: 0x0011C704
	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck)
		{
			if (this.Clock.HourTime > this.EventTime + 0.5f)
			{
				base.enabled = false;
			}
			else if (this.Clock.HourTime > this.EventTime)
			{
				if (this.EventStudent == null)
				{
					this.EventStudent = this.StudentManager.Students[this.EventStudentID];
				}
				if (this.EventStudent != null && !this.EventStudent.InEvent && !this.EventStudent.Meeting && this.EventStudent.DistanceToDestination < 1f && !this.EventStudent.Phoneless)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1f)
					{
						if (this.OsanaClubEvent != null && this.EventStudent.Alive)
						{
							Debug.Log("Osana's Monday morning phone event has begun.");
						}
						this.EventStudent.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
						if (this.EventStudentID == 11)
						{
							this.EventFriend = this.StudentManager.Students[this.EventFriendID];
							if (this.EventFriend != null && this.EventFriend.CurrentAction == StudentActionType.Follow && !this.EventFriend.InvestigatingBloodPool && !this.EventFriend.ReturningMisplacedWeapon)
							{
								Debug.Log("Raibaru is available, so she's getting involved in the event.");
								this.EventFriend.CharacterAnimation.CrossFade(this.EventFriend.IdleAnim);
								this.EventFriend.Pathfinding.canSearch = false;
								this.EventFriend.Pathfinding.canMove = false;
								this.EventFriend.TargetDistance = 0.5f;
								this.EventFriend.SpeechLines.Stop();
								this.EventFriend.PhoneEvent = this;
								this.EventFriend.CanTalk = false;
								this.EventFriend.Routine = false;
								this.EventFriend.InEvent = true;
								this.EventFriend.Prompt.Hide();
							}
						}
						if (this.EventStudent.enabled && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && !this.EventStudent.Investigating && this.EventStudent.Indoors)
						{
							if (!this.EventStudent.WitnessedMurder)
							{
								this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
								this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
								this.EventStudent.Obstacle.checkTime = 99f;
								this.EventStudent.SpeechLines.Stop();
								this.EventStudent.PhoneEvent = this;
								this.EventStudent.CanTalk = false;
								this.EventStudent.InEvent = true;
								this.EventStudent.Prompt.Hide();
								this.EventCheck = false;
								this.EventActive = true;
								this.Timer = 0f;
								this.Yandere.PauseScreen.Hint.Show = true;
								this.Yandere.PauseScreen.Hint.QuickID = 15;
								if (this.EventStudent.Following)
								{
									this.EventStudent.Pathfinding.canMove = true;
									this.EventStudent.Pathfinding.speed = 1f;
									this.EventStudent.Following = false;
									this.EventStudent.Routine = true;
									this.Yandere.Follower = null;
									this.Yandere.Followers--;
									this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
									this.EventStudent.Prompt.Label[0].text = "     Talk";
								}
							}
							else
							{
								base.enabled = false;
							}
						}
					}
				}
			}
		}
		if (this.EventActive)
		{
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				this.EventStudent.Pathfinding.canSearch = false;
				this.EventStudent.Pathfinding.canMove = false;
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Alarmed || this.EventStudent.Dodging || this.EventStudent.Dying || !this.EventStudent.Alive)
			{
				this.EndedPrematurely = true;
				this.EndEvent();
				return;
			}
			if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					this.Timer += Time.deltaTime;
					this.EventStudent.CharacterAnimation.CrossFade(this.EventAnim[0]);
					AudioClipPlayer.Play(this.EventClip[0], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 1.5f)
					{
						this.EventStudent.SmartPhone.SetActive(true);
						this.EventStudent.SmartPhone.transform.localPosition = new Vector3(-0.015f, -0.005f, -0.015f);
						this.EventStudent.SmartPhone.transform.localEulerAngles = new Vector3(0f, -150f, 165f);
					}
					if (this.Timer > 2f)
					{
						AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
						this.EventSubtitle.text = this.EventSpeech[1];
						this.Timer = 0f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > this.CurrentClipLength)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
						this.EventStudent.CurrentDestination = this.EventLocation;
						this.EventStudent.Pathfinding.target = this.EventLocation;
						this.EventStudent.Pathfinding.canSearch = true;
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = 4f;
						this.EventSubtitle.text = string.Empty;
						this.EventStudent.Hurry = true;
						Debug.Log(this.EventStudent.Name + " has been given a pathfinding speed of 4.");
						this.Timer = 0f;
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 4)
				{
					if (this.EventStudentID != 11)
					{
						this.DumpPoint.enabled = true;
					}
					this.EventStudent.Private = true;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[2]);
					AudioClipPlayer.Play(this.EventClip[2], this.EventStudent.transform.position, 5f, 10f, out this.VoiceClip, out this.CurrentClipLength);
					this.EventPhase++;
				}
				else if (this.EventPhase < 13)
				{
					if (this.VoiceClip != null)
					{
						this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
						this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time = this.VoiceClip.GetComponent<AudioSource>().time;
						if (this.VoiceClip.GetComponent<AudioSource>().time > this.SpeechTimes[this.EventPhase - 3])
						{
							this.EventSubtitle.text = this.EventSpeech[this.EventPhase - 3];
							this.EventPhase++;
						}
					}
				}
				else
				{
					if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length * 90.33333f)
					{
						this.EventStudent.SmartPhone.SetActive(true);
					}
					if (this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].time >= this.EventStudent.Character.GetComponent<Animation>()[this.EventAnim[2]].length)
					{
						this.EndEvent();
					}
				}
				float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					this.Jukebox.Dip = 1f - 0.5f * num2;
					this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
				}
				else
				{
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
				if (base.enabled && this.EventPhase > 4)
				{
					if (num < 5f)
					{
						this.Yandere.Eavesdropping = true;
					}
					else
					{
						this.Yandere.Eavesdropping = false;
					}
				}
				if (this.EventPhase == 11 && num < 5f)
				{
					if (this.EventStudentID == 30)
					{
						if (!EventGlobals.Event2)
						{
							EventGlobals.Event2 = true;
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
							ConversationGlobals.SetTopicDiscovered(25, true);
							this.Yandere.NotificationManager.TopicName = "Money";
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Topic);
							this.Yandere.NotificationManager.TopicName = "Money";
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(25, this.EventStudentID, true);
						}
					}
					else if (!this.Yandere.Police.EndOfDay.LearnedOsanaInfo1)
					{
						this.Yandere.Police.EndOfDay.LearnedOsanaInfo1 = true;
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Info);
						if (SchemeGlobals.GetSchemeStage(6) == 1)
						{
							SchemeGlobals.SetSchemeStage(6, 2);
							this.Yandere.PauseScreen.Schemes.UpdateInstructions();
						}
					}
				}
			}
			else
			{
				this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.RunAnim);
				this.EventStudent.Pathfinding.speed = 4f;
			}
			if ((this.EventStudent.Pathfinding.canMove || this.EventPhase > 3) && this.EventFriend != null && this.EventFriend.CurrentAction == StudentActionType.Follow && this.EventFriend.InEvent && this.EventPhase > 3)
			{
				if (this.EventFriend.CurrentDestination != this.SpyLocation)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 3f)
					{
						this.EventFriend.CharacterAnimation.CrossFade(this.EventStudent.RunAnim);
						this.EventFriend.CurrentDestination = this.SpyLocation;
						this.EventFriend.Pathfinding.target = this.SpyLocation;
						this.EventFriend.Pathfinding.canSearch = true;
						this.EventFriend.Pathfinding.canMove = true;
						this.EventFriend.Pathfinding.speed = 4f;
						this.EventFriend.Routine = true;
						this.Timer = 0f;
						return;
					}
					this.EventFriend.targetRotation = Quaternion.LookRotation(this.StudentManager.Students[this.EventStudentID].transform.position - this.EventFriend.transform.position);
					this.EventFriend.transform.rotation = Quaternion.Slerp(this.EventFriend.transform.rotation, this.EventFriend.targetRotation, 10f * Time.deltaTime);
					return;
				}
				else if (this.EventFriend.DistanceToDestination < 1f)
				{
					this.EventFriend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
					this.EventFriend.Pathfinding.canSearch = false;
					this.EventFriend.Pathfinding.canMove = false;
					this.SettleFriend();
				}
			}
		}
	}

	// Token: 0x06001AA4 RID: 6820 RVA: 0x0011F2B0 File Offset: 0x0011D4B0
	private void SettleFriend()
	{
		this.EventFriend.MoveTowardsTarget(this.SpyLocation.position);
		if (Quaternion.Angle(this.EventFriend.transform.rotation, this.SpyLocation.rotation) > 1f)
		{
			this.EventFriend.transform.rotation = Quaternion.Slerp(this.EventFriend.transform.rotation, this.SpyLocation.rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001AA5 RID: 6821 RVA: 0x0011F338 File Offset: 0x0011D538
	private void EndEvent()
	{
		Debug.Log("A phone event ended.");
		if (!this.EventOver)
		{
			this.EventStudent.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			if (this.EventFriend != null && this.EventFriend.CurrentAction == StudentActionType.Follow && this.EventFriend.InEvent)
			{
				Debug.Log("Raibaru is exiting the phone event.");
				this.EventFriend.CurrentDestination = this.EventFriend.Destinations[this.EventFriend.Phase];
				this.EventFriend.Pathfinding.target = this.EventFriend.Destinations[this.EventFriend.Phase];
				this.EventFriend.Obstacle.checkTime = 1f;
				this.EventFriend.Pathfinding.speed = 1f;
				this.EventFriend.TargetDistance = 1f;
				this.EventFriend.InEvent = false;
				this.EventFriend.Private = false;
				this.EventFriend.Routine = true;
				this.EventFriend.CanTalk = true;
				if (!this.EndedPrematurely)
				{
					this.OsanaClubEvent.enabled = true;
				}
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
			}
			if (!this.EventStudent.WitnessedMurder)
			{
				this.EventStudent.SmartPhone.SetActive(false);
			}
			this.EventStudent.Pathfinding.speed = 1f;
			this.EventStudent.TargetDistance = 1f;
			this.EventStudent.PhoneEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventStudent.CanTalk = true;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.EventStudent.Hurry = false;
		this.Yandere.Eavesdropping = false;
		this.Jukebox.Dip = 1f;
		this.EventActive = false;
		this.EventCheck = false;
		base.enabled = false;
	}

	// Token: 0x04002C36 RID: 11318
	public OsanaClubEventScript OsanaClubEvent;

	// Token: 0x04002C37 RID: 11319
	public StudentManagerScript StudentManager;

	// Token: 0x04002C38 RID: 11320
	public BucketPourScript DumpPoint;

	// Token: 0x04002C39 RID: 11321
	public YandereScript Yandere;

	// Token: 0x04002C3A RID: 11322
	public JukeboxScript Jukebox;

	// Token: 0x04002C3B RID: 11323
	public ClockScript Clock;

	// Token: 0x04002C3C RID: 11324
	public StudentScript EventStudent;

	// Token: 0x04002C3D RID: 11325
	public StudentScript EventFriend;

	// Token: 0x04002C3E RID: 11326
	public UILabel EventSubtitle;

	// Token: 0x04002C3F RID: 11327
	public Transform EventLocation;

	// Token: 0x04002C40 RID: 11328
	public Transform SpyLocation;

	// Token: 0x04002C41 RID: 11329
	public AudioClip[] EventClip;

	// Token: 0x04002C42 RID: 11330
	public string[] EventSpeech;

	// Token: 0x04002C43 RID: 11331
	public float[] SpeechTimes;

	// Token: 0x04002C44 RID: 11332
	public string[] EventAnim;

	// Token: 0x04002C45 RID: 11333
	public GameObject VoiceClip;

	// Token: 0x04002C46 RID: 11334
	public bool EndedPrematurely;

	// Token: 0x04002C47 RID: 11335
	public bool EventActive;

	// Token: 0x04002C48 RID: 11336
	public bool EventCheck;

	// Token: 0x04002C49 RID: 11337
	public bool EventOver;

	// Token: 0x04002C4A RID: 11338
	public bool HintGiven;

	// Token: 0x04002C4B RID: 11339
	public int EventStudentID = 7;

	// Token: 0x04002C4C RID: 11340
	public int EventFriendID = 34;

	// Token: 0x04002C4D RID: 11341
	public float EventTime = 7.5f;

	// Token: 0x04002C4E RID: 11342
	public int EventPhase = 1;

	// Token: 0x04002C4F RID: 11343
	public DayOfWeek EventDay = DayOfWeek.Monday;

	// Token: 0x04002C50 RID: 11344
	public float CurrentClipLength;

	// Token: 0x04002C51 RID: 11345
	public float FailSafe;

	// Token: 0x04002C52 RID: 11346
	public float Timer;
}
