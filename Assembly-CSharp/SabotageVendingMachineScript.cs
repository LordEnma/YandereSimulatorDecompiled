using System;
using UnityEngine;

// Token: 0x020003EB RID: 1003
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BCB RID: 7115 RVA: 0x00142EC9 File Offset: 0x001410C9
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BCC RID: 7116 RVA: 0x00142EE4 File Offset: 0x001410E4
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

	// Token: 0x040030C7 RID: 12487
	public VendingMachineScript VendingMachine;

	// Token: 0x040030C8 RID: 12488
	public GameObject SabotageSparks;

	// Token: 0x040030C9 RID: 12489
	public YandereScript Yandere;

	// Token: 0x040030CA RID: 12490
	public PromptScript Prompt;
}
