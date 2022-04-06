using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D36 RID: 7478 RVA: 0x0015D9FC File Offset: 0x0015BBFC
	private void Update()
	{
		if (this.Prompt.enabled)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.MoveToStand();
				return;
			}
		}
		else
		{
			base.transform.Rotate(Vector3.forward * (Time.deltaTime * this.RotationSpeed));
			base.transform.Rotate(Vector3.right * (Time.deltaTime * this.RotationSpeed));
			base.transform.Rotate(Vector3.up * (Time.deltaTime * this.RotationSpeed));
		}
	}

	// Token: 0x06001D37 RID: 7479 RVA: 0x0015DA9C File Offset: 0x0015BC9C
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400354E RID: 13646
	public PromptScript Prompt;

	// Token: 0x0400354F RID: 13647
	public StandScript Stand;

	// Token: 0x04003550 RID: 13648
	public float RotationSpeed;
}
