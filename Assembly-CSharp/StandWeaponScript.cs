using System;
using UnityEngine;

// Token: 0x02000449 RID: 1097
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D2F RID: 7471 RVA: 0x0015D6DC File Offset: 0x0015B8DC
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

	// Token: 0x06001D30 RID: 7472 RVA: 0x0015D77C File Offset: 0x0015B97C
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x0400354B RID: 13643
	public PromptScript Prompt;

	// Token: 0x0400354C RID: 13644
	public StandScript Stand;

	// Token: 0x0400354D RID: 13645
	public float RotationSpeed;
}
