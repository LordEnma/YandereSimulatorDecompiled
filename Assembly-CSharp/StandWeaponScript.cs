using System;
using UnityEngine;

// Token: 0x0200044C RID: 1100
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D48 RID: 7496 RVA: 0x0015F654 File Offset: 0x0015D854
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

	// Token: 0x06001D49 RID: 7497 RVA: 0x0015F6F4 File Offset: 0x0015D8F4
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x04003586 RID: 13702
	public PromptScript Prompt;

	// Token: 0x04003587 RID: 13703
	public StandScript Stand;

	// Token: 0x04003588 RID: 13704
	public float RotationSpeed;
}
