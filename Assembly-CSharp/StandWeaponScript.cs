using System;
using UnityEngine;

// Token: 0x0200044A RID: 1098
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D3A RID: 7482 RVA: 0x0015DE88 File Offset: 0x0015C088
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

	// Token: 0x06001D3B RID: 7483 RVA: 0x0015DF28 File Offset: 0x0015C128
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400355A RID: 13658
	public PromptScript Prompt;

	// Token: 0x0400355B RID: 13659
	public StandScript Stand;

	// Token: 0x0400355C RID: 13660
	public float RotationSpeed;
}
