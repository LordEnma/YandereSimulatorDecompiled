using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BD5 RID: 7125 RVA: 0x00144E8D File Offset: 0x0014308D
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x00144EA8 File Offset: 0x001430A8
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

	// Token: 0x040030D9 RID: 12505
	public VendingMachineScript VendingMachine;

	// Token: 0x040030DA RID: 12506
	public GameObject SabotageSparks;

	// Token: 0x040030DB RID: 12507
	public YandereScript Yandere;

	// Token: 0x040030DC RID: 12508
	public PromptScript Prompt;
}
