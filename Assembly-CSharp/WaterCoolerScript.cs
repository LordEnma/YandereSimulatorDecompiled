using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class WaterCoolerScript : MonoBehaviour
{
	// Token: 0x06001FA9 RID: 8105 RVA: 0x001BDED7 File Offset: 0x001BC0D7
	private void Start()
	{
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x001BDEDC File Offset: 0x001BC0DC
	private void Update()
	{
		if (!this.Browned)
		{
			if (this.Yandere.PickUp != null && this.Yandere.PickUp.BrownPaint)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Prompt.Circle[0].fillAmount == 1f)
				{
					this.Prompt.HideButton[0] = true;
					this.Browned = true;
				}
			}
			else
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		if (!this.TrapSet)
		{
			if (this.Yandere.Inventory.String && this.Yandere.Inventory.MaskingTape && this.Yandere.Weapon[1] != null && this.Yandere.Weapon[1].Type == WeaponType.Knife)
			{
				this.Prompt.HideButton[1] = false;
				if (this.Prompt.Circle[1].fillAmount == 1f)
				{
					this.TripwireTrap.SetActive(true);
					this.Prompt.HideButton[1] = true;
					this.TrapSet = true;
					return;
				}
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
		}
	}

	// Token: 0x0400422B RID: 16939
	public YandereScript Yandere;

	// Token: 0x0400422C RID: 16940
	public PromptScript Prompt;

	// Token: 0x0400422D RID: 16941
	public GameObject TripwireTrap;

	// Token: 0x0400422E RID: 16942
	public bool Browned;

	// Token: 0x0400422F RID: 16943
	public bool TrapSet;
}
