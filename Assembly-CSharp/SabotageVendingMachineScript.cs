using System;
using UnityEngine;

// Token: 0x020003EA RID: 1002
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BC1 RID: 7105 RVA: 0x0014220D File Offset: 0x0014040D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BC2 RID: 7106 RVA: 0x00142228 File Offset: 0x00140428
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

	// Token: 0x04003096 RID: 12438
	public VendingMachineScript VendingMachine;

	// Token: 0x04003097 RID: 12439
	public GameObject SabotageSparks;

	// Token: 0x04003098 RID: 12440
	public YandereScript Yandere;

	// Token: 0x04003099 RID: 12441
	public PromptScript Prompt;
}
