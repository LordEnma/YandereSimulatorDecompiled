using System;
using UnityEngine;

// Token: 0x020004AC RID: 1196
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F5B RID: 8027 RVA: 0x001B6510 File Offset: 0x001B4710
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

	// Token: 0x06001F5C RID: 8028 RVA: 0x001B65A0 File Offset: 0x001B47A0
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

	// Token: 0x0400411B RID: 16667
	public PromptScript Prompt;

	// Token: 0x0400411C RID: 16668
	public Transform CanSpawn;

	// Token: 0x0400411D RID: 16669
	public GameObject[] Cans;

	// Token: 0x0400411E RID: 16670
	public bool SnackMachine;

	// Token: 0x0400411F RID: 16671
	public bool Sabotaged;

	// Token: 0x04004120 RID: 16672
	public int Price;
}
