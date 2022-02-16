using System;
using UnityEngine;

// Token: 0x020002DA RID: 730
public class GateScript : MonoBehaviour
{
	// Token: 0x060014CF RID: 5327 RVA: 0x000CD5D0 File Offset: 0x000CB7D0
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

	// Token: 0x060014D0 RID: 5328 RVA: 0x000CDA94 File Offset: 0x000CBC94
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

	// Token: 0x040020CA RID: 8394
	public StudentManagerScript StudentManager;

	// Token: 0x040020CB RID: 8395
	public PromptScript Prompt;

	// Token: 0x040020CC RID: 8396
	public ClockScript Clock;

	// Token: 0x040020CD RID: 8397
	public Collider EmergencyDoor;

	// Token: 0x040020CE RID: 8398
	public Collider GateCollider;

	// Token: 0x040020CF RID: 8399
	public Transform RightGate;

	// Token: 0x040020D0 RID: 8400
	public Transform LeftGate;

	// Token: 0x040020D1 RID: 8401
	public bool ManuallyAdjusted;

	// Token: 0x040020D2 RID: 8402
	public bool AudioPlayed;

	// Token: 0x040020D3 RID: 8403
	public bool UpdateGates;

	// Token: 0x040020D4 RID: 8404
	public bool Crushing;

	// Token: 0x040020D5 RID: 8405
	public bool Closed;

	// Token: 0x040020D6 RID: 8406
	public AudioSource RightGateAudio;

	// Token: 0x040020D7 RID: 8407
	public AudioSource LeftGateAudio;

	// Token: 0x040020D8 RID: 8408
	public AudioSource RightGateLoop;

	// Token: 0x040020D9 RID: 8409
	public AudioSource LeftGateLoop;

	// Token: 0x040020DA RID: 8410
	public AudioClip Start;

	// Token: 0x040020DB RID: 8411
	public AudioClip StopOpen;

	// Token: 0x040020DC RID: 8412
	public AudioClip StopClose;
}
