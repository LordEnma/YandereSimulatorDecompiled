using System;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D41 RID: 7489 RVA: 0x0015E718 File Offset: 0x0015C918
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

	// Token: 0x06001D42 RID: 7490 RVA: 0x0015E7B8 File Offset: 0x0015C9B8
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x04003569 RID: 13673
	public PromptScript Prompt;

	// Token: 0x0400356A RID: 13674
	public StandScript Stand;

	// Token: 0x0400356B RID: 13675
	public float RotationSpeed;
}
