using System;
using UnityEngine;

// Token: 0x020003DD RID: 989
public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
	// Token: 0x06001B8E RID: 7054 RVA: 0x0013A570 File Offset: 0x00138770
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		this.Bentos[1].SetActive(false);
		this.Bentos[2].SetActive(false);
		if (DateGlobals.Weekday != DayOfWeek.Monday || StudentGlobals.StudentSlave == this.RivalID || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B8F RID: 7055 RVA: 0x0013A5E8 File Offset: 0x001387E8
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0)
			{
				if (this.Clock.Period == 1)
				{
					if (this.StudentManager.Students[this.RivalID] != null)
					{
						if (this.Rival == null)
						{
							this.Rival = this.StudentManager.Students[this.RivalID];
						}
						else if (this.Rival.enabled && this.Rival.Indoors && !this.Rival.Alarmed && !this.Rival.WitnessedCorpse && !this.Rival.WitnessedMurder)
						{
							Debug.Log("Osana's before class event has begun. Putting two bento boxes on her desk.");
							this.Rival.CharacterAnimation["f02_pondering_00"].speed = 0.65f;
							this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
							this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
							this.Rival.Pathfinding.target = this.Destination;
							this.Rival.CurrentDestination = this.Destination;
							this.Rival.Pathfinding.canSearch = true;
							this.Rival.Pathfinding.canMove = true;
							this.Rival.Routine = false;
							this.Rival.InEvent = true;
							if (this.Rival.Follower != null)
							{
								this.Rival.Follower.TargetDistance = 1.5f;
								this.Rival.Follower.InEvent = true;
								this.Rival.Follower.CurrentDestination = this.Rival.FollowTargetDestination;
								this.Rival.Follower.Pathfinding.target = this.Rival.FollowTargetDestination;
							}
							if (!this.HintGiven)
							{
								this.Yandere.PauseScreen.Hint.Show = true;
								this.Yandere.PauseScreen.Hint.QuickID = 13;
								this.HintGiven = true;
							}
							this.Phase++;
						}
					}
					else
					{
						base.enabled = false;
					}
				}
				else
				{
					base.enabled = false;
				}
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				if (this.Rival.Follower != null)
				{
					this.Rival.Follower.CurrentDestination = this.Rival.transform;
					this.Rival.Follower.Pathfinding.target = this.Rival.transform;
				}
				this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Bentos[1].SetActive(true);
				this.Bentos[2].SetActive(true);
				this.Phase++;
			}
			if (this.Rival.Follower != null)
			{
				if (this.Rival.Follower.DistanceToDestination >= this.Rival.Follower.TargetDistance + 0.1f)
				{
					this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.WalkAnim);
				}
				else
				{
					this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.IdleAnim);
				}
			}
		}
		else
		{
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (this.Rival.Follower != null)
			{
				if (this.Rival.Follower.DistanceToDestination >= this.Rival.Follower.TargetDistance + 0.1f)
				{
					this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.WalkAnim);
				}
				else
				{
					this.Rival.Follower.CharacterAnimation.CrossFade(this.Rival.Follower.IdleAnim);
				}
			}
			this.Timer += Time.deltaTime;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			if (this.SpeechPhase < this.SpeechTime.Length)
			{
				if (this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					if (this.Rival.Follower == null)
					{
						this.EndEvent();
					}
					else
					{
						this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
						this.SpeechPhase++;
					}
				}
			}
			else if (this.Rival.CharacterAnimation["f02_pondering_00"].time > this.Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				this.EndEvent();
			}
			if (this.Rival.Alarmed || this.Rival.Splashed || (this.Rival.Follower != null && this.Rival.Follower.DramaticReaction))
			{
				UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				this.EndEvent();
			}
			else if (this.Rival.Dying)
			{
				this.EndEvent();
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
			if (base.enabled)
			{
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
			}
		}
		if (this.Phase > 0)
		{
			if (this.Clock.Period > 1 || this.Rival.Splashed)
			{
				this.EndEvent();
			}
			if (!this.Yandere.NoDebug && Input.GetKeyDown(KeyCode.LeftControl))
			{
				this.Bentos[1].SetActive(true);
				this.Bentos[2].SetActive(true);
				this.EndEvent();
			}
		}
	}

	// Token: 0x06001B90 RID: 7056 RVA: 0x0013ADF4 File Offset: 0x00138FF4
	public void EndEvent()
	{
		Debug.Log("Osana's before class event ended.");
		this.Bentos[1].GetComponent<BentoScript>().enabled = true;
		this.Bentos[2].GetComponent<BentoScript>().enabled = true;
		this.Bentos[1].GetComponent<PromptScript>().enabled = true;
		this.Bentos[2].GetComponent<PromptScript>().enabled = true;
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		else
		{
			Debug.Log("The event ended specifically because Osana was alarmed.");
			this.Rival.Pathfinding.canSearch = false;
			this.Rival.Pathfinding.canMove = false;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.DistanceToDestination = 999f;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Rival.CharacterAnimation["f02_pondering_00"].speed = 1f;
		this.Jukebox.Dip = 1f;
		if (this.Rival.Follower != null)
		{
			this.Rival.Follower.TargetDistance = 1f;
			this.Rival.Follower.InEvent = false;
			this.Rival.Follower.CurrentDestination = this.Rival.FollowTargetDestination;
			this.Rival.Follower.Pathfinding.target = this.Rival.FollowTargetDestination;
		}
		this.EventSubtitle.text = string.Empty;
		this.NextEvent.enabled = true;
		base.enabled = false;
	}

	// Token: 0x04002F7F RID: 12159
	public StudentManagerScript StudentManager;

	// Token: 0x04002F80 RID: 12160
	public EventManagerScript NextEvent;

	// Token: 0x04002F81 RID: 12161
	public JukeboxScript Jukebox;

	// Token: 0x04002F82 RID: 12162
	public UILabel EventSubtitle;

	// Token: 0x04002F83 RID: 12163
	public YandereScript Yandere;

	// Token: 0x04002F84 RID: 12164
	public ClockScript Clock;

	// Token: 0x04002F85 RID: 12165
	public StudentScript Rival;

	// Token: 0x04002F86 RID: 12166
	public Transform Destination;

	// Token: 0x04002F87 RID: 12167
	public AudioClip SpeechClip;

	// Token: 0x04002F88 RID: 12168
	public string[] SpeechText;

	// Token: 0x04002F89 RID: 12169
	public float[] SpeechTime;

	// Token: 0x04002F8A RID: 12170
	public GameObject AlarmDisc;

	// Token: 0x04002F8B RID: 12171
	public GameObject VoiceClip;

	// Token: 0x04002F8C RID: 12172
	public GameObject[] Bentos;

	// Token: 0x04002F8D RID: 12173
	public bool EventActive;

	// Token: 0x04002F8E RID: 12174
	public bool HintGiven;

	// Token: 0x04002F8F RID: 12175
	public float Distance;

	// Token: 0x04002F90 RID: 12176
	public float Scale;

	// Token: 0x04002F91 RID: 12177
	public float Timer;

	// Token: 0x04002F92 RID: 12178
	public int SpeechPhase = 1;

	// Token: 0x04002F93 RID: 12179
	public int RivalID = 11;

	// Token: 0x04002F94 RID: 12180
	public int Phase;

	// Token: 0x04002F95 RID: 12181
	public int Frame;
}
