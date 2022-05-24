using System;
using UnityEngine;

// Token: 0x020003E6 RID: 998
public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x0013F574 File Offset: 0x0013D774
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

	// Token: 0x06001BD3 RID: 7123 RVA: 0x0013F5EC File Offset: 0x0013D7EC
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
							if (this.Rival.Follower != null && !this.Rival.Follower.ReturningMisplacedWeapon && this.Rival.Follower.DistanceToDestination < 5f)
							{
								Debug.Log("Raibaru will be joining Osana for her bento event.");
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
				if (this.Rival.Follower != null && this.Rival.Follower.InEvent)
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
			if (this.Rival.Follower != null && this.Rival.Follower.InEvent)
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
			if (this.Rival.Follower != null && this.Rival.Follower.InEvent)
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
					if (this.Rival.Follower == null || !this.Rival.Follower.InEvent)
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
			else if (this.Rival.CharacterAnimation["f02_pondering_00"].time > this.Rival.CharacterAnimation["f02_pondering_00"].length || this.Timer > 20f)
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
			if (this.Clock.Period > 1 || this.Rival.Splashed || this.Rival.Electrified)
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

	// Token: 0x06001BD4 RID: 7124 RVA: 0x0013FE9C File Offset: 0x0013E09C
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
		if (!this.Rival.Alarmed && !this.Rival.Electrified && !this.Rival.Splashed)
		{
			this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		else
		{
			Debug.Log("The event ended specifically because Osana was alarmed, splashed, or killed.");
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
		if (this.Rival.Follower != null && this.Rival.Follower.InEvent)
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

	// Token: 0x0400303C RID: 12348
	public StudentManagerScript StudentManager;

	// Token: 0x0400303D RID: 12349
	public EventManagerScript NextEvent;

	// Token: 0x0400303E RID: 12350
	public JukeboxScript Jukebox;

	// Token: 0x0400303F RID: 12351
	public UILabel EventSubtitle;

	// Token: 0x04003040 RID: 12352
	public YandereScript Yandere;

	// Token: 0x04003041 RID: 12353
	public ClockScript Clock;

	// Token: 0x04003042 RID: 12354
	public StudentScript Rival;

	// Token: 0x04003043 RID: 12355
	public Transform Destination;

	// Token: 0x04003044 RID: 12356
	public AudioClip SpeechClip;

	// Token: 0x04003045 RID: 12357
	public string[] SpeechText;

	// Token: 0x04003046 RID: 12358
	public float[] SpeechTime;

	// Token: 0x04003047 RID: 12359
	public GameObject AlarmDisc;

	// Token: 0x04003048 RID: 12360
	public GameObject VoiceClip;

	// Token: 0x04003049 RID: 12361
	public GameObject[] Bentos;

	// Token: 0x0400304A RID: 12362
	public bool EventActive;

	// Token: 0x0400304B RID: 12363
	public bool HintGiven;

	// Token: 0x0400304C RID: 12364
	public float Distance;

	// Token: 0x0400304D RID: 12365
	public float Scale;

	// Token: 0x0400304E RID: 12366
	public float Timer;

	// Token: 0x0400304F RID: 12367
	public int SpeechPhase = 1;

	// Token: 0x04003050 RID: 12368
	public int RivalID = 11;

	// Token: 0x04003051 RID: 12369
	public int Phase;

	// Token: 0x04003052 RID: 12370
	public int Frame;
}
