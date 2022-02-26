using System;
using UnityEngine;

// Token: 0x020003F0 RID: 1008
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BE7 RID: 7143 RVA: 0x00145D9D File Offset: 0x00143F9D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x00145DB8 File Offset: 0x00143FB8
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

	// Token: 0x040030F2 RID: 12530
	public VendingMachineScript VendingMachine;

	// Token: 0x040030F3 RID: 12531
	public GameObject SabotageSparks;

	// Token: 0x040030F4 RID: 12532
	public YandereScript Yandere;

	// Token: 0x040030F5 RID: 12533
	public PromptScript Prompt;
}
