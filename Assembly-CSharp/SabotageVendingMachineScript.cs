using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BD4 RID: 7124 RVA: 0x00144945 File Offset: 0x00142B45
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BD5 RID: 7125 RVA: 0x00144960 File Offset: 0x00142B60
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

	// Token: 0x040030D2 RID: 12498
	public VendingMachineScript VendingMachine;

	// Token: 0x040030D3 RID: 12499
	public GameObject SabotageSparks;

	// Token: 0x040030D4 RID: 12500
	public YandereScript Yandere;

	// Token: 0x040030D5 RID: 12501
	public PromptScript Prompt;
}
