using System;
using UnityEngine;

// Token: 0x020003F6 RID: 1014
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C11 RID: 7185 RVA: 0x00148B69 File Offset: 0x00146D69
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C12 RID: 7186 RVA: 0x00148B84 File Offset: 0x00146D84
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

	// Token: 0x04003172 RID: 12658
	public VendingMachineScript VendingMachine;

	// Token: 0x04003173 RID: 12659
	public GameObject SabotageSparks;

	// Token: 0x04003174 RID: 12660
	public YandereScript Yandere;

	// Token: 0x04003175 RID: 12661
	public PromptScript Prompt;
}
