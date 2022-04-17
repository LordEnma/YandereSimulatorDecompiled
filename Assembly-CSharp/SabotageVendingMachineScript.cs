using System;
using UnityEngine;

// Token: 0x020003F5 RID: 1013
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C0A RID: 7178 RVA: 0x0014832D File Offset: 0x0014652D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x00148348 File Offset: 0x00146548
	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					if (SchemeGlobals.GetSchemeStage(4) == 2)
					{
						SchemeGlobals.SetSchemeStage(4, 3);
						this.Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
					if (this.Yandere.StudentManager.Students[11] != null && DateGlobals.Weekday == DayOfWeek.Thursday)
					{
						this.Yandere.StudentManager.Students[11].Hungry = true;
						this.Yandere.StudentManager.Students[11].Fed = false;
					}
					UnityEngine.Object.Instantiate<GameObject>(this.SabotageSparks, new Vector3(-2.5f, 5.3605f, -32.982f), Quaternion.identity);
					this.VendingMachine.Sabotaged = true;
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					base.enabled = false;
					return;
				}
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x04003163 RID: 12643
	public VendingMachineScript VendingMachine;

	// Token: 0x04003164 RID: 12644
	public GameObject SabotageSparks;

	// Token: 0x04003165 RID: 12645
	public YandereScript Yandere;

	// Token: 0x04003166 RID: 12646
	public PromptScript Prompt;
}
