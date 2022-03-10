using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BE9 RID: 7145 RVA: 0x001462D9 File Offset: 0x001444D9
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x001462F4 File Offset: 0x001444F4
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

	// Token: 0x04003108 RID: 12552
	public VendingMachineScript VendingMachine;

	// Token: 0x04003109 RID: 12553
	public GameObject SabotageSparks;

	// Token: 0x0400310A RID: 12554
	public YandereScript Yandere;

	// Token: 0x0400310B RID: 12555
	public PromptScript Prompt;
}
