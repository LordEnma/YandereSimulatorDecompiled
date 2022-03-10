using System;
using UnityEngine;

// Token: 0x02000445 RID: 1093
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D17 RID: 7447 RVA: 0x0015B998 File Offset: 0x00159B98
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

	// Token: 0x06001D18 RID: 7448 RVA: 0x0015BA38 File Offset: 0x00159C38
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034F3 RID: 13555
	public PromptScript Prompt;

	// Token: 0x040034F4 RID: 13556
	public StandScript Stand;

	// Token: 0x040034F5 RID: 13557
	public float RotationSpeed;
}
