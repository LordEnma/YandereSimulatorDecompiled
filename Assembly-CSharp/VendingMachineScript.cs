using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F77 RID: 8055 RVA: 0x001B931C File Offset: 0x001B751C
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

	// Token: 0x06001F78 RID: 8056 RVA: 0x001B93AC File Offset: 0x001B75AC
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

	// Token: 0x04004175 RID: 16757
	public PromptScript Prompt;

	// Token: 0x04004176 RID: 16758
	public Transform CanSpawn;

	// Token: 0x04004177 RID: 16759
	public GameObject[] Cans;

	// Token: 0x04004178 RID: 16760
	public bool SnackMachine;

	// Token: 0x04004179 RID: 16761
	public bool Sabotaged;

	// Token: 0x0400417A RID: 16762
	public int Price;
}
