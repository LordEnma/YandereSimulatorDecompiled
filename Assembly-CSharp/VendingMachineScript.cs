using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001FC2 RID: 8130 RVA: 0x001BFF34 File Offset: 0x001BE134
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

	// Token: 0x06001FC3 RID: 8131 RVA: 0x001BFFC4 File Offset: 0x001BE1C4
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

	// Token: 0x0400424F RID: 16975
	public PromptScript Prompt;

	// Token: 0x04004250 RID: 16976
	public Transform CanSpawn;

	// Token: 0x04004251 RID: 16977
	public GameObject[] Cans;

	// Token: 0x04004252 RID: 16978
	public bool SnackMachine;

	// Token: 0x04004253 RID: 16979
	public bool Sabotaged;

	// Token: 0x04004254 RID: 16980
	public int Price;
}
