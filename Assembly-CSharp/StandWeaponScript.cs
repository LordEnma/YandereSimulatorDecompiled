using System;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D15 RID: 7445 RVA: 0x0015B414 File Offset: 0x00159614
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

	// Token: 0x06001D16 RID: 7446 RVA: 0x0015B4B4 File Offset: 0x001596B4
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034DD RID: 13533
	public PromptScript Prompt;

	// Token: 0x040034DE RID: 13534
	public StandScript Stand;

	// Token: 0x040034DF RID: 13535
	public float RotationSpeed;
}
