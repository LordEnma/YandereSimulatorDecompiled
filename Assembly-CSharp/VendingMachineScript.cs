using System;
using UnityEngine;

// Token: 0x020004B8 RID: 1208
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FAB RID: 8107 RVA: 0x001BDC94 File Offset: 0x001BBE94
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

	// Token: 0x06001FAC RID: 8108 RVA: 0x001BDD24 File Offset: 0x001BBF24
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

	// Token: 0x04004226 RID: 16934
	public PromptScript Prompt;

	// Token: 0x04004227 RID: 16935
	public Transform CanSpawn;

	// Token: 0x04004228 RID: 16936
	public GameObject[] Cans;

	// Token: 0x04004229 RID: 16937
	public bool SnackMachine;

	// Token: 0x0400422A RID: 16938
	public bool Sabotaged;

	// Token: 0x0400422B RID: 16939
	public int Price;
}
