using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D03 RID: 7427 RVA: 0x0015A3C4 File Offset: 0x001585C4
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

	// Token: 0x06001D04 RID: 7428 RVA: 0x0015A464 File Offset: 0x00158664
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034C3 RID: 13507
	public PromptScript Prompt;

	// Token: 0x040034C4 RID: 13508
	public StandScript Stand;

	// Token: 0x040034C5 RID: 13509
	public float RotationSpeed;
}
