using System;
using UnityEngine;

// Token: 0x020003D5 RID: 981
public class OsanaClubEventScript : MonoBehaviour
{
	// Token: 0x06001B66 RID: 7014 RVA: 0x0013455F File Offset: 0x0013275F
	private void Start()
	{
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B67 RID: 7015 RVA: 0x0013458C File Offset: 0x0013278C
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

	// Token: 0x06001B68 RID: 7016 RVA: 0x00135091 File Offset: 0x00133291
	private void SettleFriend()
	{
		this.EventStudent[2].MoveTowardsTarget(this.EventStudent[2].Pathfinding.target.position);
	}

	// Token: 0x06001B69 RID: 7017 RVA: 0x001350B8 File Offset: 0x001332B8
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

	// Token: 0x06001B6A RID: 7018 RVA: 0x001351D4 File Offset: 0x001333D4
	public void CheckForRooftopConvo()
	{
		if (this.StudentManager.Students[10] != null)
		{
			Debug.Log("Raibaru is not null, and her CurrentAction is " + this.StudentManager.Students[10].CurrentAction.ToString());
			if (this.StudentManager.Students[10].CurrentAction == StudentActionType.Follow)
			{
				Debug.Log("Osana's rooftop conversation with Raibaru can happen.");
				this.RooftopConversation.CanHappen = true;
			}
		}
	}

	// Token: 0x04002EC3 RID: 11971
	public EventManagerScript RooftopConversation;

	// Token: 0x04002EC4 RID: 11972
	public StudentManagerScript StudentManager;

	// Token: 0x04002EC5 RID: 11973
	public UILabel EventSubtitle;

	// Token: 0x04002EC6 RID: 11974
	public YandereScript Yandere;

	// Token: 0x04002EC7 RID: 11975
	public JukeboxScript Jukebox;

	// Token: 0x04002EC8 RID: 11976
	public ClockScript Clock;

	// Token: 0x04002EC9 RID: 11977
	public StudentScript[] EventStudent;

	// Token: 0x04002ECA RID: 11978
	public Transform[] EventLocation;

	// Token: 0x04002ECB RID: 11979
	public AudioClip[] EventClip;

	// Token: 0x04002ECC RID: 11980
	public string[] EventSpeech;

	// Token: 0x04002ECD RID: 11981
	public string[] EventAnim;

	// Token: 0x04002ECE RID: 11982
	public int[] EventSpeaker;

	// Token: 0x04002ECF RID: 11983
	public int[] ClubIDs;

	// Token: 0x04002ED0 RID: 11984
	public GameObject VoiceClip;

	// Token: 0x04002ED1 RID: 11985
	public AudioSource VoiceClipSource;

	// Token: 0x04002ED2 RID: 11986
	public bool ReachedTheEnd;

	// Token: 0x04002ED3 RID: 11987
	public bool EventOn;

	// Token: 0x04002ED4 RID: 11988
	public bool Spoken;

	// Token: 0x04002ED5 RID: 11989
	public int EventPhase;

	// Token: 0x04002ED6 RID: 11990
	public float Timer;

	// Token: 0x04002ED7 RID: 11991
	public float Scale;

	// Token: 0x04002ED8 RID: 11992
	public int[] StudentID;

	// Token: 0x04002ED9 RID: 11993
	public DayOfWeek EventDay;
}
