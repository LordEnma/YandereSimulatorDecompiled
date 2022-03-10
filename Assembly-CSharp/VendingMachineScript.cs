using System;
using UnityEngine;

// Token: 0x020004B2 RID: 1202
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F8F RID: 8079 RVA: 0x001BAF88 File Offset: 0x001B9188
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

	// Token: 0x06001F90 RID: 8080 RVA: 0x001BB018 File Offset: 0x001B9218
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

	// Token: 0x040041AE RID: 16814
	public PromptScript Prompt;

	// Token: 0x040041AF RID: 16815
	public Transform CanSpawn;

	// Token: 0x040041B0 RID: 16816
	public GameObject[] Cans;

	// Token: 0x040041B1 RID: 16817
	public bool SnackMachine;

	// Token: 0x040041B2 RID: 16818
	public bool Sabotaged;

	// Token: 0x040041B3 RID: 16819
	public int Price;
}
