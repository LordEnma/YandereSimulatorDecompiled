using System;
using UnityEngine;

// Token: 0x020003DB RID: 987
public class OsanaClubEventScript : MonoBehaviour
{
	// Token: 0x06001B8C RID: 7052 RVA: 0x00138147 File Offset: 0x00136347
	private void Start()
	{
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B8D RID: 7053 RVA: 0x00138174 File Offset: 0x00136374
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
		if (!this.EventOn)
		{
			for (int i = 1; i < 3; i++)
			{
				if (this.EventStudent[i] == null)
				{
					this.EventStudent[i] = this.StudentManager.Students[this.StudentID[i]];
				}
				else if (!this.EventStudent[i].Alive || this.EventStudent[i].Slave)
				{
					base.enabled = false;
				}
			}
			if (this.EventStudent[1] != null && this.EventStudent[2] != null && this.EventStudent[1].enabled && this.EventStudent[1].Pathfinding.canMove && this.EventStudent[2].Pathfinding.canMove && this.EventStudent[1].Routine && !this.EventStudent[1].Wet)
			{
				Debug.Log("Osana's club event has begun.");
				this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				this.EventStudent[1].CurrentDestination = this.EventLocation[1];
				this.EventStudent[1].Pathfinding.target = this.EventLocation[1];
				this.EventStudent[1].TargetDistance = 0.5f;
				this.EventStudent[1].Private = false;
				this.EventStudent[1].InEvent = true;
				this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
				this.EventStudent[2].CurrentDestination = this.EventLocation[2];
				this.EventStudent[2].Pathfinding.target = this.EventLocation[2];
				this.EventStudent[2].TargetDistance = 1f;
				this.EventStudent[2].Private = false;
				this.EventStudent[2].InEvent = true;
				this.Yandere.PauseScreen.Hint.Show = true;
				this.Yandere.PauseScreen.Hint.QuickID = 16;
				this.EventOn = true;
				return;
			}
		}
		else
		{
			Vector3 b = (this.EventStudent[1].transform.position - this.EventStudent[2].transform.position) * 0.5f + this.EventStudent[2].transform.position;
			float num = Vector3.Distance(this.Yandere.transform.position, b);
			if (this.EventPhase > 1 && this.EventPhase < 7)
			{
				this.Yandere.Eavesdropping = (num < 3f);
			}
			else
			{
				this.Yandere.Eavesdropping = false;
			}
			if (this.Clock.HourTime > 13.5f || this.EventStudent[1].WitnessedCorpse || this.EventStudent[2].WitnessedCorpse || this.EventStudent[1].Alarmed || this.EventStudent[2].Alarmed || this.EventStudent[1].Dying || this.EventStudent[2].Dying || this.EventStudent[1].Splashed || this.EventStudent[1].Dodging || this.Clock.Police.EndOfDay.gameObject.activeInHierarchy)
			{
				this.EndEvent();
				return;
			}
			for (int j = 1; j < 3; j++)
			{
				if (!this.EventStudent[j].Pathfinding.canMove && !this.EventStudent[j].Private)
				{
					this.EventStudent[j].CharacterAnimation.CrossFade(this.EventStudent[j].IdleAnim);
					this.EventStudent[j].Private = true;
					this.StudentManager.UpdateStudents(0);
				}
			}
			if (!this.EventStudent[1].Pathfinding.canMove && !this.EventStudent[2].Pathfinding.canMove)
			{
				if (!this.Spoken)
				{
					this.EventStudent[this.EventSpeaker[1]].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
					this.EventStudent[this.EventSpeaker[2]].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
					this.EventStudent[this.EventSpeaker[this.EventPhase]].PickRandomAnim();
					this.EventStudent[this.EventSpeaker[this.EventPhase]].CharacterAnimation.CrossFade(this.EventStudent[this.EventSpeaker[this.EventPhase]].RandomAnim);
					AudioClipPlayer.Play(this.EventClip[this.EventPhase], this.EventStudent[this.EventSpeaker[this.EventPhase]].transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Spoken = true;
					if (this.EventSpeaker[this.EventPhase] == 1 && this.EventPhase > 7 && this.EventPhase < 33 && this.EventPhase != 24 && num < 10f)
					{
						if (this.EventPhase == 30)
						{
							Debug.Log("Current EventPhase is: 30 and Osana is talking about the delinquents.");
							this.Yandere.NotificationManager.TopicName = "Violence";
							this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
							ConversationGlobals.SetTopicLearnedByStudent(this.ClubIDs[this.EventPhase], 17, true);
							return;
						}
						Debug.Log("Current EventPhase is: " + this.EventPhase.ToString() + " and ClubID is: " + this.ClubIDs[this.EventPhase].ToString());
						this.Yandere.NotificationManager.TopicName = this.Yandere.NotificationManager.ClubNames[this.ClubIDs[this.EventPhase]];
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Opinion);
						ConversationGlobals.SetTopicLearnedByStudent(this.ClubIDs[this.EventPhase], 11, true);
						return;
					}
				}
				else
				{
					int num2 = this.EventSpeaker[this.EventPhase];
					if (num2 == 1)
					{
						this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
					}
					else
					{
						this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
					}
					if (this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].time >= this.EventStudent[num2].CharacterAnimation[this.EventStudent[num2].RandomAnim].length)
					{
						this.EventStudent[num2].PickRandomAnim();
						this.EventStudent[num2].CharacterAnimation.CrossFade(this.EventStudent[num2].RandomAnim);
					}
					this.Timer += Time.deltaTime;
					if (this.Yandere.transform.position.y > this.EventStudent[1].transform.position.y - 1f && this.Yandere.transform.position.y < this.EventStudent[1].transform.position.y + 1f)
					{
						if (this.VoiceClipSource != null)
						{
							this.VoiceClipSource.volume = 1f;
						}
						if (num < 11f)
						{
							if (num < 10f)
							{
								if (this.Timer > this.EventClip[this.EventPhase].length)
								{
									this.EventSubtitle.text = string.Empty;
								}
								else
								{
									this.EventSubtitle.text = this.EventSpeech[this.EventPhase];
								}
								this.Scale = Mathf.Abs((num - 10f) * 0.2f);
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
								this.EventSubtitle.text = string.Empty;
							}
						}
					}
					else if (this.VoiceClipSource != null)
					{
						this.VoiceClipSource.volume = 0f;
					}
					if (this.Timer > this.EventClip[this.EventPhase].length + 0.5f)
					{
						this.Spoken = false;
						this.EventPhase++;
						this.Timer = 0f;
						if (this.EventPhase == 4)
						{
							this.RooftopConversation.CanHappen = true;
						}
						if (this.EventPhase == this.EventSpeech.Length)
						{
							this.EndEvent();
							return;
						}
						if (this.EventPhase > 6)
						{
							this.EventStudent[1].CurrentDestination = this.EventLocation[this.EventPhase];
							this.EventStudent[1].Pathfinding.target = this.EventLocation[this.EventPhase];
							this.EventStudent[2].CurrentDestination = this.EventStudent[1].FollowTargetDestination;
							this.EventStudent[2].Pathfinding.target = this.EventStudent[1].FollowTargetDestination;
							return;
						}
					}
				}
			}
			else
			{
				if (!this.EventStudent[1].Pathfinding.canMove)
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].IdleAnim);
				}
				else
				{
					this.EventStudent[1].CharacterAnimation.CrossFade(this.EventStudent[1].WalkAnim);
				}
				if (!this.EventStudent[2].Pathfinding.canMove)
				{
					this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].IdleAnim);
					if (this.EventPhase == 1)
					{
						this.SettleFriend();
						return;
					}
				}
				else
				{
					if (this.EventStudent[2].Pathfinding.speed == 1f)
					{
						this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].WalkAnim);
						return;
					}
					this.EventStudent[2].CharacterAnimation.CrossFade(this.EventStudent[2].RunAnim);
				}
			}
		}
	}

	// Token: 0x06001B8E RID: 7054 RVA: 0x00138C79 File Offset: 0x00136E79
	private void SettleFriend()
	{
		this.EventStudent[2].MoveTowardsTarget(this.EventStudent[2].Pathfinding.target.position);
	}

	// Token: 0x06001B8F RID: 7055 RVA: 0x00138CA0 File Offset: 0x00136EA0
	public void EndEvent()
	{
		Debug.Log("Ending Osana's club event.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		for (int i = 1; i < 3; i++)
		{
			if (this.EventStudent[i] != null)
			{
				this.EventStudent[i].CurrentDestination = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
				this.EventStudent[i].Pathfinding.target = this.EventStudent[i].Destinations[this.EventStudent[i].Phase];
				this.EventStudent[i].InEvent = false;
				this.EventStudent[i].Private = false;
			}
		}
		this.CheckForRooftopConvo();
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Yandere.Eavesdropping = false;
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		this.ReachedTheEnd = true;
		base.enabled = false;
	}

	// Token: 0x06001B90 RID: 7056 RVA: 0x00138DBC File Offset: 0x00136FBC
	public void CheckForRooftopConvo()
	{
		if (this.StudentManager.Students[10] != null && this.StudentManager.Students[10].CurrentAction == StudentActionType.Follow)
		{
			Debug.Log("Osana's rooftop conversation with Raibaru can happen.");
			this.RooftopConversation.CanHappen = true;
		}
	}

	// Token: 0x04002F1F RID: 12063
	public EventManagerScript RooftopConversation;

	// Token: 0x04002F20 RID: 12064
	public StudentManagerScript StudentManager;

	// Token: 0x04002F21 RID: 12065
	public UILabel EventSubtitle;

	// Token: 0x04002F22 RID: 12066
	public YandereScript Yandere;

	// Token: 0x04002F23 RID: 12067
	public JukeboxScript Jukebox;

	// Token: 0x04002F24 RID: 12068
	public ClockScript Clock;

	// Token: 0x04002F25 RID: 12069
	public StudentScript[] EventStudent;

	// Token: 0x04002F26 RID: 12070
	public Transform[] EventLocation;

	// Token: 0x04002F27 RID: 12071
	public AudioClip[] EventClip;

	// Token: 0x04002F28 RID: 12072
	public string[] EventSpeech;

	// Token: 0x04002F29 RID: 12073
	public string[] EventAnim;

	// Token: 0x04002F2A RID: 12074
	public int[] EventSpeaker;

	// Token: 0x04002F2B RID: 12075
	public int[] ClubIDs;

	// Token: 0x04002F2C RID: 12076
	public GameObject VoiceClip;

	// Token: 0x04002F2D RID: 12077
	public AudioSource VoiceClipSource;

	// Token: 0x04002F2E RID: 12078
	public bool ReachedTheEnd;

	// Token: 0x04002F2F RID: 12079
	public bool EventOn;

	// Token: 0x04002F30 RID: 12080
	public bool Spoken;

	// Token: 0x04002F31 RID: 12081
	public int EventPhase;

	// Token: 0x04002F32 RID: 12082
	public float Timer;

	// Token: 0x04002F33 RID: 12083
	public float Scale;

	// Token: 0x04002F34 RID: 12084
	public int[] StudentID;

	// Token: 0x04002F35 RID: 12085
	public DayOfWeek EventDay;
}
