using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FB9 RID: 8121 RVA: 0x001BEB78 File Offset: 0x001BCD78
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

	// Token: 0x06001FBA RID: 8122 RVA: 0x001BEC08 File Offset: 0x001BCE08
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

	// Token: 0x04004239 RID: 16953
	public PromptScript Prompt;

	// Token: 0x0400423A RID: 16954
	public Transform CanSpawn;

	// Token: 0x0400423B RID: 16955
	public GameObject[] Cans;

	// Token: 0x0400423C RID: 16956
	public bool SnackMachine;

	// Token: 0x0400423D RID: 16957
	public bool Sabotaged;

	// Token: 0x0400423E RID: 16958
	public int Price;
}
