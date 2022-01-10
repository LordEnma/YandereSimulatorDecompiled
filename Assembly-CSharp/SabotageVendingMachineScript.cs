using System;
using UnityEngine;

// Token: 0x020003ED RID: 1005
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BD2 RID: 7122 RVA: 0x0014323D File Offset: 0x0014143D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BD3 RID: 7123 RVA: 0x00143258 File Offset: 0x00141458
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

	// Token: 0x040030CD RID: 12493
	public VendingMachineScript VendingMachine;

	// Token: 0x040030CE RID: 12494
	public GameObject SabotageSparks;

	// Token: 0x040030CF RID: 12495
	public YandereScript Yandere;

	// Token: 0x040030D0 RID: 12496
	public PromptScript Prompt;
}
