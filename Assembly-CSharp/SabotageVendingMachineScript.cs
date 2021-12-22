using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BC9 RID: 7113 RVA: 0x00142ACD File Offset: 0x00140CCD
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BCA RID: 7114 RVA: 0x00142AE8 File Offset: 0x00140CE8
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

	// Token: 0x040030C0 RID: 12480
	public VendingMachineScript VendingMachine;

	// Token: 0x040030C1 RID: 12481
	public GameObject SabotageSparks;

	// Token: 0x040030C2 RID: 12482
	public YandereScript Yandere;

	// Token: 0x040030C3 RID: 12483
	public PromptScript Prompt;
}
