using System;
using UnityEngine;

// Token: 0x02000443 RID: 1091
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D05 RID: 7429 RVA: 0x0015A660 File Offset: 0x00158860
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

	// Token: 0x06001D06 RID: 7430 RVA: 0x0015A700 File Offset: 0x00158900
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034C7 RID: 13511
	public PromptScript Prompt;

	// Token: 0x040034C8 RID: 13512
	public StandScript Stand;

	// Token: 0x040034C9 RID: 13513
	public float RotationSpeed;
}
