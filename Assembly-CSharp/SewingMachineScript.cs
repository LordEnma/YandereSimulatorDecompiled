using System;
using UnityEngine;

// Token: 0x02000421 RID: 1057
public class SewingMachineScript : MonoBehaviour
{
	// Token: 0x06001C87 RID: 7303 RVA: 0x0014DC91 File Offset: 0x0014BE91
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

	// Token: 0x06001C88 RID: 7304 RVA: 0x0014DCD0 File Offset: 0x0014BED0
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

	// Token: 0x040032B4 RID: 12980
	public StudentManagerScript StudentManager;

	// Token: 0x040032B5 RID: 12981
	public YandereScript Yandere;

	// Token: 0x040032B6 RID: 12982
	public PromptScript Prompt;

	// Token: 0x040032B7 RID: 12983
	public Quaternion targetRotation;

	// Token: 0x040032B8 RID: 12984
	public PickUpScript Uniform;

	// Token: 0x040032B9 RID: 12985
	public Collider Chair;

	// Token: 0x040032BA RID: 12986
	public bool MoveAway;

	// Token: 0x040032BB RID: 12987
	public bool Sewing;

	// Token: 0x040032BC RID: 12988
	public bool Check;

	// Token: 0x040032BD RID: 12989
	public float Timer;
}
