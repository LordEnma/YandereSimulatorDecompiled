using System;
using UnityEngine;

// Token: 0x020004B5 RID: 1205
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BC708 File Offset: 0x001BA908
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

	// Token: 0x06001FA2 RID: 8098 RVA: 0x001BC798 File Offset: 0x001BA998
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

	// Token: 0x040041F9 RID: 16889
	public PromptScript Prompt;

	// Token: 0x040041FA RID: 16890
	public Transform CanSpawn;

	// Token: 0x040041FB RID: 16891
	public GameObject[] Cans;

	// Token: 0x040041FC RID: 16892
	public bool SnackMachine;

	// Token: 0x040041FD RID: 16893
	public bool Sabotaged;

	// Token: 0x040041FE RID: 16894
	public int Price;
}
