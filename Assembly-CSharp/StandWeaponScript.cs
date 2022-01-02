using System;
using UnityEngine;

// Token: 0x02000440 RID: 1088
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001CF6 RID: 7414 RVA: 0x00157F60 File Offset: 0x00156160
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

	// Token: 0x06001CF7 RID: 7415 RVA: 0x00158000 File Offset: 0x00156200
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034A3 RID: 13475
	public PromptScript Prompt;

	// Token: 0x040034A4 RID: 13476
	public StandScript Stand;

	// Token: 0x040034A5 RID: 13477
	public float RotationSpeed;
}
