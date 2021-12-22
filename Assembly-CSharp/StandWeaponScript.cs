using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001CF4 RID: 7412 RVA: 0x00157B1C File Offset: 0x00155D1C
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

	// Token: 0x06001CF5 RID: 7413 RVA: 0x00157BBC File Offset: 0x00155DBC
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400349C RID: 13468
	public PromptScript Prompt;

	// Token: 0x0400349D RID: 13469
	public StandScript Stand;

	// Token: 0x0400349E RID: 13470
	public float RotationSpeed;
}
