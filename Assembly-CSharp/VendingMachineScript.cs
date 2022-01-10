using System;
using UnityEngine;

// Token: 0x020004AF RID: 1199
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F73 RID: 8051 RVA: 0x001B8124 File Offset: 0x001B6324
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

	// Token: 0x06001F74 RID: 8052 RVA: 0x001B81B4 File Offset: 0x001B63B4
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

	// Token: 0x04004166 RID: 16742
	public PromptScript Prompt;

	// Token: 0x04004167 RID: 16743
	public Transform CanSpawn;

	// Token: 0x04004168 RID: 16744
	public GameObject[] Cans;

	// Token: 0x04004169 RID: 16745
	public bool SnackMachine;

	// Token: 0x0400416A RID: 16746
	public bool Sabotaged;

	// Token: 0x0400416B RID: 16747
	public int Price;
}
