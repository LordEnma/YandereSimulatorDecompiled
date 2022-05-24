using System;
using UnityEngine;

// Token: 0x02000428 RID: 1064
public class SewingMachineScript : MonoBehaviour
{
	// Token: 0x06001CB9 RID: 7353 RVA: 0x00151A1D File Offset: 0x0014FC1D
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

	// Token: 0x06001CBA RID: 7354 RVA: 0x00151A5C File Offset: 0x0014FC5C
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

	// Token: 0x04003354 RID: 13140
	public StudentManagerScript StudentManager;

	// Token: 0x04003355 RID: 13141
	public YandereScript Yandere;

	// Token: 0x04003356 RID: 13142
	public PromptScript Prompt;

	// Token: 0x04003357 RID: 13143
	public Quaternion targetRotation;

	// Token: 0x04003358 RID: 13144
	public PickUpScript Uniform;

	// Token: 0x04003359 RID: 13145
	public Collider Chair;

	// Token: 0x0400335A RID: 13146
	public bool MoveAway;

	// Token: 0x0400335B RID: 13147
	public bool Sewing;

	// Token: 0x0400335C RID: 13148
	public bool Check;

	// Token: 0x0400335D RID: 13149
	public float Timer;
}
