using System;
using UnityEngine;

// Token: 0x02000444 RID: 1092
public class StandWeaponScript : MonoBehaviour
{
	// Token: 0x06001D0C RID: 7436 RVA: 0x0015A968 File Offset: 0x00158B68
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

	// Token: 0x06001D0D RID: 7437 RVA: 0x0015AA08 File Offset: 0x00158C08
	private void MoveToStand()
	{
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.Prompt.MyCollider.enabled = false;
		this.Stand.Weapons++;
		base.transform.parent = this.Stand.Hands[this.Stand.Weapons];
		base.transform.localPosition = new Vector3(-0.277f, 0f, 0f);
	}

	// Token: 0x040034CD RID: 13517
	public PromptScript Prompt;

	// Token: 0x040034CE RID: 13518
	public StandScript Stand;

	// Token: 0x040034CF RID: 13519
	public float RotationSpeed;
}
