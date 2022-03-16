using System;
using UnityEngine;

// Token: 0x020003E0 RID: 992
public class OsanaMondayBeforeClassEventScript : MonoBehaviour
{
	// Token: 0x06001BB0 RID: 7088 RVA: 0x0013CD90 File Offset: 0x0013AF90
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

	// Token: 0x06001BB1 RID: 7089 RVA: 0x0013CE08 File Offset: 0x0013B008
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

	// Token: 0x06001BB2 RID: 7090 RVA: 0x0013D614 File Offset: 0x0013B814
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

	// Token: 0x04002FE9 RID: 12265
	public StudentManagerScript StudentManager;

	// Token: 0x04002FEA RID: 12266
	public EventManagerScript NextEvent;

	// Token: 0x04002FEB RID: 12267
	public JukeboxScript Jukebox;

	// Token: 0x04002FEC RID: 12268
	public UILabel EventSubtitle;

	// Token: 0x04002FED RID: 12269
	public YandereScript Yandere;

	// Token: 0x04002FEE RID: 12270
	public ClockScript Clock;

	// Token: 0x04002FEF RID: 12271
	public StudentScript Rival;

	// Token: 0x04002FF0 RID: 12272
	public Transform Destination;

	// Token: 0x04002FF1 RID: 12273
	public AudioClip SpeechClip;

	// Token: 0x04002FF2 RID: 12274
	public string[] SpeechText;

	// Token: 0x04002FF3 RID: 12275
	public float[] SpeechTime;

	// Token: 0x04002FF4 RID: 12276
	public GameObject AlarmDisc;

	// Token: 0x04002FF5 RID: 12277
	public GameObject VoiceClip;

	// Token: 0x04002FF6 RID: 12278
	public GameObject[] Bentos;

	// Token: 0x04002FF7 RID: 12279
	public bool EventActive;

	// Token: 0x04002FF8 RID: 12280
	public bool HintGiven;

	// Token: 0x04002FF9 RID: 12281
	public float Distance;

	// Token: 0x04002FFA RID: 12282
	public float Scale;

	// Token: 0x04002FFB RID: 12283
	public float Timer;

	// Token: 0x04002FFC RID: 12284
	public int SpeechPhase = 1;

	// Token: 0x04002FFD RID: 12285
	public int RivalID = 11;

	// Token: 0x04002FFE RID: 12286
	public int Phase;

	// Token: 0x04002FFF RID: 12287
	public int Frame;
}
