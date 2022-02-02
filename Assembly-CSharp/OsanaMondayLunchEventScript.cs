using System;
using UnityEngine;

// Token: 0x020003DE RID: 990
public class OsanaMondayLunchEventScript : MonoBehaviour
{
	// Token: 0x06001B93 RID: 7059 RVA: 0x0013B4A8 File Offset: 0x001396A8
	private void Start()
	{
		this.OriginalPosition = this.Epicenter.position;
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Week > 1 || DateGlobals.Weekday != DayOfWeek.Monday || GameGlobals.AlphabetMode || MissionModeGlobals.MissionMode || GameGlobals.Eighties)
		{
			base.gameObject.SetActive(false);
			base.enabled = false;
		}
	}

	// Token: 0x06001B94 RID: 7060 RVA: 0x0013B514 File Offset: 0x00139714
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[this.RivalID].enabled && this.StudentManager.Students[1].gameObject.activeInHierarchy && this.Clock.Period == 3)
			{
				Debug.Log("Osana's lunchtime event has begun.");
				if (this.ClubEvent.enabled)
				{
					this.ClubEvent.EndEvent();
				}
				this.DisableBentos();
				this.Bento[1].gameObject.SetActive(true);
				this.Bento[2].gameObject.SetActive(true);
				this.Senpai = this.StudentManager.Students[1];
				this.Rival = this.StudentManager.Students[this.RivalID];
				this.Friend = this.StudentManager.Students[this.FriendID];
				this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Senpai.CharacterAnimation.Play(this.Senpai.WalkAnim);
				this.Senpai.Pathfinding.target = this.Location[1];
				this.Senpai.CurrentDestination = this.Location[1];
				this.Senpai.SmartPhone.SetActive(false);
				this.Senpai.Pathfinding.canSearch = true;
				this.Senpai.Pathfinding.canMove = true;
				this.Senpai.Routine = false;
				this.Senpai.InEvent = true;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[0];
				this.Rival.CurrentDestination = this.Location[0];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.EmptyHands();
				this.Spy.gameObject.SetActive(true);
				if (this.Friend != null)
				{
					this.Friend.FocusOnYandere = false;
					this.Friend.InEvent = true;
					this.Friend.EmptyHands();
				}
				this.Yandere.PauseScreen.Hint.Show = true;
				this.Yandere.PauseScreen.Hint.QuickID = 7;
				this.Phase++;
			}
			this.Frame++;
		}
		else if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
				this.SpeechPhase++;
				AudioClipPlayer.Play(this.SpeechClip[0], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
				this.Epicenter.position = this.Rival.transform.position;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (this.Friend != null)
			{
				this.Friend.Pathfinding.target = this.Rival.transform;
				this.Friend.CurrentDestination = this.Rival.transform;
			}
			if (this.Rival.CharacterAnimation["f02_pondering_00"].time >= this.Rival.CharacterAnimation["f02_pondering_00"].length)
			{
				this.Epicenter.position = this.OriginalPosition;
				this.EventSubtitle.text = string.Empty;
				this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.Location[2];
				this.Rival.CurrentDestination = this.Location[2];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Bento[1].gameObject.SetActive(false);
				this.Bento[2].gameObject.SetActive(false);
				if (this.Friend != null)
				{
					this.Friend.Pathfinding.target = this.Rival.FollowTargetDestination;
					this.Friend.CurrentDestination = this.Rival.FollowTargetDestination;
				}
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Senpai.DistanceToDestination < 0.5f && this.Rival.DistanceToDestination < 0.5f)
			{
				this.MakeRaibaruGoHide();
				AudioClipPlayer.Play(this.SpeechClip[1], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Senpai.CharacterAnimation.CrossFade("Monday_2A");
				this.Rival.CharacterAnimation.CrossFade("f02_Monday_2A");
				this.Rival.Bento.transform.localEulerAngles = new Vector3(15f, this.Rival.Bento.transform.localEulerAngles.y, this.Rival.Bento.transform.localEulerAngles.z);
				this.Rival.Bento.transform.localPosition = new Vector3(-0.02f, this.Rival.Bento.transform.localPosition.y, this.Rival.Bento.transform.localPosition.z);
				this.Rival.Bento.SetActive(true);
				this.Senpai.Pathfinding.canSearch = false;
				this.Senpai.Pathfinding.canMove = false;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Phase++;
			}
			else
			{
				if (this.Senpai.DistanceToDestination < 0.5f)
				{
					this.Senpai.CharacterAnimation.CrossFade("thinking_00");
					this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
					this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
					this.Senpai.Pathfinding.canSearch = false;
					this.Senpai.Pathfinding.canMove = false;
				}
				if (this.Rival.DistanceToDestination < 0.5f)
				{
					this.Rival.CharacterAnimation.CrossFade("f02_pondering_00");
					this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
					this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
					this.Rival.Pathfinding.canSearch = false;
					this.Rival.Pathfinding.canMove = false;
				}
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			this.MakeRaibaruGoHide();
			this.Senpai.MoveTowardsTarget(this.Senpai.CurrentDestination.position);
			this.Senpai.transform.rotation = Quaternion.Slerp(this.Senpai.transform.rotation, this.Senpai.CurrentDestination.rotation, 10f * Time.deltaTime);
			this.Rival.MoveTowardsTarget(this.Rival.CurrentDestination.position);
			this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Rival.CurrentDestination.rotation, 10f * Time.deltaTime);
			if (this.Timer > 21.5f)
			{
				this.Senpai.Bento.transform.localPosition = new Vector3(-0.01652f, -0.02516f, -0.08239f);
				this.Senpai.Bento.transform.localEulerAngles = new Vector3(-35f, 116f, 165f);
				this.RotationX = -35f;
				this.RotationY = 115f;
				this.RotationZ = 165f;
				this.Senpai.Bento.SetActive(true);
				this.Rival.Bento.SetActive(false);
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			this.RotationX = Mathf.Lerp(this.RotationX, 6f, Time.deltaTime);
			this.RotationY = Mathf.Lerp(this.RotationY, 153f, Time.deltaTime);
			this.RotationZ = Mathf.Lerp(this.RotationZ, 102.5f, Time.deltaTime);
			this.Senpai.Bento.transform.localPosition = Vector3.Lerp(this.Senpai.Bento.transform.localPosition, new Vector3(-0.045f, -0.08f, -0.025f), Time.deltaTime);
			this.Senpai.Bento.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
			if (this.Timer > 29.833334f)
			{
				this.Senpai.Lid.transform.parent = this.Senpai.RightHand;
				this.Senpai.Lid.transform.localPosition = new Vector3(-0.025f, -0.025f, -0.015f);
				this.Senpai.Lid.transform.localEulerAngles = new Vector3(41.5f, -60f, -180f);
			}
			if (this.Timer > 30f && (float)this.Bento[1].Poison > 0f)
			{
				this.Senpai.CharacterAnimation.CrossFade("Monday_2B");
				this.Rival.CharacterAnimation.CrossFade("f02_Monday_2B");
				this.Sabotaged = true;
				this.SpeechPhase = 0;
			}
			if (this.Timer > 30.433332f)
			{
				this.Senpai.Lid.transform.parent = null;
				this.Senpai.Lid.transform.position = new Vector3(-0.31f, 12.501f, -29.335f);
				this.Senpai.Lid.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			}
			if (this.Timer > 31f)
			{
				this.Senpai.Chopsticks[0].SetActive(true);
				this.Senpai.Chopsticks[1].SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			this.Timer += Time.deltaTime;
			if (!this.Sabotaged)
			{
				if (this.Timer > 37.15f)
				{
					AudioClipPlayer.Play(this.SpeechClip[2], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.Phase++;
				}
			}
			else if (this.Timer > 41f)
			{
				AudioClipPlayer.Play(this.SpeechClip[3], this.Epicenter.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.Phase++;
			}
		}
		else if (this.Phase == 7)
		{
			this.Timer += Time.deltaTime;
			if (!this.Sabotaged)
			{
				if (this.Senpai.CharacterAnimation["Monday_2A"].time > this.Senpai.CharacterAnimation["Monday_2A"].length)
				{
					this.EndEvent();
				}
			}
			else
			{
				if (this.Timer > 44.5f && this.Senpai.Bento.transform.parent != null)
				{
					this.Senpai.Bento.transform.parent = null;
					this.Senpai.Bento.transform.position = new Vector3(-0.853f, 12.501f, -29.33333f);
					this.Senpai.Bento.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					this.Senpai.Chopsticks[0].SetActive(false);
					this.Senpai.Chopsticks[1].SetActive(false);
				}
				if (this.Senpai.InEvent && this.Senpai.CharacterAnimation["Monday_2B"].time > this.Senpai.CharacterAnimation["Monday_2B"].length)
				{
					this.Senpai.WalkAnim = "stomachPainWalk_00";
					this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.Senpai.Pathfinding.target = this.StudentManager.MaleVomitSpots[3];
					this.Senpai.CurrentDestination = this.StudentManager.MaleVomitSpots[3];
					this.Senpai.CharacterAnimation.CrossFade(this.Senpai.WalkAnim);
					this.Senpai.Pathfinding.canSearch = true;
					this.Senpai.Pathfinding.canMove = true;
					this.Senpai.Pathfinding.speed = 2f;
					this.Senpai.Distracted = true;
					this.Senpai.Vomiting = true;
					this.Senpai.InEvent = false;
					this.Senpai.Routine = false;
					this.Senpai.Private = true;
					this.StudentManager.SabotageProgress++;
					Debug.Log("Sabotage Progress: " + this.StudentManager.SabotageProgress.ToString() + "/5");
				}
				if (this.Rival.CharacterAnimation["f02_Monday_2B"].time > this.Rival.CharacterAnimation["f02_Monday_2B"].length)
				{
					this.EndEvent();
				}
			}
		}
		if (this.Phase > 3)
		{
			if (!this.Sabotaged)
			{
				if (this.SpeechPhase < this.SpeechTime.Length && this.Timer > this.SpeechTime[this.SpeechPhase])
				{
					this.EventSubtitle.text = this.SpeechText[this.SpeechPhase];
					this.SpeechPhase++;
				}
			}
			else if (this.SpeechPhase < this.SabotagedSpeechTime.Length && this.Timer > 41f + this.SabotagedSpeechTime[this.SpeechPhase])
			{
				this.EventSubtitle.text = this.SabotagedSpeechText[this.SpeechPhase];
				this.SpeechPhase++;
			}
			if (this.Friend.DistanceToDestination < 1f)
			{
				this.Friend.CharacterAnimation.CrossFade("f02_cornerPeek_00");
				this.Friend.Pathfinding.canSearch = false;
				this.Friend.Pathfinding.canMove = false;
				if (!this.Friend.MyBento.gameObject.activeInHierarchy && !this.Friend.MyBento.Tampered)
				{
					this.Friend.MyBento.gameObject.SetActive(true);
					this.Friend.MyBento.transform.parent = null;
					this.Friend.MyBento.transform.position = this.Bento[3].transform.position;
					this.Friend.MyBento.transform.eulerAngles = this.Bento[3].transform.eulerAngles;
					this.Friend.MyBento.Prompt.enabled = true;
				}
				this.SettleFriend();
			}
		}
		if (this.Phase > 0)
		{
			if (this.Clock.Period > 3 || this.Senpai.Alarmed || this.Rival.Alarmed || this.Rival.Wet)
			{
				if (this.Senpai.Alarmed || (this.Rival.Alarmed && !this.Rival.Wet))
				{
					UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, this.Yandere.transform.position + Vector3.up, Quaternion.identity).GetComponent<AlarmDiscScript>().NoScream = true;
				}
				this.EndEvent();
			}
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().pitch = Time.timeScale;
			}
			this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Epicenter.position);
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
					if (this.Phase > 3)
					{
						this.Yandere.Eavesdropping = (this.Distance < 2.5f);
						return;
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
	}

	// Token: 0x06001B95 RID: 7061 RVA: 0x0013C9B0 File Offset: 0x0013ABB0
	private void SettleFriend()
	{
		this.Friend.MoveTowardsTarget(this.Location[3].position);
		if (Quaternion.Angle(this.Friend.transform.rotation, this.Location[3].rotation) > 1f)
		{
			this.Friend.transform.rotation = Quaternion.Slerp(this.Friend.transform.rotation, this.Location[3].rotation, 10f * Time.deltaTime);
		}
	}

	// Token: 0x06001B96 RID: 7062 RVA: 0x0013CA3C File Offset: 0x0013AC3C
	private void EndEvent()
	{
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Senpai.InEvent)
		{
			this.Senpai.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Senpai.InEvent = false;
			this.Senpai.Private = false;
			this.Senpai.Pathfinding.canSearch = true;
			this.Senpai.Pathfinding.canMove = true;
			this.Senpai.TargetDistance = 1f;
			this.Senpai.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.Rival.Splashed)
		{
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
		}
		else
		{
			this.Rival.Pathfinding.canSearch = false;
			this.Rival.Pathfinding.canMove = false;
		}
		this.Rival.TargetDistance = 1f;
		this.Rival.Routine = !this.Rival.Splashed;
		if (this.Rival.Alarmed || this.Senpai.Alarmed)
		{
			this.Senpai.Pathfinding.canSearch = false;
			this.Senpai.Pathfinding.canMove = false;
			this.Senpai.TargetDistance = 0.5f;
			this.Senpai.Routine = !this.Senpai.Alarmed;
			this.Rival.Pathfinding.canSearch = false;
			this.Rival.Pathfinding.canMove = false;
			this.Rival.TargetDistance = 0.5f;
			this.Rival.Routine = !this.Rival.Alarmed;
		}
		if (this.Friend != null)
		{
			if (!this.Friend.Alarmed)
			{
				this.Friend.Pathfinding.canSearch = true;
				this.Friend.Pathfinding.canMove = true;
				this.Friend.Routine = true;
			}
			this.Friend.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Friend.Prompt.enabled = true;
			this.Friend.InEvent = false;
			this.Friend.Private = false;
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[4];
			scheduleBlock.destination = "LunchSpot";
			scheduleBlock.action = "Eat";
			this.Friend.GetDestinations();
			this.Friend.CurrentDestination = this.Friend.Destinations[this.Friend.Phase];
			this.Friend.Pathfinding.target = this.Friend.Destinations[this.Friend.Phase];
			this.Friend.DistanceToDestination = 100f;
			this.Friend.MyBento.gameObject.SetActive(false);
			this.Friend.MyBento.transform.parent = this.Friend.LeftHand;
			this.Friend.MyBento.transform.localPosition = new Vector3(-0.025f, -0.105f, 0f);
			this.Friend.MyBento.transform.localEulerAngles = new Vector3(0f, 165f, 82.5f);
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
		this.EventSubtitle.text = string.Empty;
		this.Yandere.Eavesdropping = false;
		base.enabled = false;
		this.Jukebox.Dip = 1f;
		Debug.Log("Ending Osana's Monday Lunch Event.");
		this.DisableBentos();
	}

	// Token: 0x06001B97 RID: 7063 RVA: 0x0013CE74 File Offset: 0x0013B074
	private void DisableBentos()
	{
		this.Bento[1].Prompt.Hide();
		this.Bento[1].Prompt.enabled = false;
		this.Bento[2].Prompt.Hide();
		this.Bento[2].Prompt.enabled = false;
		this.Bento[1].gameObject.SetActive(false);
		this.Bento[2].gameObject.SetActive(false);
		this.Bento[1].enabled = false;
		this.Bento[2].enabled = false;
	}

	// Token: 0x06001B98 RID: 7064 RVA: 0x0013CF10 File Offset: 0x0013B110
	private void MakeRaibaruGoHide()
	{
		if (this.Friend != null && this.Friend.DistanceToDestination > 1f)
		{
			this.Friend.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			this.Friend.CharacterAnimation.Play(this.Friend.WalkAnim);
			this.Friend.Pathfinding.target = this.Location[3];
			this.Friend.CurrentDestination = this.Location[3];
			this.Friend.Pathfinding.canSearch = true;
			this.Friend.Pathfinding.canMove = true;
			this.Friend.Routine = false;
			this.Friend.InEvent = true;
		}
	}

	// Token: 0x04002F9C RID: 12188
	public StudentManagerScript StudentManager;

	// Token: 0x04002F9D RID: 12189
	public OsanaClubEventScript ClubEvent;

	// Token: 0x04002F9E RID: 12190
	public JukeboxScript Jukebox;

	// Token: 0x04002F9F RID: 12191
	public UILabel EventSubtitle;

	// Token: 0x04002FA0 RID: 12192
	public YandereScript Yandere;

	// Token: 0x04002FA1 RID: 12193
	public ClockScript Clock;

	// Token: 0x04002FA2 RID: 12194
	public SpyScript Spy;

	// Token: 0x04002FA3 RID: 12195
	public StudentScript Senpai;

	// Token: 0x04002FA4 RID: 12196
	public StudentScript Friend;

	// Token: 0x04002FA5 RID: 12197
	public StudentScript Rival;

	// Token: 0x04002FA6 RID: 12198
	public BentoScript[] Bento;

	// Token: 0x04002FA7 RID: 12199
	public string[] SabotagedSpeechText;

	// Token: 0x04002FA8 RID: 12200
	public string[] SpeechText;

	// Token: 0x04002FA9 RID: 12201
	public float[] SabotagedSpeechTime;

	// Token: 0x04002FAA RID: 12202
	public float[] SpeechTime;

	// Token: 0x04002FAB RID: 12203
	public AudioClip[] SpeechClip;

	// Token: 0x04002FAC RID: 12204
	public Transform[] Location;

	// Token: 0x04002FAD RID: 12205
	public Transform Epicenter;

	// Token: 0x04002FAE RID: 12206
	public GameObject AlarmDisc;

	// Token: 0x04002FAF RID: 12207
	public GameObject VoiceClip;

	// Token: 0x04002FB0 RID: 12208
	public Vector3 OriginalPosition;

	// Token: 0x04002FB1 RID: 12209
	public bool Sabotaged;

	// Token: 0x04002FB2 RID: 12210
	public float Distance;

	// Token: 0x04002FB3 RID: 12211
	public float Scale;

	// Token: 0x04002FB4 RID: 12212
	public float Timer;

	// Token: 0x04002FB5 RID: 12213
	public float RotationX;

	// Token: 0x04002FB6 RID: 12214
	public float RotationY;

	// Token: 0x04002FB7 RID: 12215
	public float RotationZ;

	// Token: 0x04002FB8 RID: 12216
	public int SpeechPhase = 1;

	// Token: 0x04002FB9 RID: 12217
	public int DebugPoison;

	// Token: 0x04002FBA RID: 12218
	public int FriendID = 6;

	// Token: 0x04002FBB RID: 12219
	public int RivalID = 11;

	// Token: 0x04002FBC RID: 12220
	public int Phase;

	// Token: 0x04002FBD RID: 12221
	public int Frame;
}
