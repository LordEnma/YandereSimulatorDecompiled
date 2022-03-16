using System;
using UnityEngine;

// Token: 0x020003F1 RID: 1009
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BF6 RID: 7158 RVA: 0x0014717D File Offset: 0x0014537D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x00147198 File Offset: 0x00145398
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

	// Token: 0x0400313C RID: 12604
	public VendingMachineScript VendingMachine;

	// Token: 0x0400313D RID: 12605
	public GameObject SabotageSparks;

	// Token: 0x0400313E RID: 12606
	public YandereScript Yandere;

	// Token: 0x0400313F RID: 12607
	public PromptScript Prompt;
}
