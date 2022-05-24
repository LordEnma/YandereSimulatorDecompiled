using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C18 RID: 7192 RVA: 0x00149AA5 File Offset: 0x00147CA5
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C19 RID: 7193 RVA: 0x00149AC0 File Offset: 0x00147CC0
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

	// Token: 0x0400318F RID: 12687
	public VendingMachineScript VendingMachine;

	// Token: 0x04003190 RID: 12688
	public GameObject SabotageSparks;

	// Token: 0x04003191 RID: 12689
	public YandereScript Yandere;

	// Token: 0x04003192 RID: 12690
	public PromptScript Prompt;
}
