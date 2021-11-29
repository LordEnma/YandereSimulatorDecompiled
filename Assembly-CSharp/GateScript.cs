using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class GateScript : MonoBehaviour
{
	// Token: 0x060014BE RID: 5310 RVA: 0x000CC1C4 File Offset: 0x000CA3C4
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

	// Token: 0x060014BF RID: 5311 RVA: 0x000CC688 File Offset: 0x000CA888
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

	// Token: 0x04002093 RID: 8339
	public StudentManagerScript StudentManager;

	// Token: 0x04002094 RID: 8340
	public PromptScript Prompt;

	// Token: 0x04002095 RID: 8341
	public ClockScript Clock;

	// Token: 0x04002096 RID: 8342
	public Collider EmergencyDoor;

	// Token: 0x04002097 RID: 8343
	public Collider GateCollider;

	// Token: 0x04002098 RID: 8344
	public Transform RightGate;

	// Token: 0x04002099 RID: 8345
	public Transform LeftGate;

	// Token: 0x0400209A RID: 8346
	public bool ManuallyAdjusted;

	// Token: 0x0400209B RID: 8347
	public bool AudioPlayed;

	// Token: 0x0400209C RID: 8348
	public bool UpdateGates;

	// Token: 0x0400209D RID: 8349
	public bool Crushing;

	// Token: 0x0400209E RID: 8350
	public bool Closed;

	// Token: 0x0400209F RID: 8351
	public AudioSource RightGateAudio;

	// Token: 0x040020A0 RID: 8352
	public AudioSource LeftGateAudio;

	// Token: 0x040020A1 RID: 8353
	public AudioSource RightGateLoop;

	// Token: 0x040020A2 RID: 8354
	public AudioSource LeftGateLoop;

	// Token: 0x040020A3 RID: 8355
	public AudioClip Start;

	// Token: 0x040020A4 RID: 8356
	public AudioClip StopOpen;

	// Token: 0x040020A5 RID: 8357
	public AudioClip StopClose;
}
