using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D02 RID: 7426 RVA: 0x00159F84 File Offset: 0x00158184
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

	// Token: 0x06001D03 RID: 7427 RVA: 0x0015A024 File Offset: 0x00158224
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034BD RID: 13501
	public PromptScript Prompt;

	// Token: 0x040034BE RID: 13502
	public StandScript Stand;

	// Token: 0x040034BF RID: 13503
	public float RotationSpeed;
}
