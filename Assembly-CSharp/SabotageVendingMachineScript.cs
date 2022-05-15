using System;
using UnityEngine;

// Token: 0x020003F7 RID: 1015
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C17 RID: 7191 RVA: 0x001497E9 File Offset: 0x001479E9
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x00149804 File Offset: 0x00147A04
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

	// Token: 0x04003187 RID: 12679
	public VendingMachineScript VendingMachine;

	// Token: 0x04003188 RID: 12680
	public GameObject SabotageSparks;

	// Token: 0x04003189 RID: 12681
	public YandereScript Yandere;

	// Token: 0x0400318A RID: 12682
	public PromptScript Prompt;
}
