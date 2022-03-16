using System;
using UnityEngine;

// Token: 0x02000446 RID: 1094
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D25 RID: 7461 RVA: 0x0015CB48 File Offset: 0x0015AD48
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

	// Token: 0x06001D26 RID: 7462 RVA: 0x0015CBE8 File Offset: 0x0015ADE8
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400352E RID: 13614
	public PromptScript Prompt;

	// Token: 0x0400352F RID: 13615
	public StandScript Stand;

	// Token: 0x04003530 RID: 13616
	public float RotationSpeed;
}
