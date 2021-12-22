using System;
using UnityEngine;

// Token: 0x020004AD RID: 1197
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F65 RID: 8037 RVA: 0x001B72CC File Offset: 0x001B54CC
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

	// Token: 0x06001F66 RID: 8038 RVA: 0x001B735C File Offset: 0x001B555C
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

	// Token: 0x0400414B RID: 16715
	public PromptScript Prompt;

	// Token: 0x0400414C RID: 16716
	public Transform CanSpawn;

	// Token: 0x0400414D RID: 16717
	public GameObject[] Cans;

	// Token: 0x0400414E RID: 16718
	public bool SnackMachine;

	// Token: 0x0400414F RID: 16719
	public bool Sabotaged;

	// Token: 0x04004150 RID: 16720
	public int Price;
}
