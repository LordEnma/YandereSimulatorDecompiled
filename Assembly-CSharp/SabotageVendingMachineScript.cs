using System;
using UnityEngine;

// Token: 0x020003F4 RID: 1012
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C00 RID: 7168 RVA: 0x00147C39 File Offset: 0x00145E39
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x00147C54 File Offset: 0x00145E54
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

	// Token: 0x04003155 RID: 12629
	public VendingMachineScript VendingMachine;

	// Token: 0x04003156 RID: 12630
	public GameObject SabotageSparks;

	// Token: 0x04003157 RID: 12631
	public YandereScript Yandere;

	// Token: 0x04003158 RID: 12632
	public PromptScript Prompt;
}
