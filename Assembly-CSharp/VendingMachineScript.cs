using System;
using UnityEngine;

// Token: 0x020004BB RID: 1211
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FCD RID: 8141 RVA: 0x001C1644 File Offset: 0x001BF844
	private void Start()
	{
		if (this.SnackMachine)
		{
			this.Prompt.Text[0] = "Buy Snack for $" + this.Price.ToString() + ".00";
		}
		else
		{
			this.Prompt.Text[0] = "Buy Drink for $" + this.Price.ToString() + ".00";
		}
		this.Prompt.Label[0].text = "     " + this.Prompt.Text[0];
	}

	// Token: 0x06001FCE RID: 8142 RVA: 0x001C16D4 File Offset: 0x001BF8D4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.Inventory.Money >= (float)this.Price)
			{
				if (!this.Sabotaged)
				{
					UnityEngine.Object.Instantiate<GameObject>(this.Cans[UnityEngine.Random.Range(0, this.Cans.Length)], this.CanSpawn.position, this.CanSpawn.rotation).GetComponent<AudioSource>().pitch = UnityEngine.Random.Range(0.9f, 1.1f);
				}
				if (this.SnackMachine && SchemeGlobals.GetSchemeStage(4) == 3)
				{
					SchemeGlobals.SetSchemeStage(4, 4);
					this.Prompt.Yandere.PauseScreen.Schemes.UpdateInstructions();
				}
				this.Prompt.Yandere.Inventory.Money -= (float)this.Price;
				this.Prompt.Yandere.Inventory.UpdateMoney();
				return;
			}
			this.Prompt.Yandere.StudentManager.TutorialWindow.ShowMoneyMessage = true;
			this.Prompt.Yandere.NotificationManager.CustomText = "Not enough money!";
			this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x04004276 RID: 17014
	public PromptScript Prompt;

	// Token: 0x04004277 RID: 17015
	public Transform CanSpawn;

	// Token: 0x04004278 RID: 17016
	public GameObject[] Cans;

	// Token: 0x04004279 RID: 17017
	public bool SnackMachine;

	// Token: 0x0400427A RID: 17018
	public bool Sabotaged;

	// Token: 0x0400427B RID: 17019
	public int Price;
}
