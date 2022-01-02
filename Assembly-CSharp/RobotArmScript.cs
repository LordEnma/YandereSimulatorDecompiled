using System;
using UnityEngine;

// Token: 0x020003E5 RID: 997
public class RobotArmScript : MonoBehaviour
{
	// Token: 0x06001BB9 RID: 7097 RVA: 0x001421B4 File Offset: 0x001403B4
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

	// Token: 0x06001BBA RID: 7098 RVA: 0x001427E0 File Offset: 0x001409E0
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

	// Token: 0x06001BBB RID: 7099 RVA: 0x00142885 File Offset: 0x00140A85
	public void ToggleWork()
	{
		this.Prompt.Circle[1].fillAmount = 1f;
		this.StartWorkTimer = 1f;
		this.StopWorkTimer = 5f;
		this.Work = !this.Work;
	}

	// Token: 0x040030A3 RID: 12451
	public SkinnedMeshRenderer RobotArms;

	// Token: 0x040030A4 RID: 12452
	public AudioSource MyAudio;

	// Token: 0x040030A5 RID: 12453
	public PromptScript Prompt;

	// Token: 0x040030A6 RID: 12454
	public Transform TerminalTarget;

	// Token: 0x040030A7 RID: 12455
	public ParticleSystem[] Sparks;

	// Token: 0x040030A8 RID: 12456
	public AudioClip ArmsOff;

	// Token: 0x040030A9 RID: 12457
	public AudioClip ArmsOn;

	// Token: 0x040030AA RID: 12458
	public float StartWorkTimer;

	// Token: 0x040030AB RID: 12459
	public float StopWorkTimer;

	// Token: 0x040030AC RID: 12460
	public float[] ArmValue;

	// Token: 0x040030AD RID: 12461
	public float[] Timer;

	// Token: 0x040030AE RID: 12462
	public bool UpdateArms;

	// Token: 0x040030AF RID: 12463
	public bool Work;

	// Token: 0x040030B0 RID: 12464
	public bool[] On;

	// Token: 0x040030B1 RID: 12465
	public int ID;
}
