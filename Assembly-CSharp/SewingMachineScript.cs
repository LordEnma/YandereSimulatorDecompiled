using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SewingMachineScript : MonoBehaviour
{
	// Token: 0x06001CB8 RID: 7352 RVA: 0x00151761 File Offset: 0x0014F961
	private void Start()
	{
		if (this.StudentManager.TaskManager.TaskStatus[30] == 1)
		{
			this.Check = true;
			return;
		}
		if (this.StudentManager.TaskManager.TaskStatus[30] > 2)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x001517A0 File Offset: 0x0014F9A0
	private void Update()
	{
		if (this.Check)
		{
			if (this.Yandere.PickUp != null)
			{
				if (this.Yandere.PickUp.Clothing && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Clean && this.Yandere.PickUp.GetComponent<FoldedUniformScript>().Type == 1 && this.Yandere.PickUp.gameObject.GetComponent<FoldedUniformScript>().Type == 1)
				{
					this.Prompt.enabled = true;
				}
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.CharacterAnimation.CrossFade("f02_sewing_00");
				this.Yandere.MyController.radius = 0.1f;
				this.Yandere.CanMove = false;
				this.Chair.enabled = false;
				this.Sewing = true;
				base.GetComponent<AudioSource>().Play();
				this.Uniform = this.Yandere.PickUp;
				this.Yandere.EmptyHands();
				this.Uniform.transform.parent = this.Yandere.RightHand;
				this.Uniform.transform.localPosition = new Vector3(0f, 0f, 0.09f);
				this.Uniform.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				this.Uniform.MyRigidbody.useGravity = false;
				this.Uniform.MyCollider.enabled = false;
			}
		}
		if (this.Sewing)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer < 5f)
			{
				this.targetRotation = Quaternion.LookRotation(base.transform.parent.transform.parent.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.Yandere.MoveTowardsTarget(this.Chair.transform.position);
				return;
			}
			if (!this.MoveAway)
			{
				this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
				this.Yandere.Inventory.ModifiedUniform = true;
				this.StudentManager.Students[30].TaskPhase = 5;
				this.StudentManager.TaskManager.TaskStatus[30] = 2;
				UnityEngine.Object.Destroy(this.Uniform.gameObject);
				this.MoveAway = true;
				this.Check = false;
				return;
			}
			this.Yandere.MoveTowardsTarget(this.Chair.gameObject.transform.position + new Vector3(-0.5f, 0f, 0f));
			if (this.Timer > 6f)
			{
				this.Yandere.MyController.radius = 0.2f;
				this.Yandere.CanMove = true;
				this.Chair.enabled = true;
				base.enabled = false;
				this.Sewing = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
	}

	// Token: 0x0400334C RID: 13132
	public StudentManagerScript StudentManager;

	// Token: 0x0400334D RID: 13133
	public YandereScript Yandere;

	// Token: 0x0400334E RID: 13134
	public PromptScript Prompt;

	// Token: 0x0400334F RID: 13135
	public Quaternion targetRotation;

	// Token: 0x04003350 RID: 13136
	public PickUpScript Uniform;

	// Token: 0x04003351 RID: 13137
	public Collider Chair;

	// Token: 0x04003352 RID: 13138
	public bool MoveAway;

	// Token: 0x04003353 RID: 13139
	public bool Sewing;

	// Token: 0x04003354 RID: 13140
	public bool Check;

	// Token: 0x04003355 RID: 13141
	public float Timer;
}
