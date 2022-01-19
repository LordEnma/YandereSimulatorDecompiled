using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F75 RID: 8053 RVA: 0x001B8DF4 File Offset: 0x001B6FF4
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

	// Token: 0x06001F76 RID: 8054 RVA: 0x001B8E84 File Offset: 0x001B7084
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

	// Token: 0x0400416D RID: 16749
	public PromptScript Prompt;

	// Token: 0x0400416E RID: 16750
	public Transform CanSpawn;

	// Token: 0x0400416F RID: 16751
	public GameObject[] Cans;

	// Token: 0x04004170 RID: 16752
	public bool SnackMachine;

	// Token: 0x04004171 RID: 16753
	public bool Sabotaged;

	// Token: 0x04004172 RID: 16754
	public int Price;
}
