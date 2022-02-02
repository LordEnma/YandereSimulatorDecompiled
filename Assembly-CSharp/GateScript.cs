using System;
using UnityEngine;

// Token: 0x020002D9 RID: 729
public class GateScript : MonoBehaviour
{
	// Token: 0x060014CA RID: 5322 RVA: 0x000CD398 File Offset: 0x000CB598
	private void Update()
	{
		if (!this.ManuallyAdjusted)
		{
			if (this.Clock.PresentTime / 60f > 8f && this.Clock.PresentTime / 60f < 15.5f)
			{
				if (!this.Closed)
				{
					this.PlayAudio();
					this.Closed = true;
					if (this.EmergencyDoor.enabled)
					{
						this.EmergencyDoor.enabled = false;
					}
				}
			}
			else if (this.Closed)
			{
				this.PlayAudio();
				this.Closed = false;
				if (!this.EmergencyDoor.enabled)
				{
					this.EmergencyDoor.enabled = true;
				}
			}
		}
		if (this.StudentManager.Students[97] != null)
		{
			if (this.StudentManager.Students[97].CurrentAction == StudentActionType.AtLocker && this.StudentManager.Students[97].Routine && this.StudentManager.Students[97].Alive)
			{
				if (Vector3.Distance(this.StudentManager.Students[97].transform.position, this.StudentManager.Podiums.List[0].position) < 0.1f)
				{
					if (this.ManuallyAdjusted)
					{
						this.ManuallyAdjusted = false;
					}
					this.Prompt.enabled = false;
					this.Prompt.Hide();
				}
				else
				{
					this.Prompt.enabled = true;
				}
			}
			else
			{
				this.Prompt.enabled = true;
			}
		}
		else
		{
			this.Prompt.enabled = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.PlayAudio();
			this.EmergencyDoor.enabled = !this.EmergencyDoor.enabled;
			this.ManuallyAdjusted = true;
			this.Closed = !this.Closed;
			if (this.StudentManager.Students[97] != null && this.StudentManager.Students[97].Investigating)
			{
				this.StudentManager.Students[97].StopInvestigating();
			}
		}
		if (!this.Closed)
		{
			if (this.RightGate.localPosition.x != 7f)
			{
				this.RightGate.localPosition = new Vector3(Mathf.MoveTowards(this.RightGate.localPosition.x, 7f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
				this.LeftGate.localPosition = new Vector3(Mathf.MoveTowards(this.LeftGate.localPosition.x, -7f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
				if (!this.AudioPlayed && this.RightGate.localPosition.x == 7f)
				{
					this.RightGateAudio.clip = this.StopOpen;
					this.LeftGateAudio.clip = this.StopOpen;
					this.RightGateAudio.Play();
					this.LeftGateAudio.Play();
					this.RightGateLoop.Stop();
					this.LeftGateLoop.Stop();
					this.AudioPlayed = true;
					return;
				}
			}
		}
		else if (this.RightGate.localPosition.x != 2.325f)
		{
			if (this.RightGate.localPosition.x < 2.4f)
			{
				this.Crushing = true;
			}
			this.RightGate.localPosition = new Vector3(Mathf.MoveTowards(this.RightGate.localPosition.x, 2.325f, Time.deltaTime), this.RightGate.localPosition.y, this.RightGate.localPosition.z);
			this.LeftGate.localPosition = new Vector3(Mathf.MoveTowards(this.LeftGate.localPosition.x, -2.325f, Time.deltaTime), this.LeftGate.localPosition.y, this.LeftGate.localPosition.z);
			if (!this.AudioPlayed && this.RightGate.localPosition.x == 2.325f)
			{
				this.RightGateAudio.clip = this.StopOpen;
				this.LeftGateAudio.clip = this.StopOpen;
				this.RightGateAudio.Play();
				this.LeftGateAudio.Play();
				this.RightGateLoop.Stop();
				this.LeftGateLoop.Stop();
				this.AudioPlayed = true;
				this.Crushing = false;
			}
		}
	}

	// Token: 0x060014CB RID: 5323 RVA: 0x000CD85C File Offset: 0x000CBA5C
	public void PlayAudio()
	{
		this.RightGateAudio.clip = this.Start;
		this.LeftGateAudio.clip = this.Start;
		this.RightGateAudio.Play();
		this.LeftGateAudio.Play();
		this.RightGateLoop.Play();
		this.LeftGateLoop.Play();
		this.AudioPlayed = false;
	}

	// Token: 0x040020C2 RID: 8386
	public StudentManagerScript StudentManager;

	// Token: 0x040020C3 RID: 8387
	public PromptScript Prompt;

	// Token: 0x040020C4 RID: 8388
	public ClockScript Clock;

	// Token: 0x040020C5 RID: 8389
	public Collider EmergencyDoor;

	// Token: 0x040020C6 RID: 8390
	public Collider GateCollider;

	// Token: 0x040020C7 RID: 8391
	public Transform RightGate;

	// Token: 0x040020C8 RID: 8392
	public Transform LeftGate;

	// Token: 0x040020C9 RID: 8393
	public bool ManuallyAdjusted;

	// Token: 0x040020CA RID: 8394
	public bool AudioPlayed;

	// Token: 0x040020CB RID: 8395
	public bool UpdateGates;

	// Token: 0x040020CC RID: 8396
	public bool Crushing;

	// Token: 0x040020CD RID: 8397
	public bool Closed;

	// Token: 0x040020CE RID: 8398
	public AudioSource RightGateAudio;

	// Token: 0x040020CF RID: 8399
	public AudioSource LeftGateAudio;

	// Token: 0x040020D0 RID: 8400
	public AudioSource RightGateLoop;

	// Token: 0x040020D1 RID: 8401
	public AudioSource LeftGateLoop;

	// Token: 0x040020D2 RID: 8402
	public AudioClip Start;

	// Token: 0x040020D3 RID: 8403
	public AudioClip StopOpen;

	// Token: 0x040020D4 RID: 8404
	public AudioClip StopClose;
}
