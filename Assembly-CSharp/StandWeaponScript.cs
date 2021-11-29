using System;
using UnityEngine;

// Token: 0x0200043F RID: 1087
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001CEC RID: 7404 RVA: 0x001571F8 File Offset: 0x001553F8
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

	// Token: 0x06001CED RID: 7405 RVA: 0x00157298 File Offset: 0x00155498
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x04003471 RID: 13425
	public PromptScript Prompt;

	// Token: 0x04003472 RID: 13426
	public StandScript Stand;

	// Token: 0x04003473 RID: 13427
	public float RotationSpeed;
}
