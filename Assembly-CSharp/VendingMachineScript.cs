using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
public class VendingMachineScript : MonoBehaviour
{
	// Token: 0x06001F83 RID: 8067 RVA: 0x001B9C9C File Offset: 0x001B7E9C
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

	// Token: 0x06001F84 RID: 8068 RVA: 0x001B9D2C File Offset: 0x001B7F2C
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

	// Token: 0x04004187 RID: 16775
	public PromptScript Prompt;

	// Token: 0x04004188 RID: 16776
	public Transform CanSpawn;

	// Token: 0x04004189 RID: 16777
	public GameObject[] Cans;

	// Token: 0x0400418A RID: 16778
	public bool SnackMachine;

	// Token: 0x0400418B RID: 16779
	public bool Sabotaged;

	// Token: 0x0400418C RID: 16780
	public int Price;
}
