using System;
using UnityEngine;

// Token: 0x020003F5 RID: 1013
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001C06 RID: 7174 RVA: 0x00147F1D File Offset: 0x0014611D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001C07 RID: 7175 RVA: 0x00147F38 File Offset: 0x00146138
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

	// Token: 0x04003158 RID: 12632
	public VendingMachineScript VendingMachine;

	// Token: 0x04003159 RID: 12633
	public GameObject SabotageSparks;

	// Token: 0x0400315A RID: 12634
	public YandereScript Yandere;

	// Token: 0x0400315B RID: 12635
	public PromptScript Prompt;
}
