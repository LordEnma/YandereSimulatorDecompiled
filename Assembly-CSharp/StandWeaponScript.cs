using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D47 RID: 7495 RVA: 0x0015F398 File Offset: 0x0015D598
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

	// Token: 0x06001D48 RID: 7496 RVA: 0x0015F438 File Offset: 0x0015D638
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400357E RID: 13694
	public PromptScript Prompt;

	// Token: 0x0400357F RID: 13695
	public StandScript Stand;

	// Token: 0x04003580 RID: 13696
	public float RotationSpeed;
}
