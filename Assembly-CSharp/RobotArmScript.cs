using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class RobotArmScript : MonoBehaviour
{
	// Token: 0x06001BD7 RID: 7127 RVA: 0x001455C4 File Offset: 0x001437C4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.ActivateArms();
		}
		if (this.Prompt.Circle[1].fillAmount == 0f)
		{
			this.ToggleWork();
		}
		if (this.UpdateArms)
		{
			if (this.On[0])
			{
				this.ArmValue[0] = Mathf.Lerp(this.ArmValue[0], 0f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(0, this.ArmValue[0]);
				if (this.ArmValue[0] < 0.1f)
				{
					this.RobotArms.SetBlendShapeWeight(0, 0f);
					this.UpdateArms = false;
					this.ArmValue[0] = 0f;
				}
			}
			else
			{
				this.ArmValue[0] = Mathf.Lerp(this.ArmValue[0], 100f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(0, this.ArmValue[0]);
				if (this.ArmValue[0] > 99.9f)
				{
					this.RobotArms.SetBlendShapeWeight(0, 100f);
					this.UpdateArms = false;
					this.ArmValue[0] = 100f;
				}
			}
		}
		if (this.Work)
		{
			if (this.StartWorkTimer <= 0f)
			{
				this.ID = 1;
				while (this.ID < 9)
				{
					this.Timer[this.ID] -= Time.deltaTime;
					if (this.Timer[this.ID] < 0f)
					{
						this.Sparks[this.ID].Stop();
						this.Sparks[this.ID + 1].Stop();
						if (UnityEngine.Random.Range(0, 2) == 1)
						{
							this.On[this.ID] = true;
						}
						else
						{
							this.On[this.ID] = false;
						}
						this.Timer[this.ID] = UnityEngine.Random.Range(1f, 2f);
					}
					if (this.On[this.ID])
					{
						this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 0f, Time.deltaTime * 5f);
						this.ArmValue[this.ID + 1] = Mathf.Lerp(this.ArmValue[this.ID + 1], 100f, Time.deltaTime * 5f);
						this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
						this.RobotArms.SetBlendShapeWeight(this.ID + 1, this.ArmValue[this.ID + 1]);
						if (this.ArmValue[this.ID] < 1f)
						{
							this.Sparks[this.ID].Play();
							this.RobotArms.SetBlendShapeWeight(this.ID, 0f);
							this.RobotArms.SetBlendShapeWeight(this.ID + 1, 100f);
							this.ArmValue[this.ID] = 0f;
							this.ArmValue[this.ID + 1] = 100f;
						}
					}
					else
					{
						this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 100f, Time.deltaTime * 5f);
						this.ArmValue[this.ID + 1] = Mathf.Lerp(this.ArmValue[this.ID + 1], 0f, Time.deltaTime * 5f);
						this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
						this.RobotArms.SetBlendShapeWeight(this.ID + 1, this.ArmValue[this.ID + 1]);
						if (this.ArmValue[this.ID] > 99f)
						{
							this.Sparks[this.ID + 1].Play();
							this.RobotArms.SetBlendShapeWeight(this.ID, 100f);
							this.RobotArms.SetBlendShapeWeight(this.ID + 1, 0f);
							this.ArmValue[this.ID] = 100f;
							this.ArmValue[this.ID + 1] = 0f;
						}
					}
					this.ID += 2;
				}
				return;
			}
			this.ID = 1;
			while (this.ID < 9)
			{
				this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 100f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
				this.ID += 2;
			}
			this.StartWorkTimer -= Time.deltaTime;
			if (this.StartWorkTimer < 0f)
			{
				this.ID = 1;
				while (this.ID < 9)
				{
					this.RobotArms.SetBlendShapeWeight(this.ID, 100f);
					this.ID += 2;
				}
				return;
			}
		}
		else if (this.StopWorkTimer > 0f)
		{
			this.ID = 1;
			while (this.ID < 9)
			{
				this.ArmValue[this.ID] = Mathf.Lerp(this.ArmValue[this.ID], 0f, Time.deltaTime * 5f);
				this.RobotArms.SetBlendShapeWeight(this.ID, this.ArmValue[this.ID]);
				this.Sparks[this.ID].Stop();
				this.ID++;
			}
			this.StopWorkTimer -= Time.deltaTime;
			if (this.StopWorkTimer < 0f)
			{
				this.ID = 1;
				while (this.ID < 9)
				{
					this.RobotArms.SetBlendShapeWeight(this.ID, 0f);
					this.On[this.ID] = false;
					this.ID++;
				}
			}
		}
	}

	// Token: 0x06001BD8 RID: 7128 RVA: 0x00145BF0 File Offset: 0x00143DF0
	public void ActivateArms()
	{
		this.Prompt.Circle[0].fillAmount = 1f;
		this.UpdateArms = true;
		this.On[0] = !this.On[0];
		if (this.On[0])
		{
			this.Prompt.HideButton[1] = false;
			this.MyAudio.clip = this.ArmsOn;
		}
		else
		{
			this.Prompt.HideButton[1] = true;
			this.MyAudio.clip = this.ArmsOff;
			this.StopWorkTimer = 5f;
			this.Work = false;
		}
		this.MyAudio.Play();
	}

	// Token: 0x06001BD9 RID: 7129 RVA: 0x00145C95 File Offset: 0x00143E95
	public void ToggleWork()
	{
		this.Prompt.Circle[1].fillAmount = 1f;
		this.StartWorkTimer = 1f;
		this.StopWorkTimer = 5f;
		this.Work = !this.Work;
	}

	// Token: 0x040030E4 RID: 12516
	public SkinnedMeshRenderer RobotArms;

	// Token: 0x040030E5 RID: 12517
	public AudioSource MyAudio;

	// Token: 0x040030E6 RID: 12518
	public PromptScript Prompt;

	// Token: 0x040030E7 RID: 12519
	public Transform TerminalTarget;

	// Token: 0x040030E8 RID: 12520
	public ParticleSystem[] Sparks;

	// Token: 0x040030E9 RID: 12521
	public AudioClip ArmsOff;

	// Token: 0x040030EA RID: 12522
	public AudioClip ArmsOn;

	// Token: 0x040030EB RID: 12523
	public float StartWorkTimer;

	// Token: 0x040030EC RID: 12524
	public float StopWorkTimer;

	// Token: 0x040030ED RID: 12525
	public float[] ArmValue;

	// Token: 0x040030EE RID: 12526
	public float[] Timer;

	// Token: 0x040030EF RID: 12527
	public bool UpdateArms;

	// Token: 0x040030F0 RID: 12528
	public bool Work;

	// Token: 0x040030F1 RID: 12529
	public bool[] On;

	// Token: 0x040030F2 RID: 12530
	public int ID;
}
