using System;
using UnityEngine;

// Token: 0x020004AD RID: 1197
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F68 RID: 8040 RVA: 0x001B77A4 File Offset: 0x001B59A4
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

	// Token: 0x06001F69 RID: 8041 RVA: 0x001B7834 File Offset: 0x001B5A34
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

	// Token: 0x04004152 RID: 16722
	public PromptScript Prompt;

	// Token: 0x04004153 RID: 16723
	public Transform CanSpawn;

	// Token: 0x04004154 RID: 16724
	public GameObject[] Cans;

	// Token: 0x04004155 RID: 16725
	public bool SnackMachine;

	// Token: 0x04004156 RID: 16726
	public bool Sabotaged;

	// Token: 0x04004157 RID: 16727
	public int Price;
}
